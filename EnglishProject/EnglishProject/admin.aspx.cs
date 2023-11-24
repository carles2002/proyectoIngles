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
        static String selectedSub = "";
        databaseController dbc = new databaseController();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            
            if (Session["level"] == null || (int)Session["level"] != 0)
            {
                
                Response.Redirect("silly.aspx");
            }

            dbc.connectToDB();
            if (!IsPostBack) 
            {
                viewSubjects();
                
            }




        }
        protected void viewSubjects()
        {
            
            subjectsList.Items.Clear();
            DataTable dt = dbc.selectAll("subjects");

            foreach (DataRow row in dt.Rows)
            {
                
                subjectsList.Items.Add(row["Name"].ToString());
            }
        }

        protected void subjectsList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            String selectedName = subjectsList.SelectedValue;
            admin.selectedSub = selectedName;


            DataTable dt = dbc.obtainSubjectInfo(selectedName);
           

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
            loadProfessors();   
            
        }
        protected void loadStudents()
        {
            String selectedName = selectedSub;
           
            DataTable dt = dbc.query("SELECT ID FROM subjects WHERE Name = '" + selectedName + "'");

            String subID = "";
            foreach (DataRow dr in dt.Rows)
            {
                subID = dr["ID"].ToString();
            }
            

            dt = dbc.query("SELECT DNI FROM subjectsStud WHERE ID = '" + subID + "'");
            String DNI = "";
            studentsList.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DNI = dr["DNI"].ToString();
                studentsList.Items.Add(DNI);
                
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


                bool verification = dbc.updateSubjectInfo(id, name, credits, semester, year, details);
                if (verification) { output.Text = "todo bien"; }
                else
                {
                    output.Text = "SOMETHING WENT WRONG SAVING DATA";
                }

            }
  
        }


     
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
            
            String subID = selectedSub;

            DataTable dt = dbc.query("SELECT ID FROM subjects WHERE Name = '" + subID + "'");

            
            foreach (DataRow dr in dt.Rows)
            {
                subID = dr["ID"].ToString();
            }

            
            dt = dbc.query("DELETE FROM subjectsStud WHERE DNI = '" + DNI + "' AND ID = '" + subID + "'");

            loadStudents();
        }



        

        protected void loadProfessors()
        {
            profList.Items.Clear();
            String selectedName = selectedSub;
          
            DataTable dt = dbc.query("SELECT ID FROM subjects WHERE Name = '" + selectedName + "'");

            String subID = "";
            foreach (DataRow dr in dt.Rows)
            {
                subID = dr["ID"].ToString();
            }
            

            dt = dbc.query("SELECT DNI FROM subjectsProf WHERE ID = '" + subID + "'");
            String DNI = "";
            
            foreach (DataRow dr in dt.Rows)
            {
                DNI = dr["DNI"].ToString();
                profList.Items.Add(dr["DNI"].ToString());
            }
        }
        protected void profDNI_add(object sender, EventArgs e)
        {


            String selectedName = selectedSub;
            DataTable dt = dbc.query("SELECT ID FROM subjects WHERE Name = '" + selectedName + "'");

            String subID = "";
            foreach (DataRow dr in dt.Rows)
            {
                subID = dr["ID"].ToString();
            }


            
            Boolean ver = dbc.addProfessorToSubject(subID, DNIprof.Text.ToString(), yearSubProf.Text.ToString());
            if (ver == false)
            {
                output.Text = "An error has occurred adding the Student";
            }
            loadProfessors();
        }

        protected void deleteProfessorSubj(object sender, EventArgs e)
        {
            String DNI = profList.SelectedValue;
            String selectedName = selectedSub;
            DataTable dt = dbc.query("SELECT ID FROM subjects WHERE Name = '" + selectedName + "'");

            String subID = "";
            foreach (DataRow dr in dt.Rows)
            {
                subID = dr["ID"].ToString();
            }
            
            dt = dbc.query("DELETE FROM subjectsProf WHERE DNI = '" + DNI + "' AND ID = '" + subID + "'");

            loadProfessors();
        }

        protected void goToAddStudent(object sender, EventArgs e)
        {
            Response.Redirect("addStudent.aspx");
        }
        protected void goToAddProfessor(object sender, EventArgs e)
        {
            Response.Redirect("addProfessor.aspx");
        }


    }
}