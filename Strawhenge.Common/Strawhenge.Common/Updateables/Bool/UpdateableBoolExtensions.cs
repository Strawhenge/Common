using System.Linq;

namespace Strawhenge.Common.Updateables
{
    public static class UpdateableBoolExtensions
    {
        public static Updateable<bool> Not(this Updateable<bool> updateable)
        {
            return new Not(updateable);
        }

        public static Updateable<bool> And(this Updateable<bool> updateable, params Updateable<bool>[] updateables)
        {
            if (updateable is And and)
            {
                and.Add(updateables);
                return and;
            }

            return new And(updateables.Prepend(updateable));
        }

        public static Updateable<bool> Or(this Updateable<bool> updateable, params Updateable<bool>[] updateables)
        {
            if (updateable is Or or)
            {
                or.Add(updateables);
                return or;
            }

            return new Or(updateables.Prepend(updateable));
        }
    }
}