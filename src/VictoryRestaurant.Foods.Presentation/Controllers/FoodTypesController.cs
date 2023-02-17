namespace VictoryRestaurant.Foods.Presentation.Controllers;

/// <summary> Controller for get food types. </summary>
[Route(template: "api/food-types")]
[Produces(contentType: "application/json")]
[ApiController]
public sealed class FoodTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FoodTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary> Receipt of all food type. </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET api/food-types
    ///
    /// </remarks>
    /// <returns> Food types collection. </returns>
    /// <response code="200"> Food types collection. </response>
    /// <response code="404"> Not found. </response>
    /// <response code="500"> Internal server error. </response>
    [HttpGet(template: "")]
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<FoodTypeEntity>>> GetAllFoodTypesAsync()
    {
        var foodTypes = await _mediator.Send(request: new GetAllFoodTypeListQuery())
            .ConfigureAwait(continueOnCapturedContext: false);

        if (foodTypes.Any() is false)
        {
            return NotFound();
        }

        return Ok(value: foodTypes);
    }

    /// <summary> Get food type by <paramref name="id"/>. </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET api/food-types/{id}
    ///
    /// </remarks>
    /// <returns> Food type. </returns>
    /// <response code="200"> Food type. </response>
    /// <response code="404"> Not found. </response>
    /// <response code="500"> Internal server error. </response>
    [HttpGet(template: "{id}")]
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FoodEntity>> GetFoodTypeByIdAsync(Guid id)
    {
        var foodType = await _mediator.Send(request: new GetFoodTypeByConditionQuery(predicate: foodType => foodType.Id == id))
            .ConfigureAwait(continueOnCapturedContext: false);

        if (foodType is null)
        {
            return NotFound();
        }

        return Ok(value: foodType);
    }

    /// <summary> Create new food type. </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST api/food-types
    ///     {
    ///         "name": String
    ///     }
    ///
    /// </remarks>
    /// <returns> Created food type. </returns>
    /// <response code="200"> Created food type. </response>
    /// <response code="500"> Internal server error. </response>
    [HttpPost(template: "")]
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FoodTypeEntity>> CreateFoodTypeAsync(FoodTypeEntity foodType)
    {
        var createdFoodType = await _mediator.Send(request: new CreateFoodTypeCommand(foodType))
            .ConfigureAwait(continueOnCapturedContext: false);

        return Ok(value: createdFoodType);
    }

    /// <summary> Update food type. </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT api/food-types
    ///     {
    ///         "id": GUID,
    ///         "name": String
    ///     }
    ///
    /// </remarks>
    /// <returns> Updated food type. </returns>
    /// <response code="200"> Updated food type. </response>
    /// <response code="500"> Internal server error. </response>
    [HttpPut(template: "")]
    [Tags(tags: "FoodTypes")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FoodTypeEntity>> UpdateFoodTypeAsync(FoodTypeEntity foodType)
    {
        var updatedFoodType = await _mediator.Send(request: new UpdateFoodTypeCommand(foodType))
            .ConfigureAwait(continueOnCapturedContext: false);

        return Ok(value: updatedFoodType);
    }

    /// <summary> Delete food type by <paramref name="id"/>. </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE api/food-types/{id}
    ///
    /// </remarks>
    /// <response code="200"> Food type has been deleted. </response>
    /// <response code="500"> Internal server error. </response>
    [HttpDelete]
    [Tags(tags: "FoodTypes")]
    [Route(template: "{id}")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteFoodTypeAsync(Guid id)
    {
        await _mediator.Send(request: new DeleteFoodTypeCommand(id))
            .ConfigureAwait(continueOnCapturedContext: false);

        return Ok();
    }
}