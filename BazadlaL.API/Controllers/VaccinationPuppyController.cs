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

    [Route("api/vaccinationpuppy")]
    [ApiController]
      public class VaccinationPuppyController : ControllerBase
    {
        private readonly ITreatmentsRep _repo;
        private readonly IMapper _mapper;
        public VaccinationPuppyController (ITreatmentsRep repo, IMapper mapper){
            _mapper = mapper;
            _repo = repo;

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVaccinationPuppy(int id){
            var szczep = await _repo.GetVaccinationPuppy(id);
            return Ok(szczep);
        }
        [HttpGet]
        public async Task<IActionResult> GetVaccinationsPuppy(int puppyId){
            var szczep = await _repo.GetVaccinationsPuppy();
            var mapped = _mapper.Map<IEnumerable<VaccinationPuppyDto>>(szczep);
            return Ok(szczep);
        }

    }
}