using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerMVC.Models;
using System.Linq;
//using System.Web.Mvc;

namespace ServerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMeasurementRepository measurementRepository;
        public HomeController (IMeasurementRepository measRepo)
        {
            this.measurementRepository = measRepo;
        }

        [HttpPost]
        public JsonResult GetChartData()
        {
            try
            {
                decimal[] SeriesVal = {  };
                DateTime[] LabelsVal = { };
                return Json(new { success = true, series = SeriesVal, labels = LabelsVal, message = "succes" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Something went Wrong.! unsuccessfull!" });
            }
        }
        public ViewResult Index() => View(measurementRepository.Measurements.Where(p => p.measure_date >= new DateTime(2023, 09, 01).ToUniversalTime() &&
        p.measure_date <= new DateTime(2023, 09, 03).ToUniversalTime()));
        public ActionResult Charts()
        {
            ViewBag.Message = "Partial view";
            return PartialView();
        }
        //public ViewResult Index() => View(measurementRepository.Measurements);
    }
}