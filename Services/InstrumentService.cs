using System;
using System.Collections.Generic;
using MusicalInstrumentsCRUD.Models;
using MusicalInstrumentsCRUD.Data;
using System.Data;

namespace MusicalInstrumentsCRUD.Services
{
    // Write your services here...
    public class InstrumentService{


      public string connection;
        public InstrumentService(string connection){
            this.connection = connection;
        }

        InstrumentRepository sc = new InstrumentRepository();
        public void AddInstrument(Instrument instrument){
            sc.AddInstrument(instrument);
        }
        public Instrument GetInstrumentById(int id){
           return sc.GetInstrumentById(id);
            //return id;
        }
        public void UpdateInstrument(Instrument instrument){
            sc.UpdateInstrument(instrument);
        }
        public void DeleteInstrument(int id){
         sc.DeleteInstrument(id);
        }
        public void GetAllInstruments(){
         sc.GetAllInstruments();
        }

        
        
    }
}
