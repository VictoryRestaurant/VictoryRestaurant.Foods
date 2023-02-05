namespace VictoryRestaurant.Foods.Domain.Entities;

/// <summary> Food type entity. </summary>
public sealed class FoodTypeEntity
{
    /// <summary> Identifier. </summary>
    public Guid Id { get; set; }

    /// <summary> Type name. </summary>
    public string Name { get; set; } = default!;
}