﻿using System;
using System.Collections.Generic;
using System.Threading;
using Theraot.Threading;

namespace Theraot.Collections.ThreadSafe
{
    /// <summary>
    /// Represent a thread-safe lock-free hash based dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <remarks>
    /// Consider wrapping this class to implement <see cref="IDictionary{TKey, TValue}" /> or any other desired interface.
    /// </remarks>
    public sealed class HashBucket<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        //TODO: throw ArgumentException when trying to add items with same hash

        private const int INT_DefaultCapacity = 64;
        private const int INT_DefaultMaxProbing = 1;

        private readonly IEqualityComparer<TKey> _keyComparer;
        private readonly int _maxProbing;
        private int _copyingThreads;
        private int _copyPosition;
        private int _count;
        private FixedSizeHashBucket<TKey, TValue> _entriesNew;
        private FixedSizeHashBucket<TKey, TValue> _entriesOld;
        private volatile int _revision;
        private int _status;

        /// <summary>
        /// Initializes a new instance of the <see cref="HashBucket{TKey, TValue}" /> class.
        /// </summary>
        public HashBucket()
            : this(INT_DefaultCapacity, EqualityComparer<TKey>.Default, INT_DefaultMaxProbing)
        {
            // Empty
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashBucket{TKey, TValue}" /> class.
        /// </summary>
        /// <param name="capacity">The initial capacity.</param>
        public HashBucket(int capacity)
            : this(capacity, EqualityComparer<TKey>.Default, INT_DefaultMaxProbing)
        {
            // Empty
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashBucket{TKey, TValue}" /> class.
        /// </summary>
        /// <param name="capacity">The initial capacity.</param>
        /// <param name="maxProbing">The maximum number of steps in linear probing.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">maxProbing;maxProbing must be greater or equal to 1 and less than capacity.</exception>
        public HashBucket(int capacity, int maxProbing)
            : this(capacity, EqualityComparer<TKey>.Default, maxProbing)
        {
            // Empty
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashBucket{TKey, TValue}" /> class.
        /// </summary>
        /// <param name="comparer">The key comparer.</param>
        public HashBucket(IEqualityComparer<TKey> comparer)
            : this(INT_DefaultCapacity, comparer, INT_DefaultMaxProbing)
        {
            // Empty
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashBucket{TKey, TValue}" /> class.
        /// </summary>
        /// <param name="comparer">The key comparer.</param>
        /// <param name="maxProbing">The maximum number of steps in linear probing.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">maxProbing;maxProbing must be greater or equal to 1 and less than capacity.</exception>
        public HashBucket(IEqualityComparer<TKey> comparer, int maxProbing)
            : this(INT_DefaultCapacity, comparer, maxProbing)
        {
            // Empty
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashBucket{TKey, TValue}" /> class.
        /// </summary>
        /// <param name="capacity">The initial capacity.</param>
        /// <param name="comparer">The key comparer.</param>
        public HashBucket(int capacity, IEqualityComparer<TKey> comparer)
            : this(capacity, comparer, INT_DefaultMaxProbing)
        {
            // Empty
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashBucket{TKey, TValue}" /> class.
        /// </summary>
        /// <param name="capacity">The initial capacity.</param>
        /// <param name="comparer">The key comparer.</param>
        /// <param name="maxProbing">The maximum number of steps in linear probing.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">maxProbing;maxProbing must be greater or equal to 1 and less than capacity.</exception>
        public HashBucket(int capacity, IEqualityComparer<TKey> comparer, int maxProbing)
        {
            if (maxProbing < 1 || maxProbing >= capacity)
            {
                throw new ArgumentOutOfRangeException("maxProbing", "maxProbing must be greater or equal to 1 and less than capacity.");
            }
            else
            {
                _keyComparer = comparer ?? EqualityComparer<TKey>.Default;
                _entriesOld = null;
                _entriesNew = new FixedSizeHashBucket<TKey, TValue>(capacity, _keyComparer);
                _maxProbing = maxProbing;
            }
        }

        /// <summary>
        /// Gets the capacity.
        /// </summary>
        public int Capacity
        {
            get
            {
                return _entriesNew.Capacity;
            }
        }

        /// <summary>
        /// Gets the number of keys actually contained.
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }

        /// <summary>
        /// Gets the key comparer.
        /// </summary>
        public IEqualityComparer<TKey> KeyComparer
        {
            get
            {
                return _entriesNew.KeyComparer;
            }
        }

        /// <summary>
        /// Adds the specified key and associated value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentException">the key is already present</exception>
        public void Add(TKey key, TValue value)
        {
            bool result = false;
            while (true)
            {
                int revision = _revision;
                if (IsOperationSafe())
                {
                    bool isOperationSafe;
                    bool isCollision = false;
                    var entries = ThreadingHelper.VolatileRead(ref _entriesNew);
                    try
                    {
                        result |= AddExtracted(key, value, entries, out isCollision) != -1;
                    }
                    finally
                    {
                        isOperationSafe = IsOperationSafe(entries, revision);
                    }
                    if (isOperationSafe)
                    {
                        if (result)
                        {
                            Interlocked.Increment(ref _count);
                            return;
                        }
                        else
                        {
                            if (isCollision)
                            {
                                var oldStatus = Interlocked.CompareExchange(ref _status, (int)BucketStatus.GrowRequested, (int)BucketStatus.Free);
                                if (oldStatus == (int)BucketStatus.Free)
                                {
                                    _revision++;
                                }
                            }
                            else
                            {
                                throw new ArgumentException("the key is already present");
                            }
                        }
                    }
                }
                else
                {
                    CooperativeGrow();
                }
            }
        }

        /// <summary>
        /// Attempts to add the specified key and associated value. The value is added if the key is not found.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>The pair formed by the key and value that were found in the destination before the attempt, regardless of collisions.</returns>
        public KeyValuePair<TKey, TValue> CharyAdd(TKey key, TValue value)
        {
            bool result = false;
            KeyValuePair<TKey, TValue> previous = default(KeyValuePair<TKey, TValue>);
            while (true)
            {
                int revision = _revision;
                if (IsOperationSafe())
                {
                    bool isOperationSafe;
                    var entries = ThreadingHelper.VolatileRead(ref _entriesNew);
                    try
                    {
                        KeyValuePair<TKey, TValue> tmpPrevious;
                        if (CharyAddExtracted(key, value, entries, out tmpPrevious) != -1)
                        {
                            previous = tmpPrevious;
                            result = true;
                        }
                    }
                    finally
                    {
                        isOperationSafe = IsOperationSafe(entries, revision);
                    }
                    if (isOperationSafe)
                    {
                        if (result)
                        {
                            Interlocked.Increment(ref _count);
                        }
                        return previous;
                    }
                }
                else
                {
                    CooperativeGrow();
                }
            }
        }

        /// <summary>
        /// Removes all the elements.
        /// </summary>
        public void Clear()
        {
            ThreadingHelper.VolatileWrite(ref _entriesOld, null);
            ThreadingHelper.VolatileWrite(ref _entriesNew, new FixedSizeHashBucket<TKey, TValue>(INT_DefaultCapacity, _keyComparer));
            Thread.VolatileWrite(ref _status, (int)BucketStatus.Free);
            Thread.VolatileWrite(ref _count, 0);
            _revision++;
        }

        /// <summary>
        /// Determines whether the specified key is contained.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key is contained; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsKey(TKey key)
        {
            bool result = false;
            while (true)
            {
                int revision = _revision;
                if (IsOperationSafe())
                {
                    bool isOperationSafe;
                    var entries = ThreadingHelper.VolatileRead(ref _entriesNew);
                    try
                    {
                        result |= ContainsKeyExtracted(key, entries);
                    }
                    finally
                    {
                        isOperationSafe = IsOperationSafe(entries, revision);
                    }
                    if (isOperationSafe)
                    {
                        return result;
                    }
                }
                else
                {
                    CooperativeGrow();
                }
            }
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            var entries = ThreadingHelper.VolatileRead(ref _entriesNew);
            entries.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an <see cref="System.Collections.Generic.IEnumerator{T}" /> that allows to iterate through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _entriesNew.GetKeyValuePairEnumerable().GetEnumerator();
        }

        /// <summary>
        /// Gets the keys and associated values contained in this object.
        /// </summary>
        public IList<KeyValuePair<TKey, TValue>> GetPairs()
        {
            return _entriesNew.GetPairs();
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key was removed; otherwise, <c>false</c>.
        /// </returns>
        public bool Remove(TKey key)
        {
            bool result = false;
            while (true)
            {
                int revision = _revision;
                if (IsOperationSafe())
                {
                    bool isOperationSafe;
                    var entries = ThreadingHelper.VolatileRead(ref _entriesNew);
                    try
                    {
                        result |= RemoveExtracted(key, entries);
                    }
                    finally
                    {
                        isOperationSafe = IsOperationSafe(entries, revision);
                    }
                    if (isOperationSafe)
                    {
                        if (result)
                        {
                            Interlocked.Decrement(ref _count);
                        }
                        return result;
                    }
                }
                else
                {
                    CooperativeGrow();
                }
            }
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified key was removed; otherwise, <c>false</c>.
        /// </returns>
        public bool Remove(TKey key, out TValue value)
        {
            bool result = false;
            value = default(TValue);
            while (true)
            {
                int revision = _revision;
                if (IsOperationSafe())
                {
                    bool isOperationSafe;
                    var entries = ThreadingHelper.VolatileRead(ref _entriesNew);
                    try
                    {
                        TValue tmpValue;
                        if (RemoveExtracted(key, entries, out tmpValue))
                        {
                            value = tmpValue;
                            result = true;
                        }
                    }
                    finally
                    {
                        isOperationSafe = IsOperationSafe(entries, revision);
                    }
                    if (isOperationSafe)
                    {
                        if (result)
                        {
                            Interlocked.Decrement(ref _count);
                        }
                        return result;
                    }
                }
                else
                {
                    CooperativeGrow();
                }
            }
        }

        /// <summary>
        /// Removes the keys and associated values where the key satisfies the predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// The number or removed pairs of keys and associated values.
        /// </returns>
        /// <remarks>
        /// It is not guaranteed that all the pairs of keys and associated values that satisfies the predicate will be removed.
        /// </remarks>
        public int RemoveWhereKey(Predicate<TKey> predicate)
        {
            int removed = 0;
            again:
            var entries = ThreadingHelper.VolatileRead(ref _entriesNew);
            for (int index = 0; index < entries.Capacity; index++)
            {
                bool result = false;
            retry:
                int revision = _revision;
                if (IsOperationSafe())
                {
                    bool isOperationSafe;
                    if (ThreadingHelper.VolatileRead(ref _entriesNew) != entries)
                    {
                        goto again;
                    }
                    try
                    {
                        TKey key;
                        TValue value;
                        if (entries.TryGet(index, out key, out value) && predicate(key))
                        {
                            result |= RemoveExtracted(key, entries);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    finally
                    {
                        isOperationSafe = IsOperationSafe(entries, revision);
                    }
                    if (isOperationSafe)
                    {
                        if (result)
                        {
                            Interlocked.Decrement(ref _count);
                            removed++;
                        }
                        else
                        {
                            goto retry;
                        }
                    }
                }
                else
                {
                    CooperativeGrow();
                    goto retry;
                }
            }
            return removed;
        }

        /// <summary>
        /// Removes the keys and associated values where the key satisfies the predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// An <see cref="IEnumerable{TValue}" /> that allows to iterate over the removed pairs of keys and associated values.
        /// </returns>
        /// <remarks>
        /// It is not guaranteed that all the pairs of keys and associated values that satisfies the predicate will be removed.
        /// </remarks>
        public IEnumerable<TValue> RemoveWhereKeyEnumerable(Predicate<TKey> predicate)
        {
            again:
            var entries = ThreadingHelper.VolatileRead(ref _entriesNew);
            for (int index = 0; index < entries.Capacity; index++)
            {
                bool result = false;
            retry:
                int revision = _revision;
                if (IsOperationSafe())
                {
                    bool isOperationSafe;
                    if (ThreadingHelper.VolatileRead(ref _entriesNew) != entries)
                    {
                        goto again;
                    }
                    TValue value;
                    try
                    {
                        TKey key;
                        if (entries.TryGet(index, out key, out value) && predicate(key))
                        {
                            result |= RemoveExtracted(key, entries);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    finally
                    {
                        isOperationSafe = IsOperationSafe(entries, revision);
                    }
                    if (isOperationSafe)
                    {
                        if (result)
                        {
                            Interlocked.Decrement(ref _count);
                            yield return value;
                        }
                        else
                        {
                            goto retry;
                        }
                    }
                }
                else
                {
                    CooperativeGrow();
                    goto retry;
                }
            }
        }

        /// <summary>
        /// Sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Set(TKey key, TValue value)
        {
            while (true)
            {
                int revision = _revision;
                if (IsOperationSafe())
                {
                    bool isNew;
                    var entries = ThreadingHelper.VolatileRead(ref _entriesNew);
                    if (SetExtracted(key, value, entries, out isNew) != -1)
                    {
                        if (IsOperationSafe(entries, revision))
                        {
                            if (isNew)
                            {
                                Interlocked.Increment(ref _count);
                            }
                            break;
                        }
                        else
                        {
                            int oldStatus = Interlocked.CompareExchange(ref _status, (int)BucketStatus.GrowRequested, (int)BucketStatus.Free);
                            if (oldStatus == (int)BucketStatus.Free)
                            {
                                _revision++;
                            }
                        }
                    }
                }
                else
                {
                    CooperativeGrow();
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Attempts to add the specified key and associated value. The value is added if the key is not found.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified key and associated value were added; otherwise, <c>false</c>.
        /// </returns>
        public bool TryAdd(TKey key, TValue value)
        {
            bool result = false;
            while (true)
            {
                int revision = _revision;
                if (IsOperationSafe())
                {
                    bool isOperationSafe;
                    bool isCollision = false;
                    var entries = ThreadingHelper.VolatileRead(ref _entriesNew);
                    try
                    {
                        result |= TryAddExtracted(key, value, entries, out isCollision) != -1;
                    }
                    finally
                    {
                        isOperationSafe = IsOperationSafe(entries, revision);
                    }
                    if (isOperationSafe)
                    {
                        if (result)
                        {
                            Interlocked.Increment(ref _count);
                            return true;
                        }
                        else
                        {
                            if (isCollision)
                            {
                                var oldStatus = Interlocked.CompareExchange(ref _status, (int)BucketStatus.GrowRequested, (int)BucketStatus.Free);
                                if (oldStatus == (int)BucketStatus.Free)
                                {
                                    _revision++;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    CooperativeGrow();
                }
            }
        }

        /// <summary>
        /// Tries to retrieve the key and associated value at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the value was retrieved; otherwise, <c>false</c>.
        /// </returns>
        public bool TryGet(int index, out TKey key, out TValue value)
        {
            value = default(TValue);
            key = default(TKey);
            bool result = false;
            while (true)
            {
                int revision = _revision;
                if (IsOperationSafe())
                {
                    bool isOperationSafe;
                    var entries = ThreadingHelper.VolatileRead(ref _entriesNew);
                    try
                    {
                        TValue tmpValue;
                        TKey tmpKey;
                        if (TryGetExtracted(index, entries, out tmpKey, out tmpValue))
                        {
                            key = tmpKey;
                            value = tmpValue;
                            result = true;
                        }
                    }
                    finally
                    {
                        isOperationSafe = IsOperationSafe(entries, revision);
                    }
                    if (isOperationSafe)
                    {
                        return result;
                    }
                }
                else
                {
                    CooperativeGrow();
                }
            }
        }

        /// <summary>
        /// Tries to retrieve the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the value was retrieved; otherwise, <c>false</c>.
        /// </returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            bool result = false;
            while (true)
            {
                int revision = _revision;
                if (IsOperationSafe())
                {
                    bool isOperationSafe;
                    var entries = ThreadingHelper.VolatileRead(ref _entriesNew);
                    try
                    {
                        TValue tmpValue;
                        if (TryGetValueExtracted(key, entries, out tmpValue))
                        {
                            value = tmpValue;
                            result = true;
                        }
                    }
                    finally
                    {
                        isOperationSafe = IsOperationSafe(entries, revision);
                    }
                    if (isOperationSafe)
                    {
                        return result;
                    }
                }
                else
                {
                    CooperativeGrow();
                }
            }
        }

        /// <summary>
        /// Removes all the elements.
        /// </summary>
        /// <returns>
        /// An <see cref="FixedSizeHashBucket{TKey, TValue}" /> that with the removed pairs of keys and associated values.
        /// </returns>
        internal FixedSizeHashBucket<TKey, TValue> ClearEnumerable()
        {
            ThreadingHelper.VolatileWrite(ref _entriesOld, null);
            var displaced = Interlocked.Exchange(ref _entriesNew, new FixedSizeHashBucket<TKey, TValue>(INT_DefaultCapacity, _keyComparer));
            Thread.VolatileWrite(ref _status, (int)BucketStatus.Free);
            Thread.VolatileWrite(ref _count, 0);
            _revision++;
            return displaced;
        }

        private int AddExtracted(TKey key, TValue value, FixedSizeHashBucket<TKey, TValue> entries, out bool isCollision)
        {
            isCollision = true;
            if (entries != null)
            {
                for (int attempts = 0; attempts < _maxProbing; attempts++)
                {
                    int index = entries.Add(key, value, attempts, out isCollision);
                    if (index != -1 || !isCollision)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }

        private int CharyAddExtracted(TKey key, TValue value, FixedSizeHashBucket<TKey, TValue> entries, out KeyValuePair<TKey, TValue> previous)
        {
            previous = default(KeyValuePair<TKey, TValue>);
            if (entries != null)
            {
                for (int attempts = 0; attempts < _maxProbing; attempts++)
                {
                    int index = entries.TryAdd(key, value, attempts, out previous);
                    var isCollision = _keyComparer.Equals(previous.Key, key);
                    if (index != -1 || !isCollision)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }

        private bool ContainsKeyExtracted(TKey key, FixedSizeHashBucket<TKey, TValue> entries)
        {
            for (int attempts = 0; attempts < _maxProbing; attempts++)
            {
                if (entries.ContainsKey(key, attempts) != -1)
                {
                    return true;
                }
            }
            return false;
        }

        private void CooperativeGrow()
        {
            int status;
            do
            {
                status = Thread.VolatileRead(ref _status);
                int oldStatus;
                switch (status)
                {
                    case (int)BucketStatus.GrowRequested:

                        // This area is only accessed by one thread, if that thread is aborted, we are doomed.
                        // This class is not abort safe
                        // If a thread is being aborted here it's pending operation will be lost and there is risk of a livelock
                        var priority = Thread.CurrentThread.Priority;
                        oldStatus = Interlocked.CompareExchange(ref _status, (int)BucketStatus.Waiting, (int)BucketStatus.GrowRequested);
                        if (oldStatus == (int)BucketStatus.GrowRequested)
                        {
                            try
                            {
                                // The progress of other threads depend of this one, we should not allow a priority inversion.
                                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                                //_copyPosition is set to -1. _copyPosition is incremented before it is used, so the first time it is used it will be 0.
                                Thread.VolatileWrite(ref _copyPosition, -1);
                                //The new capacity is twice the old capacity, the capacity must be a power of two.
                                var newCapacity = _entriesNew.Capacity * 2;
                                _entriesOld = Interlocked.Exchange(ref _entriesNew, new FixedSizeHashBucket<TKey, TValue>(newCapacity, _keyComparer));
                                oldStatus = Interlocked.CompareExchange(ref _status, (int)BucketStatus.Copy, (int)BucketStatus.Waiting);
                            }
                            finally
                            {
                                Thread.CurrentThread.Priority = priority;
                                _revision++;
                            }
                        }
                        break;

                    case (int)BucketStatus.Waiting:

                        // This is the whole reason why this data structure is not wait free.
                        // Testing shows that it is uncommon that a thread enters here.
                        // _status is 2 only for a short period.
                        // Still, it happens, so this is needed for correctness.
                        // Going completely wait-free adds complexity with diminished value.
                        ThreadingHelper.SpinWaitWhile(ref _status, (int)BucketStatus.Waiting);
                        break;

                    case (int)BucketStatus.Copy:

                        // It is time to cooperate to copy the old storage to the new one
                        var old = _entriesOld;
                        if (old != null)
                        {
                            // This class is not abort safe
                            // If a thread is being aborted here it will causing lost items.
                            _revision++;
                            Interlocked.Increment(ref _copyingThreads);
                            int index = Interlocked.Increment(ref _copyPosition);
                            for (; index < old.Capacity; index = Interlocked.Increment(ref _copyPosition))
                            {
                                TKey key;
                                TValue value;
                                if (old.TryGet(index, out key, out value))
                                {
                                    // We have read an item, so let's try to add it to the new storage
                                    bool dummy;
                                    if (SetExtracted(key, value, _entriesNew, out dummy) == -1)
                                    {
                                        GC.KeepAlive(dummy);
                                    }
                                }
                            }
                            Interlocked.CompareExchange(ref _status, (int)BucketStatus.CopyCleanup, (int)BucketStatus.Copy);
                            _revision++;
                            Interlocked.Decrement(ref _copyingThreads);
                        }
                        break;

                    case (int)BucketStatus.CopyCleanup:

                        // Our copy is finished, we don't need the old storage anymore
                        oldStatus = Interlocked.CompareExchange(ref _status, (int)BucketStatus.Waiting, (int)BucketStatus.CopyCleanup);
                        if (oldStatus == (int)BucketStatus.CopyCleanup)
                        {
                            _revision++;
                            Interlocked.Exchange(ref _entriesOld, null);
                            Interlocked.CompareExchange(ref _status, (int)BucketStatus.Free, (int)BucketStatus.Waiting);
                        }
                        break;
                }
            }
            while (status != (int)BucketStatus.Free);
        }

        private bool IsOperationSafe(object entries, int revision)
        {
            bool check = _revision != revision;
            if (check)
            {
                return false;
            }
            else
            {
                var newEntries = Interlocked.CompareExchange(ref _entriesNew, null, null);
                if (entries == newEntries)
                {
                    var newStatus = Interlocked.CompareExchange(ref _status, (int)BucketStatus.Free, (int)BucketStatus.Free);
                    if (newStatus == (int)BucketStatus.Free)
                    {
                        if (Thread.VolatileRead(ref _copyingThreads) > 0)
                        {
                            _revision++;
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        private bool IsOperationSafe()
        {
            var newStatus = Interlocked.CompareExchange(ref _status, (int)BucketStatus.Free, (int)BucketStatus.Free);
            if (newStatus == (int)BucketStatus.Free)
            {
                if (Thread.VolatileRead(ref _copyingThreads) > 0)
                {
                    _revision++;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private bool RemoveExtracted(TKey key, FixedSizeHashBucket<TKey, TValue> entries)
        {
            if (entries != null)
            {
                for (int attempts = 0; attempts < _maxProbing; attempts++)
                {
                    if (entries.Remove(key, attempts) != -1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool RemoveExtracted(TKey key, FixedSizeHashBucket<TKey, TValue> entries, out TValue value)
        {
            value = default(TValue);
            if (entries != null)
            {
                for (int attempts = 0; attempts < _maxProbing; attempts++)
                {
                    if (entries.Remove(key, attempts, out value) != -1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int SetExtracted(TKey key, TValue value, FixedSizeHashBucket<TKey, TValue> entries, out bool isNew)
        {
            isNew = false;
            if (entries != null)
            {
                for (int attempts = 0; attempts < _maxProbing; attempts++)
                {
                    int index = entries.Set(key, value, attempts, out isNew);
                    if (index != -1)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }

        private int TryAddExtracted(TKey key, TValue value, FixedSizeHashBucket<TKey, TValue> entries, out bool isCollision)
        {
            isCollision = true;
            if (entries != null)
            {
                for (int attempts = 0; attempts < _maxProbing; attempts++)
                {
                    int index = entries.TryAdd(key, value, attempts, out isCollision);
                    if (index != -1 || !isCollision)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }

        private bool TryGetExtracted(int index, FixedSizeHashBucket<TKey, TValue> entries, out TKey key, out TValue value)
        {
            value = default(TValue);
            key = default(TKey);
            if (entries != null)
            {
                if (entries.TryGet(index, out key, out value))
                {
                    return true;
                }
            }
            return false;
        }

        private bool TryGetValueExtracted(TKey key, FixedSizeHashBucket<TKey, TValue> entries, out TValue value)
        {
            value = default(TValue);
            if (entries != null)
            {
                for (int attempts = 0; attempts < _maxProbing; attempts++)
                {
                    if (entries.TryGetValue(key, attempts, out value) != -1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // This class will not shrink, the reason for this is that shrinking may fail, supporting it may require to add locks. [Not solved problem]
        // Enumerating this class gives no guaranties:
        //  Items may be added or removed during enumeration without causing an exception.
        //  A version mechanism is not in place.
        //  This can be added by a wrapper.
    }
}