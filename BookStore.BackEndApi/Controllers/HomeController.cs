using Microsoft.AspNetCore.Mvc;

namespace BookStore.BackEndApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
