using BaseProject.Domain.Contracts;
using BaseProject.Domain.Model;
using BaseProject.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Infrastructure.Service;

public class CarService : ICarService
{
    private readonly BaseProjectDBContext _context;

    public CarService(BaseProjectDBContext context)
    {
        _context = context;
    }

    public async Task<List<Car>> GetAllCars()
    {
        return await _context.Cars.ToListAsync();
    }
	
    public async Task CreateCar(Car entity)
    {
        await _context.Cars.AddAsync(entity);
    }
}