using Microsoft.AspNetCore.Mvc;
using ServerMVC.Models;

namespace ServerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMeasurementRepository measurementRepository;
        public HomeController (IMeasurementRepository measRepo)
        {
            this.measurementRepository = measRepo;
        }
        public ViewResult Index() => View(measurementRepository.Measurements);
    }
}