using System.Collections.Generic;

namespace Theraot.Collections
{
    public interface IExtendedCollection<T> : ICollection<T>, IExtendedReadOnlyCollection<T>
    {
        IReadOnlyCollection<T> AsReadOnly
        {
            get;
        }

        new int Count
        {
            get;
        }

        bool Remove(T item, IEqualityComparer<T> comparer);
    }
}