using System.ComponentModel.DataAnnotations;
using WebApplicationCasusWasmachine.Data;

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
        public string Email { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }
        public int UploadedDevices { get; set; }    
        public virtual ICollection<Device> Devices { get; set;}
        public virtual ICollection<Goal> Goals { get;}

        public void LevelUp(AppDbContext context)
        {
            if(UploadedDevices % 2 == 0)
            {
                this.Level+=1;
                context.Users.Update(this);
                context.SaveChanges();
            }
        }

        public void GetPoints(AppDbContext context, int points)
        {
            this.Points += points;
            context.Users.Update(this);
            context.SaveChanges();
        }
    }
}
