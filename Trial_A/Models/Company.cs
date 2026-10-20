using System.ComponentModel.DataAnnotations;

namespace Trial_A.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        [Required, MaxLength(10000)]
        public string Description { get; set; }
        public string? Website {  get; set; }
        [Required]
        public string Location { get; set; }

        public User User { get; set; } 
        public int UserId { get; set; }

        public List<Job> Jobs { get; set; } = new List<Job>();
    }
}
