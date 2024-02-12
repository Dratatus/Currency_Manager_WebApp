using CurrencyManager.Logic.Models;
using CurrencyManager.Logic.Services.ExchangeRatesProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyManager.Logic.Services.ExchangeRates
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private readonly IExchangeRateProviderService _exchangeRateProviderService;

        private IEnumerable<ExchangeRate> _exchangeRates;

        public ExchangeRatesService(IExchangeRateProviderService exchangeRateProviderService)
        {
            _exchangeRateProviderService = exchangeRateProviderService;
        }

        public async Task InitializeData()
        {
            _exchangeRates = await _exchangeRateProviderService.GetExchangeRatesAsync();
        }

        public decimal GetExchangeRate(string currencyToPurchase, string currencyToSell)
        {
            if (string.IsNullOrEmpty(currencyToPurchase))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(currencyToSell))
            {
                throw new ArgumentException();
            }

            string currencyToPurchaseUpper = currencyToPurchase.ToUpper();
            string currencyToSellUpper = currencyToSell.ToUpper();

            var exchangeRate = _exchangeRates.SingleOrDefault(er => er.CurrencyToPurchase.Code == currencyToPurchaseUpper && er.CurrencyToSell.Code == currencyToSellUpper);

            if (exchangeRate == null)
            {
                throw new ArgumentException();
            }

            return exchangeRate.Rate;
        }

        public decimal GetAmonuntOfExchangingMoney(string currencyToPurchase, string currencyToSell, decimal amountOfmoney)
        {
            decimal exchangeRate =  GetExchangeRate(currencyToPurchase, currencyToSell);

            decimal amonuntOfExchangingMoney = exchangeRate * amountOfmoney;

            return amonuntOfExchangingMoney;
        }

        public bool CurrencyExists(string currencyCode)
        {
            string currencyCodeUpper = currencyCode.ToUpper();

            bool currencyExists = _exchangeRates.Any(er => er.CurrencyToPurchase.Code == currencyCodeUpper);

            return currencyExists;
        }
    }
}