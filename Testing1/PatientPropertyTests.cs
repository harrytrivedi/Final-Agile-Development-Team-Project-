using System;
using System.Collections.Generic;
using System.ComponentModel;
using ClassLibrary;
using Medi2GoLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class PatientPropertyTests
    {
        /*************************************  Appointments ********************************/

        //Instance of the class test
        [TestMethod]
        public void InstanceOK()
        {
            Appointment appointment = new Appointment();
            Assert.IsNotNull(appointment);
        }

        [TestMethod]
        public void TitlePropertyOK()
        {
            Appointment appointment = new Appointment();
            String TestData = "harsht1955";
            appointment.Username = TestData;
            Assert.AreEqual(appointment.Username, TestData);
        }

        [TestMethod]
        public void TitlePropertyNull() 
        {
            // Arrange
            Appointment appointment = new Appointment();
            string testData = null;

            // Act
            appointment.Username = testData;

            // Assert
            Assert.IsNull(appointment.Username);
        }

        [TestMethod]
        public void TitlePropertyEmpty()
        {
            // Arrange
            Appointment appointment = new Appointment();
            string testData = string.Empty;

            // Act
            appointment.Username = testData;

            // Assert
            Assert.AreEqual(appointment.Username, testData);
        }

        [TestMethod]
        public void DatePropertyValid()
        {
            Appointment appointment = new Appointment();
            String TestData = "12/12/2024";
            appointment.AppoDate = TestData;
            Assert.AreEqual(appointment.AppoDate, TestData);
        }

        [TestMethod]
        public void TimePropertyValid()
        {
            Appointment appointment = new Appointment();
            String TestData = "21:10PM";
            appointment.AppoTime = TestData;
            Assert.AreEqual(appointment.AppoTime, TestData);
        }

        [TestMethod]
        public void DoctorPropertyValid()
        {
            Appointment appointment = new Appointment();
            String TestData = "Doctor1";
            appointment.DoctorName = TestData;
            Assert.AreEqual(appointment.DoctorName, TestData);
        }
        /*************************************  Therapies  ********************************/
        //Instance of the class test

        [TestMethod]
        public void InstanceOK()
        {
            Appointment appointment = new Appointment();
            Assert.IsNotNull(appointment);
        }

        [TestMethod]
        public void TitlePropertyOK()
        {
            Appointment appointment = new Appointment();
            String TestData = "harsht1955";
            appointment.Username = TestData;
            Assert.AreEqual(appointment.Username, TestData);
        }

        [TestMethod]
        public void TitlePropertyNull()
        {
            // Arrange
            Appointment appointment = new Appointment();
            string testData = null;

            // Act
            appointment.Username = testData;

            // Assert
            Assert.IsNull(appointment.Username);
        }

        [TestMethod]
        public void TitlePropertyEmpty()
        {
            // Arrange
            Appointment appointment = new Appointment();
            string testData = string.Empty;

            // Act
            appointment.Username = testData;

            // Assert
            Assert.AreEqual(appointment.Username, testData);
        }

        [TestMethod]
        public void DatePropertyValid()
        {
            Appointment appointment = new Appointment();
            String TestData = "12/12/2024";
            appointment.AppoDate = TestData;
            Assert.AreEqual(appointment.AppoDate, TestData);
        }

        [TestMethod]
        public void TimePropertyValid()
        {
            Appointment appointment = new Appointment();
            String TestData = "21:10PM";
            appointment.AppoTime = TestData;
            Assert.AreEqual(appointment.AppoTime, TestData);
        }

        [TestMethod]
        public void DoctorPropertyValid()
        {
            Appointment appointment = new Appointment();
            String TestData = "Doctor1";
            appointment.DoctorName = TestData;
            Assert.AreEqual(appointment.DoctorName, TestData);
        }
    }
}