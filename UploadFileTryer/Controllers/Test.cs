using Microsoft.AspNetCore.Mvc;

namespace UploadFileTryer.Controllers
{
    public class Test : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Redirect()
        {
            return RedirectToAction("Index","Generator");
        }
    }
}
