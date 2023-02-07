namespace VictoryRestaurant.Foods.Application.Queries.Foods;

public sealed record class GetFoodByConditionQuery : IRequest<FoodEntity?>
{
    public Expression<Func<FoodEntity, bool>>? Predicate { get; }

    public GetFoodByConditionQuery(
        Expression<Func<FoodEntity, bool>> predicate)
    {
        Predicate = predicate;
    }  

    public GetFoodByConditionQuery() { }

    public sealed record class Handler : IRequestHandler<GetFoodByConditionQuery, FoodEntity?>
    {
        private readonly IFoodEntityRepository _repository;

        public Handler(IFoodEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<FoodEntity?> Handle(
            GetFoodByConditionQuery request,
            CancellationToken cancellationToken)
        {
            if (request.Predicate is null)
            {
                return default;
            }

            var food = await _repository.GetAsync(predicate: request.Predicate, cancellationToken);

            return food;
        }
    }
}