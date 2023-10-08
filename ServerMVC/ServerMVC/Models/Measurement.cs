namespace ServerMVC.Models
{
    public class Measurement
    {
        public int id { get; set; }
        public DateTime measure_date {  get; set; }
        public int measure_hour { get; set;}
        public int measure_min { get; set;}
        public decimal t_pov { get; set;}
        public decimal far { get; set; }
        public decimal rh { get; set; }
        public decimal t { get; set; }
        public decimal winddir { get; set; }
        public decimal wind { get; set; }
    }
}
