using Microsoft.AspNetCore.Mvc;
using ServerMVC.Models;

namespace ServerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMeasurementRepository measurementRepository;
        public HomeController(IMeasurementRepository measRepo)
        {
            this.measurementRepository = measRepo;
        }

        public List<object> IncarnateMeasurement(Measurement.TypeOfMeasure typeOfMeasure, DateTime startDate, int daysAmount)
        {
            List<object> temperatureChart = new List<object>();
            List<string> labels = new List<string>();
            List<decimal> values = new List<decimal>();
            switch (typeOfMeasure)
            {
                case Measurement.TypeOfMeasure.t_pov:
                {
                    for (int i = 0; i < daysAmount; i++)
                    {
                        ILookup<int, Measurement> lookup = measurementRepository.Measurements.Where(p => p.measure_date == startDate.AddDays(i).ToUniversalTime()).ToLookup(p => p.measure_hour);
                        foreach (var j in lookup)
                        {
                            int year = j.Select(p => p.measure_date.Year).First();
                            int month = j.Select(p => p.measure_date.Month).First();
                            int day = j.Select(p => p.measure_date.Day).First();
                            int hour = j.Select(p => p.measure_hour).First();
                            int minute = j.Select(p => p.measure_min).First();
                            DateTime outDate = new DateTime(year, month, day, hour, minute, 0);
                            string outStrDate = outDate.ToString("yyyy-MM-dd HH:mm");
                            decimal outNumVal = j.Select(p => p.t_pov).First();
                            labels.Add(outStrDate);
                            values.Add(outNumVal);
                        }
                    }
                    break;
                }
                case Measurement.TypeOfMeasure.far:
                {
                    for (int i = 0; i < daysAmount; i++)
                    {
                        ILookup<int, Measurement> lookup = measurementRepository.Measurements.Where(p => p.measure_date == startDate.AddDays(i).ToUniversalTime()).ToLookup(p => p.measure_hour);
                        foreach (var j in lookup)
                        {
                            int year = j.Select(p => p.measure_date.Year).First();
                            int month = j.Select(p => p.measure_date.Month).First();
                            int day = j.Select(p => p.measure_date.Day).First();
                            int hour = j.Select(p => p.measure_hour).First();
                            int minute = j.Select(p => p.measure_min).First();
                            DateTime outDate = new DateTime(year, month, day, hour, minute, 0);
                            string outStrDate = outDate.ToString("yyyy-MM-dd HH:mm");
                            decimal outNumVal = j.Select(p => p.far).First();
                            labels.Add(outStrDate);
                            values.Add(outNumVal);
                        }
                    }
                    break;
                }
                case Measurement.TypeOfMeasure.rh:
                {
                    for (int i = 0; i < daysAmount; i++)
                    {
                        ILookup<int, Measurement> lookup = measurementRepository.Measurements.Where(p => p.measure_date == startDate.AddDays(i).ToUniversalTime()).ToLookup(p => p.measure_hour);
                        foreach (var j in lookup)
                        {
                            int year = j.Select(p => p.measure_date.Year).First();
                            int month = j.Select(p => p.measure_date.Month).First();
                            int day = j.Select(p => p.measure_date.Day).First();
                            int hour = j.Select(p => p.measure_hour).First();
                            int minute = j.Select(p => p.measure_min).First();
                            DateTime outDate = new DateTime(year, month, day, hour, minute, 0);
                            string outStrDate = outDate.ToString("yyyy-MM-dd HH:mm");
                            decimal outNumVal = j.Select(p => p.rh).First();
                            labels.Add(outStrDate);
                            values.Add(outNumVal);
                        }
                    }
                    break;
                }
                case Measurement.TypeOfMeasure.t:
                {
                    for (int i = 0; i < daysAmount; i++)
                    {
                        ILookup<int, Measurement> lookup = measurementRepository.Measurements.Where(p => p.measure_date == startDate.AddDays(i).ToUniversalTime()).ToLookup(p => p.measure_hour);
                        foreach (var j in lookup)
                        {
                            int year = j.Select(p => p.measure_date.Year).First();
                            int month = j.Select(p => p.measure_date.Month).First();
                            int day = j.Select(p => p.measure_date.Day).First();
                            int hour = j.Select(p => p.measure_hour).First();
                            int minute = j.Select(p => p.measure_min).First();
                            DateTime outDate = new DateTime(year, month, day, hour, minute, 0);
                            string outStrDate = outDate.ToString("yyyy-MM-dd HH:mm");
                            decimal outNumVal = j.Select(p => p.t).First();
                            labels.Add(outStrDate);
                            values.Add(outNumVal);
                        }
                    }
                    break;
                }
                case Measurement.TypeOfMeasure.wind:
                {
                    for (int i = 0; i < daysAmount; i++)
                    {
                        ILookup<int, Measurement> lookup = measurementRepository.Measurements.Where(p => p.measure_date == startDate.AddDays(i).ToUniversalTime()).ToLookup(p => p.measure_hour);
                        foreach (var j in lookup)
                        {
                            int year = j.Select(p => p.measure_date.Year).First();
                            int month = j.Select(p => p.measure_date.Month).First();
                            int day = j.Select(p => p.measure_date.Day).First();
                            int hour = j.Select(p => p.measure_hour).First();
                            int minute = j.Select(p => p.measure_min).First();
                            DateTime outDate = new DateTime(year, month, day, hour, minute, 0);
                            string outStrDate = outDate.ToString("yyyy-MM-dd HH:mm");
                            decimal outNumVal = j.Select(p => p.wind).First();
                            labels.Add(outStrDate);
                            values.Add(outNumVal);
                        }
                    }
                    break;
                }
            }
            temperatureChart.Add(labels); temperatureChart.Add(values);
            return temperatureChart;
        }

        [HttpPost]
        public List<object> GetTpovData1() => IncarnateMeasurement(Measurement.TypeOfMeasure.t_pov, new DateTime(2023, 09, 05), 1);
        [HttpPost]
        public List<object> GetTpovData3() => IncarnateMeasurement(Measurement.TypeOfMeasure.t_pov, new DateTime(2023, 09, 05), 3);
        [HttpPost]
        public List<object> GetFarData1() => IncarnateMeasurement(Measurement.TypeOfMeasure.far, new DateTime(2023, 09, 05), 1);
        [HttpPost]
        public List<object> GetFarData3() => IncarnateMeasurement(Measurement.TypeOfMeasure.far, new DateTime(2023, 09, 05), 3);
        [HttpPost]
        public List<object> GetRhData1() => IncarnateMeasurement(Measurement.TypeOfMeasure.rh, new DateTime(2023, 09, 05), 1);
        [HttpPost]
        public List<object> GetRhData3() => IncarnateMeasurement(Measurement.TypeOfMeasure.rh, new DateTime(2023, 09, 05), 3);
        [HttpPost]
        public List<object> GetTwindData1() => IncarnateMeasurement(Measurement.TypeOfMeasure.t, new DateTime(2023, 09, 05), 1);
        [HttpPost]
        public List<object> GetTwindData3() => IncarnateMeasurement(Measurement.TypeOfMeasure.t, new DateTime(2023, 09, 05), 3);
        [HttpPost]
        public List<object> GetWindData1() => IncarnateMeasurement(Measurement.TypeOfMeasure.wind, new DateTime(2023, 09, 05), 1);
        [HttpPost]
        public List<object> GetWindData3() => IncarnateMeasurement(Measurement.TypeOfMeasure.wind, new DateTime(2023, 09, 05), 3);

        public IQueryable<Measurement> GetMeasurements()
        {
            return measurementRepository.Measurements.Where(p => p.measure_date == new DateTime(2023, 09, 05).ToUniversalTime());
        }
        public ViewResult Index() => View(GetMeasurements());

        [HttpPost]
        public void MouldMeasurementTable(string calendarValue)
        {
            string tmp = calendarValue;
        }
    }
}