namespace VictoryRestaurant.Foods.Application.Commands.FoodTypes;

public sealed record class UpdateFoodTypeCommand : IRequest<FoodTypeEntity?>
{
    public FoodTypeEntity? FoodType { get; }

    public UpdateFoodTypeCommand(FoodTypeEntity foodType) => FoodType = foodType;

    public UpdateFoodTypeCommand() { }

    public sealed record class Handler : IRequestHandler<UpdateFoodTypeCommand, FoodTypeEntity?>
    {
        private readonly IFoodTypeEntityRepository _repository;

        public Handler(IFoodTypeEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<FoodTypeEntity?> Handle(
            UpdateFoodTypeCommand request,
            CancellationToken cancellationToken)
        {
            if (request.FoodType is null)
            {
                return default;
            }

            var newFood = await _repository.UpdateAsync(entity: request.FoodType, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            return newFood;
        }
    }
}