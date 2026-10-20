using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Trial_A.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required,Range(0, 1000000)]
        public decimal Salary { get; set; }
        [Required]
        public string EmploymentType { get; set; }
        [Required]
        public DateTime PostedDate { get; set; }
        [Required]
        public DateTime DeadLine {  get; set; }
        [Required]
        public string Status { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }

        public List<Application> Applications { get; set; }
    }
}
