using BaseProject.Domain.Model;

namespace BaseProject.Domain.Contracts;

public interface ICarService
{
    Task<List<Car>> GetAllCars();
    Task CreateCar(Car entity);
}