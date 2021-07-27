using System;
using System.Collections.Generic;
using BazadlaL.API.Models;
namespace BazadlaL.API.Dtos
{
    public class DewormingPuppyForAddDto
    {
        public string Preparat { get; set; }
        public DateTime Data { get; set; }
        public int PuppyId { get; set; }
        
        public DewormingPuppyForAddDto()
        {
            Data = DateTime.Now;
        }
    }

}