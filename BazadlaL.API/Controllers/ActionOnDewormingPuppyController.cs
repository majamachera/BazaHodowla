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
    
    [Route ("api/user/{puppyId}/dewormingp")]
    [ApiController]
    public class ActionOnDewormingPuppyController : ControllerBase
    {
        private readonly ITreatmentsRep _repo;
        private readonly IMapper _mapper;
        public ActionOnDewormingPuppyController(ITreatmentsRep repo, IMapper mapper){
            _mapper = mapper;
            _repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult> AddDeworming(int puppyId, DewormingPuppyForAddDto dewormingPuppyForAddDto)
        {
            //if (projectsId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();
            
            var puppyFromRepo = await _repo.GetPuppyDeworming(puppyId);
            var DewormingToCreate = new DewormingPuppy
            {
                Preparat = dewormingPuppyForAddDto.Preparat,
                Data = dewormingPuppyForAddDto.Data,
            };
            var mapped = _mapper.Map<DewormingPuppy>(DewormingToCreate);
            puppyFromRepo.DewormingPuppy.Add(mapped);
            if (await _repo.SaveAll())
            {
                var odrob = _mapper.Map<DewormingPuppyDto>(mapped);
                return CreatedAtRoute("GetDewormingPuppy",new{id = mapped.Id}, odrob);
            }
            return BadRequest("nie udało");
        }
        
         [HttpGet("idp", Name = "GetDewormingPuppy")]
        public async Task<IActionResult> GetThisDewormingPuppy(int id)
        {
            var dew = await _repo.GetThisDewormingPuppy(id);
            var DewormingforReturnDto = _mapper.Map<DewormingPuppyDto>(dew);
            return Ok(DewormingforReturnDto);
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> DelateDewormingPuppy(int puppyId, int id)
        {
            var dewormingFromRepo = await _repo.GetThisDewormingPuppy(id);
            _repo.Delate(dewormingFromRepo);
            if(await _repo.SaveAll())
                return Ok();
            return BadRequest("nie udało się usunąć  z listy");
        }
        

    }
}