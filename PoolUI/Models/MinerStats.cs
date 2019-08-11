namespace PoolUI.Models
{
    public class MinerStats
    {
        public decimal ReportedHashrate { get; set; } = 0;
        public decimal AverageHashrate { get; set; } = 0;
        public decimal CurrentHashrate { get; set; } = 0;
        public int ValidShares { get; set; } = 0;
        public int InvalidShares { get; set; } = 0;
        public int StaleShares { get; set; } = 0;
        public int ActiveWorkers { get; set; } = 0;
        public decimal Unpaid { get; set; } = 0;
        public decimal USDPerMin { get; set; } = 0;
    }
}
