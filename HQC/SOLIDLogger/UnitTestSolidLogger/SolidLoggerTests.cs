namespace UnitTestSolidLogger
{
    using System;
    using System.IO;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using SolidLogger;
    using SolidLogger.Appenders;
    using SolidLogger.Exceptions;
    using SolidLogger.Interfaces;
    using SolidLogger.Layouts;
    using SolidLogger.Loggers;

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
            DateTime date = It.IsAny<DateTime>();
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
            bool a = false;
            DateTime date = It.IsAny<DateTime>();
            const ReportLevel ReportLevel = ReportLevel.Error;
            var message = It.IsAny<string>();
            var mock = new Mock<ILayout>();
            mock.Object.LayoutMaker(date, ReportLevel, message);
            mock.Verify(layout => layout.LayoutMaker(date, ReportLevel, message), Times.Once);
        }

        [TestMethod]
        public void TestConsoleAppender_ShouldAppendCorrectly()
        {
            const string FakeResult = "It works";
            string expetedOutput = "It works" + Environment.NewLine;
            DateTime date = It.IsAny<DateTime>();
            const ReportLevel ReportLevel = ReportLevel.Error;
            var message = It.IsAny<string>();
            var mock = new Mock<ILayout>();

            mock.Setup(layout => layout.LayoutMaker(date, ReportLevel, message)).Returns(FakeResult);
            StringWriter actualOutput = new StringWriter();
            Console.SetOut(actualOutput);
            IAppender consoleAppender = new ConsoleAppender(mock.Object);
            consoleAppender.Append(date, ReportLevel, message);
            mock.Verify(a => a.LayoutMaker(date, ReportLevel, message), Times.Once);
            Assert.AreEqual(expetedOutput, actualOutput.ToString());
        }

        [TestMethod]
        public void TestFileAppender_ShouldAppendOnFile()
        {
            const string FakeResult = "It works";
            const string FilePath = "../../Log.txt";
            string expetedOutput = "It works" + Environment.NewLine;
            DateTime date = It.IsAny<DateTime>();
            const ReportLevel ReportLevel = ReportLevel.Error;
            var message = It.IsAny<string>();
            var mock = new Mock<ILayout>();
            mock.Setup(layout => layout.LayoutMaker(date, ReportLevel, message)).Returns(FakeResult);
            var fileAppender = new FileAppender(mock.Object, FilePath);

            Assert.IsTrue(File.Exists(FilePath));
            fileAppender.Append(date, ReportLevel, message);
            fileAppender.Close();
            StreamReader reader = new StreamReader(FilePath);
            string actualOutput = reader.ReadToEnd();
            reader.Close();
            mock.Verify(a => a.LayoutMaker(date, ReportLevel, message), Times.Once);
            Assert.AreEqual(expetedOutput, actualOutput);
        }

        [TestMethod]
        public void TestWarning_ShouldBeCalledTwoTimes()
        {
            int calls = 0;
            var message = It.IsAny<string>();

            var mockLogger = new Mock<ILogger>();
            mockLogger.Setup(logger => logger.Warning(message)).Callback(() => calls++);
            mockLogger.Object.Warning(message);
            mockLogger.Object.Warning(message);
            mockLogger.Verify(l => l.Warning(message), Times.Exactly(2));
            Assert.AreEqual(2, calls);
        }
    }
}
