using System.Net.Http;
using System.Threading.Tasks;
using GolfClapBot.Domain.Integrations.Fortnite;
using GolfClapBot.Domain.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace GolfClapBot.Service.Integrations.Fortnite
{
    public class FortniteApi : IFortniteApi
    {
        private readonly HttpClient _client;
        private readonly FortniteSettings _settings;

        public FortniteApi(HttpClient client, IOptions<FortniteSettings> settings)
        {
            _client = client;
            _settings = settings.Value;
        }

        /// <inheritdoc />
        public async Task<FortniteStats> Get()
        {
            _client.DefaultRequestHeaders.Add("TRN-Api-Key", _settings.FortniteTrackerApiKey);
            
            var response = await _client.GetAsync($"{_settings.FortnitePlatform}/{_settings.FortniteName}");

            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FortniteStats>(content);
        }
    }
}