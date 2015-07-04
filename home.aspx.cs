using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.ComponentModel;

namespace aviation
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                onload();
            }
        }
        private void onload()
        {
            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
            SqlConnection sqlConnection2 = new SqlConnection(strSQLconnection);
            SqlConnection sqlConnection3 = new SqlConnection(strSQLconnection);
            SqlCommand sqlCommandAdminDesignation = new SqlCommand("SELECT * FROM admin WHERE ic='" + User.Identity.Name + "'", sqlConnection);
            SqlCommand sqlCommandSupervisorDesignation = new SqlCommand("SELECT * FROM supervisor WHERE ic='" + User.Identity.Name + "'", sqlConnection2);
            SqlCommand sqlCommandDirectorDesignation = new SqlCommand("SELECT * FROM director WHERE ic='" + User.Identity.Name + "'", sqlConnection3);
            
            sqlConnection.Open();
            sqlConnection2.Open();
            sqlConnection3.Open();
            var reader = sqlCommandSupervisorDesignation.ExecuteReader();
            var reader2 = sqlCommandAdminDesignation.ExecuteReader();
            var reader3 = sqlCommandDirectorDesignation.ExecuteReader();

            if (reader.Read())
            {
                Response.Redirect("supervisor_access/pengesahansokongan.aspx");
            }
            else if(reader2.Read())
            {
                Response.Redirect("admin_access/senaraitempahan.aspx");
            }
            else if (reader3.Read())
            {
                Response.Redirect("director_access/dpengesahansokongan.aspx");
            }
            sqlConnection.Close();
            sqlConnection2.Close();
        }
    }
}