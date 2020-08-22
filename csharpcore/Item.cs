namespace csharpcore
{
    public class ConjuredManaCake : Item
    {
        public ConjuredManaCake() : base(new DecreasingQuality(2))
        {

        }
    }

    public class BackstagePass : Item
    {
        public BackstagePass() : base (new EmotionalPeak())
        {

        }
    }

    public class Sulfuras : Item
    {
        public Sulfuras() : base(
            new NeverExpiringStrategy(),
            new Inalterable(), 
            new Range(80))
        {

        }
    }

    public class AgedBrie : Item
    {
        public AgedBrie() : base (new BetterOncePerished())
        {

        }
    }

    public class Item
    {
        public Item() : this(
            new ExpiringStartegy(), 
            new DecreasingQuality())
        {

        }

        public Item(IQualityBehavior qualityBehavior) 
            : this (new ExpiringStartegy(), qualityBehavior)
        {

        }

        public Item(
            IExpirationStrategy expirationStrategy,
            IQualityBehavior qualityBehavior,
            Range qualityRange = null)
        {
            this.expirationStrategy = expirationStrategy;
            this.qualityBehavior = qualityBehavior;
            this.qualityRange = qualityRange ?? new Range(0, 50);
        }

        private readonly IExpirationStrategy expirationStrategy;
        private readonly IQualityBehavior qualityBehavior;
        private readonly Range qualityRange;
        private BoundedInt quality;

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality
        {
            get => quality;
            set => quality = new BoundedInt(qualityRange, value);
        }

        public void UpdateQuality()
        {
            UpdateExpiration();
            InternalUpdateQuality();
        }

        protected void UpdateExpiration()
        {
            SellIn = expirationStrategy.GetNextExpiration(SellIn);
        }

        protected void InternalUpdateQuality()
        {
            quality += qualityBehavior.CalculateQualityChange(SellIn);
        }
    }
}
