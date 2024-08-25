namespace Strawhenge.Common.Updateables
{
    public sealed class Fixed<T> : Updateable<T>
    {
        public Fixed(T value) : base(value)
        {
        }
    }
}