using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software.Design.Services;

namespace Software.Design.Models.Controllers;

[ApiController]
[Route("api/carmodels")]
public class CarController : ControllerBase
{
    private readonly ILogger<CarController> _logger;
    private readonly CarService _carService;

    public CarController(
        ILogger<CarController> logger,
        CarService carService)
    {
        _logger = logger;
        _carService = carService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Car>>> Display()
    {
        var x = await _carService.Display();
        
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<object>> Display_ID(int id)
    {
        var x = await _carService.Display_ID(id);
        
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<object>> Put(CarDTO carDTO)
    {
        var x = await _carService.Put(carDTO);
        
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<object>> Put_ID(int id,CarDTO carDTO)
    {
        var x = await _carService.Put_ID(id, carDTO);
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<object>> DeleteProduct(int id)
    {
        var x = await _carService.DeleteProduct(id);
        
        return NoContent();
    }


    private ObjectResult Created(object value)
    {
        return StatusCode(201, value);
    }
}
