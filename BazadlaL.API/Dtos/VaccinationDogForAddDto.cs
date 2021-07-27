using System;
using BazadlaL.API.Models;

namespace BazadlaL.API.Dtos
{
    public class VaccinationDogForAddDto
    {
        public string Nazwa { get; set; }
        public string Seria { get; set; }
        public DateTime Data { get; set; }
        public DateTime Waznosc { get; set; }
        public int FdogId { get; set; }
         public VaccinationDogForAddDto()
        {
            Data = DateTime.Now;
        }
    }
}