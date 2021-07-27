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

    [Route("api/puppywith")]
    [ApiController]
    public class PuppyWithTreatmentsController : ControllerBase
    {
        private readonly ITreatmentsRep _repo;
        private readonly IMapper _mapper;

        public PuppyWithTreatmentsController(ITreatmentsRep repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
       
         [HttpGet("vac/{idp}")]
        public async Task<IActionResult> GetPuppyVaccination(int idp)
        {
            var pup = await _repo.GetPuppyVaccination(idp);
            return Ok(pup);
 
        }
        
         [HttpGet("dew/{idp}")]
        public async Task<IActionResult> GetPuppyDeworming(int idp)
        {
            var pup = await _repo.GetPuppyDeworming(idp);
            return Ok(pup);
 
        }
        
       
    }
}