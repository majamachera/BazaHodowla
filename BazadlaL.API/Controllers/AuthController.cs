using BazadlaL.API.Data;
using BazadlaL.API.Models;
using BazadlaL.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace BazadlaL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthReposytory _repository;
        private readonly IConfiguration _config;
        public AuthController(IAuthReposytory repository, IConfiguration config)
        {
            _config = config;
            _repository = repository;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserforRegisterDto userforRegisterDto)
        {


            userforRegisterDto.Username = userforRegisterDto.Username.ToLower();
            if (await _repository.UserExist(userforRegisterDto.Username))
                return BadRequest("Użytkownik o takiej nazwie już istnieje!!!");


            var UserToCreate = new User
            {
                Name = userforRegisterDto.Username,

            };

            var CreatedUser = await _repository.Register(UserToCreate, userforRegisterDto.Password, userforRegisterDto.Emaile);

            return StatusCode(201);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserforLoginDto userforloginDto)
        {
            var userfromRepo = await _repository.Login(userforloginDto.Username.ToLower(), userforloginDto.Password);

            if (userfromRepo == null)
                return Unauthorized();

            //tworze token
            var claims = new[]
            {
              new Claim(ClaimTypes.NameIdentifier, userfromRepo.Id.ToString()),
              new Claim(ClaimTypes.Name, userfromRepo.Name)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);        
            var tokenDescriptor = new SecurityTokenDescriptor
            {
              Subject = new ClaimsIdentity(claims),
              Expires = DateTime.Now.AddHours(12),
              SigningCredentials = creds 
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return Ok(new {token = tokenHandler.WriteToken(token)});
        }
    }
}