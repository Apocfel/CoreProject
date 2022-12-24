using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreProject.Data.Models
{
    public class User
    {
        private const string LENGTH_ERROR = "Длина должна быть от 5 до 15 символов";
        [BindNever]
        public int Id { get; set; }

        [DisplayName("Логин")]
        [Required(ErrorMessage = "Введите логин")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = LENGTH_ERROR)]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [DisplayName("Почта")]
        [Required(ErrorMessage = "Введите почту")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 5, ErrorMessage = LENGTH_ERROR)]
        [Required(ErrorMessage = "Введите пароль")]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 5, ErrorMessage = LENGTH_ERROR)]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [DisplayName("Подтверждение пароля")]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Отображаемое на сайте имя")]
        [Required(ErrorMessage = "Введите отображаемое имя")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = LENGTH_ERROR)]
        public string DisplayName { get; set; }

        [ScaffoldColumn(false)]
        [BindNever]
        public string Role { get; set; }
    }
}
