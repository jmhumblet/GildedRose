namespace csharpcore
{
    public interface IQualityBehavior
    {
        int CalculateQualityChange(int sellIn);
    }

    public class DecreasingQuality : IQualityBehavior
    {
        private readonly int rate;

        public DecreasingQuality(int rate = 1)
        {
            this.rate = rate;
        }

        public int CalculateQualityChange(int sellIn)
        {
            return sellIn >= 0 ? -rate : -2 * rate;
        }
    }

    public class BetterOncePerished : IQualityBehavior
    {
        public int CalculateQualityChange(int sellIn)
        {
            return sellIn < 0 ? 2 : 1;
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

            if (sellIn < 10)
            {
                increase++;
            }

            if (sellIn < 5)
            {
                increase++;
            }

            return increase;
        }
    }

}
