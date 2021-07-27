using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BazadlaL.API.Data;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using BazadlaL.API.Dtos;
using AutoMapper;

namespace BazadlaL.API.Controllers
{

    [Route("api/vaccinationdog")]
    [ApiController]
  
    public class VaccinationDogController : ControllerBase
    {
        private readonly ITreatmentsRep _repo;
        private readonly IMapper _mapper;
        public VaccinationDogController (ITreatmentsRep repo, IMapper mapper){
            _mapper = mapper;
            _repo = repo;

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVaccinationDog(int id){
            var szczep = await _repo.GetVaccinationDog(id);
            return Ok(szczep);
        }
        [HttpGet]
        public async Task<IActionResult> GetVaccinationsDog(int fdogId){
            var szczep = await _repo.GetVaccinationsDog();
            var mapped = _mapper.Map<IEnumerable<VaccinationDogDto>>(szczep);
            return Ok(szczep);
        }

    }
}