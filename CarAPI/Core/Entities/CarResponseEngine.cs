using CarAPI.Utils;

namespace CarAPI.Core.Entities
{
    public class CarResponseEngine
    {
        public int Capacity { get; private set; }
        public int Hp { get; private set; }
        public string Fuel { get; private set; }
        public static CarResponseEngine CreateCarResponseEngine(int capacity, int hp, string fuel) 
        {
            if (string.IsNullOrWhiteSpace(fuel))
            {
                throw new EmptyFuelException();
            }
            var carResponseEngine = new CarResponseEngine() 
            { 
                Capacity = capacity, 
                Hp = hp, 
                Fuel = fuel.Trim()
            };
            return carResponseEngine;
        }
    }
}
