using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trial_A.DTOs.Auth;
using Trial_A.Models;
using Trial_A.UnitOFWork;

namespace Trial_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public authController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var Token = await unitOfWork.AuthRepo.Login(dto);
            if (Token == null)
            {
                return Unauthorized("Email Or Password NotValid");
            }
            
            return Ok(Token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                CreateAt = dto.CreateAt,
                Password = dto.Password,
                Role = dto.Role,
            };
            if(user.Role == "Admin")
            {
                return BadRequest("Can't Reister Admin");
            }
            if(user.Role != "Candidate" && user.Role != "Employer")
            {
                return BadRequest("Must Register Candidate and Employer only");
            }
            if (await unitOfWork.AuthRepo.Register(user))
            {
                return Created();
            }
            return BadRequest("User Already Existe");
        }
    }
}
