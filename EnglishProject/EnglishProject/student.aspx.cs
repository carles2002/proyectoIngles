using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnglishProject
{
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si la variable de sesión "level" es igual a 1
            if (Session["level"] == null || (int)Session["level"] != 1)
            {
                // Redireccionar al usuario a otra página o mostrar un mensaje de error
                Response.Redirect("silly.aspx"); 
            }
        }
    }
}