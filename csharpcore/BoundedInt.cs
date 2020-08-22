using System;

namespace csharpcore
{
    public struct BoundedInt
    {
        private readonly int value;
        private readonly Range range;

        public BoundedInt(Range range, int value)
        {
            this.range = range;

            var boundedBelow = Math.Min(range.Max, value);
            var boundedAbove = Math.Max(range.Min, boundedBelow);
            this.value = boundedAbove;
        }


        public static implicit operator int (BoundedInt boundedInt)
        {
            return boundedInt.value;
        }

        public static BoundedInt operator + (BoundedInt obj, int i)
        {
            return new BoundedInt(obj.range, obj.value + i);
        }


        public static bool operator ==(BoundedInt left, BoundedInt right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BoundedInt left, BoundedInt right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BoundedInt other))
                return false;

            return this.range == other.range
                && this.value == other.value;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + range.GetHashCode();
                hash = hash * 23 + value.GetHashCode();
                return hash;
            }
        }
    }
}
