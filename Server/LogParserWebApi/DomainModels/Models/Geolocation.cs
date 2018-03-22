using System.ComponentModel.DataAnnotations;

namespace DomainModels.Models
{
    public class Geolocation
    {
        [Key]
        public int Id { get; set; }
        
        public string Ip { get; set; }
        
        public string CountryCode { get; set; }
        
        public string CountryName { get; set; }
        
        public string RegionCode { get; set; }
        
        public string RegionName { get; set; }
        
        public string ZipCode { get; set; }
        
        public string TimeZone { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
        
        public int MetroCode { get; set; }
    }
}