using Microsoft.Extensions.Configuration;
using Project1.backend.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Project1.backend.Data
{
    public class CarModelRepository : IDisposable
    {
        private readonly string _connectionString;

        public CarModelRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<CarModel> GetAllCarModels()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var query = "SELECT Id, Brand, Class, ModelName, ModelCode, Description, Features, Price, DateOfManufacturing, Active, SortOrder FROM CarModels";
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            var carModels = new List<CarModel>();
                            while (reader.Read())
                            {
                                carModels.Add(new CarModel
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Brand = reader["Brand"].ToString(),
                                    Class = reader["Class"].ToString(),
                                    ModelName = reader["ModelName"].ToString(),
                                    ModelCode = reader["ModelCode"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Features = reader["Features"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    DateOfManufacturing = Convert.ToDateTime(reader["DateOfManufacturing"]),
                                    Active = Convert.ToBoolean(reader["Active"]),
                                    SortOrder = Convert.ToInt32(reader["SortOrder"])
                                });
                            }
                            return carModels;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and handle accordingly
                throw new Exception("Error fetching car models.", ex);
            }
        }

        public CarModel GetCarModelById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var query = "SELECT Id, Brand, Class, ModelName, ModelCode, Description, Features, Price, DateOfManufacturing, Active, SortOrder FROM CarModels WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new CarModel
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Brand = reader["Brand"].ToString(),
                                    Class = reader["Class"].ToString(),
                                    ModelName = reader["ModelName"].ToString(),
                                    ModelCode = reader["ModelCode"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Features = reader["Features"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    DateOfManufacturing = Convert.ToDateTime(reader["DateOfManufacturing"]),
                                    Active = Convert.ToBoolean(reader["Active"]),
                                    SortOrder = Convert.ToInt32(reader["SortOrder"])
                                };
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and handle accordingly
                throw new Exception($"Error fetching car model with id {id}.", ex);
            }
        }

        public void AddCarModel(CarModel carModel)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var query = @"INSERT INTO CarModels (Brand, Class, ModelName, ModelCode, Description, Features, Price, DateOfManufacturing, Active, SortOrder)
                                  VALUES (@Brand, @Class, @ModelName, @ModelCode, @Description, @Features, @Price, @DateOfManufacturing, @Active, @SortOrder)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Brand", carModel.Brand);
                        command.Parameters.AddWithValue("@Class", carModel.Class);
                        command.Parameters.AddWithValue("@ModelName", carModel.ModelName);
                        command.Parameters.AddWithValue("@ModelCode", carModel.ModelCode);
                        command.Parameters.AddWithValue("@Description", carModel.Description);
                        command.Parameters.AddWithValue("@Features", carModel.Features);
                        command.Parameters.AddWithValue("@Price", carModel.Price);
                        command.Parameters.AddWithValue("@DateOfManufacturing", carModel.DateOfManufacturing);
                        command.Parameters.AddWithValue("@Active", carModel.Active);
                        command.Parameters.AddWithValue("@SortOrder", carModel.SortOrder);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and handle accordingly
                throw new Exception("Error adding car model.", ex);
            }
        }

        public void UpdateCarModel(CarModel carModel)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var query = @"UPDATE CarModels SET Brand = @Brand, Class = @Class, ModelName = @ModelName, ModelCode = @ModelCode, 
                                  Description = @Description, Features = @Features, Price = @Price, DateOfManufacturing = @DateOfManufacturing, 
                                  Active = @Active, SortOrder = @SortOrder WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Brand", carModel.Brand);
                        command.Parameters.AddWithValue("@Class", carModel.Class);
                        command.Parameters.AddWithValue("@ModelName", carModel.ModelName);
                        command.Parameters.AddWithValue("@ModelCode", carModel.ModelCode);
                        command.Parameters.AddWithValue("@Description", carModel.Description);
                        command.Parameters.AddWithValue("@Features", carModel.Features);
                        command.Parameters.AddWithValue("@Price", carModel.Price);
                        command.Parameters.AddWithValue("@DateOfManufacturing", carModel.DateOfManufacturing);
                        command.Parameters.AddWithValue("@Active", carModel.Active);
                        command.Parameters.AddWithValue("@SortOrder", carModel.SortOrder);
                        command.Parameters.AddWithValue("@Id", carModel.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and handle accordingly
                throw new Exception($"Error updating car model with id {carModel.Id}.", ex);
            }
        }

        public void DeleteCarModel(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var query = "DELETE FROM CarModels WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and handle accordingly
                throw new Exception($"Error deleting car model with id {id}.", ex);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
