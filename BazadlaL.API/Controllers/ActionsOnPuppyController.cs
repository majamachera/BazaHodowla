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
    //[Authorize]
    [Route ("api/user/{matkaId}/puppy")]
    [ApiController]
    public class ActionsOnPuppyController : ControllerBase
    {
        private readonly IUserRep _repo;
        private readonly IMapper _mapper;
        public ActionsOnPuppyController(IUserRep repo, IMapper mapper){
            _mapper = mapper;
            _repo = repo;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddPuppy(int matkaId, PuppyForAddDto puppyforaddto)
        {
            //if (projectsId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();
            
            var projFromRepo = await _repo.GetFdog(matkaId);
            var PuppyToCreate = new Puppy
            {
                Imie = puppyforaddto.Imie,
                Plec = puppyforaddto.Plec,
                Rasa = puppyforaddto.Rasa,
                Masc = puppyforaddto.Masc,
                DlugoscSiersci = puppyforaddto.DlugoscSiersci,
                Rodowod = puppyforaddto.Rodowod,
                DataUrodzenia = puppyforaddto.DataUrodzenia,
            };
            var puppymap = _mapper.Map<Puppy>(PuppyToCreate);
            projFromRepo.Puppies.Add(puppymap);
            if (await _repo.SaveAll())
            {
                var pup = _mapper.Map<PuppyForReturnDto>(puppymap);
                return CreatedAtRoute("GetPuppy",new{id = puppymap.Id}, pup);
            }
            return BadRequest("nie udało");
        }
        
         [HttpGet("idp", Name = "GetPuppy")]
        public async Task<IActionResult> GetThisPuppy(int id)
        {
            var pup = await _repo.GetThisPuppy(id);
            var PuppyforReturnDto = _mapper.Map<PuppyForReturnDto>(pup);
            return Ok(PuppyforReturnDto);
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> DelatePuppy(int matkaId, int id)
        {
            var puppyFromRepo = await _repo.GetThisPuppy(id);
            _repo.Delate(puppyFromRepo);
            if(await _repo.SaveAll())
                return Ok();
            return BadRequest("nie udało się usunąć szczeniaka z listy");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePuppy(int id, PuppyforUpdateDto puppyforUpdateDto){
            var puppyfromrepo = await _repo.GetThisPuppy(id);
            var zmapowany = _mapper.Map(puppyforUpdateDto, puppyfromrepo);
            if(await _repo.SaveAll())
                return Ok(zmapowany);
            throw new Exception("nie udało sie");
        }

    }

}