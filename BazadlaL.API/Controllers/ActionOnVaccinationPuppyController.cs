using System.Security.Claims;
using AutoMapper;
using BazadlaL.API.Data;
using BazadlaL.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using BazadlaL.API.Models;

namespace BazadlaL.API.Controllers
{
    
    [Route ("api/user/{IdPuppy}/vaccinationp")]
    [ApiController]
    public class ActionOnVaccinationPuppyController :ControllerBase
    {
        private readonly ITreatmentsRep _repo;
        private readonly IMapper _mapper;
        public ActionOnVaccinationPuppyController(ITreatmentsRep repo, IMapper mapper){
            _mapper = mapper;
            _repo = repo;
        }
        
         [HttpPost]
        public async Task<IActionResult> AddVaccinationPuppy(int IdPuppy, VaccinationPuppyForAddDto vaccinationPuppyForAddDto)
        {
            //if (projectsId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();
            
            var puppyFromRepo = await _repo.GetPuppyVaccination(IdPuppy);
            var VaccinationPuppyToCreate = new VaccinationPuppy
            {
                Nazwa = vaccinationPuppyForAddDto.Nazwa,
                Seria = vaccinationPuppyForAddDto.Seria,
                Data = vaccinationPuppyForAddDto.Data,
                Waznosc = vaccinationPuppyForAddDto.Waznosc,
            };
            var VaccinationPuppymap = _mapper.Map<VaccinationPuppy>(VaccinationPuppyToCreate);
            puppyFromRepo.VaccinationPuppy.Add(VaccinationPuppymap);
            if (await _repo.SaveAll())
            {
                var szczep = _mapper.Map<VaccinationPuppyDto>(VaccinationPuppymap);
                return CreatedAtRoute("GetVaccinationPuppy",new{id = VaccinationPuppymap.Id}, szczep);
            }
            return BadRequest("nie udało");
        }
        
         [HttpGet("idp", Name = "GetVaccinationPuppy")]
        public async Task<IActionResult> GetThisVaccinationPuppy(int id)
        {
            var szczep = await _repo.GetThisVaccinationPuppy(id);
            var VaccinationPuppyforReturnDto = _mapper.Map<VaccinationPuppyDto>(szczep);
            return Ok(VaccinationPuppyforReturnDto);
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> DelateVaccinationPuppy(int IdPuppy, int id)
        {
            var VaccinationPuppyFromRepo = await _repo.GetThisVaccinationPuppy(id);
            _repo.Delate(VaccinationPuppyFromRepo);
            if(await _repo.SaveAll())
                return Ok();
            return BadRequest("nie udało się usunąć szczeniaka z listy");
        }
        

    }
}