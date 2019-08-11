namespace PoolApiClientLibrary
{
    class Flypool: GenericPoolApi
    {
        public Flypool() : base("https://api-zcash.flypool.org")
        {
        }
    }
}
