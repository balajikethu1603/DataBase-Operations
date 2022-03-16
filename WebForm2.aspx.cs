using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WebApplication1.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            disp_data();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText ="insert into Table1 values('"+ firstName.Text +"','"+ lastName.Text +"','"+ city.Text +"')";
            cmd.ExecuteNonQuery();

            firstName.Text = "";
            lastName.Text = "";
            city.Text = "";

        }
        public void disp_data()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select *from Table1 ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Table1 where firstname='" + firstName.Text + "'";
            cmd.ExecuteNonQuery();

            firstName.Text = "";
            disp_data();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " update Table1 set firstname='"+ firstName.Text +"',lastname='"+ lastName.Text +"',city='"+ city.Text +"' where id=" + Convert.ToInt32(oldid.Text) + "";
            cmd.ExecuteNonQuery();
            firstName.Text = "";
            lastName.Text = "";
            city.Text = "";

            disp_data();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            disp_data();
        }
    }
}