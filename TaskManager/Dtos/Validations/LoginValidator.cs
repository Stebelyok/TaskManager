using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Dtos.Validations
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email обязателен для заполнения")
                .EmailAddress().WithMessage("Неверный формат email")
                .MaximumLength(100).WithMessage("Email не должен превышать 100 символов");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен для заполнения");
        }
    }
}
