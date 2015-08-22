namespace VehicleParkSystem.Models
{
    public class Motorbike : Vehicle
    {
        private const decimal MotorbikeRegularRate = 1.35M;

        private const decimal MotorbikeOvertimeRate = 3.0M;

        public Motorbike(string licensePlate, string person, int hours)
            : base(licensePlate, person, hours, MotorbikeRegularRate, MotorbikeOvertimeRate)
        {
        }
    }
}