namespace VictoryRestaurant.Foods.Application.Queries.FoodTypes;

public sealed record class GetFoodTypeListByConditionQuery : IRequest<IEnumerable<FoodTypeEntity>>
{
    public Func<FoodTypeEntity, bool>? Predicate { get; }

    public GetFoodTypeListByConditionQuery(
        Func<FoodTypeEntity, bool> predicate) =>
        Predicate = predicate;

    public GetFoodTypeListByConditionQuery() { }

    public sealed record class Handler : IRequestHandler<GetFoodTypeListByConditionQuery, IEnumerable<FoodTypeEntity>>
    {
        private readonly IFoodTypeEntityRepository _repository;

        public Handler(IFoodTypeEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FoodTypeEntity>> Handle(
            GetFoodTypeListByConditionQuery request,
            CancellationToken cancellationToken)
        {
            if (request.Predicate is null)
            {
                return Enumerable.Empty<FoodTypeEntity>();
            }

            var foodTypes = await _repository.GetAllAsync(predicate: request.Predicate, cancellationToken);

            return foodTypes;
        }
    }
}