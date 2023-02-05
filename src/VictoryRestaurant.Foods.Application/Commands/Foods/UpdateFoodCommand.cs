namespace VictoryRestaurant.Foods.Application.Commands.Foods;

public sealed record class UpdateFoodCommand : IRequest<FoodEntity?>
{
    public FoodEntity? Food { get; }

    public UpdateFoodCommand(FoodEntity food) => Food = food;

    public UpdateFoodCommand() { }

    public sealed record class Handler : IRequestHandler<UpdateFoodCommand, FoodEntity?>
    {
        private readonly IFoodEntityRepository _repository;

        public Handler(IFoodEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<FoodEntity?> Handle(
            UpdateFoodCommand request,
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