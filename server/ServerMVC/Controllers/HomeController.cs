using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerMVC.Models;
using ServerMVC.Models.Repository;
using System.Linq;

namespace ServerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMeasurementRepository _measurementRepository;
        public HomeController(IMeasurementRepository measRepo)
        {
            this._measurementRepository = measRepo;
        }

        public List<object> IncarnateMeasurement(meteo1.TypeOfMeasure typeOfMeasure, DateTime startDate, int daysAmount)
        {
            List<object> temperatureChart = new List<object>();
            List<string> labels = new List<string>();
            List<double> values = new List<double>();
            List<double> winddirValues = new List<double>();
            startDate = startDate.ToUniversalTime();
            for  (int i = daysAmount - 1; i >= 0; i--)
            {
                //IQueryable<IGrouping<int, meteo1>> lookup = _measurementRepository.Measurements.Where(p => p.reg_date == startDate.AddDays(-i).ToUniversalTime()).GroupBy(p => p.reg_date.Hour);
                IQueryable<IGrouping<int, meteo1>> lookup = _measurementRepository.Measurements.Where(p => p.reg_date.Year == startDate.AddDays(-i).ToUniversalTime().Year && p.reg_date.Month == startDate.AddDays(-i).ToUniversalTime().Month && p.reg_date.Day - 1 == startDate.AddDays(-i).ToUniversalTime().Day).GroupBy(p => p.reg_date.Hour);
                var tmp = lookup.ToList();
                foreach (var j in tmp)
                {
                    int year = j.Select(p => p.reg_date.Year).First();
                    int month = j.Select(p => p.reg_date.Month).First();
                    int day = j.Select(p => p.reg_date.Day).First();
                    int hour = j.Select(p => p.reg_date.Hour).First();
                    int minute = j.Select(p => p.reg_date.Minute).First();
                    DateTime outDate = new DateTime(year, month, day, hour, minute, 0);
                    string outStrDate = outDate.ToString("MM-dd HH:mm");
                    double outNumVal = 0;
                    switch (typeOfMeasure)
                    {
                        case meteo1.TypeOfMeasure.optical_rainfall:
                            outNumVal = j.Select(p => p.optical_rainfall).First();
                            break;
                        case meteo1.TypeOfMeasure.light:
                            outNumVal = j.Select(p => p.light).First();
                            break;
                        case meteo1.TypeOfMeasure.humidity:
                            outNumVal = j.Select(p => p.humidity).First();
                            break;
                        case meteo1.TypeOfMeasure.temperature:
                            outNumVal = j.Select(p => p.temperature).First();
                            break;
                        case meteo1.TypeOfMeasure.wind_speed:
                            double winddir = j.Select(p => p.wind_direction360).First();
                            //winddirValues.Add(Math.Abs(Math.Round(Math.Sin((double)winddir / 1200 * 360 / 180 * Math.PI) * 400, 2)));
                            //winddirValues.Add(Math.Round((double)winddir / 1024 * 360, 2));
                            winddirValues.Add((double)winddir);
                            outNumVal = j.Select(p => p.wind_speed).First();
                            break;
                    }
                    labels.Add(outStrDate);
                    values.Add(outNumVal);
                }
            }
            temperatureChart.Add(labels); temperatureChart.Add(values);
            if (typeOfMeasure == meteo1.TypeOfMeasure.wind_speed)
                temperatureChart.Add(winddirValues);
            return temperatureChart;
        }

        [HttpGet]
        public List<object> GetTpovData1(DateTime date) => IncarnateMeasurement(meteo1.TypeOfMeasure.optical_rainfall, date, 1);
        [HttpGet]
        public List<object> GetTpovData3(DateTime date) => IncarnateMeasurement(meteo1.TypeOfMeasure.optical_rainfall, date, 3);
        [HttpGet]
        public List<object> GetFarData1(DateTime date) => IncarnateMeasurement(meteo1.TypeOfMeasure.light, date, 1);
        [HttpGet]
        public List<object> GetFarData3(DateTime date) => IncarnateMeasurement(meteo1.TypeOfMeasure.light, date, 3);
        [HttpGet]
        public List<object> GetRhData1(DateTime date) => IncarnateMeasurement(meteo1.TypeOfMeasure.humidity, date, 1);
        [HttpGet]
        public List<object> GetRhData3(DateTime date) => IncarnateMeasurement(meteo1.TypeOfMeasure.humidity, date, 3);
        [HttpGet]
        public List<object> GetTwindData1(DateTime date) => IncarnateMeasurement(meteo1.TypeOfMeasure.temperature, date, 1);
        [HttpGet]
        public List<object> GetTwindData3(DateTime date) => IncarnateMeasurement(meteo1.TypeOfMeasure.temperature, date, 3);
        [HttpGet]
        public List<object> GetWindData1(DateTime date) => IncarnateMeasurement(meteo1.TypeOfMeasure.wind_speed, date, 1);
        [HttpGet]
        public List<object> GetWindData3(DateTime date) => IncarnateMeasurement(meteo1.TypeOfMeasure.wind_speed, date, 3);

        //public IQueryable<Measurement> GetMeasurements()
        //{
        //    return measurementRepository.Measurements.Where(p => p.measure_date == new DateTime(2023, 09, 05).ToUniversalTime());
        //}
        [HttpGet]
        public PartialViewResult _GetTable(DateTime date)
        {
            var tmp = _measurementRepository.Measurements.Where(p => p.reg_date.Year == date.ToUniversalTime().Year && p.reg_date.Month == date.ToUniversalTime().Month && p.reg_date.Day - 1 == date.ToUniversalTime().Day);
            return PartialView(tmp);
        }
        public ViewResult Index() 
        {
            ViewBag.Title = "Метеостанция Меньково";
            return View(); 
        }
        public ActionResult Header() => PartialView("_Header");
        public ActionResult Footer() => PartialView("_Footer");
    }
}