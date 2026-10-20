using System.ComponentModel.DataAnnotations;

namespace Trial_A.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime ApplicationDate { get; set; }
        [Required]
        public string Status { get; set; }
        public string? CoverLetter { get; set; }

        public CandidateProfile CandidateProfile { get; set; }
        public int CandidateProfileId { get; set; }
        public Job Job { get; set; }
        public int JobId { get; set; }
    }
}
