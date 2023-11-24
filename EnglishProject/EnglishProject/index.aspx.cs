using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnglishProject
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        public void loginbtn(object sender, EventArgs e)
        {
            Response.Redirect("loginPAge.aspx");
        }

        public void logo(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}