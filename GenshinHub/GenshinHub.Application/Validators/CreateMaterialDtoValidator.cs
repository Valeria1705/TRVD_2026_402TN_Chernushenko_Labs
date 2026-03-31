using FluentValidation;
using GenshinHub.Application.DTOs;

namespace GenshinHub.Application.Validators;

public class CreateMaterialDtoValidator : AbstractValidator<CreateMaterialDto>
{
    public CreateMaterialDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Category).NotEmpty();
    }
}