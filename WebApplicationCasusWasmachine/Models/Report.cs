using System.ComponentModel.DataAnnotations;

namespace WebApplicationCasusWasmachine.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateOfCreation { get; set; }
        public string Content { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
