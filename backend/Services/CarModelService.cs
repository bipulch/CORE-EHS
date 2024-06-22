using Microsoft.Extensions.Configuration;
using Project1.backend.Data;
using Project1.backend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.backend.Services
{
    // CarModelService.cs
    public class CarModelService
    {
        private readonly CarModelRepository _repository;
        private readonly string _connectionString;

        public CarModelService(CarModelRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<CarModel> GetAllCarModels()
        {
            return _repository.GetAllCarModels();
        }

        public CarModel GetCarModelById(int id)
        {
            return _repository.GetCarModelById(id);
        }

        public void AddCarModel(CarModel carModel)
        {
            // Additional business logic before adding
            _repository.AddCarModel(carModel);
        }

        public void UpdateCarModel(CarModel carModel)
        {
            // Additional business logic before updating
            _repository.UpdateCarModel(carModel);
        }

        public void DeleteCarModel(int id)
        {
            // Additional business logic before deleting
            _repository.DeleteCarModel(id);
        }

        public void CalculateCommissions()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("CalculateCommissions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }
    }


}
