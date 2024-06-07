using ClassLibrary; // Import the ClassLibrary namespace which contains the Staff class
using Microsoft.VisualStudio.TestTools.UnitTesting; // Import the testing framework from Microsoft
using System; // Import the System namespace for general .NET functionalities

namespace Tests // Define a namespace for the test class to avoid naming conflicts
{
    [TestClass] // Indicate that this class contains unit tests
    public class StaffTests
    {
        // Test to check if an instance of Staff can be created
        [TestMethod] // Attribute to indicate a method is a test method
        public void InstanceOK()
        {
            Staff staff = new Staff(); // Create an instance of Staff
            Assert.IsNotNull(staff); // Assert that the instance is not null
        }

        // Test to verify that the Username property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void StaffIdPropertyOK()
        {
            Staff staff = new Staff(); // Create an instance of Staff
            String TestData = "Vidhi"; // Define test data for Username
            staff.Username = TestData; // Set the Username property
            Assert.AreEqual(TestData, staff.Username); // Assert that the Username property is set correctly
        }

        // Test to verify that the FullName property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void FullNamePropertyOK()
        {
            Staff staff = new Staff(); // Create an instance of Staff
            string TestData = "Vidhi123"; // Define test data for FullName
            staff.FullName = TestData; // Set the FullName property
            Assert.AreEqual(TestData, staff.FullName); // Assert that the FullName property is set correctly
        }

        // Test to verify that the ContactNumber property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void ContactNOPropertyOK()
        {
            Staff staff = new Staff(); // Create an instance of Staff
            int TestData = 123; // Define test data for ContactNumber
            staff.ContactNumber = TestData; // Set the ContactNumber property
            Assert.AreEqual(TestData, staff.ContactNumber); // Assert that the ContactNumber property is set correctly
        }

        // Test to verify that the Designation property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void DesignationPropertyOK()
        {
            Staff staff = new Staff(); // Create an instance of Staff
            string TestData = "doctor"; // Define test data for Designation
            staff.Designation = TestData; // Set the Designation property
            Assert.AreEqual(TestData, staff.Designation); // Assert that the Designation property is set correctly
        }

        // Test to verify that the Salary property can be set and retrieved correctly
        [TestMethod] // Attribute to indicate a method is a test method
        public void SalaryPropertyOK()
        {
            Staff staff = new Staff(); // Create an instance of Staff
            int TestData = 20000; // Define test data for Salary
            staff.Salary = TestData; // Set the Salary property
            Assert.AreEqual(TestData, staff.Salary); // Assert that the Salary property is set correctly
        }
    }
}
