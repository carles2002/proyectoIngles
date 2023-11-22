using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnglishProject
{
    public partial class silly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        public void safe(object sender, EventArgs e)
        {
            Response.Redirect("loginPage.aspx");
        }
        
    }
}