using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace EnglishProject
{
    public partial class admin : System.Web.UI.Page
    {
        Boolean loaded = false;
        databaseController dbc = new databaseController();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Session["level"] = 0;
            // Verificar si la variable de sesión "level" es igual a 0
            if (Session["level"] == null || (int)Session["level"] != 0)
            {
                // Redireccionar al usuario a otra página o mostrar un mensaje de error
                Response.Redirect("silly.aspx");
            }

            dbc.connectToDB();

            if (loaded == false)
            {
                subjectsList.Items.Clear();
                DataTable dt = dbc.selectAll("subjects");

                foreach (DataRow row in dt.Rows)
                {
                    // Agrega el nombre de la asignatura como un ítem en la ListBox.
                    subjectsList.Items.Add(row["Name"].ToString());
                }
                loaded = true;
            }

           

        }
        protected void viewSubjects(object sender, EventArgs e)
        {
            
            subjectsList.Items.Clear();
            DataTable dt = dbc.selectAll("subjects");

            foreach (DataRow row in dt.Rows)
            {
                // Agrega el nombre de la asignatura como un ítem en la ListBox.
                subjectsList.Items.Add(row["Name"].ToString());
            }
        }

        protected void subjectsList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            String selectedName = subjectsList.SelectedValue;


            DataTable dt = dbc.obtainSubjectInfo(selectedName);
            output.Text = selectedName;

            foreach (DataRow dr in dt.Rows)
            {
                idb.Text = dr["ID"].ToString();
                nameb.Text = dr["Name"].ToString();
                creditsb.Text = dr["Credits"].ToString();
                semesterb.Text = dr["Semester"].ToString();
                yearb.Text = dr["Year"].ToString();
                detailsb.Text = dr["Details"].ToString();
            }

            loadStudents();
            
        }
        protected void loadStudents()
        {
            String selectedName = subjectsList.SelectedValue;
            //Obtener el ID de la asignatura y cargar los alumnos-----------------------
            DataTable dt = dbc.query("SELECT ID FROM subjects WHERE Name = '" + selectedName + "'");

            String subID = "";
            foreach (DataRow dr in dt.Rows)
            {
                subID = dr["ID"].ToString();
            }
            output.Text = subID;

            dt = dbc.query("SELECT DNI FROM subjectsStud WHERE ID = '" + subID + "'");
            String DNI = "";
            studentsList.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DNI = dr["DNI"].ToString();
                studentsList.Items.Add(dr["DNI"].ToString());
            }
        }

        protected void students_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

            protected void saveChanges(object sender, EventArgs e)
        {
      
            DataTable dt = dbc.obtainSubjectInfo(subjectsList.SelectedValue);

            foreach (DataRow dr in dt.Rows)
            {


                String id = idb.Text;
                String name = nameb.Text;
                String credits = creditsb.Text;
                String semester = semesterb.Text;
                String year = yearb.Text;
                String details = detailsb.Text;


                //Comprobacion AQUI


                //Hacer update y verificar el resultado
                bool verification = dbc.updateSubjectInfo(id, name, credits, semester, year, details);
                if (verification) { output.Text = "todo bien"; }
                else
                {
                    output.Text = "SOMETHING WENT WRONG SAVING DATA";
                }

            }
  
        }


        //STUDENT -------------------------------------------------------------------
        protected void studDNI_add(object sender, EventArgs e)
        {

            String selectedName = subjectsList.SelectedValue;

            DataTable dt = dbc.query("SELECT ID FROM subjects WHERE Name = '" + selectedName + "'");

            String subID = "";
            foreach (DataRow dr in dt.Rows)
            {
                subID = dr["ID"].ToString();
            }
            
            

            Boolean ver =  dbc.addStudentToSubject(subID, studDNI.Text.ToString(), addyear.Text.ToString());
             if (ver==false)
            {
                output.Text= "An error has occurred adding the Student";
            }
             loadStudents();
        }

        protected void deleteStudentSubj(object sender, EventArgs e)
        {
            String DNI = studentsList.SelectedValue;
            String subID = subjectsList.SelectedValue;
            DataTable dt = dbc.query("DELETE FROM subjectsStud WHERE DNI = '" + DNI + "' AND ID = '" + subID + "'");

            loadStudents();
        }



        //PROFESOR---------------------------------------------------------------------------------

        protected void loadProfessors()
        {
            String selectedName = subjectsList.SelectedValue;
            //Obtener el ID de la asignatura y cargar los alumnos-----------------------
            DataTable dt = dbc.query("SELECT ID FROM subjects WHERE Name = '" + selectedName + "'");

            String subID = "";
            foreach (DataRow dr in dt.Rows)
            {
                subID = dr["ID"].ToString();
            }
            output.Text = subID;

            dt = dbc.query("SELECT DNI FROM subjectsProf WHERE ID = '" + subID + "'");
            String DNI = "";
            studentsList.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DNI = dr["DNI"].ToString();
                studentsList.Items.Add(dr["DNI"].ToString());
            }
        }
        protected void profDNI_add(object sender, EventArgs e)
        {

            

            DataTable dt = dbc.query("SELECT ID FROM subjects WHERE Name = '" + selectedName + "'");

            String subID = "";
            foreach (DataRow dr in dt.Rows)
            {
                subID = dr["ID"].ToString();
            }


            
            Boolean ver = dbc.addProfessorToSubject(subID, DNIprof.Text.ToString(), addyear.Text.ToString());
            if (ver == false)
            {
                output.Text = "An error has occurred adding the Student";
            }
            loadStudents();
        }

        protected void deleteProfessorSubj(object sender, EventArgs e)
        {
            String DNI = studentsList.SelectedValue;
            String subID = subjectsList.SelectedValue;
            DataTable dt = dbc.query("DELETE FROM subjectsProf WHERE DNI = '" + DNI + "' AND ID = '" + subID + "'");

            loadStudents();
        }


    }
}