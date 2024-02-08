using System;

namespace ApiH3v3
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

      //  public FuelType FuelType { get; set; }
    }
}
