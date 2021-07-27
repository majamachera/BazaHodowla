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
    
    [Route ("api/user/{fdogId}/vaccinationd")]
    [ApiController]
    public class ActionOnVaccinationDogController :ControllerBase
    {
        private readonly ITreatmentsRep _repo;
        private readonly IMapper _mapper;
        public ActionOnVaccinationDogController(ITreatmentsRep repo, IMapper mapper){
            _mapper = mapper;
            _repo = repo;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddVaccinationDog(int fdogId, VaccinationDogForAddDto vaccinationDogForAddDto)
        {
            //if (projectsId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized();
            
            var fdogFromRepo = await _repo.GetFdogVaccination(fdogId);
            var VaccinationDogToCreate = new VaccinationDog
            {
                Nazwa = vaccinationDogForAddDto.Nazwa,
                Seria = vaccinationDogForAddDto.Seria,
                Data = vaccinationDogForAddDto.Data,
                Waznosc = vaccinationDogForAddDto.Waznosc,
            };
            var szczepmap = _mapper.Map<VaccinationDog>(VaccinationDogToCreate);
            fdogFromRepo.VaccinationDog.Add(szczepmap);
            if (await _repo.SaveAll())
            {
                var vac = _mapper.Map<VaccinationDogDto>(szczepmap);
                return CreatedAtRoute("GetVaccinationDog",new{id = szczepmap.Id}, vac);
            }
            return BadRequest("nie udało");
        }
        
         [HttpGet("idp", Name = "GetVaccinationDog")]
        public async Task<IActionResult> GetThisVaccinationDog(int id)
        {
            var vac = await _repo.GetThisVaccinationDog(id);
            var VaccinationDogforReturnDto = _mapper.Map<VaccinationDogDto>(vac);
            return Ok(VaccinationDogforReturnDto);
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> DelateVaccinationDog(int fdogId, int id)
        {
            var VaccinationDogFromRepo = await _repo.GetThisVaccinationDog(id);
            _repo.Delate(VaccinationDogFromRepo);
            if(await _repo.SaveAll())
                return Ok();
            return BadRequest("nie udało się usunąć  z listy");
        }
        

    }
}