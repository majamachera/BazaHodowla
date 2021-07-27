using System;
using System.Collections.Generic;
using BazadlaL.API.Models;
namespace BazadlaL.API.Dtos
{
    public class DewormingDogForAddDto
    {
        public string Preparat { get; set; }
        public DateTime Data { get; set; }
        public int FdogId { get; set; }
        
        public DewormingDogForAddDto()
        {
            Data = DateTime.Now;
        }
    }

}