namespace VictoryRestaurant.Foods.Presentation.Controllers;

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

    [HttpGet]
    [Tags(tags: "Foods")]
    [Route(template: "")]
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

    [HttpGet]
    [Tags(tags: "Foods")]
    [Route(template: "{id}")]
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

    [HttpPost]
    [Tags(tags: "Foods")]
    [Route(template: "")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FoodEntity>> CreateFoodAsync(FoodEntity food)
    {
        var createdFood = await _mediator.Send(request: new CreateFoodCommand(food))
            .ConfigureAwait(continueOnCapturedContext: false);

        return Ok(value: createdFood);
    }

    [HttpPut]
    [Tags(tags: "Foods")]
    [Route(template: "")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FoodEntity>> UpdateFoodAsync(FoodEntity food)
    {
        var updatedFood = await _mediator.Send(request: new UpdateFoodCommand(food))
            .ConfigureAwait(continueOnCapturedContext: false);

        return Ok(value: updatedFood);
    }

    [HttpDelete]
    [Tags(tags: "Foods")]
    [Route(template: "{id}")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteFoodAsync(Guid id)
    {
        await _mediator.Send(request: new DeleteFoodCommand(id))
            .ConfigureAwait(continueOnCapturedContext: false);

        return Ok();
    }
}