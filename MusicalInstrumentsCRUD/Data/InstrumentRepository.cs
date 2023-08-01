using System;
using System.Data;

using System.Data.SqlClient;
using MusicalInstrumentsCRUD.Models;

namespace MusicalInstrumentsCRUD.Data
{
    public class InstrumentRepository
    {
        private string connectionString;

        public InstrumentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Implement methods for CRUD operations using DataAdapter and Command objects.
        public void AddInstrument(Instrument instrument)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Instruments (InstrumentId, Name, Type, Price, Manufacturer) " +
                               "VALUES (@InstrumentId, @Name, @Type, @Price, @Manufacturer)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InstrumentId", instrument.InstrumentId);
                command.Parameters.AddWithValue("@Name", instrument.Name);
                command.Parameters.AddWithValue("@Type", instrument.Type);
                command.Parameters.AddWithValue("@Price", instrument.Price);
                command.Parameters.AddWithValue("@Manufacturer", instrument.Manufacturer);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Instrument GetInstrumentById(int instrumentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Instruments WHERE InstrumentId = @InstrumentId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InstrumentId", instrumentId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Instrument instrument = new Instrument
                    {
                        InstrumentId = Convert.ToInt32(reader["InstrumentId"]),
                        Name = reader["Name"].ToString(),
                        Type = reader["Type"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Manufacturer = reader["Manufacturer"].ToString()
                    };
                    return instrument;
                }

                return null;
            }
        }

        public void UpdateInstrument(Instrument instrument)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Instruments " +
                               "SET Name = @Name, Type = @Type, Price = @Price, Manufacturer = @Manufacturer " +
                               "WHERE InstrumentId = @InstrumentId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", instrument.Name);
                command.Parameters.AddWithValue("@Type", instrument.Type);
                command.Parameters.AddWithValue("@Price", instrument.Price);
                command.Parameters.AddWithValue("@Manufacturer", instrument.Manufacturer);
                command.Parameters.AddWithValue("@InstrumentId", instrument.InstrumentId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteInstrument(int instrumentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Instruments WHERE InstrumentId = @InstrumentId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InstrumentId", instrumentId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable GetAllInstruments()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Instruments";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable instrumentsTable = new DataTable();

                connection.Open();
                adapter.Fill(instrumentsTable);

                return instrumentsTable;
            }
        }
    }
}
