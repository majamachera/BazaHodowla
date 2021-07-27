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
    
    [Route ("api/user/{fdogId}/dewormingd")]
    [ApiController]
    public class ActionOnDewormingDogController : ControllerBase
    {
        private readonly ITreatmentsRep _repo;
        private readonly IMapper _mapper;
        public ActionOnDewormingDogController( ITreatmentsRep repo, IMapper mapper){
            _mapper = mapper;
            _repo = repo;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddDewormingDog(int fdogId, DewormingDogForAddDto dewormingDogForAddDto)
        {
            //if (projectsId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();
            
            var fdogFromRepo = await _repo.GetFdogDeworming(fdogId);
            var DewormingToCreate = new DewormingDog
            {
                Preparat = dewormingDogForAddDto.Preparat,
                Data = dewormingDogForAddDto.Data,
               
            };
            var mapped = _mapper.Map<DewormingDog>(DewormingToCreate);
            fdogFromRepo.DewormingDog.Add(mapped);
            if (await _repo.SaveAll())
            {
                var odrob = _mapper.Map<DewormingDogDto>(mapped);
                return CreatedAtRoute("GetDewormingDog",new{id = mapped.Id}, odrob);
            }
            return BadRequest("nie udało");
        }
        
         [HttpGet("idp", Name = "GetDewormingDog")]
        public async Task<IActionResult> GetThisDewormingDog(int id)
        {
            var dew = await _repo.GetThisDewormingDog(id);
            var DewormingforReturnDto = _mapper.Map<DewormingDogDto>(dew);
            return Ok(DewormingforReturnDto);
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> DelateOdrobaczenie(int fdogId, int id)
        {
            var dewormingFromRepo = await _repo.GetThisDewormingDog(id);
            _repo.Delate(dewormingFromRepo);
            if(await _repo.SaveAll())
                return Ok();
            return BadRequest("nie udało się usunąć");
        }
        

    }
}