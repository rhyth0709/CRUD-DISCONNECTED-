using System;
using System.Collections.Generic;
using MusicalInstrumentsCRUD.Models;
using MusicalInstrumentsCRUD.Data;
using System.Data;

namespace MusicalInstrumentsCRUD.Services
{
    public class InstrumentService
    {
        private InstrumentRepository instrumentRepository;

        public InstrumentService(string connectionString)
        {
            instrumentRepository = new InstrumentRepository(connectionString);
        }

        // Implement methods for business logic, validation, and calling the corresponding methods in the InstrumentRepository.
        public void AddInstrument(Instrument instrument)
        {
            // Perform any necessary validation before calling the repository method to add the instrument.
            instrumentRepository.AddInstrument(instrument);
        }

        public Instrument GetInstrumentById(int instrumentId)
        {
            // Perform any necessary validation before calling the repository method to get the instrument by ID.
            return instrumentRepository.GetInstrumentById(instrumentId);
        }

        public void UpdateInstrument(Instrument instrument)
        {
            // Perform any necessary validation before calling the repository method to update the instrument.
            instrumentRepository.UpdateInstrument(instrument);
        }

        public void DeleteInstrument(int instrumentId)
        {
            // Perform any necessary validation before calling the repository method to delete the instrument.
            instrumentRepository.DeleteInstrument(instrumentId);
        }

        public List<Instrument> GetAllInstruments()
        {
            List<Instrument> instruments = new List<Instrument>();
            DataTable instrumentData = instrumentRepository.GetAllInstruments();

            foreach (DataRow row in instrumentData.Rows)
            {
                Instrument instrument = new Instrument
                {
                    InstrumentId = Convert.ToInt32(row["InstrumentId"]),
                    Name = row["Name"].ToString(),
                    Type = row["Type"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    Manufacturer = row["Manufacturer"].ToString()
                };

                instruments.Add(instrument);
            }

            return instruments;
        }
    }
}
