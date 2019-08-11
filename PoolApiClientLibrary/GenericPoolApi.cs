using PoolApiClientLibrary.Models;

namespace PoolApiClientLibrary
{
    public class GenericPoolApi
    {
        private readonly ApiWebClient _apiWebClient;

        protected GenericPoolApi(string endpoint)
        {
            _apiWebClient = new ApiWebClient(endpoint);
        }

        public Miner GetMiner(string miner)
        {
            return new Miner(_apiWebClient, miner);
        }
    }
}
