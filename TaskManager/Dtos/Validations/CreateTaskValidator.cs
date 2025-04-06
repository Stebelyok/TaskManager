using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Dtos.Validations
{
    public class CreateTaskValidator : AbstractValidator<CreateTodoTaskDto>
    {
        public CreateTaskValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Название обязательно для заполнения")
                .Length(2, 50).WithMessage("Имя должно содержать от 2 до 50 символов")
                .Matches(@"^[a-zA-Zа-яА-ЯёЁ\s\-]+$").WithMessage("Имя может содержать только буквы и дефисы");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Описание не должно превышать 100 символов");
        }
    }
}
