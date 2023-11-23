using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnglishProject
{
    public partial class addStudent : System.Web.UI.Page
    {
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

            if (!IsPostBack) //Para saber si se carga por primera vez o es al volver con datos
            {
                // Ocultar los TextBox al cargar la página
                ShowTextBoxes();
                updateStudents();
            }

            //output.Text = "";
            

           

        }
        protected void updateStudents()
        {
            studentList.Items.Clear();
            DataTable dt = dbc.selectAll("students");
            foreach (DataRow dr in dt.Rows)
            {
                String dni = dr["DNI"].ToString();
                studentList.Items.Add(dni);
            }
        }
        
        protected void saveChanges(object sender, EventArgs e)
        {
            // Mostrar los TextBox cuando se hace clic en el botón
            
                
                String name = nameB.Text;
                String surname = surnameB.Text;
                String dni = dniB.Text;
                String dob = dobb.Text;
                String nationality = nationalityb.Text;
                String address = addressb.Text;


                //Comprobacion AQUI


                //Hacer update y verificar el resultado
                bool verification = dbc.insertStudentInfo(name, surname, dni, dob, nationality, address);
                if (verification) { output.Text= "Student: "+name+" "+surname+" added correctly"; }
                else
                {
                    output.Text = "SOMETHING WENT WRONG SAVING DATA";
                }
            updateStudents();



            


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
            dniB.Visible = true;
            dobb.Visible = true;
            nationalityb.Visible = true;
            addressb.Visible = true;

            name.Visible = false;
            surname.Visible = false;
            dni.Visible = false;
            dob.Visible = false;
            nationality.Visible = false;
            address.Visible = false;
        }

        public void deleteSelectedStudent(object sender, EventArgs e)
        {
            
            String selected = studentList.SelectedValue.ToString();
            
           if(!dbc.deleteStudent(selected)) { output.Text = "Something went wrong"; }
            updateStudents();

        }
       
        


    }
}