namespace csharpcore
{
    public interface IExpirationStrategy
    {
        int GetNextExpiration(int initialExpiration);
    }

    public class NeverExpiringStrategy : IExpirationStrategy
    {
        public int GetNextExpiration(int initialExpiration)
        {
            return initialExpiration;
        }
    }

    public class ExpiringStartegy : IExpirationStrategy
    {
        public int GetNextExpiration(int initialExpiration)
        {
            return initialExpiration - 1;
        }
    }
}
