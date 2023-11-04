using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServerMVC.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        public ViewResult Index() =>
            View(new Dictionary<string, object>
            { ["Placeholder"] = "Placeholder" });
    }
}
