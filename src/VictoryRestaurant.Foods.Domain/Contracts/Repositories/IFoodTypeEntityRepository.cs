namespace VictoryRestaurant.Foods.Domain.Contracts.Repositories;

/// <summary> Contract for <see cref="FoodTypeEntity"/> repository. </summary>
public interface IFoodTypeEntityRepository
{
    /// <summary> Asynchronous receipt of all <see cref="FoodTypeEntity"/>'s. </summary>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> <see cref="FoodTypeEntity"/>'s collection. </returns>
    public ValueTask<IEnumerable<FoodTypeEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronous receipt of all <see cref="FoodTypeEntity"/>'s
    /// by <paramref name="predicate"/> filter.
    /// </summary>
    /// <param name="predicate"> Filter. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> <see cref="FoodTypeEntity"/>'s collection. </returns>
    public ValueTask<IEnumerable<FoodTypeEntity>> GetAllAsync(
        Func<FoodTypeEntity, bool> predicate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronous first receipt <see cref="FoodTypeEntity"/> by <paramref name="id"/>
    /// or <see langword="default"/>(<see cref="FoodTypeEntity"/>).
    /// </summary>
    /// <param name="id"> Identifier. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> First finded <see cref="FoodTypeEntity"/> or <see langword="default"/>(<see cref="FoodTypeEntity"/>). </returns>
    public ValueTask<FoodTypeEntity?> FirstOrDefaultAsync(Guid id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronous first receipt <see cref="FoodTypeEntity"/> by <paramref name="predicate"/> filter
    /// or <see langword="default"/>(<see cref="FoodTypeEntity"/>).
    /// </summary>
    /// <param name="predicate"> Filter. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> First finded <see cref="FoodTypeEntity"/> or <see langword="default"/>(<see cref="FoodTypeEntity"/>). </returns>
    public ValueTask<FoodTypeEntity?> FirstOrDefaultAsync(
        Expression<Func<FoodTypeEntity, bool>> predicate,
        CancellationToken cancellationToken = default);

    /// <summary> Asynchronous create new <see cref="FoodTypeEntity"/>. </summary>
    /// <param name="entity"> Creatable <see cref="FoodTypeEntity"/>. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> Created new <see cref="FoodTypeEntity"/>. </returns>
    public ValueTask<FoodTypeEntity?> CreateAsync(FoodTypeEntity entity,
        CancellationToken cancellationToken = default);

    /// <summary> Asynchronous update <see cref="FoodTypeEntity"/>. </summary>
    /// <param name="entity"> Updatable <see cref="FoodTypeEntity"/>. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> Updated <see cref="FoodTypeEntity"/>. </returns>
    public ValueTask<FoodTypeEntity?> UpdateAsync(FoodTypeEntity entity,
        CancellationToken cancellationToken = default);

    /// <summary> Asynchronous delete <see cref="FoodTypeEntity"/> by <paramref name="id"/>. </summary>
    /// <param name="id"> Identifier. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    public ValueTask DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);
}