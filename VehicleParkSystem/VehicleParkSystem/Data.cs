namespace VehicleParkSystem
{
    using System;
    using System.Collections.Generic;

    using VehicleParkSystem.Iterfaces;

    using Wintellect.PowerCollections;

    internal class Data
    {
        public Data(int numberOfSectors)
        {
            this.VehiclesInParkPlaces = new Dictionary<IVehicle, string>();
            this.ParkPlaces = new Dictionary<string, IVehicle>();
            this.VehiclesByLicensePlate = new Dictionary<string, IVehicle>();
            this.VehiclesByStartTime = new Dictionary<IVehicle, DateTime>();
            this.VehiclesByOwner = new MultiDictionary<string, IVehicle>(false);
            this.SpacesCount = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> VehiclesInParkPlaces { get; private set; }

        public Dictionary<string, IVehicle> ParkPlaces { get; private set; }

        public Dictionary<string, IVehicle> VehiclesByLicensePlate { get; private set; }

        public Dictionary<IVehicle, DateTime> VehiclesByStartTime { get; private set; }

        public MultiDictionary<string, IVehicle> VehiclesByOwner { get; private set; }

        public int[] SpacesCount { get; private set; }

        public void InsertVehicleInDatabase(IVehicle vehicle, int sector, DateTime startTime, string place)
        {
            this.VehiclesInParkPlaces[vehicle] = place;
            this.ParkPlaces[place] = vehicle;
            this.VehiclesByLicensePlate[vehicle.LicensePlate] = vehicle;
            this.VehiclesByStartTime[vehicle] = startTime;
            this.VehiclesByOwner[vehicle.Owner].Add(vehicle);
            this.SpacesCount[sector - 1]++;
        }

        public void RemoveVehicleFromDatabase(IVehicle vehicle)
        {
            int sector = int.Parse(this.VehiclesInParkPlaces[vehicle].Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            this.ParkPlaces.Remove(this.VehiclesInParkPlaces[vehicle]);
            this.VehiclesInParkPlaces.Remove(vehicle);
            this.VehiclesByLicensePlate.Remove(vehicle.LicensePlate);
            this.VehiclesByStartTime.Remove(vehicle);
            this.VehiclesByOwner.Remove(vehicle.Owner, vehicle);
            this.SpacesCount[sector - 1]--;
        }
    }
}