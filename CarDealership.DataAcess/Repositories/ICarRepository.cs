using CarDealership.DataAcess.Models;
using System.Collections.Generic;

namespace CarDealership.DataAcess.Repositories
{
    public interface ICarRepository
    {
        Car GetCar(int id);
        IList<Car> GetCars(string name);
        
    }
}
