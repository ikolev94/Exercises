namespace VehicleParkSystem.Models
{
    public class Truck : Vehicle
    {
        private const decimal TruckRegularRate = 4.75M;

        private const decimal TruckOvertimeRate = 6.2M;

        public Truck(string licensePlate, string person, int hours)
            : base(licensePlate, person, hours, TruckRegularRate, TruckOvertimeRate)
        {
        }
    }
}