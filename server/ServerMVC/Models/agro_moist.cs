namespace ServerMVC.Models
{
    public class agro_moist
    {
        public int id { get; set; }
        /// <summary>
        /// Год, месяц, день наблюдения
        /// </summary>
        public DateTime reg_date { get; set; }
        /// <summary>
        /// Номер скважника
        /// </summary>
        public int sensor { get; set; }
        public int pos { get; set; }
        public double u1 { get; set; }
        /// <summary>
        /// Влажность с первого канала скважника
        /// </summary>
        public double m1 { get; set; }
        public double u2 { get; set; }
        /// <summary>
        /// Влажность со второго канала скважника
        /// </summary>
        public double m2 { get; set; }
        public double u3 { get; set; }
        /// <summary>
        /// Влажность с третьего канала скважника
        /// </summary>
        public int m3 { get; set; }
        public double u4 { get; set; }
        /// <summary>
        /// Влажность с четвёртого канала скважника
        /// </summary>
        public double m4 { get; set; }
        public double u5 { get; set; }
        /// <summary>
        /// Данные с пятого канала скважника
        /// </summary>
        public double m5 { get; set; }
        public double t1 { get; set; }
        public double t2 { get; set; }
        public double t3 { get; set; }
        public double t4 { get; set; }
        public double t5 { get; set; }
    }
}
