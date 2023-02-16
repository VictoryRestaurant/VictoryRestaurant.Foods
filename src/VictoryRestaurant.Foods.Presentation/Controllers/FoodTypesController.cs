namespace VictoryRestaurant.Foods.Presentation.Controllers;

[Route(template: "api/foodtypes")]
[Produces(contentType: "application/json")]
[ApiController]
public sealed class FoodTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FoodTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Tags(tags: "FoodTypes")]
    [Route(template: "")]
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

    [HttpGet]
    [Tags(tags: "FoodTypes")]
    [Route(template: "{id}")]
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

    [HttpPost]
    [Tags(tags: "FoodTypes")]
    [Route(template: "")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FoodTypeEntity>> CreateFoodTypeAsync(FoodTypeEntity foodType)
    {
        var createdFoodType = await _mediator.Send(request: new CreateFoodTypeCommand(foodType))
            .ConfigureAwait(continueOnCapturedContext: false);

        return Ok(value: createdFoodType);
    }

    [HttpPut]
    [Tags(tags: "FoodTypes")]
    [Route(template: "")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FoodTypeEntity>> UpdateFoodTypeAsync(FoodTypeEntity foodType)
    {
        var updatedFoodType = await _mediator.Send(request: new UpdateFoodTypeCommand(foodType))
            .ConfigureAwait(continueOnCapturedContext: false);

        return Ok(value: updatedFoodType);
    }

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