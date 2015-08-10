namespace TravelAgency.Models
{
    using System;

    public class BusTicket : Ticket
    {
        public BusTicket(string from, string to, string travelCompany, string dt, string pp)
        {
            this.From = from;
            this.To = to;
            this.Company = travelCompany;
            DateTime dateAndTime = ParseDateTime(dt);

            this.DateAndTime = dateAndTime;
            decimal price = decimal.Parse(pp);
            this.Price = price;
        }

        public BusTicket(string from, string to, string travelCompany, string dt)
        {
            this.From = from;
            this.To = to;
            this.Company = travelCompany;

            DateTime dateAndTime = ParseDateTime(dt);
            this.DateAndTime = dateAndTime;
        }

        public override string Type
        {
            get
            {
                return "bus";
            }
        }

        public override string MunfaridKuleed
        {
            get
            {
                return this.Type + ";;" + this.From + ";" + this.To + ";" + this.Company + this.DateAndTime + ";";
            }
        }
    }
}