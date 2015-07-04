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
    public partial class status : System.Web.UI.Page
    {
        private SqlConnection userconnection, deleteconnection;
        private SqlCommand usercommand, deletecommand;
        private SqlDataReader userreader;

        static string tiketid;

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
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM application WHERE username_pegawai=@username_pegawai ORDER BY tarikh_pergi", sqlConnection);
            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.AddWithValue("@username_pegawai", User.Identity.Name);

            try
            {
                if (sqlConnection.State.Equals(ConnectionState.Open))
                    sqlConnection.Close();

                if (sqlConnection.State.Equals(ConnectionState.Closed))
                    sqlConnection.Open();

                SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommand);
                DataSet myDataSet = new DataSet();
                mySqlAdapter.Fill(myDataSet);

                gridtempah.DataSource = myDataSet;
                gridtempah.DataBind();

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
        protected void gridtempah_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridtempah.PageIndex = e.NewPageIndex;
            onload();
        }
        protected void linkfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("superlihatfailsokongan.aspx?tiketid=" + id.Text);
        }
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            tiketid = gvrow.Cells[0].Text;

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
                    string status_lulus = userreader["lulus"].ToString();

                    if (String.Compare(status_lulus, "Dalam Pertimbangan") == 0)
                    {
                        LabelStatus.Text = "Status permohonan " + tiketid + " masih dalam pertimbangan.";

                        LabelId.Visible = false;
                        LabelNama.Visible = false;
                        LabelTarikhTempah.Visible = false;
                        LabelMasaTempah.Visible = false;
                        LabelTempat.Visible = false;
                        LabelArah.Visible = false;
                        LabelJenis.Visible = false;
                        LabelTarikhPergi.Visible = false;
                        LabelWaktuPerjalanan1.Visible = false;
                        LabelTarikhBalik.Visible = false;
                        LabelWaktuPerjalanan2.Visible = false;
                        LabelTujuanPerjalanan.Visible = false;
                        LabelCatatan.Visible = false;
                        LabelBilanganPenumpang.Visible = false;
                        LabelFail.Visible = false;

                        id.Visible = false;
                        nama.Visible = false;
                        tarikhtempah.Visible = false;
                        masatempah.Visible = false;
                        tempat.Visible = false;
                        arah.Visible = false;
                        jenis.Visible = false;
                        tarikhpergi.Visible = false;
                        waktuperjalanan1.Visible = false;
                        tarikhbalik.Visible = false;
                        waktuperjalanan2.Visible = false;
                        tujuanperjalanan.Visible = false;
                        catatan.Visible = false;
                        bilanganpenumpang.Visible = false;
                        linkfile.Visible = false;
                    }
                    else if (String.Compare(status_lulus, "Lulus") == 0)
                    {
                        LabelStatus.Text = "Status permohonan " + tiketid + " telah disokong oleh pengarah. Butir-butir perjalanan adalah seperti berikut.";

                        LabelId.Visible = true;
                        LabelNama.Visible = true;
                        LabelTarikhTempah.Visible = true;
                        LabelMasaTempah.Visible = true;
                        LabelTempat.Visible = true;
                        LabelArah.Visible = true;
                        LabelJenis.Visible = true;
                        LabelTarikhPergi.Visible = true;
                        LabelWaktuPerjalanan1.Visible = true;
                        LabelTarikhBalik.Visible = true;
                        LabelWaktuPerjalanan2.Visible = true;
                        LabelTujuanPerjalanan.Visible = true;
                        LabelCatatan.Visible = true;
                        LabelBilanganPenumpang.Visible = true;
                        LabelFail.Visible = true;

                        id.Visible = true;
                        nama.Visible = true;
                        tarikhtempah.Visible = true;
                        masatempah.Visible = true;
                        tempat.Visible = true;
                        arah.Visible = true;
                        jenis.Visible = true;
                        tarikhpergi.Visible = true;
                        waktuperjalanan1.Visible = true;
                        tarikhbalik.Visible = true;
                        waktuperjalanan2.Visible = true;
                        tujuanperjalanan.Visible = true;
                        catatan.Visible = true;
                        bilanganpenumpang.Visible = true;
                        linkfile.Visible = true;

                        id.Text = userreader["id"].ToString();
                        nama.Text = userreader["nama"].ToString();
                        tarikhtempah.Text = userreader["tarikh_tempahan"].ToString();
                        masatempah.Text = userreader["masa_tempahan"].ToString();
                        tempat.Text = userreader["tempat_perjalanan"].ToString();
                        arah.Text = userreader["arah_perjalanan"].ToString();
                        jenis.Text = userreader["jenis"].ToString();
                        tarikhpergi.Text = userreader["tarikh_pergi"].ToString();
                        waktuperjalanan1.Text = userreader["waktu_perjalanan1"].ToString();
                        tarikhbalik.Text = userreader["tarikh_balik"].ToString();
                        waktuperjalanan2.Text = userreader["waktu_perjalanan2"].ToString();
                        tujuanperjalanan.Text = userreader["tujuan_perjalanan"].ToString();
                        catatan.Text = userreader["catatan"].ToString();
                        bilanganpenumpang.Text = userreader["bilangan_penumpang"].ToString();
                    }
                    else if (String.Compare(status_lulus, "Tidak Lulus") == 0)
                    {
                        LabelStatus2.Visible = true;
                        LabelStatus3.Visible = true;
                        LinkTempahTiket.Visible = true;
                        LabelStatus.Text = "Maaf, status permohonan " + tiketid + " tidak disokong oleh pengarah.";

                        LabelId.Visible = false;
                        LabelNama.Visible = false;
                        LabelTarikhTempah.Visible = false;
                        LabelMasaTempah.Visible = false;
                        LabelTempat.Visible = false;
                        LabelArah.Visible = false;
                        LabelJenis.Visible = false;
                        LabelTarikhPergi.Visible = false;
                        LabelWaktuPerjalanan1.Visible = false;
                        LabelTarikhBalik.Visible = false;
                        LabelWaktuPerjalanan2.Visible = false;
                        LabelTujuanPerjalanan.Visible = false;
                        LabelCatatan.Visible = false;
                        LabelBilanganPenumpang.Visible = false;
                        LabelFail.Visible = false;

                        id.Visible = false;
                        nama.Visible = false;
                        tarikhtempah.Visible = false;
                        masatempah.Visible = false;
                        tempat.Visible = false;
                        arah.Visible = false;
                        jenis.Visible = false;
                        tarikhpergi.Visible = false;
                        waktuperjalanan1.Visible = false;
                        tarikhbalik.Visible = false;
                        waktuperjalanan2.Visible = false;
                        tujuanperjalanan.Visible = false;
                        catatan.Visible = false;
                        bilanganpenumpang.Visible = false;
                        linkfile.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Status lulus tidak dapat dibaca!");
                    }
                }
                else
                {
                    MessageBox.Show("Data tempahan tiket tidak ada dalam rekod.");
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
        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            tiketid = gvrow.Cells[0].Text;
            DeleteTiket.Text = tiketid;
            this.ModalPopupExtender2.Show();
        }
        protected void confirmdelete_Click(object sender, EventArgs e)
        {
            deleteconnection = new SqlConnection();
            deleteconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            deletecommand = new SqlCommand();
            deletecommand.Connection = deleteconnection;
            deletecommand.CommandText = "DELETE FROM application WHERE id=@id";

            deletecommand.Parameters.Clear();
            deletecommand.Parameters.AddWithValue("@id", tiketid);

            userconnection = new SqlConnection();
            userconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf;Trusted_Connection=True;User Instance=True";
            usercommand = new SqlCommand();
            usercommand.Connection = userconnection;

            usercommand.CommandText = "SELECT * FROM application WHERE id=@id AND lulus=@lulus";
            usercommand.Parameters.Clear();
            usercommand.Parameters.AddWithValue("@id", tiketid);
            usercommand.Parameters.AddWithValue("@lulus", "Lulus");

            userconnection.Open();
            userreader = usercommand.ExecuteReader();

            if (!userreader.Read())
            {
                try
                {
                    deleteconnection.Open();
                    int change = deletecommand.ExecuteNonQuery();
                    if (change > 0)
                    {
                        MessageBox.Show("Tempahan tiket telah dibatalkan!");
                        onload();
                    }
                    else
                        MessageBox.Show("Proses pembatalan tempahan tiket tidak berjaya!");
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
            else
            {
                MessageBox.Show("Pembatalan tiket TIDAK BOLEH dibuat kerana penempahan TELAH DILULUSKAN untuk proses pembelian.");
            }
        }
        protected void Search2_Click(object sender, EventArgs e)
        {
            LabelId.Visible = false;
            LabelNama.Visible = false;
            LabelTarikhTempah.Visible = false;
            LabelMasaTempah.Visible = false;
            LabelTempat.Visible = false;
            LabelArah.Visible = false;
            LabelJenis.Visible = false;
            LabelTarikhPergi.Visible = false;
            LabelWaktuPerjalanan1.Visible = false;
            LabelTarikhBalik.Visible = false;
            LabelWaktuPerjalanan2.Visible = false;
            LabelTujuanPerjalanan.Visible = false;
            LabelCatatan.Visible = false;
            LabelBilanganPenumpang.Visible = false;
            LabelFail.Visible = false;

            id.Visible = false;
            nama.Visible = false;
            tarikhtempah.Visible = false;
            masatempah.Visible = false;
            tempat.Visible = false;
            arah.Visible = false;
            jenis.Visible = false;
            tarikhpergi.Visible = false;
            waktuperjalanan1.Visible = false;
            tarikhbalik.Visible = false;
            waktuperjalanan2.Visible = false;
            tujuanperjalanan.Visible = false;
            catatan.Visible = false;
            bilanganpenumpang.Visible = false;
            linkfile.Visible = false;

            string strSQLconnectionstatus = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnectionstatus = new SqlConnection(strSQLconnectionstatus);

            SqlCommand sqlCommandreadstatus = new SqlCommand("SELECT * FROM application WHERE id=@id", sqlConnectionstatus);
            sqlCommandreadstatus.Parameters.Clear();
            sqlCommandreadstatus.Parameters.AddWithValue("@id", txtSearch2.Text);

            if (sqlConnectionstatus.State.Equals(ConnectionState.Open))
                sqlConnectionstatus.Close();

            if (sqlConnectionstatus.State.Equals(ConnectionState.Closed))
                sqlConnectionstatus.Open();

            SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommandreadstatus);
            DataSet myDataSet = new DataSet();
            mySqlAdapter.Fill(myDataSet);

            gridtempah.DataSource = myDataSet;
            gridtempah.DataBind();

            SqlCommand sqlCommandreadstatus2 = new SqlCommand("SELECT * FROM application WHERE id=@id", sqlConnectionstatus);
            sqlCommandreadstatus2.Parameters.Clear();
            sqlCommandreadstatus2.Parameters.AddWithValue("@id", txtSearch2.Text);

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
                MessageBox.Show("No. rujukan tiket yang anda cari tiada dalam rekod...");
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
                    // If were here then the method has allready been
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