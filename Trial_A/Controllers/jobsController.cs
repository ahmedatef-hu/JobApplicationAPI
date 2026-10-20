using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trial_A.DTOs.Job;
using Trial_A.UnitOFWork;

namespace Trial_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class jobsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public jobsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("third-most-salary")]
        public async Task<IActionResult> THirdMost()
        {
            var job = await unitOfWork.JobRepo.ThirdHighestSalery();
            return Ok(job.Salary);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var job = await unitOfWork.JobRepo.GetJob(id);
            if(job == null)
            {
                return NotFound();
            }
            var dto = mapper.Map<GetJobDTO>(job);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var job = await unitOfWork.JobRepo.GetById(id);
            if(job == null)
            {
                return NotFound();
            }
            await unitOfWork.JobRepo.Delete(job);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string keyword)
        {
            var jobs = await unitOfWork.JobRepo.Search(keyword);
            var res = mapper.Map<List<Getjos>>(jobs);
            return Ok(res);
        }

    }
}
