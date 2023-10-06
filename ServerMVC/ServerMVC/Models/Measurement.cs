namespace ServerMVC.Models
{
    public class Measurement
    {
        public DateTime? measure_date {  get; set; }
        public int? measure_hour { get; set;}
        public int? measure_min { get; set;}
        public int? t_pow { get; set;}
        public int?  far { get; set; }
        public int? rh { get; set; }
        public int? t { get; set; }
        public int? winddir { get; set; }
        public int? wind { get; set; }
    }
}
