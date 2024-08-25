using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Common.Updateables
{
    sealed class Or : Updateable<bool>
    {
        readonly List<Updateable<bool>> _updateables = new List<Updateable<bool>>();

        public Or(IEnumerable<Updateable<bool>> updateables) : this(updateables.ToArray())
        {
        }

        // Private secondary constructor with array, to avoid multiple enumerations.
        Or(Updateable<bool>[] updateables) : base(updateables.All(x => x.Current))
        {
            Add(updateables);
        }

        internal void Add(IEnumerable<Updateable<bool>> updateables)
        {
            foreach (var updateable in updateables)
                Add(updateable);
        }

        internal void Add(Updateable<bool> updateable)
        {
            _updateables.Add(updateable);
            updateable.Changed += _ => Update(_updateables.Any(x => x.Current));
        }
    }
}