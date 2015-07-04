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
using System.IO;
using System.Configuration; 

namespace aviation.supervisor_access
{
    public partial class superlihatfailsokongansehala : System.Web.UI.Page
    {
        private SqlConnection userconnection;
        private SqlCommand usercommand;
        private SqlDataReader userreader;

        protected void Page_Load(object sender, EventArgs e)
        {
            string idtiket = Request.QueryString["tiketid"];

            userconnection = new SqlConnection();
            userconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf;Trusted_Connection=True;User Instance=True";
            usercommand = new SqlCommand();
            usercommand.Connection = userconnection;

            usercommand.CommandText = "SELECT * FROM tiket_sehala WHERE id=@id";
            usercommand.Parameters.Clear();
            usercommand.Parameters.AddWithValue("@id", idtiket);

            try
            {
                userconnection.Open();
                userreader = usercommand.ExecuteReader();

                if (userreader.Read())
                {
                    Response.ContentType = userreader["MIME"].ToString();
                    Response.BinaryWrite((byte[])userreader["BinaryData"]);
                }
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                userconnection.Close();
            }
        }
    }
}