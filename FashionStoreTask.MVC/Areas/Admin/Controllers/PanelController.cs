using Microsoft.AspNetCore.Mvc;

namespace FashionStoreTask.MVC.Areas.Admin.Controllers
{
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tables()
        {
            return View();
        }
    }
}
