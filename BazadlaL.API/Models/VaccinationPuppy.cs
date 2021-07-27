using System; 
using System.Collections.Generic;
namespace BazadlaL.API.Models
{
    public class VaccinationPuppy
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Seria { get; set; }
        public DateTime Data { get; set; }
        public DateTime Waznosc { get; set; }
        public Puppy puppy { get; set; }
        public int PuppyId { get; set; }
    }
}