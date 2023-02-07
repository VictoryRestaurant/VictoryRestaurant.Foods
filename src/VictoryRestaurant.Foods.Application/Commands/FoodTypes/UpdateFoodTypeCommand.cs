namespace VictoryRestaurant.Foods.Application.Commands.FoodTypes;

public sealed record class UpdateFoodTypeCommand : IRequest<FoodEntity?>
{
    public FoodEntity? Food { get; }

    public UpdateFoodTypeCommand(FoodEntity food) => Food = food;

    public UpdateFoodTypeCommand() { }

    public sealed record class Handler : IRequestHandler<UpdateFoodTypeCommand, FoodEntity?>
    {
        private readonly IFoodEntityRepository _repository;

        public Handler(IFoodEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<FoodEntity?> Handle(
            UpdateFoodTypeCommand request,
            CancellationToken cancellationToken)
        {
            if (request.Food is null)
            {
                return default;
            }

            var newFood = await _repository.UpdateAsync(entity: request.Food, cancellationToken);

            return newFood;
        }
    }
}