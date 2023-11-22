using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace EnglishProject
{
    public class databaseController { 


        public String DBpath = "";
        private SQLiteConnection conn = new SQLiteConnection();
        public databaseController() {
             this.DBpath = HttpContext.Current.Server.MapPath("~/database.db");
                
        }
        public void connectToDB()
        {
            conn = new SQLiteConnection("Data Source=" + DBpath +
            ";Version=3;");
            conn.Open();
        }
       
        public DataTable selectAll(String table)
        {
            //COMANDOS
            String query = @"SELECT * FROM "+table;
            SQLiteCommand comm = new SQLiteCommand(query, conn);

            //READ DATABASE
            SQLiteDataReader reader = comm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
        public DataTable query(String query)
        {
            
            
            SQLiteCommand comm = new SQLiteCommand(query, conn);

            //READ DATABASE
            SQLiteDataReader reader = comm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            return dt;
        }

        //Metodo que obtiene los datos del alumno
        public DataTable obtainStudentInfo(String DNI)
        {
            //Se llama al metodo para hacer consultas
            String sentence = "SELECT * FROM students WHERE DNI = '" + DNI + "'";

            DataTable dt = new DataTable();
            dt = query(sentence);

            return dt;
        }
        public bool updateStudentInfo(String name,String surname,String DNI, String DOB, String nationality, String address)
        {
            
            bool verified = true;
            //Se llama al metodo para hacer consultas
            string sentence = "UPDATE students SET Name = '" + name + "', Surname = '" + surname + "', DOB = '" + DOB + "', Nationality = '" + nationality + "', Address = '" + address + "' WHERE DNI = '" + DNI + "'";

            DataTable dt = new DataTable();
            dt = query(sentence);
            if (dt.Rows != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (name != dr["Name"].ToString()) { verified = false; }
                    if (surname != dr["Surname"].ToString()) { verified = false; }
                    if (DOB != dr["DOB"].ToString()) { verified = false; }
                    if (nationality != dr["Nationality"].ToString()) { verified = false; }
                    if (address != dr["Address"].ToString()) { verified = false; }
                    if (DNI != dr["DNI"].ToString()) { verified = false; }
                }

            }
            else { verified = false; }

            return verified;
        }


    }
}