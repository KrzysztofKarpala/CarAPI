namespace CarAPI.Infrastructure.Mongo.Document
{
    public class CarResponseEngine
    {
        /// <summary>
        /// Engine Capacity
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Engine Horse Power
        /// </summary>
        public int Hp { get; set; }

        /// <summary>
        /// Engine fuel type
        /// </summary>
        public string Fuel { get; set; }
    }
}
