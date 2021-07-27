using System;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Collections.Generic;
using BazadlaL.API.Models;
namespace BazadlaL.API.Dtos
{
    public class FdogforAddDto
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Plec { get; set; }
        public string Rasa { get; set; }
        public string Masc { get; set; }
        public string DlugoscSiersci { get; set; }
        public bool Rodowod { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public int UserId { get; set; }

    }
}