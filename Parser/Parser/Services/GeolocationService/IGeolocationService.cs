using System.Threading.Tasks;

namespace Services.GeolocationService
{
    public interface IGeolocationService
    {
        Task<string> GetGeolocation(string host);
    }
}