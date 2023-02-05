namespace VictoryRestaurant.Foods.Domain.Contracts.Repositories;

/// <summary> Contract for <see cref="FoodEntity"/> repository. </summary>
public interface IFoodEntityRepository
{
    public ValueTask<IEnumerable<FoodEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    public ValueTask<IEnumerable<FoodEntity>> GetAllAsync(
        Func<FoodEntity, bool> predicate,
        CancellationToken cancellationToken = default);

    public ValueTask<FoodEntity?> GetAsync(Guid id, 
        CancellationToken cancellationToken = default);

    public ValueTask<FoodEntity?> GetAsync(
        Func<FoodEntity, bool> predicate, 
        CancellationToken cancellationToken = default);

    public ValueTask<FoodEntity> CreateAsync(FoodEntity entity,
        CancellationToken cancellationToken = default);

    public ValueTask UpdateAsync(FoodEntity entity,
        CancellationToken cancellationToken = default);

    public ValueTask DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);
}