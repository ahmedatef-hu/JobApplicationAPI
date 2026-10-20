using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trial_A.DTOs.CandidateProfile;
using Trial_A.Models;
using Trial_A.UnitOFWork;

namespace Trial_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class candidatesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public candidatesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPut("Profile/{id}")]
        public async Task<IActionResult> Update(int id, CreateCandidateProfileDTO dto)
        {
            var c = await unitOfWork.CandidateProfileRepo.GetById(id);
            if (c == null)
            {
                return NotFound("Profile Doesn't Exist");
            }
            mapper.Map(dto,c);
            return Ok(c);
        }
    }
}
