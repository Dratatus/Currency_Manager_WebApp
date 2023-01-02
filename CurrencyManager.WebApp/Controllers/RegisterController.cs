using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurrencyManager.WebApp.Controllers
{
    public class RegisterController : Controller
    {
        public async Task<IActionResult> Register()
        {
            await Task.FromResult(1);
            return View();
        }
    }
}
