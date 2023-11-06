using System.ComponentModel.DataAnnotations;

namespace WebApplicationCasusWasmachine.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        public string Model { get; set; }
        public string energyLabel { get; set; }
        public int KwH {  get; set; }
        public DateTime manufactureDate { get; set; }
        public DateTime warrentyEndDate { get; set; }
        public string Category { get; set; }
        public int lifeSpan { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        //public Report Report { get; set; }
    }
}
