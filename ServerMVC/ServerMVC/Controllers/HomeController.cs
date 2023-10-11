using Microsoft.AspNetCore.Mvc;
using ServerMVC.Models;
using System.Dynamic;
using System.Linq;

namespace ServerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMeasurementRepository measurementRepository;
        private readonly IChoiceRepository choiceRepository;
        public HomeController(IMeasurementRepository measRepo, IChoiceRepository choiceRepository)
        {
            this.measurementRepository = measRepo;
            this.choiceRepository = choiceRepository;
        }

        [HttpPost]
        public List<object> GetTwindData()
        {
            List<object> data = new List<object>();
            ILookup<int, Measurement> lookupFirstDay = measurementRepository.Measurements.Where(p => p.measure_date == new DateTime(2023, 09, 05).ToUniversalTime()).ToLookup(p => p.measure_hour);
            ILookup<int, Measurement> lookupSecondDay = measurementRepository.Measurements.Where(p => p.measure_date == new DateTime(2023, 09, 06).ToUniversalTime()).ToLookup(p => p.measure_hour);
            ILookup<int, Measurement> lookupThirdDay = measurementRepository.Measurements.Where(p => p.measure_date == new DateTime(2023, 09, 07).ToUniversalTime()).ToLookup(p => p.measure_hour);

            List<string> labelsOneDay = new List<string>();
            List<decimal> valuesOneDay = new List<decimal>();
            List<string> labelsThreeDays = new List<string>();
            List<decimal> valuesThreeDays = new List<decimal>();
            foreach (var i in lookupFirstDay)
            {
                int year = i.Select(p => p.measure_date.Year).First();
                int month = i.Select(p => p.measure_date.Month).First();
                int day = i.Select(p => p.measure_date.Day).First();
                int hour = i.Select(p => p.measure_hour).First();
                int minute = i.Select(p => p.measure_min).First();
                DateTime outDate = new DateTime(year, month, day, hour, minute, 0);
                string outStrDate = outDate.ToString("yyyy-MM-dd:mm");
                decimal outNumVal = i.Select(p => p.t).First();
                labelsOneDay.Add(outStrDate);
                valuesOneDay.Add(outNumVal);
                labelsThreeDays.Add(outStrDate);
                valuesThreeDays.Add(outNumVal);
            }
            foreach (var i in lookupSecondDay)
            {
                int year = i.Select(p => p.measure_date.Year).First();
                int month = i.Select(p => p.measure_date.Month).First();
                int day = i.Select(p => p.measure_date.Day).First();
                int hour = i.Select(p => p.measure_hour).First();
                int minute = i.Select(p => p.measure_min).First();
                DateTime outDate = new DateTime(year, month, day, hour, minute, 0);
                string outStrDate = outDate.ToString("yyyy-MM-dd:mm");
                decimal outNumVal = i.Select(p => p.t).First();
                labelsThreeDays.Add(outStrDate);
                valuesThreeDays.Add(outNumVal);
            }
            foreach (var i in lookupThirdDay)
            {
                int year = i.Select(p => p.measure_date.Year).First();
                int month = i.Select(p => p.measure_date.Month).First();
                int day = i.Select(p => p.measure_date.Day).First();
                int hour = i.Select(p => p.measure_hour).First();
                int minute = i.Select(p => p.measure_min).First();
                DateTime outDate = new DateTime(year, month, day, hour, minute, 0);
                string outStrDate = outDate.ToString("yyyy-MM-dd:mm");
                decimal outNumVal = i.Select(p => p.t).First();
                labelsThreeDays.Add(outStrDate);
                valuesThreeDays.Add(outNumVal);
            }
            data.Add(labelsOneDay); data.Add(valuesOneDay);
            data.Add(labelsThreeDays); data.Add(valuesThreeDays);
            return data;
        }
        public ViewResult Index()
        {
            dynamic dy = new ExpandoObject();
            dy.measurements = GetMeasurements();
            dy.choices = GetChoices();
            return View(dy);
        }
        public IQueryable<Measurement> GetMeasurements()
        {
            return measurementRepository.Measurements.Where(p => p.measure_date == new DateTime(2023, 09, 05).ToUniversalTime());
        }
        public Choice GetChoices()
        {
            return choiceRepository.Choice;
        }
    }
}