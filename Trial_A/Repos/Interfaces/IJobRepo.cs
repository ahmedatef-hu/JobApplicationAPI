using Trial_A.DTOs.Job;
using Trial_A.Models;

namespace Trial_A.Repos.Interfaces
{
    public interface IJobRepo : IGenericRepo<Job>
    {
        Task<Job?> ThirdHighestSalery();
        Task<Job?> GetJob(int id);
        Task<List<Job>> Search(string KeyWord);
    }
}
