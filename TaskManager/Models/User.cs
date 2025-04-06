using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class User
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email обязателен для заполнения")]
        [EmailAddress(ErrorMessage = "Неверный формат email")]
        [StringLength(100, ErrorMessage = "Email не должен превышать 100 символов")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен для заполнения")]
        [MinLength(8, ErrorMessage = "Пароль должен содержать минимум 8 символов")]
        [MaxLength(50, ErrorMessage = "Пароль не должен превышать 50 символов")]
        public string Password { get; set; }
        public List<TodoTask> TodoTasks { get; set; }
    }
}
