using CurrencyManager.Logic.Models;
using CurrencyManager.Logic.Services.ExchangeRates;
using CurrencyManager.Logic.Services.ExchangeRatesProvider;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CurrencyManager.Tests.Services.ExchangeRateService
{
    public class ExchangeRatesService_Tests
    {
        [Fact]
        public async Task GetExchangeRate_ShouldReturn_ProperExchangeRate()
        {
            var polishCurrency = new Currency { Name = "Polish zloty", Code = "PLN" };
            var euroCurrency = new Currency { Name = "Euro", Code = "EUR" };

            var expectedExchangeRate = new ExchangeRate
            {
                CurrencyToPurchase = polishCurrency,
                CurrencyToSell = euroCurrency,
                Rate = 4.70M
            };

            var expectedExchangeRates = new List<ExchangeRate>
            {
                expectedExchangeRate
            };

            var mockExchangeRateProviderService = new Mock<IExchangeRateProviderService>();
            mockExchangeRateProviderService.Setup(x => x.GetExchangeRatesAsync()).ReturnsAsync(expectedExchangeRates);

            var sut = new ExchangeRatesService(mockExchangeRateProviderService.Object);

            await sut.InitializeData();

            decimal checkingExchangeRate = sut.GetExchangeRate(polishCurrency.Code, euroCurrency.Code);

            Assert.Equal(expectedExchangeRate.Rate, checkingExchangeRate);

        }
        // 2 test do tej samej metody - upewnienie że rzuca błąd kiedy nie znajdzie waluty o którą prosisz
    }
}
