using System;
using MusicalInstrumentsCRUD.Presentation;

namespace MusicalInstrumentsCRUD
{

    public static class ConnectionStringProvider
    {
        public static string ConnectionString { get; } = "Data Source=Divakar;Initial Catalog=InstrumentsDB;Integrated Security=True;Pooling=False";
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
