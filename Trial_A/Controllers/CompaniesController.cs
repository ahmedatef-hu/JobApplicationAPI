using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trial_A.DTOs.Company;
using Trial_A.UnitOFWork;

namespace Trial_A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CompaniesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("most-jobs")]
        public async Task<IActionResult> MostJobs()
        {
            var job = await unitOfWork.CompanyRepo.MostJobs();
            var dto = mapper.Map<GetCopmanyDTO>(job);
            return Ok(dto);
        }

    }
}
