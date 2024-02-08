using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiH3v3.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarById(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<Car> AddCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateCar(int id, Car car)
        {
            var existingCar = await _context.Cars.FindAsync(id);
            if (existingCar == null)
                return null;

            existingCar.Brand = car.Brand;
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.Color = car.Color;
            existingCar.Price = car.Price;
            existingCar.CreatedAt = car.CreatedAt;

            await _context.SaveChangesAsync();
            return existingCar;
        }

        public async Task<bool> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
                return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
