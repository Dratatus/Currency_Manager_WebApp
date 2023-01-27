using CurrencyManager.Logic.Models;
using CurrencyManager.Logic.Services.CurrencyProvider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyManager.Tests.Services.CurrencyProvider
{
    public class HardcodedCurrencyProviderService_Tests
    {
        private readonly HardcodedCurrencyProviderService _sut = new HardcodedCurrencyProviderService();

        private readonly List<Currency> _expectedCurrencies = new List<Currency>
        {
            new Currency { Name = "złoty", Code = "PLN" },
            new Currency { Name = "dolar", Code = "USD" },
            new Currency { Name = "Brytyjski funt szterling", Code = "GBP" },
            new Currency { Name = "euro", Code = "EUR" }
        };

        [Fact]
        public async Task GetCurrenciesAsync_ShouldReturn_ExpectedCurrencies()
        {
            var currencies = await _sut.GetCurrenciesAsync();

            bool areCurrenciesExpected = true;

            for (int i = 0; i < _expectedCurrencies.Count; i++)
            {
                var testingCurrency = currencies[i];
                var expectedCurrency = _expectedCurrencies[i];

                if (testingCurrency.Name != expectedCurrency.Name || testingCurrency.Code != expectedCurrency.Code)
                {
                    areCurrenciesExpected = false;
                }
            }

            Assert.True(areCurrenciesExpected);
        }
    }
}
