using System;
using System.Collections.Generic;

namespace BazadlaL.API.Models
{
    public class Fdog
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Plec { get; set; }
        public string Rasa { get; set; }
        public string Masc { get; set; }
        public string DlugoscSiersci { get; set; }
        public bool Rodowod { get; set; }
        public ICollection<VaccinationDog> VaccinationDog { get; set; }
        public ICollection<DewormingDog> DewormingDog { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public ICollection<Puppy> Puppies { get; set; }
        public User User {get; set;}
        public int UserId { get; set; }
    }
}