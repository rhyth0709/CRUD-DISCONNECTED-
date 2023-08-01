using System;
using System.Collections.Generic;
using MusicalInstrumentsCRUD.Models;
using MusicalInstrumentsCRUD.Services;

namespace MusicalInstrumentsCRUD.Presentation
{
    public class UserInterface
    {
        private InstrumentService instrumentService;

        public UserInterface(string connectionString)
        {
            instrumentService = new InstrumentService(connectionString);
        }

        // Implement methods for interacting with the user, displaying menu options, and calling InstrumentService methods based on user input.
        public void Run()
        {
            Console.WriteLine("Welcome to the Musical Instruments Data Storage System!");

            while (true)
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1. Add Instrument");
                Console.WriteLine("2. View Instrument Details");
                Console.WriteLine("3. Update Instrument");
                Console.WriteLine("4. Delete Instrument");
                Console.WriteLine("5. View All Instruments");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice (1-6): ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddInstrument();
                        break;
                    case 2:
                        ViewInstrumentDetails();
                        break;
                    case 3:
                        UpdateInstrument();
                        break;
                    case 4:
                        DeleteInstrument();
                        break;
                    case 5:
                        ViewAllInstruments();
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddInstrument()
        {
            Instrument instrument = new Instrument();

            Console.Write("Enter the Instrument ID: ");
            if (!int.TryParse(Console.ReadLine(), out int instrumentId))
            {
                Console.WriteLine("Invalid input. Instrument ID must be an integer.");
                return;
            }

            instrument.InstrumentId = instrumentId;

            Console.Write("Enter the Name of the instrument: ");
            instrument.Name = Console.ReadLine();

            Console.Write("Enter the Type of the instrument: ");
            instrument.Type = Console.ReadLine();
            Console.Write("Enter the Price of the instrument: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid input. Price must be a decimal number.");
                return;
            }

            instrument.Price = price; // Assign the parsed price to the nullable decimal property.

            Console.Write("Enter the Manufacturer of the instrument (optional): ");
            instrument.Manufacturer = Console.ReadLine();

            instrumentService.AddInstrument(instrument);
            Console.WriteLine("Instrument added successfully.");
        }

        private void ViewInstrumentDetails()
        {
            Console.Write("Enter the ID of the instrument to view: ");
            if (!int.TryParse(Console.ReadLine(), out int instrumentId))
            {
                Console.WriteLine("Invalid input. Instrument ID must be an integer.");
                return;
            }

            Instrument instrument = instrumentService.GetInstrumentById(instrumentId);

            if (instrument == null)
            {
                Console.WriteLine("Instrument not found.");
            }
            else
            {
                Console.WriteLine("Instrument Details:");
                Console.WriteLine($"ID: {instrument.InstrumentId}");
                Console.WriteLine($"Name: {instrument.Name}");
                Console.WriteLine($"Type: {instrument.Type}");
                Console.WriteLine($"Price: {instrument.Price}");
                Console.WriteLine($"Manufacturer: {instrument.Manufacturer}");
            }
        }

        private void UpdateInstrument()
        {
            Console.Write("Enter the ID of the instrument to update: ");
            if (!int.TryParse(Console.ReadLine(), out int instrumentId))
            {
                Console.WriteLine("Invalid input. Instrument ID must be an integer.");
                return;
            }

            Instrument existingInstrument = instrumentService.GetInstrumentById(instrumentId);

            if (existingInstrument == null)
            {
                Console.WriteLine("Instrument not found.");
                return;
            }

            Console.WriteLine("Enter updated details:");

            Console.Write("Name: ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                existingInstrument.Name = newName;
            }

            Console.Write("Type: ");
            string newType = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newType))
            {
                existingInstrument.Type = newType;
            }

            Console.Write("Price: ");
            string newPriceStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPriceStr) && decimal.TryParse(newPriceStr, out decimal newPrice))
            {
                existingInstrument.Price = newPrice;
            }

            Console.Write("Manufacturer: ");
            existingInstrument.Manufacturer = Console.ReadLine();

            instrumentService.UpdateInstrument(existingInstrument);
            Console.WriteLine("Instrument updated successfully.");
        }

        private void DeleteInstrument()
        {
            Console.Write("Enter the ID of the instrument to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int instrumentId))
            {
                Console.WriteLine("Invalid input. Instrument ID must be an integer.");
                return;
            }

            Instrument existingInstrument = instrumentService.GetInstrumentById(instrumentId);

            if (existingInstrument == null)
            {
                Console.WriteLine("Instrument not found.");
                return;
            }

            Console.WriteLine("Are you sure you want to delete this instrument? (Y/N)");
            string confirmation = Console.ReadLine();

            if (confirmation.ToUpper() == "Y")
            {
                instrumentService.DeleteInstrument(instrumentId);
                Console.WriteLine("Instrument deleted successfully.");
            }
            else
            {
                Console.WriteLine("Deletion canceled.");
            }
        }

        private void ViewAllInstruments()
        {
            List<Instrument> instruments = instrumentService.GetAllInstruments();

            Console.WriteLine("All Instruments:");
            foreach (Instrument instrument in instruments)
            {
                Console.WriteLine($"ID: {instrument.InstrumentId}, Name: {instrument.Name}, Type: {instrument.Type}, " +
                                  $"Price: {instrument.Price}, Manufacturer: {instrument.Manufacturer}");
            }
        }
    }
}
