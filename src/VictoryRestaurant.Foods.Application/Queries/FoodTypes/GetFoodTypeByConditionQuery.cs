namespace VictoryRestaurant.Foods.Application.Queries.FoodTypes;

public sealed record class GetFoodTypeByConditionQuery : IRequest<FoodTypeEntity?>
{
    public Func<FoodTypeEntity, bool>? Predicate { get; }

    public GetFoodTypeByConditionQuery(
        Func<FoodTypeEntity, bool> predicate) =>
        Predicate = predicate;

    public GetFoodTypeByConditionQuery() { }

    public sealed record class Handler : IRequestHandler<GetFoodTypeByConditionQuery, FoodTypeEntity?>
    {
        private readonly IFoodTypeEntityRepository _repository;

        public Handler(IFoodTypeEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<FoodTypeEntity?> Handle(
            GetFoodTypeByConditionQuery request,
            CancellationToken cancellationToken)
        {
            if (request.Predicate is null)
            {
                return default;
            }

            var foodType = await _repository.GetAsync(predicate: request.Predicate, cancellationToken);

            return foodType;
        }
    }
}