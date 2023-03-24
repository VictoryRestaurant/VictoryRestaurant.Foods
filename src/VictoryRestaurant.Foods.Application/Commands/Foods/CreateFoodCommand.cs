namespace VictoryRestaurant.Foods.Application.Commands.Foods;

public sealed record class CreateFoodCommand : IRequest<FoodEntity?>
{
    public CreateFoodRequest? Request { get; }

    public CreateFoodCommand(CreateFoodRequest request) => Request = request;

    public CreateFoodCommand() { }

    public sealed record class Handler : IRequestHandler<CreateFoodCommand, FoodEntity?>
    {
        private readonly IFoodEntityRepository _repository;

        public Handler(IFoodEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<FoodEntity?> Handle(
            CreateFoodCommand command,
            CancellationToken cancellationToken)
        {
            if (command.Request is null)
            {
                return default;
            }

            var food = command.Request.Adapt<FoodEntity>();

            food.CreatedDate = DateTime.UtcNow;

            var newFood = await _repository.CreateAsync(entity: food, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            return newFood;
        }
    }
}