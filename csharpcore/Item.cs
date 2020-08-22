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

    public class Sulfuras : Item
    {
        public override void UpdateQuality()
        {
            base.UpdateQuality();
        }
    }

    public class Item
    {
        private const int MAXIMUM_QUALITY = 50;

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public virtual void UpdateQuality()
        {
            if (Name != "Aged Brie" && Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Quality > 0)
                {
                    if (Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Quality -= 1;
                    }
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

            if (Name != "Sulfuras, Hand of Ragnaros")
            {
                SellIn = SellIn - 1;
            }

            if (SellIn < 0)
            {
                if (Name != "Aged Brie")
                {
                    if (Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Quality > 0)
                        {
                            if (Name != "Sulfuras, Hand of Ragnaros")
                            {
                                Quality = Quality - 1;
                            }
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
