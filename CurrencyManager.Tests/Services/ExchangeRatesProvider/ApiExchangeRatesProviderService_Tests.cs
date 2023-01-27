using CurrencyManager.Logic.Models;
using CurrencyManager.Logic.Services.CurrencyProvider;
using CurrencyManager.Logic.Services.ExchangeRatesProvider;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyManager.Tests.Services.ExchangeRatesProvider
{
    public class ApiExchangeRatesProviderService_Tests
    {
        [Fact]
        public async Task GetExchangeRatesAsync_ShouldReturn_ExpectedEchangeRates()
        {
            var polishCurrency = new Currency { Name = "Polish zloty", Code = "PLN" };
            var euroCurrency = new Currency { Name = "Euro", Code = "EUR" };
            var gbpCurrency = new Currency { Name = "British pound sterling", Code = "GBP" };

            var expectedCurrencies = new List<Currency> { polishCurrency, gbpCurrency, euroCurrency };

            var expectedExchangeRates = new List<ExchangeRate>
            {
                new ExchangeRate
                {
                    CurrencyToPurchase = polishCurrency,
                    CurrencyToSell = euroCurrency,
                    Rate = 4.70M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = polishCurrency,
                    CurrencyToSell = gbpCurrency,
                    Rate = 5.38M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = euroCurrency,
                    CurrencyToSell = polishCurrency,
                    Rate = 0.21M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = euroCurrency,
                    CurrencyToSell = gbpCurrency,
                    Rate = 2.70M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = gbpCurrency,
                    CurrencyToSell = polishCurrency,
                    Rate = 0.19M
                },
                new ExchangeRate
                {
                    CurrencyToPurchase = gbpCurrency,
                    CurrencyToSell = euroCurrency,
                    Rate = 0.87M
                }
            };

            var mockCurrencyProviderService = new Mock<ICurrencyProviderService>();
            mockCurrencyProviderService.Setup(c => c.GetCurrenciesAsync()).ReturnsAsync(expectedCurrencies);

            var _sut = new ApiExchangeRatesProviderService(mockCurrencyProviderService.Object);

            var exchangeRates = await _sut.GetExchangeRatesAsync();

            bool isExchangeRatesCountProper = exchangeRates.Count() == expectedExchangeRates.Count();

            bool exchangeRatesContainProperData = true;

            foreach (var exchangeRate in exchangeRates)
            {
                var expectedExchangeRate = expectedExchangeRates.SingleOrDefault(er => 
                                            er.CurrencyToPurchase.Code == exchangeRate.CurrencyToPurchase.Code &&
                                            er.CurrencyToSell.Code == exchangeRate.CurrencyToSell.Code
                );

                bool noExpectedExchangeRateFound = expectedExchangeRate == null;

                if (noExpectedExchangeRateFound)
                {
                    exchangeRatesContainProperData = false;
                }
            }

            Assert.True(exchangeRatesContainProperData);
        }
    }
}
