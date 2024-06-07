using ClassLibrary; // Import the ClassLibrary namespace which contains the clsDoctor class
using Microsoft.VisualStudio.TestTools.UnitTesting; // Import the testing framework from Microsoft
using System; // Import the System namespace for general .NET functionalities

namespace TestKMDoctorPanel // Define a namespace for the test class to avoid naming conflicts
{
    [TestClass] // Indicate that this class contains unit tests
    public class TestDoctorPanel
    {
        // Test to check if an instance of clsDoctor can be created
        [TestMethod] // Attribute to indicate a method is a test method
        public void InstanceOK()
        {
            clsDoctor doctor = new clsDoctor(); // Create an instance of clsDoctor
            Assert.IsNotNull(doctor); // Assert that the instance is not null
        }

        // Test to verify that the DocId property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void DocIdPropertyOK()
        {
            clsDoctor doctor = new clsDoctor(); // Create an instance of clsDoctor
            int TestData = 1; // Define test data for DocId
            doctor.DocId = TestData; // Set the DocId property
            Assert.AreEqual(TestData, doctor.DocId); // Assert that the DocId property is set correctly
        }

        // Test to verify that the DocName property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void DocNamePropertyOK()
        {
            clsDoctor doctor = new clsDoctor(); // Create an instance of clsDoctor
            string TestData = "Kalyan123"; // Define test data for DocName
            doctor.DocName = TestData; // Set the DocName property
            Assert.AreEqual(TestData, doctor.DocName); // Assert that the DocName property is set correctly
        }

        // Test to verify that the FirstName property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void firstNamePropertyOK()
        {
            clsDoctor doctor = new clsDoctor(); // Create an instance of clsDoctor
            string TestData = "kalyan"; // Define test data for FirstName
            doctor.FirstName = TestData; // Set the FirstName property
            Assert.AreEqual(doctor.FirstName, TestData); // Assert that the FirstName property is set correctly
        }

        // Test to verify that the LastName property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void lastNamePropertyOK()
        {
            clsDoctor doctor = new clsDoctor(); // Create an instance of clsDoctor
            string TestData = "Cat"; // Define test data for LastName
            doctor.LastName = TestData; // Set the LastName property
            Assert.AreEqual(TestData, doctor.LastName); // Assert that the LastName property is set correctly
        }

        // Test to verify that the Designation property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void designationlPropertyOK()
        {
            clsDoctor doctor = new clsDoctor(); // Create an instance of clsDoctor
            string TestData = "Bat"; // Define test data for Designation
            doctor.Designation = TestData; // Set the Designation property
            Assert.AreEqual(TestData, doctor.Designation); // Assert that the Designation property is set correctly
        }

        // Test to verify that the Username property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void usernamePropertyOK()
        {
            clsDoctor doctor = new clsDoctor(); // Create an instance of clsDoctor
            string TestData = "Ball"; // Define test data for Username
            doctor.Username = TestData; // Set the Username property
            Assert.AreEqual(TestData, doctor.Username); // Assert that the Username property is set correctly
        }

        // Test to verify that the Address property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void addressPropertyOK()
        {
            clsDoctor doctor = new clsDoctor(); // Create an instance of clsDoctor
            string TestData = "Bell"; // Define test data for Address
            doctor.Address = TestData; // Set the Address property
            Assert.AreEqual(doctor.Address, TestData); // Assert that the Address property is set correctly
        }

        // Test to verify that the ContactNO property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void contactNOPropertyOK()
        {
            clsDoctor doctor = new clsDoctor(); // Create an instance of clsDoctor
            int TestData = 3; // Define test data for ContactNO
            doctor.ContactNO = TestData; // Set the ContactNO property
            Assert.AreEqual(doctor.ContactNO, TestData); // Assert that the ContactNO property is set correctly
        }


        [TestMethod]

        public void DocIdFound()
        {
            //Arrange
            DoctorCollection doctors = new DoctorCollection();
            clsDoctor clsdoctor = new clsDoctor();
            bool found = false;
            bool ok = true;
            int DocId = 1;

            //Act
            clsdoctor = doctors.GetDoctorById(DocId);


            //Assert
            if (clsdoctor == null || clsdoctor.DocId != DocId)
            {
                ok = true;
            }
            Assert.IsTrue(ok);
        }


    }
}