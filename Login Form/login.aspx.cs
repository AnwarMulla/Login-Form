using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Login_Form
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-PBD0B0VM\\SQLEXPRESS01; Database=ASPLogin; integrated security=yes");
            con.Open();
            string loginQuery = "select count(*) from login where username=@username and password=@password";
            SqlCommand cmd = new SqlCommand(loginQuery,con);
            cmd.Parameters.AddWithValue("@username", TextBox1.Text);
            cmd.Parameters.AddWithValue("@password", TextBox2.Text);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            if (count > 0)
            {
                Response.Write("<script>alert('login success');</script>");
            }
            else
            {
                Response.Write("<script>alert('login error');</script>");
            }
        }
    }
}