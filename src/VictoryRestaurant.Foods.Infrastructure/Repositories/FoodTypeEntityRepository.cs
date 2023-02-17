namespace VictoryRestaurant.Foods.Infrastructure.Repositories;

/// <summary> <see cref="FoodTypeEntity"/> repository. </summary>
public sealed class FoodTypeEntityRepository : IFoodTypeEntityRepository
{
    private readonly ApplicationContext _context;

    public FoodTypeEntityRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary> Asynchronous receipt of all <see cref="FoodTypeEntity"/>'s. </summary>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> <see cref="FoodTypeEntity"/>'s collection. </returns>
    public async ValueTask<IEnumerable<FoodTypeEntity>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var entities = await _context.FoodTypes.AsNoTracking()
            .ToListAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entities;
    }

    /// <summary>
    /// Asynchronous receipt of all <see cref="FoodTypeEntity"/>'s
    /// by <paramref name="predicate"/> filter.
    /// </summary>
    /// <param name="predicate"> Filter. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> <see cref="FoodTypeEntity"/>'s collection. </returns>
    public async ValueTask<IEnumerable<FoodTypeEntity>> GetAllAsync(
        Func<FoodTypeEntity, bool> predicate,
        CancellationToken cancellationToken = default)
    {
        var query = _context.FoodTypes.AsNoTracking();

        if (predicate == default)
        {
            return await query.ToListAsync(cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        var entities = await query.AsQueryable()
            .ToListAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entities;
    }

    /// <summary>
    /// Asynchronous first receipt <see cref="FoodTypeEntity"/> by <paramref name="id"/>
    /// or <see langword="default"/>(<see cref="FoodTypeEntity"/>).
    /// </summary>
    /// <param name="id"> Identifier. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> First finded <see cref="FoodTypeEntity"/> or <see langword="default"/>(<see cref="FoodTypeEntity"/>). </returns>
    public async ValueTask<FoodTypeEntity?> FirstOrDefaultAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        if (id == default)
        {
            return default;
        }

        var entity = await _context.FoodTypes.AsNoTracking()
            .SingleOrDefaultAsync(predicate: entity => entity.Id == id, cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entity;
    }

    /// <summary>
    /// Asynchronous first receipt <see cref="FoodTypeEntity"/> by <paramref name="predicate"/> filter
    /// or <see langword="default"/>(<see cref="FoodTypeEntity"/>).
    /// </summary>
    /// <param name="predicate"> Filter. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> First finded <see cref="FoodTypeEntity"/> or <see langword="default"/>(<see cref="FoodTypeEntity"/>). </returns>
    public async ValueTask<FoodTypeEntity?> FirstOrDefaultAsync(
        Expression<Func<FoodTypeEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        if (predicate == default)
        {
            return default;
        }

        var entity = await _context.FoodTypes
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate, cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entity;
    }

    /// <summary> Asynchronous create new <see cref="FoodTypeEntity"/>. </summary>
    /// <param name="entity"> Creatable <see cref="FoodTypeEntity"/>. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> Created new <see cref="FoodTypeEntity"/>. </returns>
    public async ValueTask<FoodTypeEntity?> CreateAsync(FoodTypeEntity entity,
        CancellationToken cancellationToken = default)
    {
        if (entity == default)
        {
            return default;
        }

        await _context.FoodTypes.AddAsync(entity, cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        await _context.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entity;
    }

    /// <summary> Asynchronous update <see cref="FoodTypeEntity"/>. </summary>
    /// <param name="entity"> Updatable <see cref="FoodTypeEntity"/>. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> Updated <see cref="FoodTypeEntity"/>. </returns>
    public async ValueTask<FoodTypeEntity?> UpdateAsync(FoodTypeEntity entity,
        CancellationToken cancellationToken = default)
    {
        if (entity == default || entity.Id == default)
        {
            return default;
        }

        var entityFromStorage = await _context.FoodTypes.SingleOrDefaultAsync(
            predicate: entity => entity.Id == entity.Id, cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        if (entityFromStorage == default)
        {
            return default;
        }

        entityFromStorage.Name = entity.Name;

        await _context.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entityFromStorage;
    }

    /// <summary> Asynchronous delete <see cref="FoodTypeEntity"/> by <paramref name="id"/>. </summary>
    /// <param name="id"> Identifier. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    public async ValueTask DeleteAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        if (id == default)
        {
            return;
        }

        var entity = await _context.FoodTypes.SingleOrDefaultAsync(
            predicate: entity => entity.Id == id, cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        if (entity == default)
        {
            return;
        }

        _context.FoodTypes.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);
    }
}