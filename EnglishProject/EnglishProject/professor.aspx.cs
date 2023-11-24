using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnglishProject
{
    public partial class professor : System.Web.UI.Page
    {
        
        databaseController dbc = new databaseController();
        String yearText = "";
        protected void Page_Load(object sender, EventArgs e)
		{

            
           
           if (Session["level"] == null || (int)Session["level"] != 2)
           {
              
               Response.Redirect("silly.aspx"); 
           }

           
            
            dbc.connectToDB();

        }

        protected void year_TextChanged(object sender, EventArgs e)
        {
            
            yearText = year.Text; 

            DataTable dt = dbc.query("SELECT s.Name FROM subjects s INNER JOIN subjectsProf sp ON s.ID = sp.ID WHERE sp.Year = '" + yearText + "' AND sp.DNI = '" + Session["user"].ToString() + "'");

          
            subjectsList.Items.Clear();
            studentsList.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                
                subjectsList.Items.Add(row["Name"].ToString());
            }
        }


        protected void subjectsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectedID = subjectsList.SelectedValue;
            studentsList.Items.Clear();

            DataTable dt = dbc.query("SELECT * FROM subjects WHERE Name = '" + selectedID + "'");

           
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                
                string info = $"Name: {row["Name"]}, Credits: {row["Credits"]}, Semester: {row["Semester"]}, Year: {row["Year"]}, Details: {row["Details"]}";
               
                subjectInfo.Text = info;
            }
            
            dt = dbc.query("SELECT ID FROM subjects WHERE Name = '" + selectedID + "'");
            String subID = "";
            foreach (DataRow row in dt.Rows)
            {
                 subID = row["ID"].ToString();
            }
             
            yearText = year.Text;
           
            
            DataTable dtStudDNIs = dbc.query("SELECT DNI FROM subjectsStud WHERE ID = '" + subID + "' AND Year = '" + yearText + "'");
            foreach (DataRow row in dtStudDNIs.Rows)
            {

               
                
                DataTable studentNames = dbc.query("SELECT Name FROM students WHERE DNI = '" + row["DNI"].ToString() + "'");
                foreach (DataRow row1 in studentNames.Rows)
                {
                    studentsList.Items.Add(row1["Name"].ToString());
                }
                
            }







        }

    }
}