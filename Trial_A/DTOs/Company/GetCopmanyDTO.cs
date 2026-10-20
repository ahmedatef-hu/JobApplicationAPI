using System.ComponentModel.DataAnnotations;
using Trial_A.Models;

namespace Trial_A.DTOs.Company
{
    public class GetCopmanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Website { get; set; }
        public string Location { get; set; }

        public int UserId { get; set; }
    }
}
