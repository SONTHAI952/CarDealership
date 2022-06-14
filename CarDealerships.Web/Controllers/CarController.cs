using Microsoft.AspNetCore.Mvc;
using CarDealership.DataAcess.Models;
using System.Data.SqlClient;
using CarDealership.DataAcess.Repositories;


namespace CarDealership.Web.Controllers
{
    public class CarController : Controller
    {
        private ICarRepository _carRepository;




        [HttpGet]
        public IActionResult Index(string query)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server = localhost; port = 3306; user = < root >; password = < null >; database = < db00 > ";
            _carRepository = new CarRepository(conn);
            var cars = _carRepository.GetCars(query);
            return View(cars);

        }

    }
}
