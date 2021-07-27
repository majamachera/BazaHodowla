
using System;
using System.Collections.Generic;
namespace BazadlaL.API.Models
{
    public class DewormingDog
    {
        public int Id { get; set; }
        public string Preparat { get; set; }
        public DateTime Data { get; set; }
         public Fdog fdog {get; set;}
        public int FdogId { get; set; }
    }
    
}