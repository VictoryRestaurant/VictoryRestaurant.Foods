namespace VictoryRestaurant.Foods.Presentation.Controllers;

/// <summary> Controller for get foods. </summary>
[Route(template: "api/foods")]
[Produces(contentType: "application/json")]
[ApiController]
public sealed class FoodsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FoodsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary> Receipt of all food. </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET api/foods
    ///
    /// </remarks>
    /// <returns> Foods collection. </returns>
    /// <response code="200"> Foods collection. </response>
    /// <response code="404"> Not found. </response>
    /// <response code="500"> Internal server error. </response>
    [HttpGet(template: "")]
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<FoodEntity>>> GetAllFoodsAsync()
    {
        var foods = await _mediator.Send(request: new GetAllFoodListQuery())
            .ConfigureAwait(continueOnCapturedContext: false);

        if(foods.Any() is false)
        {
            return NotFound();
        }

        return Ok(value: foods);
    }

    /// <summary> Get food by <paramref name="id"/>. </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET api/foods/{id}
    ///
    /// </remarks>
    /// <returns> Food. </returns>
    /// <response code="200"> Food. </response>
    /// <response code="404"> Not found. </response>
    /// <response code="500"> Internal server error. </response>
    [HttpGet(template: "{id}")]
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FoodEntity>> GetFoodByIdAsync(Guid id)
    {
        var food = await _mediator.Send(request: new GetFoodByConditionQuery(predicate: food => food.Id == id))
            .ConfigureAwait(continueOnCapturedContext: false);

        if(food is null)
        {
            return NotFound();
        }

        return Ok(value: food);
    }

    /// <summary> Create new food. </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST api/foods
    ///     {
    ///         "name": String,
    ///         "description": String,
    ///         "cost": Number,
    ///         "imagePath": String,
    ///         "foodTypeId": GUID
    ///     }
    ///
    /// </remarks>
    /// <returns> Created food. </returns>
    /// <response code="200"> Created food. </response>
    /// <response code="500"> Internal server error. </response>
    [HttpPost(template: "")]
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FoodEntity>> CreateFoodAsync(CreateFoodRequest request)
    {
        var createdFood = await _mediator.Send(request: new CreateFoodCommand(request))
            .ConfigureAwait(continueOnCapturedContext: false);

        return Ok(value: createdFood);
    }

    /// <summary> Update food. </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT api/foods
    ///     {
    ///         "id": GUID,
    ///         "createdDate": DateTime,
    ///         "name": String,
    ///         "description": String,
    ///         "cost": Number,
    ///         "imagePath": String,
    ///         "foodTypeId": GUID
    ///     }
    ///
    /// </remarks>
    /// <returns> Updated food. </returns>
    /// <response code="200"> Updated food. </response>
    /// <response code="500"> Internal server error. </response>
    [HttpPut(template: "")]
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FoodEntity>> UpdateFoodAsync(FoodEntity food)
    {
        var updatedFood = await _mediator.Send(request: new UpdateFoodCommand(food))
            .ConfigureAwait(continueOnCapturedContext: false);

        return Ok(value: updatedFood);
    }

    /// <summary> Delete food by <paramref name="id"/>. </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE api/foods/{id}
    ///
    /// </remarks>
    /// <response code="200"> Food has been deleted. </response>
    /// <response code="500"> Internal server error. </response>
    [HttpDelete(template: "{id}")]
    [Tags(tags: "Foods")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteFoodAsync(Guid id)
    {
        await _mediator.Send(request: new DeleteFoodCommand(id))
            .ConfigureAwait(continueOnCapturedContext: false);

        return Ok();
    }
}