namespace VictoryRestaurant.Foods.Application.Queries.Foods;

public sealed record class GetAllFoodListQuery : IRequest<IEnumerable<FoodEntity>>
{
    public sealed record class Handler : IRequestHandler<GetAllFoodListQuery, IEnumerable<FoodEntity>>
    {
        private readonly IFoodEntityRepository _repository;

        public Handler(IFoodEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FoodEntity>> Handle(
            GetAllFoodListQuery request,
            CancellationToken cancellationToken)
        {
            var foods = await _repository.GetAllAsync(cancellationToken);

            return foods;
        }
    }
}