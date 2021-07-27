
using System.Collections.Generic;

namespace BazadlaL.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Fdog> Fdogs { get; set; }
       
    
    }
}