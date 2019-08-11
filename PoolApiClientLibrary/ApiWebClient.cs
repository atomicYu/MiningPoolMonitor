using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using PoolApiClientLibrary.Models;

namespace PoolApiClientLibrary
{
    public class ApiWebClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public ApiWebClient(string endpoint)
        {
            _endpoint = endpoint;
            _httpClient = new HttpClient();
        }

        public async Task<T> GetDataAsync<T>(string methodUrl)
        {
            var response = await _httpClient.GetStringAsync(_endpoint + methodUrl);

            if (response.Contains("NO DATA"))
            {
                return default(T);
            }

            var deserializedObject = await DeseserializeObjectAsync<Response<T>>(response);

            return deserializedObject.Data;
        }

        private Task<T> DeseserializeObjectAsync<T>(string value)
        {
            return Task.Factory.StartNew(() =>
            {
                return JsonConvert.DeserializeObject<T>(value, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            });
        }
    }
}
