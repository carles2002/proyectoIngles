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
      
        protected void Login_Click(object sender, EventArgs e)
        {
            string userDNI = UserDNITextBox.Text;
            string password = PasswordTextBox.Text;

            try
            {
                Session["level"] = "";
                
                DataTable dt = dbc.query("SELECT * FROM users WHERE user = '" + userDNI + "' AND password = '" + password + "'");
                if (dt.Rows != null)
                {
                   
                    foreach (DataRow dr in dt.Rows)
                    {
                        

                        
                        Session["user"] = dr["user"].ToString();
                        Session["level"] = Convert.ToInt32(dr["level"]);

                    }
                    
                    
                    int level = (int)Session["level"]; 
                    switch (level)
                    {
                        case 0:
                            
                            Response.Redirect("admin.aspx");
                            break;
                        case 1:
                            
                            Response.Redirect("student.aspx");
                            break;
                        
                        case 2:
                            
                            Response.Redirect("professor.aspx");
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
                
                LabelDBPath.Text = "Error: No se ha encontrado al usuario en la BD o la conexión ha fallado" ;
                Panel1.Visible = true;
            }




        }
    }
}