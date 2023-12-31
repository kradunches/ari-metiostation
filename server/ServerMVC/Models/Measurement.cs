﻿namespace ServerMVC.Models
{
    public class Measurement
    {
        public int id { get; set; }
        /// <summary>
        /// Год, месяц, день наблюдения
        /// </summary>
        public DateTime measure_date {  get; set; }
        /// <summary>
        /// Час наблюдения
        /// </summary>
        public int measure_hour { get; set;}
        /// <summary>
        /// Минута наблюдения
        /// </summary>
        public int measure_min { get; set;}
        /// <summary>
        /// Температура поверхности почвы
        /// </summary>
        public decimal t_pov { get; set;}
        /// <summary>
        /// Освещённость
        /// </summary>
        public decimal far { get; set; }
        /// <summary>
        /// Влажность воздуха
        /// </summary>
        public decimal rh { get; set; }
        /// <summary>
        /// Температура воздуха
        /// </summary>
        public decimal t { get; set; }
        /// <summary>
        /// Направление ветра
        /// </summary>
        public decimal winddir { get; set; }
        /// <summary>
        /// Скорость ветра
        /// </summary>
        public decimal wind { get; set; }
        public enum TypeOfMeasure
        {
            /// <summary>
            /// Температура поверхности почвы
            /// </summary>
            t_pov,
            /// <summary>
            /// Освещённость
            /// </summary>
            far,
            /// <summary>
            /// Влажность воздуха
            /// </summary>
            rh,
            /// <summary>
            /// Температура воздуха
            /// </summary>
            t,
            /// <summary>
            /// Направление ветра
            /// </summary>
            winddir,
            /// <summary>
            /// Скорость ветра
            /// </summary>
            wind
        }
    }
}
