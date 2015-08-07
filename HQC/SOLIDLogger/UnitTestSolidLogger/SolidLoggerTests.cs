namespace UnitTestSolidLogger
{
    using System;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using SolidLogger;
    using SolidLogger.Appenders;
    using SolidLogger.Exceptions;
    using SolidLogger.Interfaces;
    using SolidLogger.Layouts;

    using SOLIDLogger.Appenders;
    using SOLIDLogger.Exceptions;

    [TestClass]
    public class SolidLoggerTests
    {
        [TestMethod]
        public void TestSimpleLayout_ShouldBeInCorrectFormat()
        {
            // Arrange
            ILayout layout = new SimpleLayout();
            DateTime date = DateTime.Now;
            const ReportLevel ReportLevel = ReportLevel.Error;
            const string Message = "Exo";
            string expectedOutput = string.Format("{0}-{1}-{2}", date, ReportLevel, Message);

            // Act
            var actualOutput = layout.LayoutMaker(date, ReportLevel, Message);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestJsonLayout_ShouldBeInCorrectFormat()
        {
            // Arrange
            ILayout layout = new JsonLayout();
            DateTime date = DateTime.Now;
            const ReportLevel ReportLevel = ReportLevel.Error;
            const string Message = "Exo";
            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("{");
            expectedOutput.AppendLine(string.Format("\"Date\" : \"{0}\"", date));
            expectedOutput.AppendLine(string.Format("\"Report level\" : \"{0}\"", ReportLevel));
            expectedOutput.AppendLine(string.Format("\"Message\" : \"{0}\"", Message));
            expectedOutput.AppendLine("}");

            // Act
            var actualOutput = layout.LayoutMaker(date, ReportLevel, Message);

            // Assert
            Assert.AreEqual(expectedOutput.ToString(), actualOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(LayoutNullException))]
        public void TestAppenderWithNullLayout_ShouldThrowLayoutNullException()
        {
            IAppender consoleAppender = new ConsoleAppender(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FilePathNotFoundException))]
        public void TestAppenderWithInvalidFilePath_ShouldThrowFilePathNotFoundException()
        {
            var mock = new Mock<ILayout>();
            var consoleAppender = new FileAppender(mock.Object, string.Empty);
        }

        [TestMethod]
        public void TestLayoutMaker_ShouldBeCallOutOnes()
        {
            DateTime date = DateTime.Now;
            const ReportLevel ReportLevel = ReportLevel.Error;
            var message = It.IsAny<string>();
            var mock = new Mock<ILayout>();
            mock.Object.LayoutMaker(date, ReportLevel, message);
            mock.Verify(layout => layout.LayoutMaker(date, ReportLevel, message), Times.Exactly(1));
        }
    }
}
