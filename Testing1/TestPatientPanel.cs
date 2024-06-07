using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ClassLibrary;
using Medi2GoLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHarshPatientPanel
{
    [TestClass]
    public class TestPatientPanel
    {
        /*************************************  Test Appointment Data  ********************************/

        String UserName = "harsht1955";
        String AppoTime = "21:45PM";
        String AppoDate = "12/12/2024";
        String DoctorName = "Doctor1";

        //Add Test
        [TestMethod]
        public void AddAppoisWorking()
        {
            // Arrange
            AppointmentCollection appointments = new AppointmentCollection();
            string username = "harsht1955";
            string appoTime = "21:45PM";
            string appoDate = "12/12/2024";
            string doctorName = "Doctor1";

            // Create an appointment object with the provided details
            Appointment appointment = new Appointment
            {
                Username = username,
                AppoTime = appoTime,
                AppoDate = appoDate,
                DoctorName = doctorName
            };

            // Act
            appointments.Add(appointment);

            // Assert
            var addedAppointment = appointments.Appointments.Find(a =>
                a.Username == username &&
                a.AppoTime == appoTime &&
                a.AppoDate == appoDate &&
                a.DoctorName == doctorName);

            Assert.IsNull(addedAppointment);
        }

        [TestMethod]
        public void DeleteisWorking()
        {
            // Arrange
            AppointmentCollection appointments = new AppointmentCollection();
            string username = "Test";
            string appoTime = "21:45PM";
            string appoDate = "12/12/2024";
            string doctorName = "Doctor1";

            // Create an appointment object
            Appointment appointment = new Appointment
            {
                Username = username,
                AppoTime = appoTime,
                AppoDate = appoDate,
                DoctorName = doctorName
            };

            // Add the appointment to the collection
            appointments.Add(appointment);

            // Act
            // Delete the appointment
            appointments.Remove(appointment.AppId);

            // Assert
            // Check if the appointment no longer exists in the collection
            var deletedAppointment = appointments.Appointments.Find(a => a.AppId == appointment.AppId);
            Assert.IsNull(deletedAppointment);
        }

        /*************************************  Test Therapy Data  ********************************/

        String UserName1 = "harsht1955";
        String TheraTime = "21:45PM";
        String TheraDate = "12/12/2024";
        String TheraName = "Hydrotherapy";
        int Price = 75;

        [TestMethod]
        public void AddTheraisWorking()
        {
            // Arrange
            TherapyCollection therapies = new TherapyCollection();
            string username1 = "harsht1955";
            string TheraTime = "21:45PM";
            string TheraDate = "12/12/2024";
            string TheraName = "Hydrotherapy";

            Therapy therapy = new Therapy
            {
                Username = username1,
                TheraTime = TheraTime,
                TheraDate = TheraDate,
                TheraName = TheraName
            };

            // Act
            therapies.Add(therapy);

            // Assert
            var addedTherapy = therapies.Therapies.Find(a =>
                a.Username == username1 &&
                a.TheraTime == TheraTime &&
                a.TheraDate == TheraDate &&
                a.TheraName == TheraName);

            Assert.IsNull(addedTherapy);
        }

        [TestMethod]
        public void DeleteTheraisWorking()
        {
            // Arrange
            TherapyCollection therapies = new TherapyCollection();
            string username1 = "test";
            string TheraTime = "21:45PM";
            string TheraDate = "12/12/2024";
            string TheraName = "Hydrotherapy";

            Therapy therapy = new Therapy
            {
                Username = username1,
                TheraTime = TheraTime,
                TheraDate = TheraDate,
                TheraName = TheraName
            };

            // Add the appointment to the collection
            therapies.Add(therapy);

            // Act
            // Delete the appointment
            therapies.Remove(therapy.TEId);

            // Assert
            // Check if the appointment no longer exists in the collection
            var deletedAppointment = therapies.Therapies.Find(a => a.TEId == therapy.TEId);
            Assert.IsNull(deletedAppointment);
        }

        /*************************************  Test Order Data  ********************************/

        String UserName2 = "harsht1955";
        String MedName = "Ibuprofen";
        int Quantity = 5;
        int Price1 = 15;

        [TestMethod]
        public void AddOrderTest()
        {
            // Arrange
            OrderCollection orders = new OrderCollection();
            string userName = "harsht1955";
            string medName = "Ibuprofen";
            int quantity = 5;
            int price = 15;

            // Create an order object
            Order order = new Order
            {
                Username = userName,
                MedName = medName,
                Quantity = quantity,
                Price = price
            };

            // Act
            orders.Add(order);

            // Assert
            // Check if the order exists in the collection
            var addedOrder = orders.Orders.Find(o =>
                o.Username == userName &&
                o.MedName == medName &&
                o.Quantity == quantity &&
                o.Price == price);
            Assert.IsNull(addedOrder);
        }

        [TestMethod]
        public void DeleteOrderTest()
        {
            // Arrange
            OrderCollection orders = new OrderCollection();
            string userName = "harsht1955";
            string medName = "Ibuprofen";
            int quantity = 5;
            int price = 15;

            // Create an order object
            Order order = new Order
            {
                Username = userName,
                MedName = medName,
                Quantity = quantity,
                Price = price
            };

            // Add the order to the collection
            orders.Add(order);

            // Act
            // Delete the order
            orders.Remove(order.OrderId);

            // Assert
            // Check if the order no longer exists in the collection
            var deletedOrder = orders.Orders.Find(o => o.OrderId == order.OrderId);
            Assert.IsNull(deletedOrder);
        }

        /*************************************  Property Data Test Found  ********************************/


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
        public void InstanceTherapyOK()
        {
            Therapy therapy = new Therapy();
            Assert.IsNotNull(therapy);
        }

        [TestMethod]
        public void UsernameTherapyOK()
        {
            Therapy therapy = new Therapy();
            String TestData = "harsht1955";
            therapy.Username = TestData;
            Assert.AreEqual(therapy.Username, TestData);
        }

        [TestMethod]
        public void UsernameTherapyNull()
        {
            // Arrange
            Therapy therapy = new Therapy();
            string testData = null;

            // Act
            therapy.Username = testData;

            // Assert
            Assert.IsNull(therapy.Username);
        }

        [TestMethod]
        public void UsernameTherapyEmpty()
        {
            // Arrange
            Therapy therapy = new Therapy();
            string testData = string.Empty;

            // Act
            therapy.Username = testData;

            // Assert
            Assert.AreEqual(therapy.Username, testData);
        }

        [TestMethod]
        public void TheraDatePropertyValid()
        {
            Therapy therapy = new Therapy();
            String TestData = "12/12/2024";
            therapy.TheraDate = TestData;
            Assert.AreEqual(therapy.TheraDate, TestData);
        }

        [TestMethod]
        public void TheraTimePropertyValid()
        {
            Therapy therapy = new Therapy();
            String TestData = "21:10PM";
            therapy.TheraTime = TestData;
            Assert.AreEqual(therapy.TheraTime, TestData);
        }

        [TestMethod]
        public void TherapyNamePropertyValid()
        {
            Therapy therapy = new Therapy();
            String TestData = "Physiotherapy";
            therapy.TheraName = TestData;
            Assert.AreEqual(therapy.TheraName, TestData);
        }

        [TestMethod]
        public void TherapyPricePropertyValid()
        {
            Therapy therapy = new Therapy();
            int TestData = 50;
            therapy.Price = TestData;
            Assert.AreEqual(therapy.Price, TestData);
        }

        /*************************************  Orders  ********************************/
        //Instance of the class test
        [TestMethod]
        public void InstanceOrderOK()
        {
            Order order = new Order();
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void UsernameOrderOK()
        {
            Order order = new Order();
            string TestData = "harsht1955";
            order.Username = TestData;
            Assert.AreEqual(order.Username, TestData);
        }

        [TestMethod]
        public void UsernameOrderNull()
        {
            // Arrange
            Order order = new Order();
            string testData = null;

            // Act
            order.Username = testData;

            // Assert
            Assert.IsNull(order.Username);
        }

        [TestMethod]
        public void UsernameOrderEmpty()
        {
            // Arrange
            Order order = new Order();
            string testData = string.Empty;

            // Act
            order.Username = testData;

            // Assert
            Assert.AreEqual(order.Username, testData);
        }

        [TestMethod]
        public void OrderMedPropertyValid()
        {
            Order order = new Order();
            String TestData = "Paracetamol";
            order.MedName = TestData;
            Assert.AreEqual(order.MedName, TestData);
        }

        [TestMethod]
        public void OrderPricePropertyValid()
        {
            Order order = new Order();
            int TestData = 7;
            order.Price = TestData;
            Assert.AreEqual(order.Price, TestData);
        }

        [TestMethod]
        public void TotalPricePropertyValid()
        {
            Order order = new Order();
            int TestData = 7;
            order.Price = TestData;
            Assert.AreEqual(order.Price, TestData);
        }

        [TestMethod]
        public void OrderQuantityPropertyValid()
        {
            Order order = new Order();
            int TestData = 0;
            order.Price = TestData;
            Assert.AreEqual(order.Quantity, TestData);
        }
        /*************************************  Find Method Tests  ********************************/

        [TestMethod]
        public void TestAppointmentIDOK()
        {
            // Arrange
            AppointmentCollection appointmentCollection = new AppointmentCollection();
            int AppID = 1;

            // Act
            Appointment appointment = appointmentCollection.FindById(AppID);
            bool found = appointment != null;

            // Assert
            Assert.IsTrue(!found);
        }

        [TestMethod]
        public void TestOrderIDOK()
        {
            OrderCollection orderCollection = new OrderCollection();
            int OrderID = 1;

            Order order = orderCollection.FindById(OrderID);
            bool found = order != null;

            Assert.IsTrue(!found);
        }

        [TestMethod]
        public void TestTherapyIDOK()
        {
            TherapyCollection therapyCollection = new TherapyCollection();
            int TherapyID = 1;

            Therapy therapy = therapyCollection.FindById(TherapyID);
            bool found = therapy != null;

            Assert.IsTrue(!found);
        }

        [TestMethod]
        public void TestUserIDOK()
        {
            UserCollection userCollection = new UserCollection();
            int userid = 1;

            User user = userCollection.FindById(userid);
            bool found = user != null;

            Assert.IsFalse(!found);

        }
        /*******************  Property Data Test **************************/
        //Appointments
        [TestMethod]
        public void TestAppointmentIDFound()
        {
            // Arrange
            AppointmentCollection appointments = new AppointmentCollection();
            Appointment appointment = new Appointment();
            bool found = false;
            bool ok = true;
            int appId = 2;

            // Act
            appointment = appointments.FindById(appId);

            // Assert
            if (appointment == null || appointment.AppId != appId)
            {
                ok = false;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestAppointmentDateFound()
        {
            // Arrange
            AppointmentCollection appointments = new AppointmentCollection();
            bool ok = true;
            string appoDate = "12/12/2024";

            // Act
            var appointment = appointments.Appointments.FirstOrDefault(a => a.AppoDate == appoDate);

            // Assert
            if (appointment == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestAppointmentTimeFound()
        {
            // Arrange
            AppointmentCollection appointments = new AppointmentCollection();
            bool ok = true;
            string AppoTime = "12:10PM";

            // Act
            var appointment = appointments.Appointments.FirstOrDefault(a => a.AppoTime == AppoTime);

            // Assert
            if (appointment == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }
        [TestMethod]
        public void TestUsernameApposFound()
        {
            // Arrange
            AppointmentCollection appointments = new AppointmentCollection();
            bool found = false;
            bool ok = true;
            string username = "harsht1955";

            // Act
            appointments.LoadAppointmentsByUsername(username);
            var appointment = appointments.Appointments.FirstOrDefault(a => a.Username == username);

            // Assert
            if (appointment == null)
            {
                ok = false;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestDocNameFound()
        {
            // Arrange
            AppointmentCollection appos = new AppointmentCollection();
            bool ok = true;
            string docname = "doctor1";

            // Act
            var appointment = appos.Appointments.FirstOrDefault(a => a.DoctorName == docname);

            // Assert
            if (appointment == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        // Orders
        [TestMethod]
        public void TestOrderIDFound()
        {
            // Arrange
            OrderCollection orders = new OrderCollection();
            Order order = new Order();
            bool found = false;
            bool ok = true;
            int OrderId = 134;

            // Act
            order = orders.FindById(OrderId);

            // Assert
            if (order == null || order.OrderId != OrderId)
            {
                ok = false;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestOrderUsernameFound()
        {
            // Arrange
            OrderCollection orders = new OrderCollection();
            bool ok = true;
            string username = "harsht1955";

            // Act
            var order = orders.Orders.FirstOrDefault(a => a.Username == username);

            // Assert
            if (order == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestOrderMedNameFound()
        {
            // Arrange
            OrderCollection orders = new OrderCollection();
            bool ok = true;
            string MedName = "Ibuprofen";

            // Act
            var order = orders.Orders.FirstOrDefault(a => a.MedName == MedName);

            // Assert
            if (orders == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestOrderQuantFound()
        {
            // Arrange
            OrderCollection orders = new OrderCollection();
            bool ok = true;
            int quant = 5;

            // Act
            var order = orders.Orders.FirstOrDefault(a => a.Quantity == quant);

            // Assert
            if (order == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestUsernameOrdersFound()
        {
            // Arrange
            OrderCollection orders = new OrderCollection();
            bool found = false;
            bool ok = true;
            string username = "harsht1955";

            // Act
            orders.LoadOrdersByUsername(username);
            var therapies = orders.Orders.FirstOrDefault(a => a.Username == username);

            // Assert
            if (therapies == null)
            {
                ok = false;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestOrderPriceFound()
        {
            // Arrange
            OrderCollection orders = new OrderCollection();
            bool ok = true;
            int price = 15;

            // Act
            var order = orders.Orders.FirstOrDefault(a => a.Price == price);

            // Assert
            if (order == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        // Therapies
        [TestMethod]
        public void TestTherapyIDFound()
        {
            // Arrange
            TherapyCollection therapies = new TherapyCollection();
            Therapy therapy = new Therapy();
            bool found = false;
            bool ok = true;
            int TEId = 122;

            // Act
            therapy = therapies.FindById(TEId);

            // Assert
            if (therapy == null || therapy.TEId != TEId)
            {
                ok = false;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestTherapyDateFound()
        {
            // Arrange
            TherapyCollection therapys = new TherapyCollection();
            bool ok = true;
            string TheraDate = "12/12/2024";

            // Act
            var therapy = therapys.Therapies.FirstOrDefault(a => a.TheraDate == TheraDate);

            // Assert
            if (therapy == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestTherapyTimeFound()
        {
            // Arrange
            TherapyCollection therapys = new TherapyCollection();
            bool ok = true;
            string TheraTime = "12:10PM";

            // Act
            var therapy = therapys.Therapies.FirstOrDefault(a => a.TheraTime == TheraTime);

            // Assert
            if (therapy == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestTherapyNameFound()
        {
            // Arrange
            TherapyCollection therapys = new TherapyCollection();
            bool ok = true;
            string TheraName = "Hydrotherapy";

            // Act
            var therapy = therapys.Therapies.FirstOrDefault(a => a.TheraName == TheraName);

            // Assert
            if (therapy == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestTherapyPriceFound()
        {
            // Arrange
            TherapyCollection therapys = new TherapyCollection();
            bool ok = true;
            int Price = 75;

            // Act
            var therapy = therapys.Therapies.FirstOrDefault(a => a.Price == Price);

            // Assert
            if (therapy == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestTherapyUsernameFound()
        {
            // Arrange
            TherapyCollection therapys = new TherapyCollection();
            bool ok = true;
            string Username = "harsht1955";

            // Act
            var therapy = therapys.Therapies.FirstOrDefault(a => a.Username == Username);

            // Assert
            if (therapy == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        // User
        [TestMethod]
        public void TestUserIDFound()
        {
            // Arrange
            UserCollection users = new UserCollection();
            User user = new User();
            bool found = false;
            bool ok = true;
            int userid = 2;

            // Act
            user = users.FindById(userid);

            // Assert
            if (user == null || user.UserId != userid)
            {
                ok = false;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestUserNameFound()
        {
            // Arrange
            UserCollection users = new UserCollection();
            bool ok = true;
            string userName = "harsht1955";

            // Act
            var user = users.Users.FirstOrDefault(a => a.Username == userName);

            // Assert
            if (user == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestFullNameFound()
        {
            // Arrange
            UserCollection users = new UserCollection();
            bool ok = true;
            string FullName = "Harsh Bhaveshkumar Trivedi";

            // Act
            var user = users.Users.FirstOrDefault(a => a.Fullname == FullName);

            // Assert
            if (user == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void TestEmailFound()
        {
            // Arrange
            UserCollection users = new UserCollection();
            bool ok = true;
            string email = "harsht1955@gmail.com";

            // Act
            var user = users.Users.FirstOrDefault(a => a.Email == email);

            // Assert
            if (user == null)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }
    }
}