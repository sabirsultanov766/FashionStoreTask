using Microsoft.AspNetCore.Mvc;

namespace FashionStoreTask.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
