using CurrencyManager.Logic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CurrencyManager.WebApp.Models.ViewModels
{
    public class CurrencyViewModel
    {
        // Display 
        public List<SelectListItem> CurrencySelectedList { get; set; }

        public Currency CurrencyToPurchase { get; set; }

        public Currency CurrencyToSell { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Podaj poprawną ilość!")]
        public decimal Amount { get; set; }

        public decimal Rate { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
