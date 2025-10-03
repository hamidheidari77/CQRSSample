using CustomCQRS.CQRS.Commands;
using CustomCQRS.CQRS.Mediator;
using CustomCQRS.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CustomCQRS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly DIMediator _mediator;

    public ProductsController(DIMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }
}
