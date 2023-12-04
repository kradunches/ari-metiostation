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

        public List<object> IncarnateMeasurement(Measurement.TypeOfMeasure typeOfMeasure, DateTime startDate, int daysAmount)
        {
            List<object> temperatureChart = new List<object>();
            List<string> labels = new List<string>();
            List<decimal> values = new List<decimal>();
            List<double> winddirValues = new List<double>();
            startDate = startDate.ToUniversalTime();
            //for (int i = 0; i < daysAmount; i++)
            for  (int i = daysAmount - 1; i >= 0; i--)
            {
                IQueryable<IGrouping<int, Measurement>> lookup = _measurementRepository.Measurements.Where(p => p.measure_date == startDate.AddDays(-i).ToUniversalTime()).GroupBy(p => p.measure_hour);
                var tmp = lookup.ToList();
                foreach (var j in tmp)
                {
                    int year = j.Select(p => p.measure_date.Year).First();
                    int month = j.Select(p => p.measure_date.Month).First();
                    int day = j.Select(p => p.measure_date.Day).First();
                    int hour = j.Select(p => p.measure_hour).First();
                    int minute = j.Select(p => p.measure_min).First();
                    DateTime outDate = new DateTime(year, month, day, hour, minute, 0);
                    string outStrDate = outDate.ToString("MM-dd HH:mm");
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
                            decimal winddir = j.Select(p => p.winddir).First();
                            winddirValues.Add(Math.Abs(Math.Round(Math.Sin((double)winddir / 1200 * 360 / 180 * Math.PI) * 400, 2)));
                            outNumVal = j.Select(p => p.wind).First();
                            break;
                    }
                    labels.Add(outStrDate);
                    values.Add(outNumVal);
                }
            }
            temperatureChart.Add(labels); temperatureChart.Add(values);
            if (typeOfMeasure == Measurement.TypeOfMeasure.wind)
                temperatureChart.Add(winddirValues);
            return temperatureChart;
        }

        [HttpGet]
        public List<object> GetTpovData1(DateTime date) => IncarnateMeasurement(Measurement.TypeOfMeasure.t_pov, date, 1);
        [HttpGet]
        public List<object> GetTpovData3(DateTime date) => IncarnateMeasurement(Measurement.TypeOfMeasure.t_pov, date, 3);
        [HttpGet]
        public List<object> GetFarData1(DateTime date) => IncarnateMeasurement(Measurement.TypeOfMeasure.far, date, 1);
        [HttpGet]
        public List<object> GetFarData3(DateTime date) => IncarnateMeasurement(Measurement.TypeOfMeasure.far, date, 3);
        [HttpGet]
        public List<object> GetRhData1(DateTime date) => IncarnateMeasurement(Measurement.TypeOfMeasure.rh, date, 1);
        [HttpGet]
        public List<object> GetRhData3(DateTime date) => IncarnateMeasurement(Measurement.TypeOfMeasure.rh, date, 3);
        [HttpGet]
        public List<object> GetTwindData1(DateTime date) => IncarnateMeasurement(Measurement.TypeOfMeasure.t, date, 1);
        [HttpGet]
        public List<object> GetTwindData3(DateTime date) => IncarnateMeasurement(Measurement.TypeOfMeasure.t, date, 3);
        [HttpGet]
        public List<object> GetWindData1(DateTime date) => IncarnateMeasurement(Measurement.TypeOfMeasure.wind, date, 1);
        [HttpGet]
        public List<object> GetWindData3(DateTime date) => IncarnateMeasurement(Measurement.TypeOfMeasure.wind, date, 3);

        //public IQueryable<Measurement> GetMeasurements()
        //{
        //    return measurementRepository.Measurements.Where(p => p.measure_date == new DateTime(2023, 09, 05).ToUniversalTime());
        //}
        [HttpGet]
        public PartialViewResult _GetTable(DateTime date)
        {
            var tmp = _measurementRepository.Measurements.Where(p => p.measure_date == date.ToUniversalTime());
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