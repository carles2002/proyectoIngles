using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Xml.Linq;

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

        public bool insertStudentInfo(String name, String surname, String DNI, String DOB, String nationality, String address)
        {
            
            DataTable dt = new DataTable();
            dt = obtainStudentInfo(DNI);
            foreach (DataRow dr in dt.Rows)
            {
                if (DNI == dr["DNI"].ToString()) { return false; }
            }
                //Se llama al metodo para hacer consultas
            String sentence = "INSERT INTO students (DNI, Name, Surname, DOB, Nationality, Address) VALUES ('" + DNI + "', '" + name + "', '" + surname + "', '" + DOB + "', '" + nationality + "', '" + address + "')";

            
            dt = query(sentence);
            

            return true;
        }

        public bool deleteStudent( String DNI)
        {

            DataTable dt = new DataTable();
            dt = obtainStudentInfo(DNI);
            foreach (DataRow dr in dt.Rows)
            {
                if (DNI != dr["DNI"].ToString()) { return false; }
            }
            //Se llama al metodo para hacer consultas
            string sentence = "DELETE FROM students WHERE DNI = '" + DNI + "'";
            dt = query(sentence);
            sentence = "DELETE FROM subjectsStud WHERE DNI = '" + DNI + "'";
            dt = query(sentence);

            return true;
        }

        public DataTable obtainSubjectInfo(String Name)
        {
            //Se llama al metodo para hacer consultas
            String sentence = "SELECT * FROM subjects WHERE Name = '" + Name + "'";

            DataTable dt = new DataTable();
            dt = query(sentence);

            return dt;
        }
        public bool updateSubjectInfo(String ID, String name, String credits, String semester, String year, String details)
        {

            bool verified = true;
            //Se llama al metodo para hacer consultas
            string sentence = "UPDATE subjects SET ID = '" + ID + "', Name = '" + name + "', Credits = '" + credits + "', Semester = '" + semester + "', Year = '" + year + "', Details = '" + details + "' WHERE ID = '" + ID + "'";

            DataTable dt = new DataTable();
            dt = query(sentence);
            if (dt.Rows != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (ID != dr["Id"].ToString()) { verified = false; }
                    if (name != dr["Name"].ToString()) { verified = false; }
                    if (credits != dr["Credits"].ToString()) { verified = false; }
                    if (semester != dr["Semester"].ToString()) { verified = false; }
                    if (year != dr["Year"].ToString()) { verified = false; }
                    if (details != dr["Details"].ToString()) { verified = false; }
                }

            }
            else { verified = false; }

            return verified;
        }



        public bool addStudentToSubject(String ID, String DNI, String Year)
        {

            string verifySentence = "SELECT DNI FROM subjectsStud  WHERE DNI = '" + DNI + "' AND ID = '" + ID + "'";
            DataTable dtVerify = query(verifySentence);

            // If any rows are returned, the DNI already exists, so we return false
            if (dtVerify.Rows.Count > 0)
            {
                return false; // DNI exists, so we cannot add a new student with the same DNI
            }
            // Construct the INSERT SQL statement


            string sentence = "INSERT INTO subjectsStud (ID, DNI, Year) VALUES ('" + ID + "', '" + DNI + "', '" + Year + "')";
            
            
            DataTable dt = query(sentence);
            // Execute the query and check the result
            // Assuming 'executeNonQuery' is a method that executes an SQL statement and returns the number of rows affected
            return true;
        }

        public bool addProfessorToSubject(String ID, String DNI, String Year)
        {

            string verifySentence = "SELECT DNI FROM subjectsProf  WHERE DNI = '" + DNI + "' AND ID = '" + ID + "'AND Year = '" + Year + "'";
            DataTable dtVerify = query(verifySentence);

            // If any rows are returned, the DNI already exists, so we return false
            if (dtVerify.Rows.Count > 0)
            {
                return false; // DNI exists, so we cannot add a new student with the same DNI
            }
            // Construct the INSERT SQL statement


            string sentence = "INSERT INTO subjectsProf (ID, DNI, Year) VALUES ('" + ID + "', '" + DNI + "', '" + Year + "')";


            DataTable dt = query(sentence);
            // Execute the query and check the result
            // Assuming 'executeNonQuery' is a method that executes an SQL statement and returns the number of rows affected
            return true;
        }

        public bool insertProfessorInfo(String name,  String DNI)
        {

            DataTable dt = new DataTable();
            dt = query("SELECT DNI FROM professors  WHERE DNI = '" + DNI +"'");
            foreach (DataRow dr in dt.Rows)
            {
                if (DNI == dr["DNI"].ToString()) { return false; }
            }
            //Se llama al metodo para hacer consultas
            String sentence = "INSERT INTO professors (DNI, Name) VALUES ('" + DNI + "', '" + name +"')";


            dt = query(sentence);


            return true;
        }

        public bool deleteProfessor(String DNI)
        {

            DataTable dt = new DataTable();
            dt = query("SELECT DNI FROM professors  WHERE DNI = '" + DNI + "'");
            foreach (DataRow dr in dt.Rows)
            {
                if (DNI != dr["DNI"].ToString()) { return false; }
            }
            //Se llama al metodo para hacer consultas
            string sentence = "DELETE FROM professors WHERE DNI = '" + DNI + "'";
            dt = query(sentence);
            sentence = "DELETE FROM subjectsProf WHERE DNI = '" + DNI + "'";
            dt = query(sentence);

            return true;
        }




    }
}