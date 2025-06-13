using BaseProject.Domain.Contracts;
using BaseProject.Domain.Model;
using BaseProject.Infrastructure.Database;

namespace BaseProject.Infrastructure.ServiceRunner;

public class CarServiceRunner : ICarServiceRunner
{
    private readonly BaseProjectDBContext _context;
    private readonly ICarService _carService;
	
    public CarServiceRunner(BaseProjectDBContext context, ICarService carService)
    {
        _context = context;
        _carService = carService;
    }
	
    public async Task RunCreateCar(Car entity)
    {
        await _carService.CreateCar(entity);
        await _context.SaveChangesAsync();
    }
}