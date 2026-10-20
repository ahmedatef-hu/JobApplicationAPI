using AutoMapper;
using Trial_A.DTOs.Application;
using Trial_A.DTOs.CandidateProfile;
using Trial_A.DTOs.Company;
using Trial_A.DTOs.Job;
using Trial_A.Models;

namespace Trial_A.Mapping
{
    public class ModelsProfile : Profile
    {
        public ModelsProfile()
        {
            CreateMap<Job, Getjos>();
            CreateMap<Job, GetJobDTO>()
                .ForMember(c => c.CompanyDesc, c => c.MapFrom(src => src.Company.Description))
                .ForMember(c => c.CompanyLocation, c => c.MapFrom(src => src.Company.Location))
                .ForMember(c => c.CompanyName, c => c.MapFrom(src => src.Company.Name))
                .ForMember(c => c.CompanyWebsite, c => c.MapFrom(src => src.Company.Website));
            
            
            CreateMap<Company, GetCopmanyDTO>();

            CreateMap<Application, GetApplicationDTO>();

            CreateMap<CreateCandidateProfileDTO, CandidateProfile>();
        }
    }
}
