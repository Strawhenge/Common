using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Common.Updateables
{
    sealed class And : Updateable<bool>
    {
        readonly List<Updateable<bool>> _updateables = new List<Updateable<bool>>();

        public And(IEnumerable<Updateable<bool>> updateables) : this(updateables.ToArray())
        {
        }

        // Private secondary constructor with array, to avoid multiple enumerations.
        And(Updateable<bool>[] updateables) : base(updateables.All(x => x.Current))
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
            updateable.Changed += _ => Update(_updateables.All(x => x.Current));
        }
    }
}