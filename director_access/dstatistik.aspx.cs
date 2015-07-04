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

namespace aviation.director_access
{
    public partial class dstatistik : System.Web.UI.Page
    {
        static string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
        SqlConnection sqlConnection = new SqlConnection(strSQLconnection);

        static string month;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                onload();
            }
        }
        private void onload()
        {
            BindGridDuaHala();
            BindGridSehala();
            getmonthduahala();
            getmonthsehala();
            tiketduahala();
            tiketsehala();
            tiketduahalalulus();
            tiketsehalalulus();
            bahagiantiketduahala();
            bahagiantiketsehala();
            bahagiantiketduahalalulus();
            bahagiantiketsehalalulus();
        }
        protected void gdvDuaHala_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvDuaHala.PageIndex = e.NewPageIndex;
            onload();
        }
        protected void gdvSehala_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvSehala.PageIndex = e.NewPageIndex;
            onload();
        }
        private void BindGridDuaHala()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT id,username_pegawai,tarikh_tempahan,bulan,nama_penyelia,lulus FROM application ORDER BY tarikh_tempahan,masa_tempahan", sqlConnection);

            try
            {
                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();
                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommand);
                DataSet myDataSet = new DataSet();
                mySqlAdapter.Fill(myDataSet);

                gdvDuaHala.DataSource = myDataSet;
                gdvDuaHala.DataBind();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sistem sedang sibuk. Sila cuba sebentar lagi!");
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void getmonthduahala()
        {
            for (int count = 0; count < gdvDuaHala.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvDuaHala.Rows[count];
                    string tiket_id = gvrow.Cells[0].Text;

                    string strSQLconnectionmonth = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectionmonth = new SqlConnection(strSQLconnectionmonth);

                    SqlCommand sqlCommandreadmonth = new SqlCommand("SELECT datename(month,tarikh_tempahan) AS bulan FROM application WHERE id=@id", sqlConnectionmonth);
                    sqlCommandreadmonth.Parameters.Clear();
                    sqlCommandreadmonth.Parameters.AddWithValue("@id", tiket_id);

                    if (sqlConnectionmonth.State.Equals(ConnectionState.Open))
                        sqlConnectionmonth.Close();

                    if (sqlConnectionmonth.State.Equals(ConnectionState.Closed))
                        sqlConnectionmonth.Open();

                    SqlDataReader readermonth = sqlCommandreadmonth.ExecuteReader();

                    if (readermonth.Read())
                    {
                        month = readermonth["bulan"].ToString();
                    }

                    SqlCommand sqlUpdate1 = new SqlCommand();
                    sqlUpdate1.Connection = sqlConnection;
                    sqlUpdate1.CommandText = "Update application SET bulan=@bulan WHERE id=@id";
                    sqlUpdate1.Parameters.Clear();
                    sqlUpdate1.Parameters.AddWithValue("@bulan", month);
                    sqlUpdate1.Parameters.AddWithValue("@id", tiket_id);

                    if (sqlConnection.State.Equals(ConnectionState.Open))
                        sqlConnection.Close();

                    if (sqlConnection.State.Equals(ConnectionState.Closed))
                        sqlConnection.Open();

                    int change = sqlUpdate1.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Gagal mendapatkan data bulan untuk permohonan dua hala. Sila cuba sebentar lagi.");
                }
                finally
                {

                }
            }
        }
        private void BindGridSehala()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT id,username_pegawai,tarikh_tempahan,bulan,nama_penyelia,lulus FROM tiket_sehala ORDER BY tarikh_tempahan,masa_tempahan", sqlConnection);

            try
            {
                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();
                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommand);
                DataSet myDataSet = new DataSet();
                mySqlAdapter.Fill(myDataSet);

                gdvSehala.DataSource = myDataSet;
                gdvSehala.DataBind();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Sistem sedang sibuk. Sila cuba sebentar lagi!");
            }
            finally
            {

            }
        }
        private void getmonthsehala()
        {
            for (int count = 0; count < gdvSehala.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvSehala.Rows[count];
                    string tiket_id = gvrow.Cells[0].Text;

                    string strSQLconnectionmonth = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectionmonth = new SqlConnection(strSQLconnectionmonth);

                    SqlCommand sqlCommandreadmonth = new SqlCommand("SELECT datename(month,tarikh_tempahan) AS bulan FROM tiket_sehala WHERE id=@id", sqlConnectionmonth);
                    sqlCommandreadmonth.Parameters.Clear();
                    sqlCommandreadmonth.Parameters.AddWithValue("@id", tiket_id);

                    if (sqlConnectionmonth.State.Equals(ConnectionState.Open))
                        sqlConnectionmonth.Close();

                    if (sqlConnectionmonth.State.Equals(ConnectionState.Closed))
                        sqlConnectionmonth.Open();

                    SqlDataReader readermonth = sqlCommandreadmonth.ExecuteReader();

                    if (readermonth.Read())
                    {
                        month = readermonth["bulan"].ToString();
                    }
                    sqlConnectionmonth.Close();

                    if (sqlConnection.State.Equals(ConnectionState.Open))
                        sqlConnection.Close();
                    if (sqlConnection.State.Equals(ConnectionState.Closed))
                        sqlConnection.Open();

                    SqlCommand sqlUpdate1 = new SqlCommand();
                    sqlUpdate1.Connection = sqlConnection;
                    sqlUpdate1.CommandText = "Update tiket_sehala SET bulan=@bulan WHERE id=@id";
                    sqlUpdate1.Parameters.Clear();
                    sqlUpdate1.Parameters.AddWithValue("@bulan", month);
                    sqlUpdate1.Parameters.AddWithValue("@id", tiket_id);

                    int change = sqlUpdate1.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Gagal mendapatkan data bulan untuk permohonan sehala. Sila cuba sebentar lagi.");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        private void tiketduahala()
        {
            for (int count = 0; count < gdvDuaHala.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvDuaHala.Rows[count];
                    string month = gvrow.Cells[3].Text;

                    string strSQLconnectionmonth = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectionmonth = new SqlConnection(strSQLconnectionmonth);

                    SqlCommand sqlCommandreadmonth = new SqlCommand("UPDATE laporanbulanan SET bil_tiket_duahala=(SELECT COUNT(*) FROM application WHERE bulan=@bulan) WHERE bulan=@bulan", sqlConnectionmonth);
                    sqlCommandreadmonth.Parameters.Clear();
                    sqlCommandreadmonth.Parameters.AddWithValue("@bulan", month);

                    if (sqlConnectionmonth.State.Equals(ConnectionState.Open))
                        sqlConnectionmonth.Close();

                    if (sqlConnectionmonth.State.Equals(ConnectionState.Closed))
                        sqlConnectionmonth.Open();

                    int change = sqlCommandreadmonth.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Gagal mengemaskini laporan untuk bil tiket dua hala. Sila cuba sebentar lagi.");
                }
                finally
                {

                }
            }
        }
        private void tiketduahalalulus()
        {
            for (int count = 0; count < gdvDuaHala.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvDuaHala.Rows[count];
                    string month = gvrow.Cells[3].Text;

                    string strSQLconnectionmonth = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectionmonth = new SqlConnection(strSQLconnectionmonth);

                    SqlCommand sqlCommandreadmonth = new SqlCommand("UPDATE laporanbulanan SET duahala_lulus=(SELECT COUNT(*) FROM application WHERE bulan=@bulan AND lulus=@lulus) WHERE bulan=@bulan", sqlConnectionmonth);
                    sqlCommandreadmonth.Parameters.Clear();
                    sqlCommandreadmonth.Parameters.AddWithValue("@bulan", month);
                    sqlCommandreadmonth.Parameters.AddWithValue("@lulus", "Lulus");

                    if (sqlConnectionmonth.State.Equals(ConnectionState.Open))
                        sqlConnectionmonth.Close();

                    if (sqlConnectionmonth.State.Equals(ConnectionState.Closed))
                        sqlConnectionmonth.Open();

                    int change = sqlCommandreadmonth.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Gagal mengemaskini laporan untuk bil tiket dua hala yang dikeluarkan. Sila cuba sebentar lagi.");
                }
                finally
                {

                }
            }
        }
        private void tiketsehala()
        {
            for (int count = 0; count < gdvSehala.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvSehala.Rows[count];
                    string month = gvrow.Cells[3].Text;

                    string strSQLconnectionmonth = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectionmonth = new SqlConnection(strSQLconnectionmonth);

                    SqlCommand sqlCommandreadmonth = new SqlCommand("UPDATE laporanbulanan SET bil_tiket_sehala=(SELECT COUNT(*) FROM tiket_sehala WHERE bulan=@bulan) WHERE bulan=@bulan", sqlConnectionmonth);
                    sqlCommandreadmonth.Parameters.Clear();
                    sqlCommandreadmonth.Parameters.AddWithValue("@bulan", month);

                    if (sqlConnectionmonth.State.Equals(ConnectionState.Open))
                        sqlConnectionmonth.Close();

                    if (sqlConnectionmonth.State.Equals(ConnectionState.Closed))
                        sqlConnectionmonth.Open();

                    int change = sqlCommandreadmonth.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Gagal mengemaskini laporan untuk bil tiket sehala. Sila cuba sebentar lagi.");
                }
                finally
                {

                }
            }
        }
        private void tiketsehalalulus()
        {
            for (int count = 0; count < gdvSehala.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvSehala.Rows[count];
                    string month = gvrow.Cells[3].Text;

                    string strSQLconnectionmonth = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectionmonth = new SqlConnection(strSQLconnectionmonth);

                    SqlCommand sqlCommandreadmonth = new SqlCommand("UPDATE laporanbulanan SET sehala_lulus=(SELECT COUNT(*) FROM tiket_sehala WHERE bulan=@bulan AND lulus=@lulus) WHERE bulan=@bulan", sqlConnectionmonth);
                    sqlCommandreadmonth.Parameters.Clear();
                    sqlCommandreadmonth.Parameters.AddWithValue("@bulan", month);
                    sqlCommandreadmonth.Parameters.AddWithValue("@lulus", "Lulus");

                    if (sqlConnectionmonth.State.Equals(ConnectionState.Open))
                        sqlConnectionmonth.Close();

                    if (sqlConnectionmonth.State.Equals(ConnectionState.Closed))
                        sqlConnectionmonth.Open();

                    int change = sqlCommandreadmonth.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Gagal mengemaskini laporan untuk bil tiket dua sehala yang dikeluarkan. Sila cuba sebentar lagi.");
                }
                finally
                {

                }
            }
        }
        private void bahagiantiketduahala()
        {
            for (int count = 0; count < gdvDuaHala.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvDuaHala.Rows[count];
                    string dept = gvrow.Cells[4].Text;

                    string strSQLconnectiondept2 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectiondept2 = new SqlConnection(strSQLconnectiondept2);

                    SqlCommand sqlCommandreaddept2 = new SqlCommand("SELECT nama FROM bahagian WHERE @nama LIKE '%' + nama + '%'", sqlConnectiondept2);
                    sqlCommandreaddept2.Parameters.Clear();
                    sqlCommandreaddept2.Parameters.AddWithValue("@nama", dept);

                    if (sqlConnectiondept2.State.Equals(ConnectionState.Open))
                        sqlConnectiondept2.Close();

                    if (sqlConnectiondept2.State.Equals(ConnectionState.Closed))
                        sqlConnectiondept2.Open();

                    SqlDataReader getdept = sqlCommandreaddept2.ExecuteReader();
                    getdept.Read();
                    string tracedept = getdept["nama"].ToString();

                    string strSQLconnectiondept = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectiondept = new SqlConnection(strSQLconnectiondept);

                    SqlCommand sqlCommandreaddept = new SqlCommand("UPDATE bahagian SET bil_tiket_duahala=(SELECT COUNT(*) FROM application WHERE nama_penyelia LIKE '%' + @nama_penyelia + '%') WHERE @nama_penyelia=nama", sqlConnectiondept);
                    sqlCommandreaddept.Parameters.Clear();
                    sqlCommandreaddept.Parameters.AddWithValue("@nama_penyelia", tracedept);

                    if (sqlConnectiondept.State.Equals(ConnectionState.Open))
                        sqlConnectiondept.Close();

                    if (sqlConnectiondept.State.Equals(ConnectionState.Closed))
                        sqlConnectiondept.Open();

                    int change = sqlCommandreaddept.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Gagal mengemaskini laporan untuk bil tiket dua hala mengikut bahagian. Sila cuba sebentar lagi.");
                }
                finally
                {

                }
            }
        }
        private void bahagiantiketduahalalulus()
        {
            for (int count = 0; count < gdvDuaHala.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvDuaHala.Rows[count];
                    string dept = gvrow.Cells[4].Text;

                    string strSQLconnectiondept2 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectiondept2 = new SqlConnection(strSQLconnectiondept2);

                    SqlCommand sqlCommandreaddept2 = new SqlCommand("SELECT nama FROM bahagian WHERE @nama LIKE '%' + nama + '%'", sqlConnectiondept2);
                    sqlCommandreaddept2.Parameters.Clear();
                    sqlCommandreaddept2.Parameters.AddWithValue("@nama", dept);

                    if (sqlConnectiondept2.State.Equals(ConnectionState.Open))
                        sqlConnectiondept2.Close();

                    if (sqlConnectiondept2.State.Equals(ConnectionState.Closed))
                        sqlConnectiondept2.Open();

                    SqlDataReader getdept = sqlCommandreaddept2.ExecuteReader();
                    getdept.Read();
                    string tracedept = getdept["nama"].ToString();

                    string strSQLconnectiondept = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectiondept = new SqlConnection(strSQLconnectiondept);

                    SqlCommand sqlCommandreaddept = new SqlCommand("UPDATE bahagian SET duahala_lulus=(SELECT COUNT(*) FROM application WHERE nama_penyelia LIKE '%' + @nama_penyelia + '%' AND lulus=@lulus) WHERE @nama_penyelia=nama", sqlConnectiondept);
                    sqlCommandreaddept.Parameters.Clear();
                    sqlCommandreaddept.Parameters.AddWithValue("@nama_penyelia", tracedept);
                    sqlCommandreaddept.Parameters.AddWithValue("@lulus", "Lulus");

                    if (sqlConnectiondept.State.Equals(ConnectionState.Open))
                        sqlConnectiondept.Close();

                    if (sqlConnectiondept.State.Equals(ConnectionState.Closed))
                        sqlConnectiondept.Open();

                    int change = sqlCommandreaddept.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Gagal mengemaskini laporan untuk bil tiket dua hala yang dikeluarkan mengikut bahagian. Sila cuba sebentar lagi.");
                }
                finally
                {

                }
            }
        }
        private void bahagiantiketsehala()
        {
            for (int count = 0; count < gdvSehala.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvSehala.Rows[count];
                    string dept = gvrow.Cells[4].Text;

                    string strSQLconnectiondept2 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectiondept2 = new SqlConnection(strSQLconnectiondept2);

                    SqlCommand sqlCommandreaddept2 = new SqlCommand("SELECT nama FROM bahagian WHERE @nama LIKE '%' + nama + '%'", sqlConnectiondept2);
                    sqlCommandreaddept2.Parameters.Clear();
                    sqlCommandreaddept2.Parameters.AddWithValue("@nama", dept);

                    if (sqlConnectiondept2.State.Equals(ConnectionState.Open))
                        sqlConnectiondept2.Close();

                    if (sqlConnectiondept2.State.Equals(ConnectionState.Closed))
                        sqlConnectiondept2.Open();

                    SqlDataReader getdept = sqlCommandreaddept2.ExecuteReader();
                    getdept.Read();
                    string tracedept = getdept["nama"].ToString();

                    string strSQLconnectiondept = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectiondept = new SqlConnection(strSQLconnectiondept);

                    SqlCommand sqlCommandreaddept = new SqlCommand("UPDATE bahagian SET bil_tiket_sehala=(SELECT COUNT(*) FROM tiket_sehala WHERE nama_penyelia LIKE '%' + @nama_penyelia + '%') WHERE @nama_penyelia=nama", sqlConnectiondept);
                    sqlCommandreaddept.Parameters.Clear();
                    sqlCommandreaddept.Parameters.AddWithValue("@nama_penyelia", tracedept);

                    if (sqlConnectiondept.State.Equals(ConnectionState.Open))
                        sqlConnectiondept.Close();

                    if (sqlConnectiondept.State.Equals(ConnectionState.Closed))
                        sqlConnectiondept.Open();

                    int change = sqlCommandreaddept.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Gagal mengemaskini laporan untuk bil tiket sehala mengikut bahagian. Sila cuba sebentar lagi.");
                }
                finally
                {

                }
            }
        }
        private void bahagiantiketsehalalulus()
        {
            for (int count = 0; count < gdvSehala.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvSehala.Rows[count];
                    string dept = gvrow.Cells[4].Text;

                    string strSQLconnectiondept2 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectiondept2 = new SqlConnection(strSQLconnectiondept2);

                    SqlCommand sqlCommandreaddept2 = new SqlCommand("SELECT nama FROM bahagian WHERE @nama LIKE '%' + nama + '%'", sqlConnectiondept2);
                    sqlCommandreaddept2.Parameters.Clear();
                    sqlCommandreaddept2.Parameters.AddWithValue("@nama", dept);

                    if (sqlConnectiondept2.State.Equals(ConnectionState.Open))
                        sqlConnectiondept2.Close();

                    if (sqlConnectiondept2.State.Equals(ConnectionState.Closed))
                        sqlConnectiondept2.Open();

                    SqlDataReader getdept = sqlCommandreaddept2.ExecuteReader();
                    getdept.Read();
                    string tracedept = getdept["nama"].ToString();

                    string strSQLconnectiondept = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;Pooling=True;Max Pool Size = 500;User Instance=True";
                    SqlConnection sqlConnectiondept = new SqlConnection(strSQLconnectiondept);

                    SqlCommand sqlCommandreaddept = new SqlCommand("UPDATE bahagian SET sehala_lulus=(SELECT COUNT(*) FROM tiket_sehala WHERE nama_penyelia LIKE '%' + @nama_penyelia + '%' AND lulus=@lulus) WHERE @nama_penyelia=nama", sqlConnectiondept);
                    sqlCommandreaddept.Parameters.Clear();
                    sqlCommandreaddept.Parameters.AddWithValue("@nama_penyelia", tracedept);
                    sqlCommandreaddept.Parameters.AddWithValue("@lulus", "Lulus");

                    if (sqlConnectiondept.State.Equals(ConnectionState.Open))
                        sqlConnectiondept.Close();

                    if (sqlConnectiondept.State.Equals(ConnectionState.Closed))
                        sqlConnectiondept.Open();

                    int change = sqlCommandreaddept.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Gagal mengemaskini laporan untuk bil tiket sehala yang dikeluarkan mengikut bahagian. Sila cuba sebentar lagi.");
                }
                finally
                {

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