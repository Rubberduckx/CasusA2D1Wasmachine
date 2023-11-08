namespace WebApplicationCasusWasmachine.Models
{
    public class UsingReport
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public int Duration { get; set; }
        public string Setting { get; set; }
        public Device Device { get; set; }
        public int DeviceId { get; set; }
    }
}
