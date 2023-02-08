namespace VictoryRestaurant.Foods.Application.Queries.Foods;

public sealed record class GetFoodListByConditionQuery : IRequest<IEnumerable<FoodEntity>>
{
    public Func<FoodEntity, bool>? Predicate { get; }

    public GetFoodListByConditionQuery(
        Func<FoodEntity, bool> predicate) =>
        Predicate = predicate;

    public GetFoodListByConditionQuery() { }

    public sealed record class Handler : IRequestHandler<GetFoodListByConditionQuery, IEnumerable<FoodEntity>>
    {
        private readonly IFoodEntityRepository _repository;

        public Handler(IFoodEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FoodEntity>> Handle(
            GetFoodListByConditionQuery request,
            CancellationToken cancellationToken)
        {
            if (request.Predicate is null)
            {
                return Enumerable.Empty<FoodEntity>();
            }

            var foods = await _repository.GetAllAsync(predicate: request.Predicate, cancellationToken);

            return foods;
        }
    }
}