namespace VictoryRestaurant.Foods.Domain.Contracts.Repositories;

/// <summary> Contract for <see cref="FoodEntity"/> repository. </summary>
public interface IFoodEntityRepository
{
    /// <summary> Asynchronous receipt of all <see cref="FoodEntity"/>'s. </summary>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> <see cref="FoodEntity"/>'s collection. </returns>
    public ValueTask<IEnumerable<FoodEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);

    /// <summary> 
    /// Asynchronous receipt of all <see cref="FoodEntity"/>'s
    /// by <paramref name="predicate"/> filter.
    /// </summary>
    /// <param name="predicate"> Filter. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> <see cref="FoodEntity"/>'s collection. </returns>
    public ValueTask<IEnumerable<FoodEntity>> GetAllAsync(
        Func<FoodEntity, bool> predicate,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronous first receipt <see cref="FoodEntity"/> by <paramref name="id"/>
    /// or <see langword="default"/>(<see cref="FoodEntity"/>).
    /// </summary>
    /// <param name="id"> Identifier. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> First finded <see cref="FoodEntity"/> or <see langword="default"/>(<see cref="FoodEntity"/>). </returns>
    public ValueTask<FoodEntity?> FirstOrDefaultAsync(Guid id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronous first receipt <see cref="FoodEntity"/> by <paramref name="predicate"/> filter
    /// or <see langword="default"/>(<see cref="FoodEntity"/>).
    /// </summary>
    /// <param name="predicate"> Filter. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> First finded <see cref="FoodEntity"/> or <see langword="default"/>(<see cref="FoodEntity"/>). </returns>
    public ValueTask<FoodEntity?> FirstOrDefaultAsync(
        Expression<Func<FoodEntity, bool>> predicate,
        CancellationToken cancellationToken = default);

    /// <summary> Asynchronous create new <see cref="FoodEntity"/>. </summary>
    /// <param name="entity"> Creatable <see cref="FoodEntity"/>. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> Created new <see cref="FoodEntity"/>. </returns>
    public ValueTask<FoodEntity?> CreateAsync(FoodEntity entity,
        CancellationToken cancellationToken = default);

    /// <summary> Asynchronous update <see cref="FoodEntity"/>. </summary>
    /// <param name="entity"> Updatable <see cref="FoodEntity"/>. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> Updated <see cref="FoodEntity"/>. </returns>
    public ValueTask<FoodEntity?> UpdateAsync(FoodEntity entity,
        CancellationToken cancellationToken = default);

    /// <summary> Asynchronous delete <see cref="FoodEntity"/> by <paramref name="id"/>. </summary>
    /// <param name="id"> Identifier. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    public ValueTask DeleteAsync(Guid id,
        CancellationToken cancellationToken = default);
}