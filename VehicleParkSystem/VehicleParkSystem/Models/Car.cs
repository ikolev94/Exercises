namespace VehicleParkSystem.Models
{
    public class Car : Vehicle
    {
        private const decimal CarRegularRate = 2M;

        private const decimal CarOvertimeRate = 3.5M;

        public Car(string licensePlate, string person, int hours)
            : base(licensePlate, person, hours, CarRegularRate, CarOvertimeRate)
        {
        }
    }
}