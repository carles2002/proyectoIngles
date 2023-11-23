using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnglishProject
{
    public partial class student : System.Web.UI.Page
    {
        databaseController dbc = new databaseController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            // Verificar si la variable de sesión "level" es igual a 1
            if (Session["level"] == null || (int)Session["level"] != 1)
            {
                // Redireccionar al usuario a otra página o mostrar un mensaje de error
                Response.Redirect("silly.aspx"); 
            }

            

            if (!IsPostBack) //Para saber si se carga por primera vez o es al volver con datos
            {
                // Ocultar los TextBox al cargar la página
                HideTextBoxes();
            }

            //Mostrar informacion del alumno
            Session["user"] = "123456789B";
            if (Session["user"] !=null)
            {
                //Cargar informacion del alumno
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
            // Mostrar los TextBox cuando se hace clic en el botón
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
            // Mostrar los TextBox cuando se hace clic en el botón
            DataTable dt = dbc.obtainStudentInfo(Session["user"].ToString());

            foreach (DataRow dr in dt.Rows)
            {
               

                String name = nameB.Text;
                String surname = surnameB.Text;
                String dni= dniB.Text;
                String dob = dobb.Text;
                String nationality= nationalityb.Text;
                String address= addressb.Text;


                //Comprobacion AQUI


                //Hacer update y verificar el resultado
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
            //dniB.Visible = true;
            dobb.Visible = true;
            nationalityb.Visible = true;
            addressb.Visible = true;

            name.Visible = false;
            surname.Visible = false;
            //dni.Visible = false;
            dob.Visible = false;
            nationality.Visible = false;
            address.Visible = false;
        }

        protected void year_TextChanged(object sender, EventArgs e)
        {
            string yearText = year.Text; // Esto obtendrá el texto actual de tu TextBox

            // Ejecuta la consulta con el año especificado.
            DataTable dt = dbc.query("SELECT s.* FROM subjects s INNER JOIN subjectsStud ss ON s.ID = ss.ID WHERE ss.Year = '" + yearText + "' AND ss.DNI = '" + Session["user"].ToString() + "'");

            // Llena la ListBox con los datos del DataTable.
            subjectsList.Items.Clear(); // Limpia los ítems existentes.
            foreach (DataRow row in dt.Rows)
            {
                // Suponiendo que tienes una columna que quieres mostrar, por ejemplo 'SubjectName'.
                string displayText = row["ID"].ToString(); // Ajusta 'SubjectName' al nombre de tu columna.
                string value = row["ID"].ToString(); // Ajusta 'ID' si deseas usar otro valor como el valor del ítem.

                ListItem item = new ListItem(row["name"].ToString());
                subjectsList.Items.Add(item);
            }
        }


        protected void subjectsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtiene el ID seleccionado de la ListBox.
            string selectedID = subjectsList.SelectedValue;

            // Ejecuta la consulta en la base de datos para obtener la información correspondiente al ID seleccionado.
            // De nuevo, es importante utilizar parámetros para evitar inyecciones SQL, pero seguiré tu solicitud de mantener la estructura.
            DataTable dt = dbc.query("SELECT * FROM subjects WHERE Name = '" + selectedID + "'");

            // Suponiendo que solo hay una fila que coincida con el ID.
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                // Construye la información para mostrar, puedes ajustar los nombres de las columnas según sea necesario.
                string info = $"Name: {row["Name"]}, Credits: {row["Credits"]}, Semester: {row["Semester"]}, Year: {row["Year"]}, Details: {row["Details"]}";
                // Actualiza la Label con la información.
                subjectInfo.Text = info;
            }
        }





    }
}