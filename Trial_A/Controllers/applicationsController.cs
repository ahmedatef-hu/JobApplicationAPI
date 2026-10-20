using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Trial_A.DTOs.Application;
using Trial_A.UnitOFWork;

namespace Trial_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class applicationsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public applicationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPatch("{id}")]
        [Authorize]
        
        public async Task<IActionResult> UpdateStatus(int id, string Status)
        {
            var UserRole = User.FindFirst(ClaimTypes.Role).Value;
            if(UserRole != "Admin")
            {
                return Unauthorized("Only Admin Update Status");
            }
            var app = await unitOfWork.ApplicationRepo.UpdateStatus(id, Status);
            unitOfWork.ApplicationRepo.Update(app);
            unitOfWork.Save();
            return Ok(app);
        }

        [HttpGet]
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> GetAll()
        {
            var candidate = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            if(candidate < 0)
            {
                return BadRequest("Candidate not found");
            }
            var apps = await unitOfWork.ApplicationRepo.GetAllCByCan(candidate);
            var res = mapper.Map<List<GetApplicationDTO>>(apps);
            return Ok(res);
        }

    }
}
