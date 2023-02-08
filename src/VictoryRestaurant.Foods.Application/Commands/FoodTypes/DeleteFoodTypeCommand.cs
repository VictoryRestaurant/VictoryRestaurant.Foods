namespace VictoryRestaurant.Foods.Application.Commands.FoodTypes;

public sealed record class DeleteFoodTypeCommand : IRequest
{
    public Guid Id { get; }

    public DeleteFoodTypeCommand(Guid id) => Id = id;

    public DeleteFoodTypeCommand() { }

    public sealed record class Handler : IRequestHandler<DeleteFoodTypeCommand>
    {
        private readonly IFoodEntityRepository _repository;

        public Handler(IFoodEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(
            DeleteFoodTypeCommand request,
            CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return default;
            }

            await _repository.DeleteAsync(id: request.Id, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            return default;
        }
    }
}