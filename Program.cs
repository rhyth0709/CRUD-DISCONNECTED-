using System;
using MusicalInstrumentsCRUD.Presentation;

namespace MusicalInstrumentsCRUD
{

    public static class ConnectionStringProvider
    {
        // Replace with your actual connection string
        public static string ConnectionString { get; } ="User ID=sa;password=examlyMssql@123; server=localhost;Database=InstrumentsDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = ConnectionStringProvider.ConnectionString;
            UserInterface userInterface = new UserInterface(connectionString);
            userInterface.Run();
        }
    }
}
