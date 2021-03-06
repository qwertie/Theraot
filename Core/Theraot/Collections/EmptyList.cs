using System.Collections.Generic;

namespace Theraot.Collections
{
    [global::System.Diagnostics.DebuggerNonUserCode]
    [global::System.ComponentModel.ImmutableObject(true)]
    public sealed class EmptyList<T> : ProgressiveList<T>, IEnumerable<T>
    {
        private static readonly EmptyList<T> _instance = new EmptyList<T>();

        private EmptyList()
            : base(BuildEmptyEnumerable())
        {
            Progressor.All().Consume();
        }

        public static EmptyList<T> Instance
        {
            get
            {
                return _instance;
            }
        }

        private static IEnumerable<T> BuildEmptyEnumerable()
        {
            yield break;
        }
    }
}