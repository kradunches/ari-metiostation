using Microsoft.AspNetCore.Mvc;

namespace ServerMVC.Controllers
{
    public class UserController : Controller
    {
        public ViewResult Index() =>
            View(new Dictionary<string, object>
            { ["Placeholder"] = "Placeholder" });
    }
}
