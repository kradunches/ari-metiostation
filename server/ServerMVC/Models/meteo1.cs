namespace ServerMVC.Models
{
    public class meteo1
    {
        public int id { get; set; }
        /// <summary>
        /// Дата наблюдения (timestamp)
        /// </summary>
        public DateTime reg_date {  get; set; }
        /// <summary>
        /// Скорость ветра
        /// </summary>
        public double wind_speed { get; set; }
        public double wind_p { get; set; }
        public double wind_direction_07 { get; set; }
        public string? wind_direction { get; set; }
        /// <summary>
        /// Направление ветра
        /// </summary>
        public double wind_direction360 { get; set; }
        /// <summary>
        /// Влажность воздуха
        /// </summary>
        public double humidity { get; set; }
        /// <summary>
        /// Температура воздуха
        /// </summary>
        public double temperature { get; set; }
        public double noise { get; set; }
        public double pm2_5 { get; set; }
        public double pm10 { get; set; }
        public double atmospheric_pressure { get; set; }
        public double the_lux { get; set; }
        public double the_lux_value2 { get; set; }
        /// <summary>
        /// Освещённость
        /// </summary>
        public double light { get; set; }
        /// <summary>
        /// Осадки
        /// </summary>
        public double optical_rainfall { get; set; }
        public double electronic_compass_angle { get; set; }
        public double voltage { get; set; }
        public double current_1 { get; set; }
        public string? comment { get; set; }
        public enum TypeOfMeasure
        {
            /// <summary>
            /// Осадки
            /// </summary>
            optical_rainfall,
            /// <summary>
            /// Освещённость
            /// </summary>
            light,
            /// <summary>
            /// Влажность воздуха
            /// </summary>
            humidity,
            /// <summary>
            /// Температура воздуха
            /// </summary>
            temperature,
            /// <summary>
            /// Направление ветра
            /// </summary>
            wind_direction360,
            /// <summary>
            /// Скорость ветра
            /// </summary>
            wind_speed
        }
    }
}
