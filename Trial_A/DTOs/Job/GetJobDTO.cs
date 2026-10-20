using System.ComponentModel.DataAnnotations;
using Trial_A.Models;

namespace Trial_A.DTOs.Job
{
    public class GetJobDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public string EmploymentType { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime DeadLine { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDesc { get; set; }
        public string CompanyLocation { get; set; }
        public string? CompanyWebsite { get; set; }
    }
}
