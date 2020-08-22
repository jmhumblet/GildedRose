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
        protected override void InternalUpdateQuality()
        {

        }

        protected override void InternalUpdateExpiration()
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
        protected const int MAXIMUM_QUALITY = 50;

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

        protected virtual void InternalUpdateExpiration()
        {
            SellIn = SellIn - 1;
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
