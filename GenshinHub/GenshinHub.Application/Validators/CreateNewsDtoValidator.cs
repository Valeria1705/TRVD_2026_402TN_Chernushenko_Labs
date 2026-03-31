using FluentValidation;
using GenshinHub.Application.DTOs;

namespace GenshinHub.Application.Validators;

public class CreateNewsDtoValidator : AbstractValidator<CreateNewsDto>
{
    public CreateNewsDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Content).NotEmpty();
    }
}