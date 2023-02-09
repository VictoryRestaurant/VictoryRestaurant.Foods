namespace VictoryRestaurant.Foods.Infrastructure.Repositories;

public sealed class FoodTypeEntityRepository : IFoodTypeEntityRepository
{
    private readonly ApplicationContext _context;

    public FoodTypeEntityRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async ValueTask<IEnumerable<FoodTypeEntity>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var entities = await _context.FoodTypes.AsNoTracking()
            .ToListAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entities;
    }

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

    public async ValueTask<FoodTypeEntity?> GetAsync(Guid id,
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

    public async ValueTask<FoodTypeEntity?> GetAsync(
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