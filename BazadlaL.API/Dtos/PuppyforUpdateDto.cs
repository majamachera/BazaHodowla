using System;
using Microsoft.AspNetCore.Http;
using BazadlaL.API.Models;
using System.Collections.Generic;
namespace BazadlaL.API.Dtos
{
    public class PuppyforUpdateDto
    {
   
        public string Imie { get; set; }
        public string Plec { get; set; }
        public string Rasa { get; set; }
        public string Masc { get; set; }
        public string DlugoscSiersci { get; set; }
        public bool Rodowod { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public int MatkaId { get; set; }
        
    }
}