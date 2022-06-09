using CarDealership.DataAcess.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarDealership.DataAcess.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly SqlConnection _conn;
        public CarRepository(SqlConnection sqlConnection)
        {
            _conn = sqlConnection;
        }

        public Car GetCar(int id)
        {
            var query = "select top 1* from car where Id = " +id;
            SqlCommand cm = new SqlCommand(query, _conn);
            var car = new Car();
            _conn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            {
                while (reader.Read())
                {
                    car.Id = (int)reader["id"];
                    car.Name = reader["name"].ToString();
                    car.Price = (int)reader["price"];
                    break;
                }
            }
            _conn.Close();
            return car;
        }
       
        public IList<Car> GetCars(string name)
        {
            var query = "select * from car";
            if (!string.IsNullOrWhiteSpace(name))
               query += "where Name like '%" +name+ "%'";
            SqlCommand cm = new SqlCommand(query, _conn);
            var cars = new List<Car>();
            _conn.Open();
            SqlDataReader reader = cm.ExecuteReader();
            {
                while (reader.Read())
                {
                    var car = new Car();
                    car.Id = (int)reader["id"];
                    car.Name = reader["name"].ToString();
                    car.Price = (int)reader["price"];
                    cars.Add(car);
                }
            }
            _conn.Close();
            return cars;
        }

        
    }
}
