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
		protected void Page_Load(object sender, EventArgs e)
		{
            /*
            string DBpath = Server.MapPath("~/database.db");
            LabelDBPath.Text = DBpath;

			SQLiteConnection conn = new
			SQLiteConnection("Data Source=" + DBpath +
			";Version=3;");
			conn.Open();


			//COMANDOS
			String query = @"SELECT * FROM users";
            SQLiteCommand comm = new SQLiteCommand(query,conn);

            //READ DATABASE
            SQLiteDataReader reader = comm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            */
            databaseController dbc = new databaseController();
            dbc.connectToDB();
            DataTable dt = dbc.selectAll("users");
            foreach (DataRow dr in dt.Rows)
            {
                LabelDBPath.Text = LabelDBPath.Text+dr["user"].ToString();
                LabelDBPath.Text = LabelDBPath.Text + dr["password"].ToString();
                LabelDBPath.Text = LabelDBPath.Text + dr["level"].ToString();
            }

        }
    }
}