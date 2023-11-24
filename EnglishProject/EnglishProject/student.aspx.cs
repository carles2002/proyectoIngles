using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace EnglishProject
{
    public partial class student : System.Web.UI.Page
    {
        databaseController dbc = new databaseController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (Session["level"] == null || (int)Session["level"] != 1)
            {
              
                Response.Redirect("silly.aspx"); 
            }

            

            if (!IsPostBack) 
            {
                
                HideTextBoxes();
            }

            
            
            if (Session["user"] !=null)
            {
                
                dbc.connectToDB();
                DataTable dt = dbc.obtainStudentInfo(Session["user"].ToString());

                foreach (DataRow dr in dt.Rows)
                {
                    name.Text = dr["Name"].ToString();
                    surname.Text = dr["Surname"].ToString();
                    dni.Text = dr["DNI"].ToString();
                    dob.Text = dr["DOB"].ToString();
                    nationality.Text = dr["Nationality"].ToString();
                    address.Text = dr["Address"].ToString();
                }
            }
        }
        protected void change_information_Click(object sender, EventArgs e)
        {
            
            DataTable dt = dbc.obtainStudentInfo(Session["user"].ToString());

            ShowTextBoxes();
            foreach (DataRow dr in dt.Rows)
            {
                nameB.Text = dr["Name"].ToString();
                surnameB.Text = dr["Surname"].ToString();
                dniB.Text = dr["DNI"].ToString();
                dobb.Text = dr["DOB"].ToString();
                nationalityb.Text = dr["Nationality"].ToString();
                addressb.Text = dr["Address"].ToString();
            }
        }
        protected void saveChanges(object sender, EventArgs e)
        {
            
            DataTable dt = dbc.obtainStudentInfo(Session["user"].ToString());

            foreach (DataRow dr in dt.Rows)
            {
               

                String name = nameB.Text;
                String surname = surnameB.Text;
                String dni= dniB.Text;
                String dob = dobb.Text;
                String nationality= nationalityb.Text;
                String address= addressb.Text;


                


                
                bool verification = dbc.updateStudentInfo(name, surname, dni, dob, nationality, address);
                if (verification) { Response.Redirect("student.aspx"); } else
                {
                    output.Text = "SOMETHING WENT WRONG SAVING DATA";
                }
                 
                
                
                
            }
            
            
        }

        private void HideTextBoxes()
        {
            nameB.Visible = false;
            surnameB.Visible = false;
            dniB.Visible = false;
            dobb.Visible = false;
            nationalityb.Visible = false;
            addressb.Visible = false;
        }

        private void ShowTextBoxes()
        {
            nameB.Visible = true;
            surnameB.Visible = true;
            
            dobb.Visible = true;
            nationalityb.Visible = true;
            addressb.Visible = true;

            name.Visible = false;
            surname.Visible = false;
            
            dob.Visible = false;
            nationality.Visible = false;
            address.Visible = false;
        }

        protected void year_TextChanged(object sender, EventArgs e)
        {
            string yearText = year.Text; 

           
            DataTable dt = dbc.query("SELECT s.* FROM subjects s INNER JOIN subjectsStud ss ON s.ID = ss.ID WHERE ss.Year = '" + yearText + "' AND ss.DNI = '" + Session["user"].ToString() + "'");

            
            subjectsList.Items.Clear(); 
            foreach (DataRow row in dt.Rows)
            {
              
                subjectsList.Items.Add(row["name"].ToString());
            }
        }


        protected void subjectsList_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string selectedID = subjectsList.SelectedValue;
             DataTable dt = dbc.query("SELECT * FROM subjects WHERE Name = '" + selectedID + "'");

           
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                
                string info = $"Name: {row["Name"]}, Credits: {row["Credits"]}, Semester: {row["Semester"]}, Year: {row["Year"]}, Details: {row["Details"]}";
               
                subjectInfo.Text = info;
            }
        }




    }
}