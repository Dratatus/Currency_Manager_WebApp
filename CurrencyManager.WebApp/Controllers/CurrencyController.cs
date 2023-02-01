using CurrencyManager.Logic.Services.CurrencyProvider;
using CurrencyManager.WebApp.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurrencyManager.WebApp.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICurrencyProviderService _currencyProviderService;

        public CurrencyController(ICurrencyProviderService currencyProviderService)
        {
            _currencyProviderService = currencyProviderService;
        }

        public async Task<IActionResult> Index()
        {
            var currencies = await _currencyProviderService.GetCurrenciesAsync(); 

            return View(currencies);
        }
    }
}