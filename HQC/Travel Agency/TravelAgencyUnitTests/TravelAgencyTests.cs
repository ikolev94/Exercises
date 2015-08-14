namespace TravelAgencyUnitTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using TravelAgency.Core;
    using TravelAgency.Enums;
    using TravelAgency.Interfaces;
    using TravelAgency.Models;

    [TestClass]
    public class TravelAgencyTests
    {
        private ITicketCatalog ticketCatalog;

        [TestInitializeAttribute]
        public void InitializeTicketCatalog()
        {
            this.ticketCatalog = new TicketCatalog();
        }

        public void TestEmptyTicketCatalogShouldHaveZeroTickets()
        {
            Assert.AreEqual(0, this.ticketCatalog.GetTicketsCount(TicketType.Air));
            Assert.AreEqual(0, this.ticketCatalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, this.ticketCatalog.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestAddAirTicketShouldAdd()
        {
            string flightNumber = It.IsAny<string>();
            string from = It.IsAny<string>();
            string to = It.IsAny<string>();
            string airline = It.IsAny<string>();
            DateTime dateTime = It.IsAny<DateTime>();
            decimal price = It.IsAny<decimal>();

            string result = this.ticketCatalog.AddAirTicket(flightNumber, from, to, airline, dateTime, price);

            Assert.AreEqual("Ticket added", result);
            Assert.AreEqual(1, this.ticketCatalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestAddAirTicketWhenDuplicate()
        {
            string flightNumber = It.IsAny<string>();
            string from = It.IsAny<string>();
            string to = It.IsAny<string>();
            string airline = It.IsAny<string>();
            DateTime dateTime = It.IsAny<DateTime>();
            decimal price = It.IsAny<decimal>();

            this.ticketCatalog.AddAirTicket(flightNumber, from, to, airline, dateTime, price);
            string result = this.ticketCatalog.AddAirTicket(flightNumber, from, to, airline, dateTime, price);

            Assert.AreEqual("Duplicate ticket", result);
            Assert.AreEqual(1, this.ticketCatalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketWhenTicketDoesNotExist()
        {
            string flightNumber = It.IsAny<string>();

            string result = this.ticketCatalog.DeleteAirTicket(flightNumber);

            Assert.AreEqual("Ticket does not exist", result);
            Assert.AreEqual(0, this.ticketCatalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestDeleteAirTicketWhenTicketExist()
        {
            string flightNumber = It.IsAny<string>();
            this.ticketCatalog.AddAirTicket(flightNumber, null, null, null, default(DateTime), default(decimal));

            Assert.AreEqual(1, this.ticketCatalog.GetTicketsCount(TicketType.Air));
            string result = this.ticketCatalog.DeleteAirTicket(flightNumber);

            Assert.AreEqual("Ticket deleted", result);
            Assert.AreEqual(0, this.ticketCatalog.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void TestAddTrainTicket()
        {
            string from = It.IsAny<string>();
            string to = It.IsAny<string>();
            var dateTime = It.IsAny<DateTime>();
            decimal price = It.IsAny<decimal>();
            decimal studentPrice = It.IsAny<decimal>();

            string result = this.ticketCatalog.AddTrainTicket(from, to, dateTime, price, studentPrice);

            Assert.AreEqual(1, this.ticketCatalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void TestAddTrainTicketTwice()
        {
            string from = It.IsAny<string>();
            string to = It.IsAny<string>();
            var dateTime = It.IsAny<DateTime>();
            decimal price = It.IsAny<decimal>();
            decimal studentPrice = It.IsAny<decimal>();

            this.ticketCatalog.AddTrainTicket(from, to, dateTime, price, studentPrice);
            string result = this.ticketCatalog.AddTrainTicket(from, to, dateTime, price, studentPrice);

            Assert.AreEqual(1, this.ticketCatalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual("Duplicate ticket", result);
        }

        [TestMethod]
        public void TestDeleteTrainTicket()
        {
            string from = It.IsAny<string>();
            string to = It.IsAny<string>();
            var dateTime = It.IsAny<DateTime>();
            decimal price = It.IsAny<decimal>();
            decimal studentPrice = It.IsAny<decimal>();

            this.ticketCatalog.AddTrainTicket(from, to, dateTime, price, studentPrice);
            string result = this.ticketCatalog.DeleteTrainTicket(from, to, dateTime);

            Assert.AreEqual(0, this.ticketCatalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual("Ticket deleted", result);
        }

        [TestMethod]
        public void TestDeleteTrainTicketNotExist()
        {
            string from = It.IsAny<string>();
            string to = It.IsAny<string>();
            var dateTime = It.IsAny<DateTime>();

            string result = this.ticketCatalog.DeleteTrainTicket(from, to, dateTime);

            Assert.AreEqual(0, this.ticketCatalog.GetTicketsCount(TicketType.Train));
            Assert.AreEqual("Ticket does not exist", result);
        }

        [TestMethod]
        public void TestAddBusTicket()
        {
            string from = It.IsAny<string>();
            string to = It.IsAny<string>();
            var dateTime = It.IsAny<DateTime>();
            string travelCompany = It.IsAny<string>();
            decimal price = It.IsAny<decimal>();

            string result = this.ticketCatalog.AddBusTicket(from, to, travelCompany, dateTime, price);

            Assert.AreEqual(1, this.ticketCatalog.GetTicketsCount(TicketType.Bus));
            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void TestAddBusTicketTwice()
        {
            string from = It.IsAny<string>();
            string to = It.IsAny<string>();
            var dateTime = It.IsAny<DateTime>();
            string travelCompany = It.IsAny<string>();
            decimal price = It.IsAny<decimal>();

            this.ticketCatalog.AddBusTicket(from, to, travelCompany, dateTime, price);
            string result = this.ticketCatalog.AddBusTicket(from, to, travelCompany, dateTime, price);

            Assert.AreEqual(1, this.ticketCatalog.GetTicketsCount(TicketType.Bus));
            Assert.AreEqual("Duplicate ticket", result);
        }

        [TestMethod]
        public void TesDeleteBusTicket()
        {
            string from = It.IsAny<string>();
            string to = It.IsAny<string>();
            var dateTime = It.IsAny<DateTime>();
            string travelCompany = It.IsAny<string>();

            string result = this.ticketCatalog.DeleteBusTicket(from, to, travelCompany, dateTime);

            Assert.AreEqual(0, this.ticketCatalog.GetTicketsCount(TicketType.Bus));
            Assert.AreEqual("Ticket does not exist", result);
        }

        [TestMethod]
        public void TestDeleteBusTicket()
        {
            string from = It.IsAny<string>();
            string to = It.IsAny<string>();
            var dateTime = It.IsAny<DateTime>();
            string travelCompany = It.IsAny<string>();
            decimal price = It.IsAny<decimal>();

            this.ticketCatalog.AddBusTicket(from, to, travelCompany, dateTime, price);
            string result = this.ticketCatalog.DeleteBusTicket(from, to, travelCompany, dateTime);

            Assert.AreEqual(0, this.ticketCatalog.GetTicketsCount(TicketType.Bus));
            Assert.AreEqual("Ticket deleted", result);
        }

        [TestMethod]
        public void TestFindTicketsShouldntFind()
        {
            this.ticketCatalog = new TicketCatalog();
            string result = this.ticketCatalog.FindTickets("Sofia", "Plovdiv");
            Assert.AreEqual("Not found", result);
        }
    }
}
