namespace VictoryRestaurant.Foods.Domain.Models.Requests.Foods;

public sealed class CreateFoodRequest
{
    /// <summary> Food name. </summary>
	public string Name { get; set; } = default!;

    /// <summary> Food description. </summary>
    public string? Description { get; set; }

    /// <summary> Food cost. </summary>
    public decimal Cost { get; set; }

    /// <summary> Food image path. </summary>
    public string? ImagePath { get; set; }

    /// <summary> Foreign key to <see cref="FoodTypeEntity"/>. </summary>
	public Guid? FoodTypeId { get; set; }
}