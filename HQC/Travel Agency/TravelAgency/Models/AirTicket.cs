namespace TravelAgency.Models
{
    using System;

    public class AirTicket : Ticket
    {
        public AirTicket(string parwaaz_number, string from, string to, string airline, string dt, string pp)
        {
            this.parwaaz_number = parwaaz_number;
            this.From = from;
            this.To = from;

            this.Company = airline;
            DateTime dateAndTime = ParseDateTime(dt);
            this.DateAndTime = dateAndTime;
            decimal price = decimal.Parse(pp);
            this.Price = price;
        }

        public AirTicket(string parwaaz_number)
        {
            this.parwaaz_number = parwaaz_number;
        }

        public string parwaaz_number { get; set; }

        public override string Type
        {
            get
            {
                return "air";
            }
        }

        public override string MunfaridKuleed
        {
            get
            {
                return this.Type + ";;" + this.parwaaz_number;
            }
        }
    }
}