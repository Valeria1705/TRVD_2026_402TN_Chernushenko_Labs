using FluentValidation;
using GenshinHub.Application.DTOs;

namespace GenshinHub.Application.Validators;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email обов'язковий")
            .EmailAddress().WithMessage("Невірний формат email");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Пароль обов'язковий")
            .MinimumLength(6).WithMessage("Пароль має містити мінімум 6 символів");
    }
}