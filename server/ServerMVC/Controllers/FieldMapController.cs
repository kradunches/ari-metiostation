using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using ServerMVC.Controllers;
using ServerMVC.Models;
using ServerMVC.Models.Repository;

namespace ServerMVC.Controllers
{
    public class FieldMapController : Controller
    {
        private readonly IMoistmeterRepository _moistmeterRepository;
        public FieldMapController(IMoistmeterRepository moistRepo)
        {
            _moistmeterRepository = moistRepo;
        }
        public List<object> IncarnateMoistMeasurement(DateTime startDate, int sensorName)
        {
            List<object> temperatureChart = new List<object>();
            List<string> labels = new List<string>();
            List<double> valuesChan1 = new List<double>();
            List<double> valuesChan2 = new List<double>();
            List<double> valuesChan3 = new List<double>();
            List<double> valuesChan4 = new List<double>();
            List<double> valuesChan5 = new List<double>();
            IQueryable<IGrouping<int, agro_moist>> lookup;
            startDate = startDate.ToUniversalTime();
            if (sensorName != 0)
                lookup = _moistmeterRepository.Moistmeters.Where(p => p.reg_date == startDate && p.sensor == sensorName).GroupBy(p => p.reg_date.Hour);
            else
                lookup = _moistmeterRepository.Moistmeters.Where(p => p.reg_date == startDate).GroupBy(p => p.reg_date.Hour);
            var tmp = lookup.ToList();
            foreach (var j in tmp)
            {
                int year = j.Select(p => p.reg_date.Year).First();
                int month = j.Select(p => p.reg_date.Month).First();
                int day = j.Select(p => p.reg_date.Day).First();
                int hour = j.Select(p => p.reg_date.Hour).First();
                DateTime outDate = new DateTime(year, month, day, hour, 0, 0);
                string outStrDate = outDate.ToString("MM-dd HH:mm");
                double chan1val = j.Select(p => p.m1).First();
                double chan2val = j.Select(p => p.m2).First();
                double chan3val = j.Select(p => p.m3).First();
                double chan4val = j.Select(p => p.m4).First();
                double chan5val = j.Select(p => p.m5).First();
                labels.Add(outStrDate);
                valuesChan1.Add(chan1val);
                valuesChan2.Add(chan2val);
                valuesChan3.Add(chan3val);
                valuesChan4.Add(chan4val);
                valuesChan5.Add(chan5val);
            }
            temperatureChart.Add(labels);
            temperatureChart.Add(valuesChan1);
            temperatureChart.Add(valuesChan2);
            temperatureChart.Add(valuesChan3);
            temperatureChart.Add(valuesChan4);
            temperatureChart.Add(valuesChan5);
            return temperatureChart;
        }
        [HttpGet]
        public List<object> GetData(DateTime date, int sensorName)
        {
            return IncarnateMoistMeasurement(date.ToUniversalTime(), sensorName);
        }
        [HttpGet]
        public PartialViewResult _GetMoistmeterTable(DateTime date, int sensorName)
        {
            if (sensorName != null)
                return PartialView(_moistmeterRepository.Moistmeters.Where(p => p.reg_date == date.ToUniversalTime() && p.sensor == sensorName));
            return PartialView(_moistmeterRepository.Moistmeters.Where(p => p.reg_date == date.ToUniversalTime()));
        }
        public ViewResult Index() 
        {
            ViewBag.Title = "Датчики"; 
            return View(); 
        }
        public ActionResult Header() => PartialView("_Header");
        public ActionResult Footer() => PartialView("_Footer");
    }
}
