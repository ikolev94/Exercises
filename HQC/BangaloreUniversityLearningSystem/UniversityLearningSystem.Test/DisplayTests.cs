namespace UniversityLearningSystem.Test
{
    using System;

    using BangaloreUniversityLearningSystem.Views;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using UniversityLearningSystem.Models;
    using UniversityLearningSystem.Views;
    using UniversityLearningSystem.Views.CourseViews;
    using UniversityLearningSystem.Views.UserViews;

    [TestClass]
    public class DisplayTests
    {
        [TestMethod]
        public void TestDetailsViewDisplay()
        {
            string expectedResult = "testCourse" + Environment.NewLine + "No lectures";
            var course = new Course("testCourse");
            var view = new DetailsView(course);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestEnrollViewDisplay()
        {
            string expectedResult = "Student successfully enrolled in course testCourse.";
            var course = new Course("testCourse");
            var view = new EnrollView(course);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestCreateViewDisplay()
        {
            string expectedResult = "Course testCourse created successfully.";
            var course = new Course("testCourse");
            var view = new CreateView(course);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestAddLecturesViewDisplay()
        {
            string expectedResult = "Lecture successfully added to course testCourse.";
            var course = new Course("testCourse");
            var view = new AddLecturesView(course);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestLoginViewDisplay()
        {
            const string Username = "testUser";
            const string Password = "testPassword";
            string expectedResult = string.Format("User {0} logged in successfully.", Username);
            var user = new User(Username, Password, Role.Lecturer);
            var view = new LoginView(user);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestLogoutViewDisplay()
        {
            const string Username = "testUser";
            const string Password = "testPassword";
            string expectedResult = string.Format("User {0} logged out successfully.", Username);
            var user = new User(Username, Password, Role.Lecturer);
            var view = new LogoutView(user);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestRegisterViewDisplay()
        {
            const string Username = "testUser";
            const string Password = "testPassword";
            string expectedResult = string.Format("User {0} registered successfully.", Username);
            var user = new User(Username, Password, Role.Lecturer);
            var view = new RegisterView(user);
            string actualResult = view.Display();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
