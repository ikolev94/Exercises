namespace UniversityLearningSystem.Test
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using UniversityLearningSystem.Data;

    [TestClass]
    public class GetTests
    {
        [TestMethod]
        public void TestGetWhitEmptyRepository()
        {
            int expectedResult = default(int);
            Repository<int> repository = new Repository<int>();
            var actualResult = repository.Get(0);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetWhitEmptyRepository2()
        {
            int input = It.IsAny<int>();
            int expectedResult = default(int);
            Repository<int> repository = new Repository<int>();
            var actualResult = repository.Get(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetWhitNoEmptyRepository2()
        {
            int input = It.IsAny<int>();
            Repository<int> repository = new Repository<int>();
            repository.Add(input);
            var actualResult = repository.Get(1);
            Assert.AreEqual(input, actualResult);
        }

        [TestMethod]
        public void TestGetWhitRefType()
        {
            string input = It.IsAny<string>();
            Repository<string> repository = new Repository<string>();
            repository.Add(input);
            var actualResult = repository.Get(1);
            Assert.AreEqual(input, actualResult);
            Assert.AreSame(input, actualResult);
        }

        [TestMethod]
        public void TestGetWhitManyItems()
        {
            int input = It.IsAny<int>();
            int input2 = It.IsAny<int>();
            int input3 = It.IsAny<int>();
            Repository<int> repository = new Repository<int>();
            repository.Add(input);
            repository.Add(input2);
            repository.Add(input3);
            var actualResult = repository.Get(2);
            Assert.AreEqual(input2, actualResult);
        }
    }
}
