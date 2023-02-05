namespace VictoryRestaurant.Foods.Application.Commands.Foods;

public sealed record class CreateFoodCommand : IRequest<FoodEntity?>
{
    public FoodEntity? Food { get; }

    public CreateFoodCommand(FoodEntity food) => Food = food;

    public CreateFoodCommand() { }

    public sealed record class Handler : IRequestHandler<CreateFoodCommand, FoodEntity?>
    {
        private readonly IFoodEntityRepository _repository;

        public Handler(IFoodEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<FoodEntity?> Handle(
            CreateFoodCommand request,
            CancellationToken cancellationToken)
        {
            if (request.Food is null)
            {
                return default;
            }

            var newFood = await _repository.CreateAsync(entity: request.Food, cancellationToken);

            return newFood;
        }
    }
}