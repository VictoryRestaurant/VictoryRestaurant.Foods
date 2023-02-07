namespace VictoryRestaurant.Foods.Application.Queries.FoodTypes;

public sealed record class GetAllFoodTypeListQuery : IRequest<IEnumerable<FoodTypeEntity>>
{
    public sealed record class Handler : IRequestHandler<GetAllFoodTypeListQuery, IEnumerable<FoodTypeEntity>>
    {
        private readonly IFoodTypeEntityRepository _repository;

        public Handler(IFoodTypeEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FoodTypeEntity>> Handle(
            GetAllFoodTypeListQuery request,
            CancellationToken cancellationToken)
        {
            var foodTypes = await _repository.GetAllAsync(cancellationToken);

            return foodTypes;
        }
    }
}