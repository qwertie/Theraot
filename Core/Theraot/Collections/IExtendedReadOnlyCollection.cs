using System.Collections.Generic;

namespace Theraot.Collections
{
    public interface IExtendedReadOnlyCollection<T> : IReadOnlyCollection<T>
    {
        bool Contains(T item);

        bool Contains(T item, IEqualityComparer<T> comparer);

        void CopyTo(T[] array);

        void CopyTo(T[] array, int arrayIndex);

        void CopyTo(T[] array, int arrayIndex, int countLimit);
    }
}