using FluentValidation;
using GenshinHub.Application.DTOs;

namespace GenshinHub.Application.Validators;

public class CreateWeaponDtoValidator : AbstractValidator<CreateWeaponDto>
{
    public CreateWeaponDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.Rarity).InclusiveBetween(3, 5);
    }
}