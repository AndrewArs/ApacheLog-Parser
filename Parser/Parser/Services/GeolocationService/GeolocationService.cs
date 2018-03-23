using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
        public async Task<string> GetGeolocation(string host)
        {
            using (var client = new HttpClient())
            {
                var resp = await client.GetAsync($"{ServiceUrl}{host}");
                
                return resp.IsSuccessStatusCode ? (string)JObject.Parse(await resp.Content.ReadAsStringAsync()).GetValue("country_name") : null;
            }
        }
    }
}