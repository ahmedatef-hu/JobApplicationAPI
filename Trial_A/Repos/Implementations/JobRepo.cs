using Microsoft.EntityFrameworkCore;
using Trial_A.Data;
using Trial_A.Models;
using Trial_A.Repos.Interfaces;

namespace Trial_A.Repos.Implementations
{
    public class JobRepo : GenericRepo<Job>, IJobRepo
    {
        public JobRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<Job?> GetJob(int id)
        {
            return await context.Jobs
                .Include(c => c.Company)
                .FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<List<Job>> Search(string KeyWord)
        {
            return await context.Jobs
                .Where(c => c.Title.Contains(KeyWord) && c.Title.Contains(KeyWord))
                .ToListAsync();
        }

        public async Task<Job?> ThirdHighestSalery()
        {
            return await context.Jobs
                .Include(c => c.Company)
                .OrderByDescending(c => c.Salary)
                .Skip(2)
                .FirstOrDefaultAsync();
        }
    }
}
