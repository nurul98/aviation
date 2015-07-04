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

namespace aviation.supervisor_access
{
    public partial class pengesahansokongan : System.Web.UI.Page
    {
        private SqlConnection userconnection;
        private SqlCommand usercommand;
        private SqlDataReader userreader;
        
        static string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
        SqlConnection sqlConnection = new SqlConnection(strSQLconnection);

        static string name,rujukan,tiketid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                onload();
            }
        }
        private void onload()
        {
            string strSQLconnectiondept = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnectiondept = new SqlConnection(strSQLconnectiondept);

            SqlCommand sqlCommandreaddept = new SqlCommand("SELECT * FROM profil_pegawai WHERE username=@username", sqlConnectiondept);
            sqlCommandreaddept.Parameters.Clear();
            sqlCommandreaddept.Parameters.AddWithValue("@username", User.Identity.Name);

            if (sqlConnectiondept.State.Equals(ConnectionState.Open))
                sqlConnectiondept.Close();

            if (sqlConnectiondept.State.Equals(ConnectionState.Closed))
                sqlConnectiondept.Open();

            SqlDataReader readerdept = sqlCommandreaddept.ExecuteReader();

            if (readerdept.Read())
            {
                name = readerdept["nama"].ToString();
            }
            BindGridPending();
            BindGridApproved();
            BindGridRejected();
        }
        protected void gdvPending_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvPending.PageIndex = e.NewPageIndex;
            onload();
        }
        protected void gdvApproved_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvApproved.PageIndex = e.NewPageIndex;
            onload();
        }
        protected void gdvRejected_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvRejected.PageIndex = e.NewPageIndex;
            onload();
        }
        protected void linkfile_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            rujukan = gvrow.Cells[0].Text;
            
            Response.Redirect("lihatfail.aspx?tiketid=" + rujukan);
        }
        private void BindGridPending()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM application WHERE pangkat=@pangkat AND status=@status AND nama_penyelia LIKE '%' + @nama_penyelia + '%' ORDER BY tarikh_tempahan,masa_tempahan", sqlConnection);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@status", "Dalam Pertimbangan");
            sqlCommand.Parameters.AddWithValue("@pangkat", "pegawai");
            sqlCommand.Parameters.AddWithValue("@nama_penyelia", name);

            try
            {
                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommand);
                DataSet myDataSet = new DataSet();
                mySqlAdapter.Fill(myDataSet);

                gdvPending.DataSource = myDataSet;
                gdvPending.DataBind();
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
        private void BindGridApproved()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM application WHERE pangkat=@pangkat AND status=@status AND nama_penyelia LIKE '%' + @nama_penyelia + '%' ORDER BY tarikh_tempahan,masa_tempahan", sqlConnection);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@status", "Disokong");
            sqlCommand.Parameters.AddWithValue("@pangkat", "pegawai");
            sqlCommand.Parameters.AddWithValue("@nama_penyelia", name);

            try
            {
                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommand);
                DataSet myDataSet = new DataSet();
                mySqlAdapter.Fill(myDataSet);

                gdvApproved.DataSource = myDataSet;
                gdvApproved.DataBind();
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
        private void BindGridRejected()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM application WHERE pangkat=@pangkat AND status=@status AND nama_penyelia LIKE '%' + @nama_penyelia + '%' ORDER BY tarikh_tempahan,masa_tempahan", sqlConnection);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@status", "Tidak Disokong");
            sqlCommand.Parameters.AddWithValue("@pangkat", "pegawai");
            sqlCommand.Parameters.AddWithValue("@nama_penyelia", name);

            try
            {
                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommand);
                DataSet myDataSet = new DataSet();
                mySqlAdapter.Fill(myDataSet);

                gdvRejected.DataSource = myDataSet;
                gdvRejected.DataBind();
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            for (int count = 0; count < gdvPending.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvPending.Rows[count];

                    string tiket_id = gvrow.Cells[0].Text;

                    DropDownList list = ((DropDownList)gdvPending.Rows[count].FindControl("drpdwnDecision"));

                    SqlCommand sqlUpdate1 = new SqlCommand();
                    sqlUpdate1.Connection = sqlConnection;
                    sqlUpdate1.CommandText = "Update application SET status=@status,lulus=@lulus WHERE id=@id";
                    sqlUpdate1.Parameters.Clear();
                    sqlUpdate1.Parameters.AddWithValue("@status", list.SelectedItem.ToString());
                    sqlUpdate1.Parameters.AddWithValue("@lulus", "Dalam Pertimbangan");
                    sqlUpdate1.Parameters.AddWithValue("@id", tiket_id);
                    
                    SqlCommand sqlUpdate2 = new SqlCommand();
                    sqlUpdate2.Connection = sqlConnection;
                    sqlUpdate2.CommandText = "Update application SET status=@status WHERE id=@id";
                    sqlUpdate2.Parameters.Clear();
                    sqlUpdate2.Parameters.AddWithValue("@status", list.SelectedItem.ToString());
                    sqlUpdate2.Parameters.AddWithValue("@id", tiket_id);

                    SqlCommand sqlUpdate3 = new SqlCommand();
                    sqlUpdate3.Connection = sqlConnection;
                    sqlUpdate3.CommandText = "Update application SET status=@status,lulus=@lulus WHERE id=@id";
                    sqlUpdate3.Parameters.Clear();
                    sqlUpdate3.Parameters.AddWithValue("@status", list.SelectedItem.ToString());
                    sqlUpdate3.Parameters.AddWithValue("@lulus", "Tidak Lulus");
                    sqlUpdate3.Parameters.AddWithValue("@id", tiket_id);

                    sqlConnection.Open();

                    if (String.Compare(list.SelectedItem.ToString(), "Dalam Pertimbangan") == 0)
                    {
                        int change = sqlUpdate1.ExecuteNonQuery();
                    }
                    if (String.Compare(list.SelectedItem.ToString(), "Disokong") == 0)
                    {
                        int change = sqlUpdate2.ExecuteNonQuery();
                    }
                    if (String.Compare(list.SelectedItem.ToString(), "Tidak Disokong") == 0)
                    {
                        int change = sqlUpdate3.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Permohonan gagal dikemaskini. Sila cuba sebentar lagi.");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            for (int count = 0; count < gdvApproved.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvApproved.Rows[count];

                    string tiket_id = gvrow.Cells[0].Text;

                    DropDownList list = ((DropDownList)gdvApproved.Rows[count].FindControl("drpdwnDecision"));

                    SqlCommand sqlUpdate1 = new SqlCommand();
                    sqlUpdate1.Connection = sqlConnection;
                    sqlUpdate1.CommandText = "Update application SET status=@status,lulus=@lulus WHERE id=@id";
                    sqlUpdate1.Parameters.Clear();
                    sqlUpdate1.Parameters.AddWithValue("@status", list.SelectedItem.ToString());
                    sqlUpdate1.Parameters.AddWithValue("@lulus", "Dalam Pertimbangan");
                    sqlUpdate1.Parameters.AddWithValue("@id", tiket_id);

                    SqlCommand sqlUpdate2 = new SqlCommand();
                    sqlUpdate2.Connection = sqlConnection;
                    sqlUpdate2.CommandText = "Update application SET status=@status WHERE id=@id";
                    sqlUpdate2.Parameters.Clear();
                    sqlUpdate2.Parameters.AddWithValue("@status", list.SelectedItem.ToString());
                    sqlUpdate2.Parameters.AddWithValue("@id", tiket_id);

                    SqlCommand sqlUpdate3 = new SqlCommand();
                    sqlUpdate3.Connection = sqlConnection;
                    sqlUpdate3.CommandText = "Update application SET status=@status,lulus=@lulus WHERE id=@id";
                    sqlUpdate3.Parameters.Clear();
                    sqlUpdate3.Parameters.AddWithValue("@status", list.SelectedItem.ToString());
                    sqlUpdate3.Parameters.AddWithValue("@lulus", "Tidak Lulus");
                    sqlUpdate3.Parameters.AddWithValue("@id", tiket_id);

                    sqlConnection.Open();

                    if (String.Compare(list.SelectedItem.ToString(), "Dalam Pertimbangan") == 0)
                    {
                        int change = sqlUpdate1.ExecuteNonQuery();
                    }
                    if (String.Compare(list.SelectedItem.ToString(), "Disokong") == 0)
                    {
                        int change = sqlUpdate2.ExecuteNonQuery();
                    }
                    if (String.Compare(list.SelectedItem.ToString(), "Tidak Disokong") == 0)
                    {
                        int change = sqlUpdate3.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Permohonan gagal dikemaskini. Sila cuba sebentar lagi.");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            for (int count = 0; count < gdvRejected.Rows.Count; count++)
            {
                try
                {
                    GridViewRow gvrow = gdvRejected.Rows[count];

                    string tiket_id = gvrow.Cells[0].Text;

                    DropDownList list = ((DropDownList)gdvRejected.Rows[count].FindControl("drpdwnDecision"));

                    SqlCommand sqlUpdate1 = new SqlCommand();
                    sqlUpdate1.Connection = sqlConnection;
                    sqlUpdate1.CommandText = "Update application SET status=@status,lulus=@lulus WHERE id=@id";
                    sqlUpdate1.Parameters.Clear();
                    sqlUpdate1.Parameters.AddWithValue("@status", list.SelectedItem.ToString());
                    sqlUpdate1.Parameters.AddWithValue("@lulus", "Dalam Pertimbangan");
                    sqlUpdate1.Parameters.AddWithValue("@id", tiket_id);

                    SqlCommand sqlUpdate2 = new SqlCommand();
                    sqlUpdate2.Connection = sqlConnection;
                    sqlUpdate2.CommandText = "Update application SET status=@status WHERE id=@id";
                    sqlUpdate2.Parameters.Clear();
                    sqlUpdate2.Parameters.AddWithValue("@status", list.SelectedItem.ToString());
                    sqlUpdate2.Parameters.AddWithValue("@id", tiket_id);

                    SqlCommand sqlUpdate3 = new SqlCommand();
                    sqlUpdate3.Connection = sqlConnection;
                    sqlUpdate3.CommandText = "Update application SET status=@status,lulus=@lulus WHERE id=@id";
                    sqlUpdate3.Parameters.Clear();
                    sqlUpdate3.Parameters.AddWithValue("@status", list.SelectedItem.ToString());
                    sqlUpdate3.Parameters.AddWithValue("@lulus", "Tidak Lulus");
                    sqlUpdate3.Parameters.AddWithValue("@id", tiket_id);

                    sqlConnection.Open();

                    if (String.Compare(list.SelectedItem.ToString(), "Dalam Pertimbangan") == 0)
                    {
                        int change = sqlUpdate1.ExecuteNonQuery();
                    }
                    if (String.Compare(list.SelectedItem.ToString(), "Disokong") == 0)
                    {
                        int change = sqlUpdate2.ExecuteNonQuery();
                    }
                    if (String.Compare(list.SelectedItem.ToString(), "Tidak Disokong") == 0)
                    {
                        int change = sqlUpdate3.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Permohonan gagal dikemaskini. Sila cuba sebentar lagi.");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            //MessageBox.Show("Permohonan berjaya dikemaskini.");
            onload();
        }
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            tiketid = gvrow.Cells[0].Text;

            Labelpermohonan.Text = tiketid;
            this.ModalPopupExtender.Show();

            userconnection = new SqlConnection();
            userconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf;Trusted_Connection=True;User Instance=True";
            usercommand = new SqlCommand();
            usercommand.Connection = userconnection;

            usercommand.CommandText = "SELECT * FROM application WHERE id=@id";
            usercommand.Parameters.Clear();
            usercommand.Parameters.AddWithValue("@id", tiketid);

            try
            {
                userconnection.Open();
                userreader = usercommand.ExecuteReader();

                if (userreader.Read())
                {
                    ic.Text = userreader["username_pegawai"].ToString();
                    id.Text = userreader["id"].ToString();
                    nama.Text = userreader["nama"].ToString();
                    tarikhtempah.Text = userreader["tarikh_tempahan"].ToString();
                    masatempah.Text = userreader["masa_tempahan"].ToString();
                    tempat.Text = userreader["tempat_perjalanan"].ToString();
                    arah.Text = userreader["arah_perjalanan"].ToString();
                    jenis.Text = userreader["jenis"].ToString();
                    tarikhpergi.Text = userreader["tarikh_pergi"].ToString();
                    waktuperjalanan1a.Text = userreader["waktu_perjalanan1"].ToString();
                    tarikhbalik.Text = userreader["tarikh_balik"].ToString();
                    waktuperjalanan2a.Text = userreader["waktu_perjalanan2"].ToString();
                    tujuanperjalanan.Text = userreader["tujuan_perjalanan"].ToString();
                    catatan.Text = userreader["catatan"].ToString();
                    bilanganpenumpang.Text = userreader["bilangan_penumpang"].ToString();
                    namapenyelia.Text = userreader["nama_penyelia"].ToString();
                    emailpenyelia.Text = userreader["email_penyelia"].ToString();
                }
                else
                {
                    MessageBox.Show("Data permohonan tiket tidak ada dalam rekod.");
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