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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FDogController : ControllerBase
    {
      
        private readonly IUserRep _repo;
        private readonly IMapper _mapper;

        public FDogController(IUserRep repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
       
         [HttpGet]
        public async Task<IActionResult> GetFdogs()
        {
            
            var fdog = await _repo.GetFdogs();
            var mappedfdog = _mapper.Map<IEnumerable<FdogDto>>(fdog);
            return Ok(mappedfdog);
        }
          [HttpGet("{idp}")]
        public async Task<IActionResult> GetFdog(int idp)
        {
            var fdog = await _repo.GetFdog(idp);
            return Ok(fdog);
        }

        
    }

}

    