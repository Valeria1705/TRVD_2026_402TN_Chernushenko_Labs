using FluentValidation;
using GenshinHub.Application.DTOs;

namespace GenshinHub.Application.Validators;

public class CreateCharacterDtoValidator : AbstractValidator<CreateCharacterDto>
{
	public CreateCharacterDtoValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Ім'я персонажа обов'язкове")
			.MaximumLength(100);

		RuleFor(x => x.Element)
			.NotEmpty()
			.Must(e => new[] { "Pyro", "Hydro", "Anemo", "Electro", "Dendro", "Cryo", "Geo" }.Contains(e))
			.WithMessage("Невірний елемент");

		RuleFor(x => x.Rarity)
			.InclusiveBetween(4, 5)
			.WithMessage("Рідкість має бути 4 або 5");

		RuleFor(x => x.WeaponType)
			.NotEmpty();
	}
}