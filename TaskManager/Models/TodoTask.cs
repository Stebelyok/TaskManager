using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class TodoTask
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Название обязательно для заполнения")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 50 символов")]
        public string Title { get; set; }


        [StringLength(200, ErrorMessage = "Описание не должен превышать 200 символов")]
        public string? Description { get; set; }

        public User user { get; set; }

        public long UserId { get; set; }
    }
}
