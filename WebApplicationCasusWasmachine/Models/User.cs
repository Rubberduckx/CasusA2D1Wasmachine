using System.ComponentModel.DataAnnotations;

namespace WebApplicationCasusWasmachine.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }
        public Device Device { get; set; }
        public virtual ICollection<Device> Devices { get; set;}
        public virtual ICollection<Goal> Goals { get;}
    }
}
