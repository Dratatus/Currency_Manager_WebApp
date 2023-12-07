using CurrencyManager.WebApp.Models.ViewModels;
using System.Threading.Tasks;

namespace CurrencyManager.WebApp.Services.Converter
{
    public interface IConverterService
    {
        Task<CurrencyViewModel> GetCurrenciesModelToDisplay();
        bool IsValueCorrect(decimal value);
    }
}
