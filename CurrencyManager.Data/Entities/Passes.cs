using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyManager.Data.Entities
{
    public class Passes : EntityBase
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$",
        ErrorMessage = "Proszę wpisać prawidłowy adres email")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", 
        ErrorMessage = "Hasło musi mieć od 8 do 15 znaków i zawierać co najmniej jeden znak specjalny, jedną cyfrę, małą i dużą literę")]
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Hasło musi mieć od 8 do 15 znaków i zawierać co najmniej jeden znak specjalny, jedną cyfrę, małą i dużą literę")]
        [Compare("Password", ErrorMessage ="Hasła muszą być takie same!")]
        public string ConfirmPassword { get; set; }

    }
}