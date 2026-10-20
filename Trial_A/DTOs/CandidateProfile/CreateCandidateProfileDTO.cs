using System.ComponentModel.DataAnnotations;
using Trial_A.Models;

namespace Trial_A.DTOs.CandidateProfile
{
    public class CreateCandidateProfileDTO
    {
        [Required, Phone]
        public string Phone { get; set; }
        public string? ResumeUrl { get; set; }
        [Required, MaxLength(500)]
        public string Skill { get; set; }
        [Range(0, 50)]
        public int YearsOfExperience { get; set; }

        public int CandidateId { get; set; }

    }
}
