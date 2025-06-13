using BaseProject.Domain.Model;

namespace BaseProject.Domain.Contracts;

public interface ICarServiceRunner
{
    Task RunCreateCar(Car entity);
}