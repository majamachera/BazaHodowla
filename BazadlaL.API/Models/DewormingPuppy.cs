
using System;
using System.Collections.Generic;
namespace BazadlaL.API.Models
{
    public class DewormingPuppy
    {
        public int Id { get; set; }
        public string Preparat { get; set; }
        public DateTime Data { get; set; }
        public Puppy puppy { get; set; }
        public int PuppyId { get; set; }
    }
    
}