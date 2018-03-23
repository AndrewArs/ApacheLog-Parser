using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Host { get; set; }

        public string Route { get; set; }

        public string UrlQueryParameters { get; set; }

        public int StatusCode { get; set; }

        public int? Length { get; set; }

        public string Method { get; set; }

        public string Geolocation { get; set; }
    }
}
