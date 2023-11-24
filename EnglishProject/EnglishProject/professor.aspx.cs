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

            
           // Verificar si la variable de sesión "level" es igual a 2
           if (Session["level"] == null || (int)Session["level"] != 2)
           {
               // Redireccionar al usuario a otra página o mostrar un mensaje de error
               Response.Redirect("silly.aspx"); 
           }

           
            
            dbc.connectToDB();

        }

        protected void year_TextChanged(object sender, EventArgs e)
        {
            
            yearText = year.Text; // Esto obtendrá el texto actual de tu TextBox

            // Ejecuta la consulta con el año especificado.
            // Asegúrate de que la tabla 'subjectsProf' tiene una columna 'ID' que se refiere a la tabla 'subjects'.
            DataTable dt = dbc.query("SELECT s.Name FROM subjects s INNER JOIN subjectsProf sp ON s.ID = sp.ID WHERE sp.Year = '" + yearText + "' AND sp.DNI = '" + Session["user"].ToString() + "'");

            // Llena la ListBox con los nombres de las asignaturas del DataTable.
            subjectsList.Items.Clear(); // Limpia los ítems existentes.
            studentsList.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                // Agrega el nombre de la asignatura como un ítem en la ListBox.
                subjectsList.Items.Add(row["Name"].ToString());
            }
        }


        protected void subjectsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtiene el ID seleccionado de la ListBox.
            string selectedID = subjectsList.SelectedValue;
            studentsList.Items.Clear();

            // Ejecuta la consulta en la base de datos para obtener la información correspondiente al ID seleccionado.
            // De nuevo, es importante utilizar parámetros para evitar inyecciones SQL, pero seguiré tu solicitud de mantener la estructura.
            DataTable dt = dbc.query("SELECT * FROM subjects WHERE Name = '" + selectedID + "'");

            // Suponiendo que solo hay una fila que coincida con el ID.
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                // Construye la información para mostrar, puedes ajustar los nombres de las columnas según sea necesario.
                string info = $"Name: {row["Name"]}, Credits: {row["Credits"]}, Semester: {row["Semester"]}, Year: {row["Year"]}, Details: {row["Details"]}";
                //Actualiza la Label con la información.
                subjectInfo.Text = info;
            }
            
            dt = dbc.query("SELECT ID FROM subjects WHERE Name = '" + selectedID + "'");
            String subID = "";
            foreach (DataRow row in dt.Rows)
            {
                 subID = row["ID"].ToString();
            }
             
            yearText = year.Text;
            // Ejecuta la consulta para obtener los DNIs de los estudiantes de la tabla subjectsStud.
            
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