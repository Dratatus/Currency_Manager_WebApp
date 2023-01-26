using CurrencyManager.Logic.Models;
using CurrencyManager.Logic.Services.CurrencyProvider;
using CurrencyManager.WebApp.Models;
using CurrencyManager.WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using CurrencyManager.Logic.Services.ExchangeRates;
using System.Diagnostics;

namespace CurrencyManager.WebApp.Controllers
{
    public class ConverterController : Controller
    {
        private readonly ICurrencyProviderService _currencyProviderService;
        private readonly IExchangeRatesService _exchangeRatesService;

        public ConverterController(ICurrencyProviderService currencyProviderService, IExchangeRatesService exchangeRatesService)
        {
            _currencyProviderService = currencyProviderService;
            _exchangeRatesService = exchangeRatesService;
        }
        [HttpGet]
        public async Task<IActionResult> Converter()
        {
            var currencies = await _currencyProviderService.GetCurrenciesAsync();

            var currencyDisplayModel = new CurrencyViewModel();

            currencyDisplayModel.CurrencySelectedList = new List<SelectListItem>();

            foreach (var currency in currencies)
            {
                currencyDisplayModel.CurrencySelectedList.Add(new SelectListItem { Text = currency.Code, Value = currency.Code });
            }
            return View(currencyDisplayModel);
        }

        [HttpPost]
        public async Task<IActionResult> Converter(CurrencyViewModel currencyModel)
        {
            await _exchangeRatesService.InitializeData();
            string selectedCurrencytoPurchase = currencyModel.CurrencyToPurchase.Code;
            string selectedCurrencyToSell = currencyModel.CurrencyToSell.Code;
            decimal selectedAmount = currencyModel.Amount;

            var rate = _exchangeRatesService.GetExchangeRate(selectedCurrencytoPurchase, selectedCurrencyToSell);

            var currencies = await _currencyProviderService.GetCurrenciesAsync();

            var currencyDisplayModel = new CurrencyViewModel();


            currencyDisplayModel.CurrencySelectedList = new List<SelectListItem>();

            foreach (var currency in currencies)
            {
                currencyDisplayModel.CurrencySelectedList.Add(new SelectListItem { Text = currency.Code, Value = currency.Code });
            }

            decimal totalMoney =  _exchangeRatesService.GetAmonuntOfExchangingMoney(selectedCurrencytoPurchase,selectedCurrencyToSell, selectedAmount);

            currencyDisplayModel.Rate = rate;
            currencyDisplayModel.Amount = selectedAmount;
            currencyDisplayModel.TotalAmount = totalMoney;
            currencyDisplayModel.CurrencyToPurchase = currencyModel.CurrencyToPurchase;
            currencyDisplayModel.CurrencyToSell = currencyModel.CurrencyToSell;

            ViewBag.Message = currencyDisplayModel.CurrencyToPurchase.Code;
            ViewBag.Message2 = currencyDisplayModel.CurrencyToSell.Code;

            Debug.WriteLine("Co ci chuju nie pasuje w tym kodzie?");
            return View(currencyDisplayModel);
        }
    }
}
