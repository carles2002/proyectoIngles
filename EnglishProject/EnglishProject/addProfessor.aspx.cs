using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnglishProject
{
    public partial class addProfessor : System.Web.UI.Page
    {
        databaseController dbc = new databaseController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
                updateProfessors();
            }

            //output.Text = "";




        }
        protected void updateProfessors()
        {
            studentList.Items.Clear();
            DataTable dt = dbc.selectAll("professors");
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
            
            String dni = dniB.Text;
       


            //Comprobacion AQUI


            //Hacer update y verificar el resultado
            bool verification = dbc.insertProfessorInfo(name,dni);
            if (verification) { output.Text = "Prodessor: " + name +  " added correctly"; }
            else
            {
                output.Text = "SOMETHING WENT WRONG SAVING DATA";
            }
            updateProfessors();






        }



        private void HideTextBoxes()
        {
            nameB.Visible = false;
            
            dniB.Visible = false;
          
        }

        private void ShowTextBoxes()
        {
            nameB.Visible = true;
           
            dniB.Visible = true;
          

            name.Visible = false;
            
            dni.Visible = false;
          
        }

        public void deleteSelectedProfessor(object sender, EventArgs e)
        {

            String selected = studentList.SelectedValue.ToString();

            if (!dbc.deleteProfessor(selected)) { output.Text = "Something went wrong"; }
            updateProfessors();

        }



    }
}