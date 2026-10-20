using System.ComponentModel.DataAnnotations;
using Trial_A.Models;

namespace Trial_A.DTOs.Application
{
    public class GetApplicationDTO
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
        public string? CoverLetter { get; set; }
        public int CandidateProfileId { get; set; }
        public int JobId { get; set; }
    }
}
