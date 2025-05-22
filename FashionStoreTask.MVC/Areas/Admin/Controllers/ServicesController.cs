using Microsoft.AspNetCore.Mvc;

namespace FashionStoreTask.MVC.Areas.Admin.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
