namespace Strawhenge.Common.Ranges
{
    public class IntRange : Range<int>
    {
        public static IntRange Zero => new IntRange(0, 0);

        public IntRange(int min, int max) : base(min, max)
        {
        }
    }
}