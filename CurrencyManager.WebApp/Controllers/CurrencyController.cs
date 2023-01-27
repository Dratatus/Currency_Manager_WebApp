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

        // Metoda return View zwraca plik cshtml
        // Wybiera go na podstawie konwencji nazewnictwa, więcej info w komentarzu w klasie Program przy metodzie AddControllersWithViews
        public async Task<IActionResult> Index()
        {
            var currencies = await _currencyProviderService.GetCurrenciesAsync(); 

            return View(currencies);
        }
    }
}