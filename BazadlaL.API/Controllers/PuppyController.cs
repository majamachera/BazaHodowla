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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PuppyController : ControllerBase
    {
        private readonly IUserRep _repo;
        private readonly IMapper _mapper;

        public PuppyController(IUserRep repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
       
         [HttpGet("{idp}")]
        public async Task<IActionResult> GetPuppy(int idp)
        {
            var pup = await _repo.GetPuppy(idp);
            return Ok(pup);
 
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPuppies(int matkaId)
        {
          
            var pup = await _repo.GetPuppies();
            var mappedlink = _mapper.Map<IEnumerable<PuppyDto>>(pup);
            return Ok(mappedlink);
        }
       
    }
}