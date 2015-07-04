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
    public partial class daftaragen : System.Web.UI.Page
    {
        private SqlConnection updateconnection2;
        private SqlCommand updatecommand2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                onload();
            }
        }
        public string GetConnectionString()
        {
            //sets the connection string from your web config file "Table_Connection" is the name of your Connection String
            return System.Configuration.ConfigurationManager.ConnectionStrings["Table_Connection"].ConnectionString;
        }
        public int Count_Row()
        {
            Random rand = new Random();
            System.Data.SqlClient.SqlConnection conn3 = new System.Data.SqlClient.SqlConnection(GetConnectionString());
            string sql = "SELECT COUNT(*) FROM agen AS no";
            conn3.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn3);
            return (Convert.ToInt32(cmd.ExecuteScalar())) + 1 + rand.Next(1, 500);
        }
        private void onload()
        {
            
        }
        protected void assign_Click(object sender, EventArgs e)
        {
            updateconnection2 = new SqlConnection();
            updateconnection2.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand2 = new SqlCommand();
            updatecommand2.Connection = updateconnection2;

            updatecommand2.CommandText = "INSERT INTO agen (id,nama,alamat,nombor,faks,email,catatan,tarikh_mula_kewangan,tarikh_tamat_kewangan,tarikh_mula_tdc,tarikh_tamat_tdc,amaun,kod_prestasi) VALUES "

                        + " (@id,@nama,@alamat,@nombor,@faks,@email,@catatan,@tarikh_mula_kewangan,@tarikh_tamat_kewangan,@tarikh_mula_tdc,@tarikh_tamat_tdc,@amaun,@kod_prestasi)";

            updatecommand2.Parameters.Clear();

            updatecommand2.Parameters.AddWithValue("@id", "AG" + Count_Row());
            updatecommand2.Parameters.AddWithValue("@nama", TxtNama.Text);
            updatecommand2.Parameters.AddWithValue("@alamat", TxtAlamat.Text);
            updatecommand2.Parameters.AddWithValue("@nombor", DropDownListPhone2.Text + TxtPhone2.Text);
            updatecommand2.Parameters.AddWithValue("@faks", TxtFaks.Text);
            updatecommand2.Parameters.AddWithValue("@email", TxtEmail.Text);
            updatecommand2.Parameters.AddWithValue("@catatan", TxtCatatan.Text);
            updatecommand2.Parameters.AddWithValue("@tarikh_mula_kewangan", TxtTarikhKewangan1.Text);
            updatecommand2.Parameters.AddWithValue("@tarikh_tamat_kewangan", TxtTarikhKewangan2.Text);
            updatecommand2.Parameters.AddWithValue("@tarikh_mula_tdc", TarikhTDC1.Text);
            updatecommand2.Parameters.AddWithValue("@tarikh_tamat_tdc", TarikhTDC2.Text);
            updatecommand2.Parameters.AddWithValue("@amaun", TxtGaji.Text);
            updatecommand2.Parameters.AddWithValue("@kod_prestasi", "6 - Baik");

            DateTime datepick = Convert.ToDateTime(TxtTarikhKewangan1.Text);
            DateTime datepick2 = Convert.ToDateTime(TxtTarikhKewangan2.Text);
            DateTime datepick3 = Convert.ToDateTime(TarikhTDC1.Text);
            DateTime datepick4 = Convert.ToDateTime(TarikhTDC2.Text);

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
                        updateconnection2.Open();

                        int change = updatecommand2.ExecuteNonQuery();
                        if (change > 0)
                        {
                            MessageBox.Show("Pendaftaran agen berjaya! ");
                        }
                        else
                            MessageBox.Show("Proses tidak berjaya! Sila cuba sekali lagi");


                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Maaf, sistem sedang sibuk. Sila cuba sebentar lagi");
                    }
                    finally
                    {
                        updateconnection2.Close();

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
            onload();
            Response.Redirect("daftaragen.aspx");
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
        protected void Clear_Click(object sender, EventArgs e)
        {
            Response.Redirect("daftaragen.aspx");
        }
       
        
    }
}