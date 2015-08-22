namespace VehicleParkSystem
{
    using System;

    public class Layout
    {
        private int sectors;

        private int placesSec;

        public Layout(int numberOfSectors, int placesPerSector)
        {
            this.Sectors = numberOfSectors;

            this.PlacesPerSector = placesPerSector;
        }

        public int Sectors
        {
            get
            {
                return this.sectors;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of sectors must be positive.");
                }

                this.sectors = value;
            }
        }

        public int PlacesPerSector
        {
            get
            {
                return this.placesSec;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of places per sector must be positive.");
                }

                this.placesSec = value;
            }
        }
    }
}