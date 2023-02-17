namespace VictoryRestaurant.Foods.Infrastructure.Repositories;

/// <summary> <see cref="FoodEntity"/> repository. </summary>
public sealed class FoodEntityRepository : IFoodEntityRepository
{
    private readonly ApplicationContext _context;

    public FoodEntityRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary> Asynchronous receipt of all <see cref="FoodEntity"/>'s. </summary>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> <see cref="FoodEntity"/>'s collection. </returns>
    public async ValueTask<IEnumerable<FoodEntity>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var entities = await _context.Foods.AsNoTracking()
            .Include(navigationPropertyPath: entity => entity.FoodType)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entities;
    }

    /// <summary> 
    /// Asynchronous receipt of all <see cref="FoodEntity"/>'s
    /// by <paramref name="predicate"/> filter.
    /// </summary>
    /// <param name="predicate"> Filter. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> <see cref="FoodEntity"/>'s collection. </returns>
    public async ValueTask<IEnumerable<FoodEntity>> GetAllAsync(
        Func<FoodEntity, bool> predicate,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Foods.AsNoTracking();

        if (predicate == default)
        {
            return await query.ToListAsync(cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        var entities = await query.AsQueryable()
            .Include(navigationPropertyPath: entity => entity.FoodType)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entities;
    }

    /// <summary>
    /// Asynchronous first receipt <see cref="FoodEntity"/> by <paramref name="id"/>
    /// or <see langword="default"/>(<see cref="FoodEntity"/>).
    /// </summary>
    /// <param name="id"> Identifier. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> First finded <see cref="FoodEntity"/> or <see langword="default"/>(<see cref="FoodEntity"/>). </returns>
    public async ValueTask<FoodEntity?> FirstOrDefaultAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        if (id == default)
        {
            return default;
        }

        var entity = await _context.Foods.AsNoTracking()
            .SingleOrDefaultAsync(predicate: entity => entity.Id == id, cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entity;
    }

    /// <summary>
    /// Asynchronous first receipt <see cref="FoodEntity"/> by <paramref name="predicate"/> filter
    /// or <see langword="default"/>(<see cref="FoodEntity"/>).
    /// </summary>
    /// <param name="predicate"> Filter. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> First finded <see cref="FoodEntity"/> or <see langword="default"/>(<see cref="FoodEntity"/>). </returns>
    public async ValueTask<FoodEntity?> FirstOrDefaultAsync(
        Expression<Func<FoodEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        if (predicate == default)
        {
            return default;
        }

        var entities = await _context.Foods
            .AsNoTracking()
            .Include(navigationPropertyPath: entity => entity.FoodType)
            .FirstOrDefaultAsync(predicate, cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entities;
    }

    /// <summary> Asynchronous create new <see cref="FoodEntity"/>. </summary>
    /// <param name="entity"> Creatable <see cref="FoodEntity"/>. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> Created new <see cref="FoodEntity"/>. </returns>
    public async ValueTask<FoodEntity?> CreateAsync(FoodEntity entity,
        CancellationToken cancellationToken = default)
    {
        if (entity == default)
        {
            return default;
        }

        await _context.Foods.AddAsync(entity, cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        await _context.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entity;
    }

    /// <summary> Asynchronous update <see cref="FoodEntity"/>. </summary>
    /// <param name="entity"> Updatable <see cref="FoodEntity"/>. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    /// <returns> Updated <see cref="FoodEntity"/>. </returns>
    public async ValueTask<FoodEntity?> UpdateAsync(FoodEntity entity,
        CancellationToken cancellationToken = default)
    {
        if (entity == default || entity.Id == default)
        {
            return default;
        }

        var entityFromStorage = await _context.Foods
            .Include(navigationPropertyPath: entity => entity.FoodType)
            .FirstOrDefaultAsync(predicate: entity => entity.Id == entity.Id, cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        if (entityFromStorage == default)
        {
            return default;
        }

        entityFromStorage.CreatedDate = entity.CreatedDate;
        entityFromStorage.Name = entity.Name;
        entityFromStorage.Description = entity.Description;
        entityFromStorage.Cost = entity.Cost;
        entityFromStorage.ImagePath = entity.ImagePath;
        entityFromStorage.FoodTypeId = entityFromStorage.FoodTypeId;

        if(entityFromStorage.FoodType is not null && entity.FoodType is not null)
        {
            entityFromStorage.FoodType.Name = entity.Name;
        }

        await _context.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entityFromStorage;
    }

    /// <summary> Asynchronous delete <see cref="FoodEntity"/> by <paramref name="id"/>. </summary>
    /// <param name="id"> Identifier. </param>
    /// <param name="cancellationToken"> Asynchronous operation cancellation token. </param>
    public async ValueTask DeleteAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        if (id == default)
        {
            return;
        }

        var entity = await _context.Foods.SingleOrDefaultAsync(
            predicate: entity => entity.Id == id, cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        if (entity == default)
        {
            return;
        }

        _context.Foods.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);
    }
}