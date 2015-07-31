namespace UnitTestTheatre
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Theatre.Core;

    [TestClass]
    public class TheatreTest
    {
        [TestMethod]
        public void TestEmptyListTheatres_ShouldHaveZeroElements()
        {
            var engine = new Engine();
            Assert.AreEqual(0, engine.ListTheatres().Count());
        }

        [TestMethod]
        public void TestListTheatres_ShouldHaveOneElement()
        {
            var engine = new Engine();
            engine.AddTheatre("Ivan Vazov");
            Assert.AreEqual(1, engine.ListTheatres().Count());
        }

        [TestMethod]
        public void TestListTheatres_ShouldHaveManyElement()
        {
            int theatreTestCount = 2;
            var engine = new Engine();
            for (int i = 0; i < theatreTestCount; i++)
            {
                engine.AddTheatre("Theatre" + i);
                var a = engine.ListTheatres().Last();
                Assert.AreEqual("Theatre" + i, engine.ListTheatres().Last());
            }
        }

        [TestMethod]
        public void TestListTheatresWhenHundredUniqueTheatresAddedShouldHaveHundredTheatres()
        {
            var engine = new Engine();
            const int TestNumOfTheatres = 100;
            for (int i = 0; i < TestNumOfTheatres; i++)
            {
                engine.AddTheatre("Theatre" + i);
                Assert.AreSame("Theatre" + i, engine.ListTheatres().Last());
            }

            var theatres = engine.ListTheatres();
            Assert.AreEqual(TestNumOfTheatres, theatres.Count());
        }
    }
}
