namespace VictoryRestaurant.Foods.Application.Commands.FoodTypes;

public sealed record class CreateFoodTypeCommand : IRequest<FoodTypeEntity?>
{
    public FoodTypeEntity? FoodType { get; }

    public CreateFoodTypeCommand(FoodTypeEntity foodType) => FoodType = foodType;

    public CreateFoodTypeCommand() { }

    public sealed record class Handler : IRequestHandler<CreateFoodTypeCommand, FoodTypeEntity?>
    {
        private readonly IFoodTypeEntityRepository _repository;

        public Handler(IFoodTypeEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<FoodTypeEntity?> Handle(
            CreateFoodTypeCommand request,
            CancellationToken cancellationToken)
        {
            if (request.FoodType is null)
            {
                return default;
            }

            var newFoodType = await _repository.CreateAsync(entity: request.FoodType, cancellationToken);

            return newFoodType;
        }
    }
}