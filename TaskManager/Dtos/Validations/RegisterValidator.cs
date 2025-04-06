using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Dtos.Validations
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Имя обязательно для заполнения")
                .Length(2, 50).WithMessage("Имя должно содержать от 2 до 50 символов")
                .Matches(@"^[a-zA-Zа-яА-ЯёЁ\s\-]+$").WithMessage("Имя может содержать только буквы и дефисы");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email обязателен для заполнения")
                .EmailAddress().WithMessage("Неверный формат email")
                .MaximumLength(100).WithMessage("Email не должен превышать 100 символов");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен для заполнения")
                .MinimumLength(8).WithMessage("Пароль должен содержать минимум 8 символов")
                .MaximumLength(50).WithMessage("Пароль не должен превышать 50 символов")
                .Matches("[A-Z]").WithMessage("Пароль должен содержать хотя бы одну заглавную букву")
                .Matches("[a-z]").WithMessage("Пароль должен содержать хотя бы одну строчную букву")
                .Matches("[0-9]").WithMessage("Пароль должен содержать хотя бы одну цифру")
                .Matches("[^a-zA-Z0-9]").WithMessage("Пароль должен содержать хотя бы один спецсимвол");
        }
    }
}
