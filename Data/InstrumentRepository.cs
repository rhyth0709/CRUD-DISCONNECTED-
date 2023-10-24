using System;
using System.Data;
using System.Data.SqlClient;
using MusicalInstrumentsCRUD.Models;
namespace MusicalInstrumentsCRUD.Data

{

    // Write your CRUD operations here inside InstrumentRepository Class

    // Method names Should be

    // 1. AddInstrument

    // 2. GetInstrumentById

    // 3. UpdateInstrument

    // 4. DeleteInstrument

    // 5. GetAllInstruments

    public class InstrumentRepository

    {

      public static string str;


       public InstrumentRepository(){

       }

     

       public void AddInstrument(Instrument instrument)

        {

            SqlConnection con=null;
            SqlDataAdapter adapter=null;    
            DataSet ds=null;
            try{

                con=new SqlConnection(str);
                adapter=new SqlDataAdapter("select * from instruments",con);
                SqlCommandBuilder cmd=new SqlCommandBuilder(adapter);
                ds=new DataSet();
                adapter.Fill(ds,"prodTable");
                DataRow dr=ds.Tables["prodTable"].NewRow();
                dr[0]=instrument.InstrumentId;
                dr[1]=instrument.Name;
                dr[2]=instrument.Type;
                dr[3]=instrument.Price;
                dr[4]=instrument.Manufacturer;
                ds.Tables["prodTable"].Rows.Add(dr);
                adapter.Update(ds,"prodTable");
            }

            catch(Exception e)
            {

                Console.WriteLine("Failed to connect to the database. Error message: " + e);

            }
           

        }

        public  Instrument GetInstrumentById(int instrumentId)

        {

           Instrument instrument = new Instrument();
         

            SqlConnection con=null;
            SqlDataAdapter adapter=null;
            DataSet ds=null;

            try{

                con=new SqlConnection(str);
                adapter=new SqlDataAdapter("select * from instruments",con);
                SqlCommandBuilder cmd=new SqlCommandBuilder(adapter);
                ds=new DataSet();
                adapter.Fill(ds,"t");
                foreach(DataRow dr in ds.Tables["t"].Rows)
                {
                    if(Convert.ToInt32(dr[0])==instrumentId)
                    {

                       // Instrument instrument;
                         Console.WriteLine("Name: "+dr[1]+"Type: "+dr[2]+" Price: "+dr[3]+"Manufacturer: "+dr[4]);
                         instrument.Name = dr[1].ToString();
                         instrument.Type = dr[2].ToString();
                         instrument.Price = Convert.ToDecimal(dr[3].ToString());
                         instrument.Manufacturer = dr[4].ToString();
                         return instrument;
                        break;
                    }

                }

            }catch(Exception e)
                {
                    Console.WriteLine("Failed to connect to the database. Error message: " + e);
                }
                return instrument;
        }

        public void UpdateInstrument(Instrument instrument)

        {
            SqlConnection con=null;
            SqlDataAdapter adapter=null;
            DataSet ds=null;
            try{

                con=new SqlConnection(str);
                adapter=new SqlDataAdapter("select * from instruments",con);
                SqlCommandBuilder cmd=new SqlCommandBuilder(adapter);
                ds=new DataSet();
                adapter.Fill(ds,"prodTable");
                foreach(DataRow dr in ds.Tables["prodTable"].Rows)
                {
                    if(Convert.ToInt32(dr[0])==instrument.InstrumentId)
                    {
                        dr[1]=instrument.Name;
                        dr[2]=instrument.Type;
                        dr[3]=instrument.Price;
                        dr[4]=instrument.Manufacturer;
                        break;
                    }
                }
                adapter.Update(ds,"prodTable");
                

               

        }

        catch(Exception e)

        {

            Console.WriteLine("Failed to connect to the database. Error message: " + e);

        }
        

        }

        public  void DeleteInstrument(int instrumentId)

        {

            Console.WriteLine("DELETE--------------------------");

            SqlConnection conn = null;
            SqlDataAdapter adapter = null;
            DataSet ds = null;
            try{
                conn = new SqlConnection(str);
                adapter= new SqlDataAdapter("select * from instruments",conn);
                SqlCommandBuilder cms = new SqlCommandBuilder(adapter);
                ds=new DataSet();
                adapter.Fill(ds,"prodTable");         
                foreach(DataRow dr in ds.Tables["prodTable"].Rows)
                {
                    if(Convert.ToInt32(dr[0])==instrumentId)
                    {
                       ds.Tables["prodTable"].Rows.Remove(dr);
                        break;
                     }

                }

            }

            catch (Exception e){

                  Console.WriteLine("Failed to connect to the database. Error message: " + e);

            }


        }

        public void GetAllInstruments()

        {

        SqlConnection con=null;
        SqlDataAdapter adapter=null; 
        DataSet ds=null;
            try{
                con=new SqlConnection(str);
               adapter=new SqlDataAdapter("select * from instruments",con);
                SqlCommandBuilder cmd=new SqlCommandBuilder(adapter);
                ds=new DataSet();
                adapter.Fill(ds,"t");
                foreach(DataRow dr in ds.Tables["t"].Rows)
                {
                        Console.WriteLine("Id:"+dr[0]+"Name: "+dr[1]+"Type: "+dr[2]+" Price: "+dr[3]+"Manufacturer: "+dr[4]);
                }
            }catch(Exception e)
                {
                    Console.WriteLine("Failed to connect to the database. Error message: " + e);
                }

           

        }

    }

}

 




     


