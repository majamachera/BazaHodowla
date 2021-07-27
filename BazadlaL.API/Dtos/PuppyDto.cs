using System;
using BazadlaL.API.Models;
using System.Collections.Generic;
namespace BazadlaL.API.Dtos

{
    public class PuppyDto
    {
       public int Id { get; set; }
        public string Imie { get; set; }
        public string Plec { get; set; }
        public string Rasa { get; set; }
        public string Masc { get; set; }
        public string DlugoscSiersci { get; set; }
        public bool Rodowod { get; set; }
       public ICollection<VaccinationPuppy> VaccinationPuppy { get; set; }
        public ICollection<DewormingPuppy> DewormingPuppy { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public int MatkaId { get; set; }
    }
}