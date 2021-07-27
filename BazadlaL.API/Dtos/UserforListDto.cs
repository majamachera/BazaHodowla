using System.Collections.Generic;
using BazadlaL.API.Models;

namespace BazadlaL.API.Dtos
{
    public class UserforListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<FdogDto> Fdogs { get; set; }
       
    }
}