﻿using Microsoft.AspNetCore.Mvc;
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
            startDate = startDate.ToUniversalTime();
            for (int i = 0; i < daysAmount; i++)
            {
                var lookup = measurementRepository.Measurements.Where(p => p.measure_date == startDate.AddDays(i).ToUniversalTime()).GroupBy(p => p.measure_hour);
                uint cntr = 0; //берем первые три измерения за каждый день
                foreach (var j in lookup)
                {
                    int year = j.Select(p => p.measure_date.Year).First();
                    int month = j.Select(p => p.measure_date.Month).First();
                    int day = j.Select(p => p.measure_date.Day).First();
                    int hour = j.Select(p => p.measure_hour).First();
                    int minute = j.Select(p => p.measure_min).First();
                    DateTime outDate = new DateTime(year, month, day, hour, minute, 0);
                    string outStrDate = outDate.ToString("yyyy-MM-dd HH:mm");
                    decimal outNumVal = 0;
                    switch (typeOfMeasure)
                    {
                        case Measurement.TypeOfMeasure.t_pov:
                            outNumVal = j.Select(p => p.t_pov).First();
                            break;
                        case Measurement.TypeOfMeasure.far:
                            outNumVal = j.Select(p => p.far).First();
                            break;
                        case Measurement.TypeOfMeasure.rh:
                            outNumVal = j.Select(p => p.rh).First();
                            break;
                        case Measurement.TypeOfMeasure.t:
                            outNumVal = j.Select(p => p.t).First();
                            break;
                        case Measurement.TypeOfMeasure.wind:
                            outNumVal = j.Select(p => p.wind).First();
                            break;
                    }
                    labels.Add(outStrDate);
                    values.Add(outNumVal);
                    cntr++;        //
                    if (cntr == 6) //берем первые три измерения за каждый день
                        break;     //
                }
            }
            temperatureChart.Add(labels); temperatureChart.Add(values);
            return temperatureChart;
        }

        [HttpGet]
        public List<object> GetTpovData1() => IncarnateMeasurement(Measurement.TypeOfMeasure.t_pov, new DateTime(2023, 09, 05), 1);
        [HttpGet]
        public List<object> GetTpovData3() => IncarnateMeasurement(Measurement.TypeOfMeasure.t_pov, new DateTime(2023, 09, 05), 3);
        [HttpGet]
        public List<object> GetFarData1() => IncarnateMeasurement(Measurement.TypeOfMeasure.far, new DateTime(2023, 09, 05), 1);
        [HttpGet]
        public List<object> GetFarData3() => IncarnateMeasurement(Measurement.TypeOfMeasure.far, new DateTime(2023, 09, 05), 3);
        [HttpGet]
        public List<object> GetRhData1() => IncarnateMeasurement(Measurement.TypeOfMeasure.rh, new DateTime(2023, 09, 05), 1);
        [HttpGet]
        public List<object> GetRhData3() => IncarnateMeasurement(Measurement.TypeOfMeasure.rh, new DateTime(2023, 09, 05), 3);
        [HttpGet]
        public List<object> GetTwindData1() => IncarnateMeasurement(Measurement.TypeOfMeasure.t, new DateTime(2023, 09, 05), 1);
        [HttpGet]
        public List<object> GetTwindData3() => IncarnateMeasurement(Measurement.TypeOfMeasure.t, new DateTime(2023, 09, 05), 3);
        [HttpGet]
        public List<object> GetWindData1() => IncarnateMeasurement(Measurement.TypeOfMeasure.wind, new DateTime(2023, 09, 05), 1);
        [HttpGet]
        public List<object> GetWindData3() => IncarnateMeasurement(Measurement.TypeOfMeasure.wind, new DateTime(2023, 09, 05), 3);

        //public void GetCalendarDate(DateTime date)
        //{
        //    var tmp = date;
        //}
        public IQueryable<Measurement> GetMeasurements()
        {
            return measurementRepository.Measurements.Where(p => p.measure_date == new DateTime(2023, 09, 05).ToUniversalTime());
        }
        public ViewResult Index() => View(GetMeasurements());
    }
}