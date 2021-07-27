using System.Security.Claims;
using AutoMapper;
using BazadlaL.API.Data;
using BazadlaL.API.Dtos;
using BazadlaL.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace BazadlaL.API.Controllers
{
    [Authorize]
    [Route ("api/user/{userId}/fdogs")]
    [ApiController]
    public class ActionsOnFdogsController : ControllerBase
    {
        private readonly IUserRep _repo;
        private readonly IMapper _mapper;

        public ActionsOnFdogsController(IUserRep repo, IMapper mapper)
       {
            _repo = repo;
            _mapper = mapper;
        } 
       [HttpPost]
        public async Task<IActionResult> AddFdog(int userId, FdogforAddDto fdogforAddDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            var userFromRepo = await _repo.GetUser(userId);
            var FdogToCreate = new Fdog
            {
                Imie = fdogforAddDto.Imie,
                Plec = fdogforAddDto.Plec,
                Rasa = fdogforAddDto.Rasa,
                Masc = fdogforAddDto.Masc,
                DlugoscSiersci = fdogforAddDto.DlugoscSiersci,
                Rodowod = fdogforAddDto.Rodowod,
                DataUrodzenia = fdogforAddDto.DataUrodzenia,

            };
            var fdogmap = _mapper.Map<Fdog>(FdogToCreate);
            userFromRepo.Fdogs.Add(fdogmap);
            
            if (await _repo.SaveAll())
            {
                var fdog = _mapper.Map<FdogForReturn>(fdogmap);
                return CreatedAtRoute("GetFdog",new{id = fdogmap.Id}, fdog);
            }
            return BadRequest("nie udało");
        }
         [HttpGet("id", Name = "GetFdog")]
        public async Task<IActionResult> GetThisFdog(int id)
        {
            var fdog = await _repo.GetThisFdog(id);
            var FdogforReturn = _mapper.Map<FdogforAddDto>(fdog);
            return Ok(FdogforReturn);
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> DelateFdog(int userId, int id)
        {
            var fdog = await _repo.GetThisFdog(id);
            _repo.Delate(fdog);
            if (await _repo.SaveAll())
              return Ok(); 
            return BadRequest("Nie udało się");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFdog(int id, FdogforUpdateDto FdogforUpdateDto)
        {
            var fdog = await _repo.GetThisFdog(id);
            _mapper.Map(FdogforUpdateDto, fdog);
            if(await _repo.SaveAll()){
                return Ok(fdog);
            }
            throw new Exception("nie udało sie");
        }
    }
    
}