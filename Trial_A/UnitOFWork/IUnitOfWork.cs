using Trial_A.JWT;
using Trial_A.Models;
using Trial_A.Repos.Interfaces;

namespace Trial_A.UnitOFWork
{
    public interface IUnitOfWork
    {
        IAuthRepo AuthRepo { get; }
        IJobRepo JobRepo { get; }
        ICompanyRepo CompanyRepo { get; }
        IApplicationRepo ApplicationRepo { get; }
        IGenericRepo<CandidateProfile> CandidateProfileRepo {  get; }
        int Save();
    }
}
