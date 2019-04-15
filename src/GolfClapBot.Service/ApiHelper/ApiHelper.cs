using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GolfClapBot.Service.ApiHelper
{
    public class ApiHelper<T> : IApiHelper<T>
    {
        private readonly HttpClient _client;

        public ApiHelper(HttpClient client)
        {
            _client = client;
        }

        /// <inheritdoc />
        public async Task<T> Get(string baseAddress, string endPoint)
        {
            _client.BaseAddress = new Uri(baseAddress);

            var response = await _client.GetAsync(endPoint);

            if (!response.IsSuccessStatusCode) return default(T);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}