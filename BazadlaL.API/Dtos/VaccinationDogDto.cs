using System;
using BazadlaL.API.Models;

namespace BazadlaL.API.Dtos
{
    public class VaccinationDogDto
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Seria { get; set; }
        public DateTime Data { get; set; }
        public DateTime Waznosc { get; set; }
        public int FdogId { get; set; }
    }
}