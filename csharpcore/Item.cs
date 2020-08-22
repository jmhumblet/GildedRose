using System;

namespace csharpcore
{
    public class ConjuredManaCake : Item
    {
        public ConjuredManaCake() : base(new Decreasing(2))
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
        public Sulfuras() : base(new NeverExpiringStrategy(), new Inalterable())
        {
            MaximumQuality = 80;
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
        public Item() : this(new ExpiringStartegy(), new Decreasing())
        {

        }

        public Item(IQualityBehavior qualityBehavior) 
            : this (new ExpiringStartegy(), qualityBehavior)
        {

        }

        public Item(
            IExpirationStrategy expirationStrategy,
            IQualityBehavior qualityBehavior)
        {
            this.expirationStrategy = expirationStrategy;
            this.qualityBehavior = qualityBehavior;
        }

        protected int MaximumQuality = 50;
        protected int MinimumQuality = 0;

        private readonly IExpirationStrategy expirationStrategy;
        private readonly IQualityBehavior qualityBehavior;
        private int quality;

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality
        {
            get => quality;
            set => quality = Math.Min(MaximumQuality,
                Math.Max(MinimumQuality, value));
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

        protected virtual void InternalUpdateQuality()
        {
            Quality += qualityBehavior.CalculateQualityChange(SellIn);
        }
    }
}
