using Trial_A.Models;

namespace Trial_A.Repos.Interfaces
{
    public interface ICompanyRepo : IGenericRepo<Company>
    {
        Task<Company> MostJobs();
    }
}
