namespace PoolApiClientLibrary.Models
{
    public class Response<T>
    {
        public string Status { get; set; }

        public T Data { get; set; }
    }
}
