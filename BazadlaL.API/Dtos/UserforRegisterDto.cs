using System.ComponentModel.DataAnnotations;
namespace BazadlaL.API.Dtos
{
    public class UserforRegisterDto
    {
        [Required(ErrorMessage="Nazwa użytkownika jest wymagana")]
        public string Username { get; set; }
       
        [Required(ErrorMessage="Hasło jest wymagane")]
        [StringLength(12, MinimumLength=6,ErrorMessage="Hasło musi się składać z 6 do 12 znaków")]
        public string Password { get; set; }

        [Required(ErrorMessage="Email jest wymagany")]
        public string Emaile { get; set; }
    }
}