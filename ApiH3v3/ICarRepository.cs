namespace ApiH3v3
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetCarById(int id);
        Task<Car> AddCar(Car car);
        Task<Car> UpdateCar(int id, Car car);
        Task<bool> DeleteCar(int id);
    }
}
