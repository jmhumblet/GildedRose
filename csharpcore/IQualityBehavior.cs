namespace csharpcore
{
    public interface IQualityBehavior
    {
        int CalculateQualityChange(int sellIn);
    }

    public class Decreasing : IQualityBehavior
    {
        private readonly int rate;

        public Decreasing(int rate = 1)
        {
            this.rate = rate;
        }

        public int CalculateQualityChange(int sellIn)
        {
            return -rate;
        }
    }

    public class Increasing : IQualityBehavior
    {
        public int CalculateQualityChange(int sellIn)
        {
            return 1;
        }
    }

    public class Inalterable : IQualityBehavior
    {
        public int CalculateQualityChange(int sellIn)
        {
            return 0;
        }
    }

    public class EmotionalPeak : IQualityBehavior
    {
        public int CalculateQualityChange(int sellIn)
        {
            if (sellIn < 0)
            {
                return int.MinValue;
            }

            var increase = 1;

            if (sellIn < 11)
            {
                increase++;
            }

            if (sellIn < 6)
            {
                increase++;
            }

            return increase;
        }
    }

}
