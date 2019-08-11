namespace PoolUI.Models
{
    public class PoolSettings
    {
        public string MinerAddress { get; set; }

        public string Pool { get; set; }

        public decimal MinHeshRate { get; set; }

        public bool Startup { get; set; } = true;

        public int RefreshTime { get; set; } = 5;
    }
}
