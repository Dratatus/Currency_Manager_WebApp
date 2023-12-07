using CurrencyManager.Logic.Services.CurrencyProvider;
using CurrencyManager.WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyManager.WebApp.Services.Converter
{
    public class ConverterService : IConverterService
    {
        private readonly ICurrencyProviderService _currencyProviderService;

        public ConverterService(ICurrencyProviderService currencyProviderService)
        {
            _currencyProviderService = currencyProviderService;
        }

        public bool IsValueCorrect(decimal value)
        {
            if (value <= 0)
            {
                throw new Exception("Podaj poprawną ilość!");
            }

            else
            {
                return true;
            }
        }

        public async Task<CurrencyViewModel> GetCurrenciesModelToDisplay()
        {
            var currencies = await _currencyProviderService.GetCurrenciesAsync();

            var currencyDisplayModel = new CurrencyViewModel();

            currencyDisplayModel.CurrencySelectedList = new List<SelectListItem>();

            foreach (var currency in currencies)
            {
                currencyDisplayModel.CurrencySelectedList.Add(new SelectListItem { Text = currency.Code, Value = currency.Code });
            }

            return currencyDisplayModel;
        }
    }
}
