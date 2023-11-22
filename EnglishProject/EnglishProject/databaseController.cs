using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
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


    }
}