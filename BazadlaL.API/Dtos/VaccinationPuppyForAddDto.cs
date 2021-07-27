using System;
using BazadlaL.API.Models;

namespace BazadlaL.API.Dtos
{
    public class VaccinationPuppyForAddDto
    {
        public string Nazwa { get; set; }
        public string Seria { get; set; }
        public DateTime Data { get; set; }
        public DateTime Waznosc { get; set; }
        public int PuppyId { get; set; }
         public VaccinationPuppyForAddDto()
        {
            Data = DateTime.Now;
        }
    }
    
}