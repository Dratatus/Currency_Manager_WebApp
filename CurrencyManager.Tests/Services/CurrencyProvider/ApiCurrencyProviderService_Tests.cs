using CurrencyManager.Logic.Services.CurrencyProvider;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyManager.Tests.Services.CurrencyProvider
{
    public class ApiCurrencyProviderService_Tests
    {
        private readonly ApiCurrencyProviderService _sut = new ApiCurrencyProviderService();

        [Fact]
        public async Task GetCurrenciesAsync_ShouldReturn_AnyProperCurrencies()
        {
            var currencies = await _sut.GetCurrenciesAsync();

            bool anyCurrenciesWereReturned = currencies.Any();

            bool haveCurrenciesProperData = currencies.All(c => !string.IsNullOrEmpty(c.Name) && !string.IsNullOrEmpty(c.Code));

            bool areCurrenciesProper = anyCurrenciesWereReturned && haveCurrenciesProperData;

            Assert.True(areCurrenciesProper);
        }
    }
}
