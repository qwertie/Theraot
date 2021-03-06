using System.Collections.Generic;

namespace Theraot.Collections
{
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "By Design")]
    public interface IExtendedSet<T> : IReadOnlySet<T>, ISet<T>
    {
        IReadOnlySet<T> AsReadOnly
        {
            get;
        }

        new int Count
        {
            get;
        }

        new bool Add(T item);

        new bool IsProperSubsetOf(IEnumerable<T> other);

        new bool IsProperSupersetOf(IEnumerable<T> other);

        new bool IsSubsetOf(IEnumerable<T> other);

        new bool IsSupersetOf(IEnumerable<T> other);

        new bool Overlaps(IEnumerable<T> other);

        bool Remove(T item, IEqualityComparer<T> comparer);

        new bool SetEquals(IEnumerable<T> other);
    }
}