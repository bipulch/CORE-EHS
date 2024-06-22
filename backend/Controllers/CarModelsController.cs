using Microsoft.AspNetCore.Mvc;
using Project1.backend.Models;
using Project1.backend.Services;
using System;
using System.Collections.Generic;

namespace Project1.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {
        private readonly CarModelService _carModelService;

        public CarModelsController(CarModelService carModelService)
        {
            _carModelService = carModelService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarModel>> GetAllCarModels()
        {
            try
            {
                var carModels = _carModelService.GetAllCarModels();
                return Ok(carModels);
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate error response
                return StatusCode(500, "An error occurred while fetching car models.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CarModel> GetCarModelById(int id)
        {
            try
            {
                var carModel = _carModelService.GetCarModelById(id);
                if (carModel == null)
                {
                    return NotFound();
                }
                return Ok(carModel);
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate error response
                return StatusCode(500, "An error occurred while fetching the car model.");
            }
        }

        [HttpPost]
        public ActionResult AddCarModel([FromBody] CarModel carModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _carModelService.AddCarModel(carModel);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate error response
                return StatusCode(500, "An error occurred while adding the car model.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCarModel(int id, [FromBody] CarModel carModel)
        {
            try
            {
                if (id != carModel.Id)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _carModelService.UpdateCarModel(carModel);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate error response
                return StatusCode(500, "An error occurred while updating the car model.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCarModel(int id)
        {
            try
            {
                var carModel = _carModelService.GetCarModelById(id);
                if (carModel == null)
                {
                    return NotFound();
                }

                _carModelService.DeleteCarModel(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate error response
                return StatusCode(500, "An error occurred while deleting the car model.");
            }
        }

        [HttpPost("calculate-commissions")]
        public ActionResult CalculateCommissions()
        {
            try
            {
                _carModelService.CalculateCommissions();
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate error response
                return StatusCode(500, "An error occurred while calculating commissions.");
            }
        }
    }
}
