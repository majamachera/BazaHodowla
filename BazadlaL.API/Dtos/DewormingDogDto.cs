using System;
using System.Collections.Generic;
using BazadlaL.API.Models;
namespace BazadlaL.API.Dtos
{
    public class DewormingDogDto
    {
        public int Id { get; set; }
        public string Preparat { get; set; }
        public DateTime Data { get; set; }
        public int FdogId { get; set; }
    }
}