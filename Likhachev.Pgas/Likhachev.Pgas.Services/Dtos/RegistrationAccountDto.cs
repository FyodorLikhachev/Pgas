using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Likhachev.Pgas.Services.Dtos
{
    public class RegistrationAccountDto
    {
        [Required(ErrorMessage = "Не указан логин")]
        [MaxLength(30, ErrorMessage = "Логин не должен быть длиннее 50 символов")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        public AccountModelTypes AccountType { get; set; } = AccountModelTypes.Student;

        [Display(Name = "Учебная группа")]
        public string StudyGroup { get; set; }

        [Display(Name = "Факультет")]
        public int Faculty { get; set; }
        public string FacultyName { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [MaxLength(50, ErrorMessage = "Имя не должно быть длиннее 50 символов")]
        [Display(Name = "Имя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [MaxLength(50, ErrorMessage = "Фамилия не должно быть длиннее 50 символов")]
        [Display(Name = "Фамилия")]
        public string UserSecondName { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        [MaxLength(50, ErrorMessage = "Отчество не должно быть длиннее 50 символов")]
        [Display(Name = "Отчество")]
        public string UserMiddleName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }

    public enum AccountModelTypes
    {
        [Display(Name = "Студент")]
        Student = 1,
        [Display(Name = "Эксперт")]
        Expert
    }
}
