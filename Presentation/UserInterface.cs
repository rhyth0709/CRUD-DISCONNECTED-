using System;
using System.Collections.Generic;
using MusicalInstrumentsCRUD.Models;
using MusicalInstrumentsCRUD.Services;
using MusicalInstrumentsCRUD.Data;

namespace MusicalInstrumentsCRUD.Presentation
{
    // Write your console user interface here...
    public class UserInterface{


        private string connection;
        public UserInterface(string connection){

            this.connection = connection;

        }

        public void Run(){

            while(true)
            {

              InstrumentRepository.str =connection;
              Instrument instrument=new Instrument();
              InstrumentService ins=new InstrumentService(connection);
              Console.WriteLine("1.Add Instrumnet");
              Console.WriteLine("2. Get instrument by id");
              Console.WriteLine("3. Update instrument");
              Console.WriteLine("4. Delete instrument");
              Console.WriteLine("5. Get instruments");
               int input = Convert.ToInt32(Console.ReadLine());

        switch(input){
                  
                case 1:
                instrument.InstrumentId=Convert.ToInt32(Console.ReadLine());
                instrument.Name=Console.ReadLine();
                instrument.Type=Console.ReadLine();
                instrument.Price=Convert.ToDecimal(Console.ReadLine());
                instrument.Manufacturer=Console.ReadLine();
                ins.AddInstrument(instrument);
                break;
               case 2:
                int instrumentId=Convert.ToInt32(Console.ReadLine());
                ins.GetInstrumentById(instrumentId);
                break; 
                case 3:
                instrument.InstrumentId=Convert.ToInt32(Console.ReadLine());
                instrument.Name=Console.ReadLine();
                instrument.Type=Console.ReadLine();
                instrument.Price=Convert.ToDecimal(Console.ReadLine());
                instrument.Manufacturer=Console.ReadLine();
                ins.UpdateInstrument(instrument);
                break;
                case 4:
                int id=Convert.ToInt32(Console.ReadLine());
                ins.DeleteInstrument(id);
                break;
                case 5:
                ins.GetAllInstruments();
                break;
                default:
                break;

                }

            }
            
        }


    }

}
