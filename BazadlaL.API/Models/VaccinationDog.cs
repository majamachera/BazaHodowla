using System; 
using System.Collections.Generic;
namespace BazadlaL.API.Models
{
    public class VaccinationDog
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Seria { get; set; }
        public DateTime Data { get; set; }
        public DateTime Waznosc { get; set; }
        public Fdog fdog {get; set;}
        public int FdogId { get; set; }
    }
}