using CurrencyManager.WebApp.Models.ViewModels;
using System.Threading.Tasks;

namespace CurrencyManager.WebApp.Models.Services.Converter
{
    public interface IConverterService
    {
        Task<CurrencyViewModel> GetCurrenciesModelToDisplay();
        bool IsValueCorrect(decimal value);
    }
}
