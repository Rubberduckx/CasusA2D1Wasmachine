using System.ComponentModel.DataAnnotations;

namespace WebApplicationCasusWasmachine.Models
{
    public class Goal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
