using System;

namespace CurrencyManager.WebApp.Models.Services.Converter
{
    public class ConverterService: IConverterService
    {
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
    }
}
