namespace ServerMVC.Models
{
    public class Moistmeter
    {
        public int id { get; set; }
        /// <summary>
        /// Год, месяц, день наблюдения
        /// </summary>
        public DateTime measure_date { get; set; }
        /// <summary>
        /// Данные с первого канала скважника
        /// </summary>
        public int channel1 { get; set; }
        /// <summary>
        /// Данные со второго канала скважника
        /// </summary>
        public int channel2 { get; set; }
        /// <summary>
        /// Данные с третьего канала скважника
        /// </summary>
        public int channel3 { get; set; }
        /// <summary>
        /// Данные с четвёртого канала скважника
        /// </summary>
        public int channel4 { get; set; }
        /// <summary>
        /// Данные с пятого канала скважника
        /// </summary>
        public int channel5 { get; set; }
        /// <summary>
        /// Час наблюдения
        /// </summary>
        public int measure_hour { get; set; }
        /// <summary>
        /// Номер скважника
        /// </summary>
        public string name { get; set; }
    }
}
