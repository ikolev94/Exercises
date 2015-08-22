namespace VehicleParkSystem.Models
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    using VehicleParkSystem.Iterfaces;

    public abstract class Vehicle : IVehicle
    {
        private int hh;

        private string licenseplate;

        private decimal morerate;

        private string person;

        private decimal regularrate;

        protected Vehicle(string licensePlate, string person, int hours, decimal regularRate, decimal overTimeRate)
        {
            this.RegularRate = regularRate;
            this.OvertimeRate = overTimeRate;
            this.LicensePlate = licensePlate;
            this.Owner = person;
            this.ReservedHours = hours;
        }

        public string LicensePlate
        {
            get
            {
                return this.licenseplate;
            }

            set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{1,2}\d{4}[A-Z]{2,}$"))
                {
                    throw new ArgumentException("The license plate number is invalid.");
                }

                this.licenseplate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.person;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidCastException("The owner is required.");
                }

                this.person = value;
            }
        }

        public decimal RegularRate
        {
            get
            {
                return this.regularrate;
            }

            set
            {
                if (value < 0)
                {
                    throw new InvalidTimeZoneException("The regular rate must be non-negative.");
                }

                this.regularrate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return this.morerate;
            }

            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("The overtime rate must be non-negative.");
                }

                this.morerate = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return this.hh;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.hh = value;
            }
        }

        public override string ToString()
        {
            var vehicle = new StringBuilder();
            vehicle.AppendFormat("{0} [{1}], owned by {2}", this.GetType().Name, this.LicensePlate, this.Owner);
            return vehicle.ToString();
        }
    }
}
