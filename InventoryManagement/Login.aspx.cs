using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    MySqlConnection sqlcon = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mySQLconn"].ConnectionString);

    //static SqlConnection sqlcon = new SqlConnection("Server=localhost;Port=3306;Database=pipds;User=root;Password;Option=3;");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        sqlcon.Open();
        string checkquery = "Select count(1) from Login where Username='"+txtUserName.Text+"' and Password='"+txtPassword.Text.Trim()+"'";
        MySqlCommand cmd = new MySqlCommand(checkquery, sqlcon);
        int count = Convert.ToInt32(cmd.ExecuteScalar());
        if (count == 1)
        {
            //lblerror.Text = "login Successful!";

            Session["user"] = txtUserName.Text.Trim();
            Response.Redirect("Home.aspx");
            
        }
        else
        {
            lblerror.Text = "Login Failed. Incorrect Username or Password!";
        }
        sqlcon.Close();
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        txtPassword.Text = "";
    }
}