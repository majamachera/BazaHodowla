using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using BazadlaL.API.Data;
using BazadlaL.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BazadlaL.API.Controllers 
{
    
    [Route("api/dogwith")]
    [ApiController]
    public class FDogWithTreatmentsController : ControllerBase
    {
      
        private readonly ITreatmentsRep _repo;
        private readonly IMapper _mapper;

        public FDogWithTreatmentsController(ITreatmentsRep repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
       
        
        [HttpGet("dew/{idp}")]
        public async Task<IActionResult> GetFdogDeworming(int idp)
        {
            var fdog = await _repo.GetFdogDeworming(idp);
            return Ok(fdog);
        }
        [HttpGet("vac/{idp}")]
        public async Task<IActionResult> GetFdogVacination(int idp)
        {
            var fdog = await _repo.GetFdogVaccination(idp);
            return Ok(fdog);
        }

        
    }

}

    