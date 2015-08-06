using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestTheatre
{
    using System.Linq;

    using Theatre.Core;
    using Theatre.Exceptions;

    [TestClass]
    public class TheatreUnitTest
    {
        [TestMethod]
        public void TestEmptyListTheatres_ShouldHaveZeroElements()
        {
            Engine engine = new Engine();
            int elementCount = engine.ListTheatres().Count();
            Assert.AreEqual(0, elementCount);
        }

        [TestMethod]
        public void TestListTheatres_ShouldHaveOneElements()
        {
            Engine engine = new Engine();
            var theatres = engine.ListTheatres();
            engine.AddTheatre("test");

            Assert.AreEqual(1, theatres.Count());
        }

        [TestMethod]
        public void TestListTheatres_ShouldHaveManyElements()
        {
            int testElementsToAdd = 20;
            Engine engine = new Engine();
            var theatres = engine.ListTheatres();
            for (int i = 0; i < testElementsToAdd; i++)
            {
                string name = "Theatr" + i;
                engine.AddTheatre(name);
            }

            Assert.AreEqual(testElementsToAdd, theatres.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestAddPerformance_ShouldThrowTheatreNotFoundException()
        {
            Engine engine = new Engine();
            engine.AddPerformance("testTheatre", "perform", DateTime.Now, new TimeSpan(1, 3, 1), 1m);
        }

        [TestMethod]
        public void TestAddPerformance_ShouldAddOnePerformance()
        {
            Engine engine = new Engine();
            engine.AddTheatre("testTheatre");
            engine.AddPerformance("testTheatre", "perform", DateTime.Now, new TimeSpan(1, 3, 1), 1m);
            Assert.AreEqual(1, engine.ListAllPerformances().Count());
        }

        [TestMethod]
        public void TestAddPerformance_ShouldAddManyPerformance()
        {
            Engine engine = new Engine();
            engine.AddTheatre("testTheatre");
            for (int i = 0; i < 10; i++)
            {
                engine.AddPerformance("testTheatre", "perform" + i, new DateTime(2000, 11, i + 1), new TimeSpan(1, 3, 1), 1m);
            }

            Assert.AreEqual(10, engine.ListAllPerformances().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void TestAddPerformance_ShouldThrowTimeDurationOverlapException()
        {
            Engine engine = new Engine();
            engine.AddTheatre("testTheatre");
            engine.AddPerformance("testTheatre", "perform", new DateTime(2000, 11, 11, 12, 12, 12), new TimeSpan(1, 3, 1), 1m);
            engine.AddPerformance("testTheatre", "perform", new DateTime(2000, 11, 11, 11, 55, 12), new TimeSpan(1, 3, 1), 1m);
        }

        [TestMethod]
        public void TestListPerformances_ShouldHaveZeroElements()
        {
            Engine engine = new Engine();
            const string TheatreName = "Some theatre";
            engine.AddTheatre(TheatreName);
            var performances = engine.ListPerformances(TheatreName);
            Assert.AreEqual(0, performances.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTheatreException))]
        public void TestAddTheatre_ShouldThrowDuplicateTheatreException()
        {
            Engine engine = new Engine();
            const string TheatreName = "Some theatre";
            engine.AddTheatre(TheatreName);
            engine.AddTheatre(TheatreName);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestListPerformances_ShouldThrowTheatreNotFoundException()
        {
            Engine engine = new Engine();
            const string TheatreName = "Some theatre";
            engine.ListPerformances(TheatreName);
        }
    }
}
