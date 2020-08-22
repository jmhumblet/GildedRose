namespace csharpcore
{
    public class ConjuredManaCake : Item
    {
        protected override void InternalUpdateQuality()
        {
            if (Quality > 0)
            {
                Quality -= 2;
            }
        }
    }

    public class BackstagePass : Item
    {
        protected override void InternalUpdateQuality()
        {
            if (SellIn < 0)
            {
                Quality = 0;
                return;
            }

            UpdateQualityUpToMaximum();
            
            if (SellIn < 11)
            {
                UpdateQualityUpToMaximum();
            }
            
            if (SellIn < 6)
            {
                UpdateQualityUpToMaximum();
            }            
        }

        private void UpdateQualityUpToMaximum()
        {
            if (Quality < MAXIMUM_QUALITY)
            {
                Quality += 1;
            }
        }
    }

    public class Sulfuras : Item
    {
        public Sulfuras(): base(new NeverExpiringStrategy())
        {

        }

        protected override void InternalUpdateQuality()
        {

        }
    }

    public class AgedBrie : Item
    {
        protected override void InternalUpdateQuality()
        {
            if (Quality < MAXIMUM_QUALITY)
            {
                Quality += 1;
            }
        }
    }

    public class Item
    {
        public Item() : this(new ExpiringStartegy())
        {

        }

        public Item(IExpirationStrategy expirationStrategy)
        {
            this.expirationStrategy = expirationStrategy;
        }

        protected const int MAXIMUM_QUALITY = 50;
        private readonly IExpirationStrategy expirationStrategy;

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void UpdateQuality()
        {
            InternalUpdateQuality();
            InternalUpdateExpiration();

            if (SellIn < 0)
            {
                InternalUpdateQuality();
            }
        }

        protected void InternalUpdateExpiration()
        {
            SellIn = expirationStrategy.GetNextExpiration(SellIn);
        }

        protected virtual void InternalUpdateQuality()
        {
            if (Quality > 0)
            {
                Quality -= 1;
            }
        }
    }
}
