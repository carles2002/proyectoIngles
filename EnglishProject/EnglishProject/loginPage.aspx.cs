using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnglishProject
{
	public partial class LoginPage : System.Web.UI.Page
	{
        databaseController dbc = new databaseController();
        protected void Page_Load(object sender, EventArgs e)
		{
         
           
            dbc.connectToDB();
        
        }
        /*LOGICA DEL LOGIN*/
        protected void Login_Click(object sender, EventArgs e)
        {
            string userDNI = UserDNITextBox.Text;
            string password = PasswordTextBox.Text;

            try
            {
                // Sentencia sql que busca al usuario en la bd
                DataTable dt = dbc.query("SELECT * FROM users WHERE user = '" + userDNI + "' AND password = '" + password + "'");
                if (dt.Rows != null)
                {
                    //Obtener datos de la tabla de la bd 
                    foreach (DataRow dr in dt.Rows)
                    {
                        LabelDBPath.Text = LabelDBPath.Text + dr["user"].ToString();
                        LabelDBPath.Text = LabelDBPath.Text + dr["password"].ToString();
                        LabelDBPath.Text = LabelDBPath.Text + dr["level"].ToString();

                        // Guardar los valores en la sesión
                        Session["user"] = dr["user"].ToString();
                        Session["level"] = Convert.ToInt32(dr["level"]);

                    }
                    
                    
                    int level = (int)Session["level"]; 
                    switch (level)
                    {
                        case 0:
                            //ADMIN
                            break;
                        case 1:
                            //STUDENT
                            Response.Redirect("student.aspx");
                            break;
                        
                        case 2:
                            //PROFESSOR
                            Response.Redirect("student.aspx");
                            break;
                        default:
                            LabelDBPath.Text = "ERROR: NO LEVEL";
                            break;
                    }
                    



                }
                else
                {
                    Session["user"] = null;
                    Session["level"] = null;

                    LabelDBPath.Text = "There is not a user registered with that data";
                }

            }
            catch (Exception ex)
            {
                // Manejo de excepciones aquí
                // Puedes imprimir el mensaje de la excepción o realizar cualquier otra acción necesaria.
                // Por ejemplo:
                LabelDBPath.Text = "Error: No se ha encontrado al usuario en la BD o la conexión ha fallado" ;
            }




        }
    }
}