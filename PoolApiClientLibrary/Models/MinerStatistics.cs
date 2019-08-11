using Newtonsoft.Json;
using System;

namespace PoolApiClientLibrary.Models
{
    public class MinerStatistics
    {
        private decimal _reportedHashrate;
        private decimal _averageHashrate;
        private decimal _currenyHashrate;
        private decimal _unpaid;

        /// <summary>
        /// Gets or sets the reported hashrate.
        /// </summary>
        /// <value>Reported hashrate of the miner in H/s.</value>
        [JsonProperty(PropertyName = "reportedHashrate")]
        public decimal ReportedHashrate
        {
            get { return Math.Round(_reportedHashrate / 1000000, 1); }
            set { _reportedHashrate = value; }
        }

        /// <summary>
        /// Gets or sets the average hashrate.
        /// </summary>
        /// <value>Average hashrate of the miner in H/s during the last 24h.</value>        
        [JsonProperty(PropertyName = "averageHashrate")]
        public decimal AverageHashrate
        {
            get { return Math.Round(_averageHashrate / 1000000, 1); }
            set { _averageHashrate = value; }
        }

        /// <summary>
        /// Gets or sets the curreny hashrate.
        /// </summary>
        /// <value>Current hashrate of the miner in H/s.</value>
        [JsonProperty(PropertyName = "currentHashrate")]
        public decimal CurrenyHashrate
        {
            get { return Math.Round(_currenyHashrate / 1000000, 1); }
            set { _currenyHashrate = value; }
        }

        /// <summary>
        /// Gets or sets the valid shares.
        /// </summary>
        /// <value>Valid shares submitted by the miner.</value>
        [JsonProperty(PropertyName = "validShares")]
        public int ValidShares { get; set; }

        /// <summary>
        /// Gets or sets the invalid shares.
        /// </summary>
        /// <value>Invalid shares submitted by the miner.</value>
        [JsonProperty(PropertyName = "invalidShares")]
        public int InvalidShares { get; set; }

        /// <summary>
        /// Gets or sets the stale shares.
        /// </summary>
        /// <value>Stale shares submitted by the miner.</value>
        [JsonProperty(PropertyName = "staleShares")]
        public int StaleShares { get; set; }

        /// <summary>
        /// Gets or sets the active workers.
        /// </summary>
        /// <value>Currently active workers of the miner.</value>
        [JsonProperty(PropertyName = "activeWorkers")]
        public int ActiveWorkers { get; set; }

        /// <summary>
        /// Gets or sets the unpaid.
        /// </summary>
        /// <value>Unpaid balance(in base units) of the miner.</value>
        [JsonProperty(PropertyName = "unpaid")]
        public decimal Unpaid
        {
            get {return Math.Round(_unpaid/1000000000000000000,5); }
            set {_unpaid = value; }
        }

        /// <summary>
        /// Gets or sets the USDP er minimum.
        /// </summary>
        /// <value>Estimated number of USD(in base units) mined per minute(based on your average hashrate as well as the average block time and difficulty of the network over the last 24 hours.)</value>
        [JsonProperty(PropertyName = "usdPerMin")]
        public decimal USDPerMin { get; set; }
    }
}
