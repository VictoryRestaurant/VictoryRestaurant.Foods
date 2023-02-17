namespace VictoryRestaurant.Foods.Infrastructure.Repositories;

public sealed class FoodEntityRepository : IFoodEntityRepository
{
    private readonly ApplicationContext _context;

    public FoodEntityRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async ValueTask<IEnumerable<FoodEntity>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var entities = await _context.Foods.AsNoTracking()
            .Include(navigationPropertyPath: entity => entity.FoodType)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(continueOnCapturedContext: false);

        return entities; 
    }

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

    public async ValueTask<FoodEntity?> GetAsync(Guid id,
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

    public async ValueTask<FoodEntity?> GetAsync(
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