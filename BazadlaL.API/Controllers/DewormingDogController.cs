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
 
    [Route("api/dewormingdog")]
    [ApiController]
    public class DewormingDogController: ControllerBase
    {
       private readonly ITreatmentsRep _repo;
        private readonly IMapper _mapper;
        public DewormingDogController (ITreatmentsRep repo, IMapper mapper){
            _mapper = mapper;
            _repo = repo;

        }
       
        [HttpGet("{idp}")]
        public async Task<IActionResult> GetDewormingDog(int idp){
            var odrob = await _repo.GetDewormingDog(idp);
            return Ok(odrob);
        }
        [HttpGet]
        public async Task<IActionResult> GetDewormingsDog(int fdogId){
            var odrob = await _repo.GetDewormingsDog();
            var mapped = _mapper.Map<IEnumerable<DewormingDogDto>>(odrob);
            return Ok(mapped);
        }
  
    }
}