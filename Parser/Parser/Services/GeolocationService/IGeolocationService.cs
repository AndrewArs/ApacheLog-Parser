using System.Threading.Tasks;
using DomainModels.Models;

namespace Services.GeolocationService
{
    public interface IGeolocationService
    {
        Task<Geolocation> GetGeolocation(string host);
    }
}