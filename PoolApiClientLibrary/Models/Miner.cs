using System.Threading.Tasks;

namespace PoolApiClientLibrary.Models
{
    public class Miner
    {
        private readonly ApiWebClient _client;
        private readonly string _miner;

        public Miner(ApiWebClient client, string miner)
        {
            _client = client;
            _miner = miner;
        }

        /// <summary>
        /// Miner Statistics.
        /// </summary>
        /// <returns>The statistics async.</returns>
        public async Task<MinerStatistics> GetStatisticsAsync() => await _client.GetDataAsync<MinerStatistics>($"/miner/{_miner}/currentStats");

        /// <summary>
        /// Array of the worker statistic entries sorted by name ASC.
        /// </summary>
        public async Task<Worker[]> GetWorkersAsync() => await _client.GetDataAsync<Worker[]>($"/miner/{_miner}/workers");
    }
}
