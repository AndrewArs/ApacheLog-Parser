using System.Net.Http;
using System.Threading.Tasks;
using DomainModels.Models;
using Newtonsoft.Json;

namespace Services.GeolocationService
{
    public class GeolocationService : IGeolocationService
    {
        private const string ServiceUrl = "http://freegeoip.net/json/";

        /// <summary>
        /// Gets the geolocation.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <returns></returns>
        public async Task<Geolocation> GetGeolocation(string host)
        {
            using (var client = new HttpClient())
            {
                var resp = await client.GetAsync($"{ServiceUrl}{host}");

                return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Geolocation>(await resp.Content.ReadAsStringAsync()) : null;
            }
        }
    }
}