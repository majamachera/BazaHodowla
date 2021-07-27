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
 
    [Route("api/dewormingpuppy")]
    [ApiController]
    public class DewormingPuppyController: ControllerBase
    {
       private readonly ITreatmentsRep _repo;
        private readonly IMapper _mapper;
        public DewormingPuppyController (ITreatmentsRep repo, IMapper mapper){
            _mapper = mapper;
            _repo = repo;

        }
       
        [HttpGet("{idp}")]
        public async Task<IActionResult> GetDewormingPuppy(int id){
            var odrob = await _repo.GetDewormingPuppy(id);
            return Ok(odrob);
        }
        [HttpGet]
        public async Task<IActionResult> GetDewormingsPuppy(int fdogId){
            var odrob = await _repo.GetDewormingsPuppy();
            var mapped = _mapper.Map<IEnumerable<DewormingPuppyDto>>(odrob);
            return Ok(mapped);
        }
  
    }
}