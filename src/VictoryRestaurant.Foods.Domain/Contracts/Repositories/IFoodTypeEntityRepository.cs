namespace VictoryRestaurant.Foods.Domain.Contracts.Repositories;

/// <summary> Contract for <see cref="FoodTypeEntity"/> repository. </summary>
public interface IFoodTypeEntityRepository
{
    public ValueTask<IEnumerable<FoodTypeEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    public ValueTask<IEnumerable<FoodTypeEntity>> GetAllAsync(
        Func<FoodTypeEntity, bool> predicate,
        CancellationToken cancellationToken = default);

    public ValueTask<FoodTypeEntity?> GetAsync(Guid id,
        CancellationToken cancellationToken = default);

    public ValueTask<FoodTypeEntity?> GetAsync(
        Func<FoodTypeEntity, bool> predicate,
        CancellationToken cancellationToken = default);

    public ValueTask<FoodTypeEntity> CreateAsync(FoodTypeEntity entity,
        CancellationToken cancellationToken = default);

    public ValueTask UpdateAsync(FoodTypeEntity entity,
        CancellationToken cancellationToken = default);

    public ValueTask DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);
}