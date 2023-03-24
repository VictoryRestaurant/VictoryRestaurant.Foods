namespace VictoryRestaurant.Foods.Infrastructure.Validation.Profiles.Models.Requests.Foods;

public sealed class CreateFoodRequestValidator : AbstractValidator<CreateFoodRequest>
{
    public CreateFoodRequestValidator()
    {
        RuleFor(expression: model => model.Name)
            .NotNull()
            .MinimumLength(minimumLength: 2);
    }
}