using Microsoft.EntityFrameworkCore;
using Trial_A.Data;
using Trial_A.Models;
using Trial_A.Repos.Interfaces;

namespace Trial_A.Repos.Implementations
{
    public class CompanyRepo : GenericRepo<Company>, ICompanyRepo
    {
        public CompanyRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<Company> MostJobs()
        {
            return await context.Companies
                .OrderByDescending(c => c.Jobs.Count())
                .FirstOrDefaultAsync();
        }
    }
}
