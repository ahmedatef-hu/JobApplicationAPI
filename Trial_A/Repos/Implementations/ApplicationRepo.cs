using Microsoft.EntityFrameworkCore;
using Trial_A.Data;
using Trial_A.Models;
using Trial_A.Repos.Interfaces;

namespace Trial_A.Repos.Implementations
{
    public class ApplicationRepo : GenericRepo<Application>, IApplicationRepo
    {
        public ApplicationRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Application>> GetAllCByCan(int UsId)
        {
            return await context.Applications.Where(c => c.CandidateProfileId == UsId)
                .ToListAsync();
        }

        public async Task<Application> UpdateStatus(int id, string Status)
        {
            var application = await GetById(id);
            if (application == null)
            {
                return null;
            }
            application.Status = Status;
            context.SaveChanges();
            return application;
        }
    }
}
