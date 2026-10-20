using Trial_A.Models;

namespace Trial_A.Repos.Interfaces
{
    public interface IApplicationRepo : IGenericRepo<Application>
    {
        Task<Application> UpdateStatus(int id, string Status);
        Task<List<Application>> GetAllCByCan(int usId);
    }
}
