using Trial_A.Data;
using Trial_A.JWT;
using Trial_A.Models;
using Trial_A.Repos.Interfaces;

namespace Trial_A.UnitOFWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public IAuthRepo AuthRepo { get; }

        public IJobRepo JobRepo { get; }
        public ICompanyRepo CompanyRepo { get; }
        public IApplicationRepo ApplicationRepo { get; }
        public IGenericRepo<CandidateProfile> CandidateProfileRepo {  get; }

        public UnitOfWork(AppDbContext context, IAuthRepo AuthRepo, IJobRepo JobRepo, ICompanyRepo companyRepo, IApplicationRepo applicationRepo, IGenericRepo<CandidateProfile> genericRepo)
        {
            this.context = context;
            this.AuthRepo = AuthRepo;
            this.JobRepo = JobRepo;
            CompanyRepo = companyRepo;
            ApplicationRepo = applicationRepo;
            CandidateProfileRepo = genericRepo;
        }


        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
