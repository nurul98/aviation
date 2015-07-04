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

namespace aviation.admin_access
{
    public partial class profilpegawai : System.Web.UI.Page
    {
        private SqlConnection userconnection, updateconnection, deleteconnection, deleteconnection2, deleteconnection2a;
        private SqlCommand usercommand, updatecommand, deletecommand, deletecommand2, deletecommand2a;
        private SqlDataReader userreader;

        static string pegawaiid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                onload();
            }
        }
        private void onload()
        {
            LabelIC.Visible = false;
            LabelNamaPegawai.Visible = false;
            LabelEmail.Visible = false;
            LabelKumpulanPerkhidmatan.Visible = false;
            LabelJawatan.Visible = false;
            LabelBahagian.Visible = false;
            LabelGredJawatan.Visible = false;
            LabelSektor.Visible = false;
            LabelTelefonBimbit.Visible = false;
            LabelTelefonPejabat.Visible = false;
           
            update.Visible = false;
            TxtIC.Visible = false;
            TxtNama.Visible = false;
            TxtEmail.Visible = false;
            KumpulanPerkhidmatan.Visible = false;
            Jawatan.Visible = false;
            Bahagian.Visible = false;
            GredJawatan.Visible = false;
            TxtSektor.Visible = false;
            TxtPhone.Visible = false;
            TxtPhone2.Visible = false;
            
            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM profil_pegawai ORDER BY nama", sqlConnection);

            try
            {
                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();

                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommand);
                DataSet myDataSet = new DataSet();
                mySqlAdapter.Fill(myDataSet);
               
                gridpegawai.DataSource = myDataSet;
                gridpegawai.DataBind();

                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();

                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        protected void gridpegawai_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridpegawai.PageIndex = e.NewPageIndex;
            onload();
        }
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            LabelIC.Visible = true;
            LabelNamaPegawai.Visible = true;
            LabelEmail.Visible = true;
            LabelKumpulanPerkhidmatan.Visible = true;
            LabelJawatan.Visible = true;
            LabelBahagian.Visible = true;
            LabelGredJawatan.Visible = true;
            LabelSektor.Visible = true;
            LabelTelefonBimbit.Visible = true;
            LabelTelefonPejabat.Visible = true;

            update.Visible = true;
            TxtIC.Visible = true;
            TxtNama.Visible = true;
            TxtEmail.Visible = true;
            KumpulanPerkhidmatan.Visible = true;
            Jawatan.Visible = true;
            Bahagian.Visible = true;
            GredJawatan.Visible = true;
            TxtSektor.Visible = true;
            TxtPhone.Visible = true;
            TxtPhone2.Visible = true;

            update.Enabled = true;
            TxtIC.Enabled = false;
            TxtNama.Enabled = true;
            TxtEmail.Enabled = true;
            KumpulanPerkhidmatan.Enabled = true;
            Jawatan.Enabled = true;
            Bahagian.Enabled = true;
            GredJawatan.Enabled = true;
            TxtSektor.Enabled = true;
            TxtPhone.Enabled = true;
            TxtPhone2.Enabled = true;

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            pegawaiid = gvrow.Cells[0].Text;

            userconnection = new SqlConnection();
            userconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf;Trusted_Connection=True;User Instance=True";
            usercommand = new SqlCommand();
            usercommand.Connection = userconnection;

            usercommand.CommandText = "SELECT * FROM profil_pegawai WHERE username=@username";
            usercommand.Parameters.Clear();
            usercommand.Parameters.AddWithValue("@username", pegawaiid);

            try
            {
                userconnection.Open();
                userreader = usercommand.ExecuteReader();

                if (userreader.Read())
                {
                    TxtIC.Text = userreader["username"].ToString();
                    TxtNama.Text = userreader["nama"].ToString();
                    TxtEmail.Text = userreader["email"].ToString();
                    KumpulanPerkhidmatan.Text = userreader["kumpulan_perkhidmatan"].ToString();
                    Jawatan.Text = userreader["jawatan"].ToString();
                    Bahagian.Text = userreader["bahagian"].ToString();
                    GredJawatan.Text = userreader["gred_jawatan"].ToString();
                    TxtSektor.Text = userreader["sektor"].ToString();
                    TxtPhone.Text = userreader["telefon_bimbit"].ToString();
                    TxtPhone2.Text = userreader["telefon_pejabat"].ToString();
                }
                else
                {
                    MessageBox.Show("Data pegawai tidak ada dalam rekod.");
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
        protected void update_Click(object sender, EventArgs e)
        {
            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;

            updatecommand.CommandText = "UPDATE profil_pegawai SET nama=@nama,email=@email,kumpulan_perkhidmatan=@kumpulan_perkhidmatan,jawatan=@jawatan,bahagian=@bahagian,gred_jawatan=@gred_jawatan,sektor=@sektor,telefon_bimbit=@telefon_bimbit,telefon_pejabat=@telefon_pejabat WHERE username=@username";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@username", TxtIC.Text);
            updatecommand.Parameters.AddWithValue("@nama", TxtNama.Text);
            updatecommand.Parameters.AddWithValue("@email", TxtEmail.Text);
            updatecommand.Parameters.AddWithValue("@kumpulan_perkhidmatan", KumpulanPerkhidmatan.Text);
            updatecommand.Parameters.AddWithValue("@jawatan", Jawatan.Text);
            updatecommand.Parameters.AddWithValue("@bahagian", Bahagian.Text);
            updatecommand.Parameters.AddWithValue("@gred_jawatan", GredJawatan.Text);
            updatecommand.Parameters.AddWithValue("@sektor", TxtSektor.Text);
            updatecommand.Parameters.AddWithValue("@telefon_bimbit", TxtPhone.Text);
            updatecommand.Parameters.AddWithValue("@telefon_pejabat", TxtPhone2.Text);
           
            try
            {
                updateconnection.Open();
                int change = updatecommand.ExecuteNonQuery();
                if (change > 0)
                {
                    MessageBox.Show("Rekod pegawai berjaya dikemaskini!");
                }
                else
                    MessageBox.Show("Rekod pegawai gagal dikemaskini.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sistem sedang sibuk. Sila cuba sekali lagi");
            }
            finally
            {
                updateconnection.Close();
            }
            
            update.Enabled = true;
            TxtIC.Enabled = false;
            TxtNama.Enabled = true;
            TxtEmail.Enabled = true;
            KumpulanPerkhidmatan.Enabled = true;
            Jawatan.Enabled = true;
            Bahagian.Enabled = true;
            GredJawatan.Enabled = true;
            TxtSektor.Enabled = true;
            TxtPhone.Enabled = true;
            TxtPhone2.Enabled = true;

            onload();
        }
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            pegawaiid = gvrow.Cells[0].Text;
            DeleteProfil.Text = pegawaiid;
            this.ModalPopupExtender2.Show();
        }
        protected void confirmdelete_Click(object sender, EventArgs e)
        {
            deleteconnection = new SqlConnection();
            deleteconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            deletecommand = new SqlCommand();
            deletecommand.Connection = deleteconnection;
            deletecommand.CommandText = "DELETE FROM profil_pegawai WHERE username=@username";

            deletecommand.Parameters.Clear();
            deletecommand.Parameters.AddWithValue("@username", pegawaiid);

            try
            {
                Membership.DeleteUser(pegawaiid);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sistem asp.net sedang sibuk. Sila cuba sebentar lagi.");
            }
            finally
            {
            }
    
            try
            {
                deleteconnection.Open();
                int change = deletecommand.ExecuteNonQuery();
                if (change > 0)
                {
                    MessageBox.Show("Profil berjaya dipadam!");
                    onload();
                }
                else
                    MessageBox.Show("Proses memadam data gagal!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sistem sedang sibuk. Sila cuba sebentar lagi");
            }
            finally
            {
                deleteconnection.Close();
            }

            deleteconnection2 = new SqlConnection();
            deleteconnection2.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            deletecommand2 = new SqlCommand();
            deletecommand2.Connection = deleteconnection2;
            deletecommand2.CommandText = "DELETE FROM application WHERE username_pegawai=@username_pegawai";

            deletecommand2.Parameters.Clear();
            deletecommand2.Parameters.AddWithValue("@username_pegawai", pegawaiid);

            try
            {
                deleteconnection2.Open();
                int change2 = deletecommand2.ExecuteNonQuery();
                if (change2 > 0)
                {
                    onload();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sistem masih sibuk. Sila cuba sebentar lagi");
            }
            finally
            {
                deleteconnection2.Close();
            }

            deleteconnection2a = new SqlConnection();
            deleteconnection2a.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            deletecommand2a = new SqlCommand();
            deletecommand2a.Connection = deleteconnection2a;
            deletecommand2a.CommandText = "DELETE FROM tiket_sehala WHERE username_pegawai=@username_pegawai";

            deletecommand2a.Parameters.Clear();
            deletecommand2a.Parameters.AddWithValue("@username_pegawai", pegawaiid);

            try
            {
                deleteconnection2a.Open();
                int change2a = deletecommand2a.ExecuteNonQuery();
                if (change2a > 0)
                {
                    onload();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sistem masih sibuk. Sila cuba sebentar lagi");
            }
            finally
            {
                deleteconnection2a.Close();
            }
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            LabelIC.Visible = false;
            LabelNamaPegawai.Visible = false;
            LabelEmail.Visible = false;
            LabelKumpulanPerkhidmatan.Visible = false;
            LabelJawatan.Visible = false;
            LabelBahagian.Visible = false;
            LabelGredJawatan.Visible = false;
            LabelSektor.Visible = false;
            LabelTelefonBimbit.Visible = false;
            LabelTelefonPejabat.Visible = false;

            update.Visible = false;
            TxtIC.Visible = false;
            TxtNama.Visible = false;
            TxtEmail.Visible = false;
            KumpulanPerkhidmatan.Visible = false;
            Jawatan.Visible = false;
            Bahagian.Visible = false;
            GredJawatan.Visible = false;
            TxtSektor.Visible = false;
            TxtPhone.Visible = false;
            TxtPhone2.Visible = false;

            string strSQLconnectionstatus = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnectionstatus = new SqlConnection(strSQLconnectionstatus);

            SqlCommand sqlCommandreadstatus = new SqlCommand("SELECT * FROM profil_pegawai WHERE username=@username", sqlConnectionstatus);
            sqlCommandreadstatus.Parameters.Clear();
            sqlCommandreadstatus.Parameters.AddWithValue("@username", txtSearch.Text);

            if (sqlConnectionstatus.State.Equals(ConnectionState.Open))
                sqlConnectionstatus.Close();

            if (sqlConnectionstatus.State.Equals(ConnectionState.Closed))
                sqlConnectionstatus.Open();

            SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommandreadstatus);
            DataSet myDataSet = new DataSet();
            mySqlAdapter.Fill(myDataSet);

            gridpegawai.DataSource = myDataSet;
            gridpegawai.DataBind();

            SqlCommand sqlCommandreadstatus2 = new SqlCommand("SELECT * FROM profil_pegawai WHERE username=@username", sqlConnectionstatus);
            sqlCommandreadstatus2.Parameters.Clear();
            sqlCommandreadstatus2.Parameters.AddWithValue("@username", txtSearch.Text);

            if (sqlConnectionstatus.State.Equals(ConnectionState.Open))
                sqlConnectionstatus.Close();

            if (sqlConnectionstatus.State.Equals(ConnectionState.Closed))
                sqlConnectionstatus.Open();

            SqlDataReader reader3 = sqlCommandreadstatus.ExecuteReader();

            if (reader3.Read())
            {

            }
            else
            {
                MessageBox.Show("IC Pegawai yang anda cari tiada dalam rekod...");
            }

        }
        public static void ClearControls(Control Parent)
        {
            if (Parent is TextBox)
            {
                (Parent as TextBox).Text = string.Empty;
            }
            else
            {
                foreach (Control c in Parent.Controls)
                    ClearControls(c);
            }
        }
        public class MessageBox
        {
            private static System.Collections.Hashtable m_executingPages = new System.Collections.Hashtable();
            private MessageBox()
            {
            }
            public static void Show(string sMessage)
            {
                // If this is the first time a page has called this method then
                if (!m_executingPages.Contains(HttpContext.Current.Handler))
                {
                    // Attempt to cast HttpHandler as a Page.
                    Page executingPage = HttpContext.Current.Handler as Page;
                    if (executingPage != null)
                    {
                        // Create a Queue to hold one or more messages.
                        System.Collections.Queue messageQueue = new System.Collections.Queue();
                        // Add our message to the Queue
                        messageQueue.Enqueue(sMessage);
                        // Add our message queue to the hash table. Use our page reference
                        // (IHttpHandler) as the key.
                        m_executingPages.Add(HttpContext.Current.Handler, messageQueue);
                        // Wire up Unload event so that we can inject
                        // some JavaScript for the alerts.
                        executingPage.Unload += new EventHandler(ExecutingPage_Unload);
                    }
                }
                else
                {
                    // If were here then the method has already been
                    // called from the executing Page.
                    // We have allready created a message queue and stored a
                    // reference to it in our hastable.
                    System.Collections.Queue queue = (System.Collections.Queue)m_executingPages[HttpContext.Current.Handler];
                    // Add our message to the Queue
                    queue.Enqueue(sMessage);
                }
            }
            // Our page has finished rendering so lets output the JavaScript to produce the alert's
            private static void ExecutingPage_Unload(object sender, EventArgs e)
            {
                // Get our message queue from the hashtable
                System.Collections.Queue queue = (System.Collections.Queue)m_executingPages[HttpContext.Current.Handler];
                if (queue != null)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    // How many messages have been registered?
                    int iMsgCount = queue.Count;
                    // Use StringBuilder to build up our client slide JavaScript.
                    sb.Append("<script language='javascript'>");
                    // Loop round registered messages
                    string sMsg;
                    while (iMsgCount-- > 0)
                    {
                        sMsg = (string)queue.Dequeue();
                        sMsg = sMsg.Replace("\n", "\\n");
                        sMsg = sMsg.Replace("\"", "'");
                        sb.Append(@"alert( """ + sMsg + @""" );");
                    }
                    // Close our JS
                    sb.Append(@"</script>");
                    // Were done, so remove our page reference from the hashtable
                    m_executingPages.Remove(HttpContext.Current.Handler);
                    // Write the JavaScript to the end of the response stream.
                    HttpContext.Current.Response.Write(sb.ToString());
                }
            }
        }
    }
}