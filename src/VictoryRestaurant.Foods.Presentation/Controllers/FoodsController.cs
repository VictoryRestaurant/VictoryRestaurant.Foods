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
    [Tags("Foods", "Get")]
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
}