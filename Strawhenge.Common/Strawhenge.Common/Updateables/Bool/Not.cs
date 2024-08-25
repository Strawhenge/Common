namespace Strawhenge.Common.Updateables
{
    sealed class Not : Updateable<bool>
    {
        public Not(Updateable<bool> updateable) : base(!updateable.Current)
        {
            updateable.Changed += value => Update(!value);
        }
    }
}