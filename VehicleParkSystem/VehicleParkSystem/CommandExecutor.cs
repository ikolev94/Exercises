namespace VehicleParkSystem
{
    using System;
    using System.Globalization;

    using VehicleParkSystem.Iterfaces;
    using VehicleParkSystem.Models;

    public class CommandExecutor
    {
        private VehiclePark vehiclePark;

        public string Execute(ICommand c)
        {
            if (c.Name != "SetupPark" && this.vehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            switch (c.Name)
            {
                case "SetupPark":
                    int sectors = int.Parse(c.Parameters["sectors"]);
                    int placesPerSector = int.Parse(c.Parameters["placesPerSector"]);
                    this.vehiclePark = new VehiclePark(sectors, placesPerSector);
                    return "Vehicle park created";
                case "Park":
                    switch (c.Parameters["type"])
                    {
                        case "car":
                            var car = new Car(c.Parameters["licensePlate"], c.Parameters["owner"], int.Parse(c.Parameters["hours"]));
                            return this.vehiclePark.InsertCar(
                                car,
                                int.Parse(c.Parameters["sector"]),
                                int.Parse(c.Parameters["place"]),
                                DateTime.Parse(c.Parameters["time"], null, DateTimeStyles.RoundtripKind));
                        case "motorbike":
                            return
                                this.vehiclePark.InsertMotorbike(
                                    new Motorbike(
                                        c.Parameters["licensePlate"],
                                        c.Parameters["owner"],
                                        int.Parse(c.Parameters["hours"])),
                                    int.Parse(c.Parameters["sector"]),
                                    int.Parse(c.Parameters["place"]),
                                    DateTime.Parse(c.Parameters["time"], null, DateTimeStyles.RoundtripKind));

                        case "truck":
                            return
                                this.vehiclePark.InsertTruck(
                                    new Truck(
                                        c.Parameters["licensePlate"],
                                        c.Parameters["owner"],
                                        int.Parse(c.Parameters["hours"])),
                                    int.Parse(c.Parameters["sector"]),
                                    int.Parse(c.Parameters["place"]),
                                    DateTime.Parse(c.Parameters["time"], null, DateTimeStyles.RoundtripKind));
                    }

                    break;

                case "Exit":
                    return this.vehiclePark.ExitVehicle(
                        c.Parameters["licensePlate"],
                        DateTime.Parse(c.Parameters["time"], null, DateTimeStyles.RoundtripKind),
                        decimal.Parse(c.Parameters["paid"]));
                case "Status":
                    return this.vehiclePark.GetStatus();
                case "FindVehicle":
                    return this.vehiclePark.FindVehicle(c.Parameters["licensePlate"]);
                case "VehiclesByOwner":
                    return this.vehiclePark.FindVehiclesByOwner(c.Parameters["owner"]);
                default:
                    throw new InvalidOperationException("Invalid command.");
            }

            return string.Empty;
        }
    }
}