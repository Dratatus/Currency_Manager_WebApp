using Microsoft.AspNetCore.Mvc;

namespace CurrencyManager.WebApp.Controllers
{
    public class ConverterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
