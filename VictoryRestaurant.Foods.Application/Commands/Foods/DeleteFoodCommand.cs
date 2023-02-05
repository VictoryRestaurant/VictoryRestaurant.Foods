namespace VictoryRestaurant.Foods.Application.Commands.Foods;

public sealed record class DeleteFoodCommand : IRequest
{
    public Guid Id { get; }

    public DeleteFoodCommand(Guid id) => Id = id;

    public DeleteFoodCommand() { }

    public sealed record class Handler : IRequestHandler<DeleteFoodCommand>
    {
        private readonly IFoodEntityRepository _repository;

        public Handler(IFoodEntityRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(
            DeleteFoodCommand request,
            CancellationToken cancellationToken)
        {
            if(request.Id == Guid.Empty)
            {
                return default;
            }

            await _repository.DeleteAsync(id: request.Id, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            return default;
        }
    }
}