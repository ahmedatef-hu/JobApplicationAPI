using System.ComponentModel.DataAnnotations;

namespace Trial_A.Models
{
    public class CandidateProfile
    {
        public int Id { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        public string? ResumeUrl { get; set; }
        [Required, MaxLength(500)]
        public string Skill {  get; set; }
        [Range(0, 50)]
        public int YearsOfExperience { get; set; }

        public User Candidate { get; set; }
        public int CandidateId { get; set; } 

        public List<Application> Applications { get; set; } = new List<Application>();
    }
}
