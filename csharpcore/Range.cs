namespace csharpcore
{
    public class Range
    {
        public Range (int value)
        {
            Min = value;
            Max = value;
        }

        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; }
        public int Max { get; }
    }
}
