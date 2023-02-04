namespace VictoryRestaurant.Foods.Domain.Entities;

/// <summary> Food entity. </summary>
public sealed class FoodEntity
{
    /// <summary> Identifier. </summary>
    public Guid Id { get; set; }

    /// <summary> Date of creation. </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary> Food name. </summary>
	public string? Name { get; set; }

    /// <summary> Food description. </summary>
    public string? Description { get; set; }

    /// <summary> Food cost. </summary>
    public decimal Cost { get; set; }

    /// <summary> Food image path. </summary>
    public string? ImagePath { get; set; }

    /// <summary> Foreign key to <see cref="FoodTypeEntity"/>. </summary>
	public Guid? FoodTypeId { get; set; }

    /// <summary> Food type. </summary>
	public FoodTypeEntity? FoodType { get; set; }
}