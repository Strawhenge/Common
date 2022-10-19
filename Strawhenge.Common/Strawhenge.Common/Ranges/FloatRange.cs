namespace Strawhenge.Common.Ranges
{
    public class FloatRange : Range<float>
    {
        public static FloatRange Zero => new FloatRange(0, 0);

        public static implicit operator FloatRange((float min, float max) range) =>
            new FloatRange(range.min, range.max);

        public FloatRange(float min, float max) : base(min, max)
        {
        }
    }
}