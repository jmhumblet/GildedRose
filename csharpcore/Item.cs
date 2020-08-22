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
            
            if (Quality < MAXIMUM_QUALITY)
            {
                Quality += 1;

                if (SellIn < 6)
                {
                    if (Quality < MAXIMUM_QUALITY)
                    {
                        Quality = Quality + 1;
                    }
                }

                if (SellIn < 11)
                {
                    if (Quality < MAXIMUM_QUALITY)
                    {
                        Quality = Quality + 1;
                    }
                }
            }

            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = 0;
            }
        }
    }

    public class Sulfuras : Item
    {
        public override void UpdateQuality()
        {

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
            if (Name != "Aged Brie" && Name != "Backstage passes to a TAFKAL80ETC concert")
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

                    if (Name == "Backstage passes to a TAFKAL80ETC concert")
                    {

                        if (SellIn < 6)
                        {
                            if (Quality < MAXIMUM_QUALITY)
                            {
                                Quality = Quality + 1;
                            }
                        }

                        if (SellIn < 11)
                        {
                            if (Quality < MAXIMUM_QUALITY)
                            {
                                Quality = Quality + 1;
                            }
                        }
                    }
                }
            }

            SellIn = SellIn - 1;
            
            if (SellIn < 0)
            {
                if (Name != "Aged Brie")
                {
                    if (Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Quality > 0)
                        {
                            
                            Quality = Quality - 1;
                            
                        }
                    }
                    else
                    {
                        Quality = Quality - Quality;
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
