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

namespace aviation.admin_access
{
    public partial class nilaiagen : System.Web.UI.Page
    {
        private SqlConnection userconnection, updateconnection, deleteconnection;
        private SqlCommand usercommand, updatecommand, deletecommand;
        private SqlDataReader userreader;

        static string agenid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                onload();
            }
        }
        private void onload()
        {
            LabelId.Visible = false;
            LabelSyarikat.Visible = false;
            LabelAlamat.Visible = false;
            LabelNombor.Visible = false;
            LabelFaks.Visible = false;
            LabelEmail.Visible = false;
            LabelCatatan.Visible = false;
            LabelTarikhMulaKewangan.Visible = false;
            LabelTarikhTamatKewangan.Visible = false;
            LabelTarikhMulaTDC.Visible = false;
            LabelTarikhTamatTDC.Visible = false;
            LabelAmaun.Visible = false;
            LabelKodPrestasi.Visible = false;

            update.Visible = false;
            id.Visible = false;
            nama.Visible = false;
            alamat.Visible = false;
            nombor.Visible = false;
            faks.Visible = false;
            email.Visible = false;
            catatan.Visible = false;
            tarikh_mula_kewangan.Visible = false;
            tarikh_tamat_kewangan.Visible = false;
            tarikh_mula_tdc.Visible = false;
            tarikh_tamat_tdc.Visible = false;
            amaun.Visible = false;
            kod_prestasi.Visible = false;

            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM agen ORDER BY nama", sqlConnection);

            try
            {
                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();

                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommand);
                DataSet myDataSet = new DataSet();
                mySqlAdapter.Fill(myDataSet);

                gridnilai.DataSource = myDataSet;
                gridnilai.DataBind();

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
        protected void gridnilai_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridnilai.PageIndex = e.NewPageIndex;
            onload();
        }
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            LabelId.Visible = true;
            LabelSyarikat.Visible = true;
            LabelAlamat.Visible = true;
            LabelNombor.Visible = true;
            LabelFaks.Visible = true;
            LabelEmail.Visible = true;
            LabelCatatan.Visible = true;
            LabelTarikhMulaKewangan.Visible = true;
            LabelTarikhTamatKewangan.Visible = true;
            LabelTarikhMulaTDC.Visible = true;
            LabelTarikhTamatTDC.Visible = true;
            LabelAmaun.Visible = true;
            LabelKodPrestasi.Visible = true;

            update.Visible = true;
            id.Visible = true;
            nama.Visible = true;
            alamat.Visible = true;
            nombor.Visible = true;
            faks.Visible = true;
            email.Visible = true;
            catatan.Visible = true;
            tarikh_mula_kewangan.Visible = true;
            tarikh_tamat_kewangan.Visible = true;
            tarikh_mula_tdc.Visible = true;
            tarikh_tamat_tdc.Visible = true;
            amaun.Visible = true;
            kod_prestasi.Visible = true;

            update.Enabled = true;
            id.Enabled = false;
            nama.Enabled = true;
            alamat.Enabled = true;
            nombor.Enabled = true;
            faks.Enabled = true;
            email.Enabled = true;
            catatan.Enabled = true;
            tarikh_mula_kewangan.Enabled = true;
            tarikh_tamat_kewangan.Enabled = true;
            tarikh_mula_tdc.Enabled = true;
            tarikh_tamat_tdc.Enabled = true;
            amaun.Enabled = true;
            kod_prestasi.Enabled = true;

            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            agenid = gvrow.Cells[0].Text;

            userconnection = new SqlConnection();
            userconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf;Trusted_Connection=True;User Instance=True";
            usercommand = new SqlCommand();
            usercommand.Connection = userconnection;

            usercommand.CommandText = "SELECT * FROM agen WHERE id=@id";
            usercommand.Parameters.Clear();
            usercommand.Parameters.AddWithValue("@id", agenid);

            try
            {
                userconnection.Open();
                userreader = usercommand.ExecuteReader();

                if (userreader.Read())
                {
                    id.Text = userreader["id"].ToString();
                    nama.Text = userreader["nama"].ToString();
                    alamat.Text = userreader["alamat"].ToString();
                    nombor.Text = userreader["nombor"].ToString();
                    faks.Text = userreader["faks"].ToString();
                    email.Text = userreader["email"].ToString();
                    catatan.Text = userreader["catatan"].ToString();
                    tarikh_mula_kewangan.Text = userreader["tarikh_mula_kewangan"].ToString();
                    tarikh_tamat_kewangan.Text = userreader["tarikh_tamat_kewangan"].ToString();
                    tarikh_mula_tdc.Text = userreader["tarikh_mula_tdc"].ToString();
                    tarikh_tamat_tdc.Text = userreader["tarikh_tamat_tdc"].ToString();
                    amaun.Text = userreader["amaun"].ToString();
                    kod_prestasi.Text = userreader["kod_prestasi"].ToString();
                }
                else
                {
                    MessageBox.Show("Data agen tidak ada dalam rekod.");
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

            updatecommand.CommandText = "UPDATE agen SET nama=@nama,alamat=@alamat,nombor=@nombor,faks=@faks,email=@email,catatan=@catatan,tarikh_mula_kewangan=@tarikh_mula_kewangan,tarikh_tamat_kewangan=@tarikh_tamat_kewangan,tarikh_mula_tdc=@tarikh_mula_tdc,tarikh_tamat_tdc=@tarikh_tamat_tdc,amaun=@amaun,kod_prestasi=@kod_prestasi WHERE id=@id";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@id", id.Text);
            updatecommand.Parameters.AddWithValue("@nama", nama.Text);
            updatecommand.Parameters.AddWithValue("@alamat", alamat.Text);
            updatecommand.Parameters.AddWithValue("@nombor", nombor.Text);
            updatecommand.Parameters.AddWithValue("@faks", faks.Text);
            updatecommand.Parameters.AddWithValue("@email", email.Text);
            updatecommand.Parameters.AddWithValue("@catatan", catatan.Text);
            updatecommand.Parameters.AddWithValue("@tarikh_mula_kewangan", tarikh_mula_kewangan.Text);
            updatecommand.Parameters.AddWithValue("@tarikh_tamat_kewangan", tarikh_tamat_kewangan.Text);
            updatecommand.Parameters.AddWithValue("@tarikh_mula_tdc", tarikh_mula_tdc.Text);
            updatecommand.Parameters.AddWithValue("@tarikh_tamat_tdc", tarikh_tamat_tdc.Text);
            updatecommand.Parameters.AddWithValue("@amaun", amaun.Text);
            updatecommand.Parameters.AddWithValue("@kod_prestasi", kod_prestasi.Text);

            DateTime datepick = Convert.ToDateTime(tarikh_mula_kewangan.Text);
            DateTime datepick2 = Convert.ToDateTime(tarikh_tamat_kewangan.Text);
            DateTime datepick3 = Convert.ToDateTime(tarikh_mula_tdc.Text);
            DateTime datepick4 = Convert.ToDateTime(tarikh_tamat_tdc.Text);

            try
            {
                if (datepick3 > datepick4 || datepick > datepick2)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    try
                    {
                        updateconnection.Open();
                        int change = updatecommand.ExecuteNonQuery();
                        if (change > 0)
                        {
                            MessageBox.Show("Rekod agen berjaya dikemaskini!");
                        }
                        else
                            MessageBox.Show("Rekod agen gagal dikemaskini.");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Sistem sedang sibuk. Sila cuba sekali lagi");
                    }
                    finally
                    {
                        updateconnection.Close();
                    }
                }

            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Sila masukkan tarikh yang sah");
            }
            finally
            {

            }
            update.Enabled = true;
            id.Enabled = false;
            nama.Enabled = true;
            alamat.Enabled = true;
            nombor.Enabled = true;
            faks.Enabled = true;
            email.Enabled = true;
            catatan.Enabled = true;
            tarikh_mula_kewangan.Enabled = true;
            tarikh_tamat_kewangan.Enabled = true;
            tarikh_mula_tdc.Enabled = true;
            tarikh_tamat_tdc.Enabled = true;
            amaun.Enabled = true;
            kod_prestasi.Enabled = true;

            onload();
        }
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            agenid = gvrow.Cells[0].Text;
            DeleteAgen.Text = agenid;
            this.ModalPopupExtender2.Show();
        }
        protected void confirmdelete_Click(object sender, EventArgs e)
        {
            deleteconnection = new SqlConnection();
            deleteconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            deletecommand = new SqlCommand();
            deletecommand.Connection = deleteconnection;
            deletecommand.CommandText = "DELETE FROM agen WHERE id=@id";

            deletecommand.Parameters.Clear();
            deletecommand.Parameters.AddWithValue("@id", agenid);

            try
            {
                deleteconnection.Open();
                int change = deletecommand.ExecuteNonQuery();
                if (change > 0)
                {
                    MessageBox.Show("Data berjaya dipadam!");
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
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            LabelId.Visible = false;
            LabelSyarikat.Visible = false;
            LabelAlamat.Visible = false;
            LabelNombor.Visible = false;
            LabelFaks.Visible = false;
            LabelEmail.Visible = false;
            LabelCatatan.Visible = false;
            LabelTarikhMulaKewangan.Visible = false;
            LabelTarikhTamatKewangan.Visible = false;
            LabelTarikhMulaTDC.Visible = false;
            LabelTarikhTamatTDC.Visible = false;
            LabelAmaun.Visible = false;
            LabelKodPrestasi.Visible = false;

            update.Visible = false;
            id.Visible = false;
            nama.Visible = false;
            alamat.Visible = false;
            nombor.Visible = false;
            faks.Visible = false;
            email.Visible = false;
            catatan.Visible = false;
            tarikh_mula_kewangan.Visible = false;
            tarikh_tamat_kewangan.Visible = false;
            tarikh_mula_tdc.Visible = false;
            tarikh_tamat_tdc.Visible = false;
            amaun.Visible = false;
            kod_prestasi.Visible = false;

            string strSQLconnectionstatus = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnectionstatus = new SqlConnection(strSQLconnectionstatus);

            SqlCommand sqlCommandreadstatus = new SqlCommand("SELECT * FROM agen WHERE nama LIKE '%' + @nama + '%'", sqlConnectionstatus);
            sqlCommandreadstatus.Parameters.Clear();
            sqlCommandreadstatus.Parameters.AddWithValue("@nama", txtSearch.Text);

            if (sqlConnectionstatus.State.Equals(ConnectionState.Open))
                sqlConnectionstatus.Close();

            if (sqlConnectionstatus.State.Equals(ConnectionState.Closed))
                sqlConnectionstatus.Open();

            SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommandreadstatus);
            DataSet myDataSet = new DataSet();
            mySqlAdapter.Fill(myDataSet);

            gridnilai.DataSource = myDataSet;
            gridnilai.DataBind();

            SqlCommand sqlCommandreadstatus2 = new SqlCommand("SELECT * FROM agen WHERE nama LIKE '%' + @nama + '%'", sqlConnectionstatus);
            sqlCommandreadstatus2.Parameters.Clear();
            sqlCommandreadstatus2.Parameters.AddWithValue("@nama", txtSearch.Text);

            if (sqlConnectionstatus.State.Equals(ConnectionState.Open))
                sqlConnectionstatus.Close();

            if (sqlConnectionstatus.State.Equals(ConnectionState.Closed))
                sqlConnectionstatus.Open();

            SqlDataReader reader3 = sqlCommandreadstatus2.ExecuteReader();

            if (reader3.Read())
            {

            }
            else
            {
                MessageBox.Show("Syarikat yang anda cari tiada dalam rekod...");
            }
        }
        protected void Susun_Click(object sender, EventArgs e)
        {
            if (String.Compare(susunlist.SelectedItem.ToString(), "Nama Syarikat") == 0)
            {
                string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
                SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM agen ORDER BY nama,tarikh_mula_kewangan", sqlConnection);

                try
                {
                    if (sqlConnection.State.Equals(ConnectionState.Open))
                        sqlConnection.Close();

                    if (sqlConnection.State.Equals(ConnectionState.Closed))
                        sqlConnection.Open();

                    SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommand);
                    DataSet myDataSet = new DataSet();
                    mySqlAdapter.Fill(myDataSet);

                    gridnilai.DataSource = myDataSet;
                    gridnilai.DataBind();

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
            if (String.Compare(susunlist.SelectedItem.ToString(), "Tarikh Tamat Kewangan") == 0)
            {
                string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
                SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM agen ORDER BY tarikh_tamat_kewangan", sqlConnection);

                try
                {
                    if (sqlConnection.State.Equals(ConnectionState.Open))
                        sqlConnection.Close();

                    if (sqlConnection.State.Equals(ConnectionState.Closed))
                        sqlConnection.Open();

                    SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommand);
                    DataSet myDataSet = new DataSet();
                    mySqlAdapter.Fill(myDataSet);

                    gridnilai.DataSource = myDataSet;
                    gridnilai.DataBind();

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