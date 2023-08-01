using NUnit.Framework;
using System;
using System.IO;
using System.Data.SqlClient;
using MusicalInstrumentsCRUD;
using MusicalInstrumentsCRUD.Services;
using MusicalInstrumentsCRUD.Models;
using System.Reflection;

namespace MusicalInstrumentsCRUD.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private Assembly assembly;
        private InstrumentService instrumentService;

        private string connectionString;
        private string databaseName;
        private string tableName;
        private Type? _instrumentType;
        private int lastInsertedProductId; // Store the ID of the last inserted product

        [OneTimeSetUp]
        public void LoadAssembly()
        {
            string assemblyPath = "MusicalInstrumentsCRUD.dll"; // Adjust the path if needed
            assembly = Assembly.LoadFrom(assemblyPath);
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            // Set up the connection string and other variables
            connectionString = ConnectionStringProvider.ConnectionString;
            databaseName = "InstrumentsDB";
            tableName = "Instruments";


            // Create the database
            // CreateDatabase();

            // Create the Products table
            // CreateTable();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            // Delete the product added during the test
            //DeleteProduct(lastInsertedProductId);
            //DeleteTestData();
            DeleteProduct1(lastInsertedProductId);


            // Drop the Products table
            // DropTable();

            // Drop the database
            // DropDatabase();
        }

        [Test]
        public void ConnectToDatabase_ConnectionSuccessful()
        {
            bool connectionSuccess = false;
            string errorMessage = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connectionSuccess = true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            Assert.IsTrue(connectionSuccess, "Failed to connect to the database. Error message: " + errorMessage);
        }

        [Test]
        public void Test_InstrumentClassExists()
        {
            string className = "MusicalInstrumentsCRUD.Models.Instrument";
            Type movieType = assembly.GetType(className);
            Assert.NotNull(movieType, $"The class '{className}' does not exist in the assembly.");
        }

        [Test]
        public void Test_InstrumentServiceClassExists()
        {
            string className = "MusicalInstrumentsCRUD.Services.InstrumentService";
            Type movieType = assembly.GetType(className);
            Assert.NotNull(movieType, $"The class '{className}' does not exist in the assembly.");
        }

        [Test]
        public void Test_InstrumentRepositoryClassExists()
        {
            string className = "MusicalInstrumentsCRUD.Data.InstrumentRepository";
            Type movieType = assembly.GetType(className);
            Assert.NotNull(movieType, $"The class '{className}' does not exist in the assembly.");
        }

        [Test]
        public void Test_UserInterfaceClassExists()
        {
            string className = "MusicalInstrumentsCRUD.Presentation.UserInterface";
            Type movieType = assembly.GetType(className);
            Assert.NotNull(movieType, $"The class '{className}' does not exist in the assembly.");
        }

        [Test]
        public void Test_InstrumentIdPropertyDataType_Int()
        {
            Type movieType = assembly.GetType("MusicalInstrumentsCRUD.Models.Instrument");
            PropertyInfo property = movieType.GetProperty("InstrumentId");
            Assert.AreEqual("System.Int32", property.PropertyType.FullName, "The 'InstrumentId' property should be of type int.");
        }

        [Test]
        public void Test_NamePropertyDataType_string()
        {
            Type movieType = assembly.GetType("MusicalInstrumentsCRUD.Models.Instrument");
            PropertyInfo property = movieType.GetProperty("Name");
            Assert.AreEqual("System.String", property.PropertyType.FullName, "The 'Name' property should be of type int.");
        }

        [Test]
        public void Test_TypePropertyDataType_string()
        {
            Type movieType = assembly.GetType("MusicalInstrumentsCRUD.Models.Instrument");
            PropertyInfo property = movieType.GetProperty("Type");
            PropertyInfo property1 = movieType.GetProperty("Manufacturer");
            Assert.AreEqual("System.String", property.PropertyType.FullName, "The 'Type' property should be of type int.");
            Assert.AreEqual("System.String", property1.PropertyType.FullName, "The 'Manufacturer' property should be of type int.");
        }

        [Test]
        public void Test_PricePropertyDataType_decimal()
        {
            Type movieType = assembly.GetType("MusicalInstrumentsCRUD.Models.Instrument");
            PropertyInfo property = movieType.GetProperty("Price");
            Assert.AreEqual("System.Decimal", property.PropertyType.FullName, "The 'Price' property should be of type int.");
        }

        [Test]
        public void Test_InstrumentIdPropertyGetterSetter()
        {
            Type movieType = assembly.GetType("MusicalInstrumentsCRUD.Models.Instrument");
            PropertyInfo property = movieType.GetProperty("InstrumentId");
            Assert.IsTrue(property.CanRead, "The 'InstrumentId' property should have a getter.");
            Assert.IsTrue(property.CanWrite, "The 'InstrumentId' property should have a setter.");
        }

        [Test]
        public void Test_Name_Type_Manufacturer_PropertyGetterSetter()
        {
            Type movieType = assembly.GetType("MusicalInstrumentsCRUD.Models.Instrument");
            PropertyInfo property = movieType.GetProperty("Type");
            PropertyInfo property1 = movieType.GetProperty("Name");
            PropertyInfo property2 = movieType.GetProperty("Manufacturer");
            Assert.IsTrue(property.CanRead, "The 'Type' property should have a getter.");
            Assert.IsTrue(property.CanWrite, "The 'Type' property should have a setter.");
            Assert.IsTrue(property1.CanRead, "The 'Name' property should have a getter.");
            Assert.IsTrue(property1.CanWrite, "The 'Name' property should have a setter.");
            Assert.IsTrue(property2.CanRead, "The 'Manufacturer' property should have a getter.");
            Assert.IsTrue(property2.CanWrite, "The 'Manufacturer' property should have a setter.");
        }

        [Test]
        public void Test_PricePropertyGetterSetter()
        {
            Type movieType = assembly.GetType("MusicalInstrumentsCRUD.Models.Instrument");
            PropertyInfo property = movieType.GetProperty("Price");
            Assert.IsTrue(property.CanRead, "The 'Price' property should have a getter.");
            Assert.IsTrue(property.CanWrite, "The 'Price' property should have a setter.");
        }

        [Test]
        public void Test_InstrumentRepository_ClassExists()
        {
            string className = "MusicalInstrumentsCRUD.Data.InstrumentRepository";
            Type movieType = assembly.GetType(className);
            Assert.NotNull(movieType, $"The class '{className}' does not exist in the assembly.");
        }

        [Test]
        public void Test_UserInterface_ClassExists()
        {
            string className = "MusicalInstrumentsCRUD.Presentation.UserInterface";
            Type movieType = assembly.GetType(className);
            Assert.NotNull(movieType, $"The class '{className}' does not exist in the assembly.");
        }

        [Test]
        public void Test_InstrumentService_ClassExists()
        {
            string className = "MusicalInstrumentsCRUD.Services.InstrumentService";
            Type movieType = assembly.GetType(className);
            Assert.NotNull(movieType, $"The class '{className}' does not exist in the assembly.");
        }

        [Test]
        public void Test_AddInstrument_ShouldAddInstrumentToDatabase()
        {
            // Arrange
            InstrumentService instrumentService = new InstrumentService(connectionString);
            MusicalInstrumentsCRUD.Models.Instrument testInstrument = new MusicalInstrumentsCRUD.Models.Instrument
            {
                InstrumentId = 999, // Replace with a unique ID that doesn't already exist in the database
                Name = "Test Instrument",
                Type = "Test Type",
                Price = 123.45M,
                Manufacturer = "Test Manufacturer"
            };
            lastInsertedProductId = testInstrument.InstrumentId;


            // Act
            instrumentService.AddInstrument(testInstrument);
            MusicalInstrumentsCRUD.Models.Instrument addedInstrument = instrumentService.GetInstrumentById(testInstrument.InstrumentId);

            // Assert
            Assert.IsNotNull(addedInstrument, "Failed to add the instrument to the database.");
            Assert.AreEqual(testInstrument.Name, addedInstrument.Name, "The instrument name was not added correctly.");
            Assert.AreEqual(testInstrument.Type, addedInstrument.Type, "The instrument type was not added correctly.");
            //Assert.AreEqual(testInstrument.Price, addedInstrument.Price, "The instrument price was not added correctly.");
            Assert.AreEqual(testInstrument.Manufacturer, addedInstrument.Manufacturer, "The instrument manufacturer was not added correctly.");

            DeleteProduct1(testInstrument.InstrumentId);
        }

        [Test]
        public void Test_UpdateInstrument_ShouldUpdateInstrumentInDatabase()
        {
            // Arrange
            InstrumentService instrumentService = new InstrumentService(connectionString);
            Instrument testInstrument = new Instrument
            {
                InstrumentId = 999, // Replace with the ID of an existing instrument in the database
                Name = "Test Instrument",
                Type = "Test Type",
                Price = 123.45M,
                Manufacturer = "Test Manufacturer"
            };
            lastInsertedProductId = testInstrument.InstrumentId;


            // Add the instrument to the database initially
            instrumentService.AddInstrument(testInstrument);

            // Modify the testInstrument with updated values
            testInstrument.Name = "Updated Test Instrument";
            testInstrument.Type = "Updated Test Type";
            testInstrument.Price = 789.0M;
            testInstrument.Manufacturer = "Updated Test Manufacturer";

            // Act
            instrumentService.UpdateInstrument(testInstrument);
            Instrument updatedInstrument = instrumentService.GetInstrumentById(testInstrument.InstrumentId);

            // Assert
            Assert.IsNotNull(updatedInstrument, "Failed to update the instrument in the database.");
            Assert.AreEqual(testInstrument.Name, updatedInstrument.Name, "The instrument name was not updated correctly.");
            Assert.AreEqual(testInstrument.Type, updatedInstrument.Type, "The instrument type was not updated correctly.");
            Assert.AreEqual(testInstrument.Price, updatedInstrument.Price, "The instrument price was not updated correctly.");
            Assert.AreEqual(testInstrument.Manufacturer, updatedInstrument.Manufacturer, "The instrument manufacturer was not updated correctly.");
            DeleteProduct1(testInstrument.InstrumentId);
        }

        [Test]
        public void Test_DeleteInstrument_ShouldDeleteInstrumentFromDatabase()
        {
            // Arrange
            InstrumentService instrumentService = new InstrumentService(connectionString);
            Instrument testInstrument = new Instrument
            {
                InstrumentId = 999, // Replace with the ID of an existing instrument in the database
                Name = "Test Instrument",
                Type = "Test Type",
                Price = 123.45M,
                Manufacturer = "Test Manufacturer"
            };
            lastInsertedProductId = testInstrument.InstrumentId;

            // Add the instrument to the database initially
            instrumentService.AddInstrument(testInstrument);

            // Act
            instrumentService.DeleteInstrument(testInstrument.InstrumentId);
            Instrument deletedInstrument = instrumentService.GetInstrumentById(testInstrument.InstrumentId);

            // Assert
            Assert.IsNull(deletedInstrument, "Failed to delete the instrument from the database.");
        }



        private void DeleteProduct1(int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.ChangeDatabase(databaseName);

                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $"DELETE FROM {tableName} WHERE InstrumentId = @ID";
                    command.Parameters.AddWithValue("@ID", productId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // Handle any exception if necessary
            }
        }




    }



}
