namespace csharpcore
{
    public class ConjuredManaCake : Item
    {
        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality--;
            }

            base.UpdateQuality();
        }
    }

    public class BackstagePass : Item
    {
        public override void UpdateQuality()
        {
            UpdateQualityUpToMaximum();

            if (SellIn < 6)
            {
                UpdateQualityUpToMaximum();
            }

            if (SellIn < 11)
            {
                UpdateQualityUpToMaximum();
            }


            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = 0;
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
        public override void UpdateQuality()
        {

        }
    }

    public class AgedBrie : Item
    {
        public override void UpdateQuality()
        {
            if (Quality < MAXIMUM_QUALITY)
            {
                Quality += 1;
            }
            
            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                if (Quality < MAXIMUM_QUALITY)
                {
                    Quality = Quality + 1;
                }
            }
        }
    }

    public class Item
    {
        protected const int MAXIMUM_QUALITY = 50;

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public virtual void UpdateQuality()
        {
            if (Name != "Aged Brie")
            {
                if (Quality > 0)
                {
                    Quality -= 1;
                }
            }
            else
            {
                if (Quality < MAXIMUM_QUALITY)
                {
                    Quality += 1;
                }
            }

            SellIn = SellIn - 1;
            
            if (SellIn < 0)
            {
                if (Name != "Aged Brie")
                {
                    if (Quality > 0)
                    {
                            
                        Quality = Quality - 1;
                            
                    }
                }
                else
                {
                    if (Quality < MAXIMUM_QUALITY)
                    {
                        Quality = Quality + 1;
                    }
                }
            }
        }
    }
}
