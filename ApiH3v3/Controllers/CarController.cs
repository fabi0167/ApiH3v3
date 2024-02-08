using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiH3v3.Repositories;

namespace ApiH3v3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carRepository.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carRepository.GetCarById(id);
            if (car == null)
                return NotFound();

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(Car car)
        {
            var newCar = await _carRepository.AddCar(car);
            return CreatedAtAction(nameof(GetCarById), new { id = newCar.CarId }, newCar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, Car car)
        {
            var updatedCar = await _carRepository.UpdateCar(id, car);
            if (updatedCar == null)
                return NotFound();

            return Ok(updatedCar);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var result = await _carRepository.DeleteCar(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
