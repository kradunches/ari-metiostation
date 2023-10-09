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
            var dates = measurementRepository.Measurements.Where(p => p.measure_date == new DateTime(2023, 09, 01).ToUniversalTime());
            List<int> labels = dates.Select(p => p.measure_hour).ToList();
            List<decimal> values = dates.Select(p => p.t).ToList();
            data.Add(labels);
            data.Add(values);
            return data;
        }
        //public ViewResult Index() => View(measurementRepository.Measurements.Where(p => p.measure_date >= new DateTime(2023, 09, 01).ToUniversalTime() &&
        //p.measure_date <= new DateTime(2023, 09, 03).ToUniversalTime()));
        public ViewResult Index()
        {
            dynamic dy = new ExpandoObject();
            dy.measurements = GetMeasurements();
            dy.choices = GetChoices();
            return View(dy);
        }
        public IQueryable<Measurement> GetMeasurements()
        {
            return measurementRepository.Measurements.Where(p => p.measure_date >= new DateTime(2023, 09, 01).ToUniversalTime() && p.measure_date <= new DateTime(2023, 09, 03).ToUniversalTime());
        }
        public Choice GetChoices()
        {
            return choiceRepository.Choice;
        }
        //public ActionResult Charts()
        //{
        //    dynamic dy = new ExpandoObject();
        //    dy.choices = GetChoice();
        //    return PartialView(dy);
        //}
    }
}