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
        public List<object> IncarnateMoistMeasurement(DateTime startDate)
        {
            List<object> temperatureChart = new List<object>();
            List<string> labels = new List<string>();
            List<decimal> valuesChan1 = new List<decimal>();
            List<decimal> valuesChan2 = new List<decimal>();
            List<decimal> valuesChan3 = new List<decimal>();
            List<decimal> valuesChan4 = new List<decimal>();
            List<decimal> valuesChan5 = new List<decimal>();
            startDate = startDate.ToUniversalTime();
            IQueryable<IGrouping<int, Moistmeter>> lookup = _moistmeterRepository.Moistmeters.Where(p => p.measure_date == startDate).GroupBy(p => p.measure_hour);
            var tmp = lookup.ToList();
            foreach (var j in tmp)
            {
                int year = j.Select(p => p.measure_date.Year).First();
                int month = j.Select(p => p.measure_date.Month).First();
                int day = j.Select(p => p.measure_date.Day).First();
                int hour = j.Select(p => p.measure_hour).First();
                DateTime outDate = new DateTime(year, month, day, hour, 0, 0);
                string outStrDate = outDate.ToString("MM-dd HH:mm");
                int chan1val = j.Select(p => p.channel1).First();
                int chan2val = j.Select(p => p.channel2).First();
                int chan3val = j.Select(p => p.channel3).First();
                int chan4val = j.Select(p => p.channel4).First();
                int chan5val = j.Select(p => p.channel5).First();
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
        public List<object> GetData(DateTime date, string sensorName)
        {

            return IncarnateMoistMeasurement(date.ToUniversalTime());
        }
        [HttpGet]
        public PartialViewResult _GetMoistmeterTable(DateTime date, string sensorName)
        {
            if (sensorName != null)
                return PartialView(_moistmeterRepository.Moistmeters.Where(p => p.measure_date == date.ToUniversalTime() && p.name == sensorName));
            return PartialView(_moistmeterRepository.Moistmeters.Where(p => p.measure_date == date.ToUniversalTime()));
        }
        public ViewResult Index() => View();
    }
}
