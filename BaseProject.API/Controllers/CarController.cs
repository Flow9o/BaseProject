using Microsoft.AspNetCore.Mvc;
using System.Net;
using BaseProject.Domain.Contracts;
using BaseProject.Domain.Model;

namespace BaseProject.API.Controllers;

// [Authorize] - Use Only when JWT Auth is needed - ONLY IN TEST - NOT IN PROD
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CarController : ControllerBase
{
    private readonly ICarServiceRunner _carServiceRunner;
    private readonly ICarService _carService;

    public CarController(ICarServiceRunner carServiceRunner, ICarService carService)
    {
        _carServiceRunner = carServiceRunner;
        _carService = carService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar([FromBody] Car car)
    {
        try 
        {
            await _carServiceRunner.RunCreateCar(car);
            return Ok();

        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Car>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
    public async Task<IActionResult> GetAllCars()
    {
        try
        {
            var cars = await _carService.GetAllCars();
            if (cars.Count == 0)
            {
                return NotFound();
            }
            return Ok(cars);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}