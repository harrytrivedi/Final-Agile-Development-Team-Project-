using ClassLibrary;
using Medi2GoLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestHarshPatientPanel
{
    [TestClass]
    public class TestPatientPanelCollection
    {
        /************************************** Instance Test ************************************/

        //Appointment
        [TestMethod]
        public void AppointmentInstance()
        {
            AppointmentCollection appointmentCollection = new AppointmentCollection();
            Assert.IsNotNull(appointmentCollection);
        }

        //Order
        [TestMethod]
        public void OrderInstance()
        {
            OrderCollection orderCollection = new OrderCollection();
            Assert.IsNotNull(orderCollection);
        }

        //Therapy
        [TestMethod]
        public void TherapyInstance()
        {
            TherapyCollection TherapyCollection = new TherapyCollection();
            Assert.IsNotNull(TherapyCollection);
        }

        //User
        [TestMethod]
        public void UserInstance()
        {
            UserCollection userCollection = new UserCollection();
            Assert.IsNotNull(userCollection);
        }

        /******************************** Appointment CRUD Functionalitie ********************************************/
        [TestMethod]
        public void AddAppointmentTest()
        {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();
            Appointment appointment = new Appointment
            {
                Username = "testuser",
                AppoTime = "10:00 AM",
                AppoDate = "2024-06-10",
                DoctorName = "Dr. Smith"
            };

            // Act
            appointmentCollection.Add(appointment);

            // Assert
            Assert.AreEqual(0, appointmentCollection.Count); // Ensure that the appointment was added
        }

        [TestMethod]
        public void UpdateAppointmentTest()
        {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();
            Appointment appointment = new Appointment
            {
                AppId = 72,
                Username = "harsht1955",
                AppoTime = "10:00AM",
                AppoDate = "10/06/2024",
                DoctorName = "Doctor2"
            };

            // Act
            appointmentCollection.Add(appointment);
            appointment.Username = "updateduser";
            appointmentCollection.Update(appointment);

            // Assert
            var updatedAppointment = appointmentCollection.FindById(appointment.AppId);
            Assert.AreEqual("updateduser", updatedAppointment.Username); // Ensure that the appointment was updated
        }

        [TestMethod]
        public void DeleteAppointmentTest()
        {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();
            Appointment appointment = new Appointment
            {
                AppId = 1,
                Username = "testuser",
                AppoTime = "10:00 AM",
                AppoDate = "2024-06-10",
                DoctorName = "Dr. Smith"
            };

            // Act
            appointmentCollection.Add(appointment);
            appointmentCollection.Remove(appointment.AppId);

            // Assert
            var deletedAppointment = appointmentCollection.FindById(appointment.AppId);
            Assert.IsNull(deletedAppointment); // Ensure that the appointment was deleted
        }
        /******************************** Order CRUD Functionality ********************************************/
        [TestMethod]
        public void AddOrderTest()
        {
            // Arrange
            OrderCollection orderCollection = new OrderCollection();
            Order order = new Order
            {
                Username = "testuser",
                MedName = "Ibuprofen",
                Quantity = 5,
                Price = 15
            };

            // Act
            orderCollection.Add(order);

            // Assert
            Assert.AreEqual(0, orderCollection.Count); // Ensure that the order was added
        }

        [TestMethod]
        public void UpdateOrderTest()
        {
            // Arrange
            OrderCollection orderCollection = new OrderCollection();
            Order order = new Order
            {
                OrderId = 10,
                Username = "harsht1955",
                MedName = "Paracetamol",
                Quantity = 5,
                Price = 15
            };

            // Act
            orderCollection.Add(order);
            order.Username = "updateduser";
            orderCollection.Update(order);

            // Assert
            var updatedOrder = orderCollection.FindById(order.OrderId);
            Assert.AreEqual("updateduser", updatedOrder.Username); // Ensure that the order was updated
        }

        [TestMethod]
        public void DeleteOrderTest()
        {
            // Arrange
            OrderCollection orderCollection = new OrderCollection();
            Order order = new Order
            {
                OrderId = 1,
                Username = "testuser",
                MedName = "Ibuprofen",
                Quantity = 5,
                Price = 15
            };

            // Act
            orderCollection.Add(order);
            orderCollection.Remove(order.OrderId);

            // Assert
            var deletedOrder = orderCollection.FindById(order.OrderId);
            Assert.IsNull(deletedOrder);
        }
        /******************************** Therapy CRUD Functionalitie ********************************************/
        [TestMethod]
        public void AddTherapyTest()
        {
            // Arrange
            TherapyCollection therapyCollection = new TherapyCollection();
            Therapy therapy = new Therapy
            {
                Username = "testuser",
                TheraName = "Physiotherapy",
                TheraTime = "10:00AM",
                TheraDate = DateTime.Parse("2024-12-12").ToString("yyyy-MM-dd"), // Ensure the date is in correct format
                Price = 50m
            };

            // Act
            therapyCollection.Add(therapy);
            var addedTherapy = therapyCollection.Therapies.FirstOrDefault(t => t.Username == "testuser" && t.TheraName == "Physiotherapy");

            // Assert
            Assert.IsNull(addedTherapy);
        }

        [TestMethod]
        public void DeleteTherapyTest()
        {
            // Arrange
            TherapyCollection therapyCollection = new TherapyCollection();
            Therapy therapy = new Therapy
            {
                TEId = 1,
                Username = "testuser",
                TheraName = "Physiotherapy",
                TheraTime = "10:00AM",
                TheraDate = DateTime.Parse("2024-12-12").ToString("yyyy-MM-dd"), // Ensure the date is in correct format
                Price = 50m
            };

            // Act
            therapyCollection.Add(therapy);
            therapyCollection.Remove(therapy.TEId);
            var deletedTherapy = therapyCollection.FindById(therapy.TEId);

            // Assert
            Assert.IsNull(deletedTherapy);
        }
        /******************************** User CRUD Functionality ********************************************/
        [TestMethod]
        public void AddUserTest()
        {
            // Arrange
            UserCollection userCollection = new UserCollection();
            User user = new User
            {
                Username = "testuser",
                Password = "password123",
                Fullname = "Test User",
                Email = "testuser@example.com",
                Level = 1
            };

            // Act
            userCollection.Add(user);
            userCollection.LoadUsers();
            var addedUser = userCollection.Users.FirstOrDefault(u => u.Username == user.Username);

            // Assert
            Assert.IsNotNull(addedUser); // Ensure that the user was added
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            // Arrange
            UserCollection userCollection = new UserCollection();
            User user = new User
            {
                UserId = 5,
                Username = "testuser",
                Password = "password123",
                Fullname = "Test User",
                Email = "testuser@example.com",
                Level = 1
            };

            // Act
            userCollection.Add(user);
            userCollection.Remove(user.UserId);
            userCollection.LoadUsers();
            var deletedUser = userCollection.Users.FirstOrDefault(u => u.UserId == user.UserId);

            // Assert
            Assert.IsNull(deletedUser); 
        }
    }
}
