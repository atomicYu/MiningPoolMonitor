using Newtonsoft.Json;

namespace PoolApiClientLibrary.Models
{
    public class Worker
    {        
        /// <summary>
        /// Gets or sets the worker name.
        /// </summary>
        /// <value>Worker name.</value>
        [JsonProperty(PropertyName = "worker")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the reported hashrate.
        /// </summary>
        /// <value>Reported hashrate of the worker in H/s.</value>
        [JsonProperty(PropertyName = "reportedHashrate")]
        public decimal ReportedHashrate { get; private set; }

        /// <summary>
        /// Gets or sets the average hashrate.
        /// </summary>
        /// <value>Average hashrate of the worker in H/s during the last 24h.</value>
        [JsonProperty(PropertyName = "averageHashrate")]
        public decimal AverageHashrate { get; private set; }

        /// <summary>
        /// Gets or sets the curreny hashrate.
        /// </summary>
        /// <value>Current hashrate of the worker in H/s.</value>
        [JsonProperty(PropertyName = "currentHashrate")]
        public decimal CurrenyHashrate { get; private set; }

        /// <summary>
        /// Gets or sets the valid shares.
        /// </summary>
        /// <value>Valid shares submitted by the worker.</value>
        [JsonProperty(PropertyName = "validShares")]
        public int ValidShares { get; private set; }

        /// <summary>
        /// Gets or sets the invalid shares.
        /// </summary>
        /// <value>Invalid shares submitted by the worker.</value>
        [JsonProperty(PropertyName = "invalidShares")]
        public int InvalidShares { get; private set; }

        /// <summary>
        /// Gets or sets the stale shares.
        /// </summary>
        /// <value>Stale shares submitted by the worker.</value>
        [JsonProperty(PropertyName = "staleShares")]
        public int StaleShares { get; private set; }

    }
}
