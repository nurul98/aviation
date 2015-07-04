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

namespace aviation
{
    public partial class BookingApplication : System.Web.UI.Page
    {
        private SqlConnection updateconnection2;
        private SqlCommand updatecommand2;

        static string name;

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
            string sql = "SELECT COUNT(*) FROM application AS no";
            conn3.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn3);
            return (Convert.ToInt32(cmd.ExecuteScalar())) + 1 + rand.Next(1, 500);
        }
        private void onload()
        {
        }
        protected void tempah()
        {
            string strSQLconnectionnama = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnectionnama = new SqlConnection(strSQLconnectionnama);

            SqlCommand sqlCommandreadnama = new SqlCommand("SELECT nama FROM profil_pegawai WHERE username=@username", sqlConnectionnama);
            sqlCommandreadnama.Parameters.Clear();
            sqlCommandreadnama.Parameters.AddWithValue("@username", User.Identity.Name);

            if (sqlConnectionnama.State.Equals(ConnectionState.Open))
                sqlConnectionnama.Close();

            if (sqlConnectionnama.State.Equals(ConnectionState.Closed))
                sqlConnectionnama.Open();

            SqlDataReader readernama = sqlCommandreadnama.ExecuteReader();

            if (readernama.Read())
            {
                name = readernama["nama"].ToString();
            }
            else
            {
                MessageBox.Show("Gagal membaca nama pegawai.");
            }
            
            string strSQLconnection3 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection3 = new SqlConnection(strSQLconnection3);

            SqlCommand sqlCommandread3 = new SqlCommand("SELECT * FROM application WHERE tarikh_pergi=@tarikh_pergi AND username_pegawai=@username_pegawai", sqlConnection3);
            sqlCommandread3.Parameters.Clear();
            sqlCommandread3.Parameters.AddWithValue("@tarikh_pergi", TxtTarikhPergi.Text);
            sqlCommandread3.Parameters.AddWithValue("@username_pegawai", User.Identity.Name);
            
            if (sqlConnection3.State.Equals(ConnectionState.Open))
                sqlConnection3.Close();

            if (sqlConnection3.State.Equals(ConnectionState.Closed))
                sqlConnection3.Open();

            SqlDataReader reader3 = sqlCommandread3.ExecuteReader();

            string strSQLconnection3a = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection3a = new SqlConnection(strSQLconnection3a);

            SqlCommand sqlCommandread3a = new SqlCommand("SELECT * FROM application WHERE tarikh_balik=@tarikh_balik AND username_pegawai=@username_pegawai", sqlConnection3a);
            sqlCommandread3a.Parameters.Clear();
            sqlCommandread3a.Parameters.AddWithValue("@tarikh_balik", TxtTarikhPergi.Text);
            sqlCommandread3a.Parameters.AddWithValue("@username_pegawai", User.Identity.Name);

            if (sqlConnection3a.State.Equals(ConnectionState.Open))
                sqlConnection3a.Close();

            if (sqlConnection3a.State.Equals(ConnectionState.Closed))
                sqlConnection3a.Open();

            SqlDataReader reader3a = sqlCommandread3a.ExecuteReader();

            string strSQLconnection3b = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection3b = new SqlConnection(strSQLconnection3b);

            SqlCommand sqlCommandread3b = new SqlCommand("SELECT * FROM tiket_sehala WHERE tarikh_pergi=@tarikh_pergi AND username_pegawai=@username_pegawai", sqlConnection3b);
            sqlCommandread3b.Parameters.Clear();
            sqlCommandread3b.Parameters.AddWithValue("@tarikh_pergi", TxtTarikhPergi.Text);
            sqlCommandread3b.Parameters.AddWithValue("@username_pegawai", User.Identity.Name);

            if (sqlConnection3b.State.Equals(ConnectionState.Open))
                sqlConnection3b.Close();

            if (sqlConnection3b.State.Equals(ConnectionState.Closed))
                sqlConnection3b.Open();

            SqlDataReader reader3b = sqlCommandread3b.ExecuteReader();

            string strSQLconnection4 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection4 = new SqlConnection(strSQLconnection4);

            SqlCommand sqlCommandread4 = new SqlCommand("SELECT * FROM application WHERE tarikh_balik=@tarikh_balik AND username_pegawai=@username_pegawai", sqlConnection4);
            sqlCommandread4.Parameters.Clear();
            sqlCommandread4.Parameters.AddWithValue("@tarikh_balik", TxtTarikhBalik.Text);
            sqlCommandread4.Parameters.AddWithValue("@username_pegawai", User.Identity.Name);

            if (sqlConnection4.State.Equals(ConnectionState.Open))
                sqlConnection4.Close();

            if (sqlConnection4.State.Equals(ConnectionState.Closed))
                sqlConnection4.Open();

            SqlDataReader reader4 = sqlCommandread4.ExecuteReader();

            string strSQLconnection4a = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection4a = new SqlConnection(strSQLconnection4a);

            SqlCommand sqlCommandread4a = new SqlCommand("SELECT * FROM application WHERE tarikh_pergi=@tarikh_pergi AND username_pegawai=@username_pegawai", sqlConnection4a);
            sqlCommandread4a.Parameters.Clear();
            sqlCommandread4a.Parameters.AddWithValue("@tarikh_pergi", TxtTarikhBalik.Text);
            sqlCommandread4a.Parameters.AddWithValue("@username_pegawai", User.Identity.Name);

            if (sqlConnection4a.State.Equals(ConnectionState.Open))
                sqlConnection4a.Close();

            if (sqlConnection4a.State.Equals(ConnectionState.Closed))
                sqlConnection4a.Open();

            SqlDataReader reader4a = sqlCommandread4a.ExecuteReader();

            string strSQLconnection4b = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection4b = new SqlConnection(strSQLconnection4b);

            SqlCommand sqlCommandread4b = new SqlCommand("SELECT * FROM tiket_sehala WHERE tarikh_pergi=@tarikh_pergi AND username_pegawai=@username_pegawai", sqlConnection4b);
            sqlCommandread4b.Parameters.Clear();
            sqlCommandread4b.Parameters.AddWithValue("@tarikh_pergi", TxtTarikhBalik.Text);
            sqlCommandread4b.Parameters.AddWithValue("@username_pegawai", User.Identity.Name);

            if (sqlConnection4b.State.Equals(ConnectionState.Open))
                sqlConnection4b.Close();

            if (sqlConnection4b.State.Equals(ConnectionState.Closed))
                sqlConnection4b.Open();

            SqlDataReader reader4b = sqlCommandread4b.ExecuteReader();

            updateconnection2 = new SqlConnection();
            updateconnection2.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand2 = new SqlCommand();
            updatecommand2.Connection = updateconnection2;

            updatecommand2.CommandText = "INSERT INTO application (id,username_pegawai,nama,tarikh_tempahan,masa_tempahan,tempat_perjalanan,arah_perjalanan,jenis,tarikh_pergi,waktu_perjalanan1,tarikh_balik,waktu_perjalanan2,cara_perjalanan,tujuan_perjalanan,catatan,bilangan_penumpang,nama_penyelia,email_penyelia,status,lulus,FileName,MIME,BinaryData,pangkat) VALUES "

                        + " (@id,@username_pegawai,@nama,@tarikh_tempahan,@masa_tempahan,@tempat_perjalanan,@arah_perjalanan,@jenis,@tarikh_pergi,@waktu_perjalanan1,@tarikh_balik,@waktu_perjalanan2,@cara_perjalanan,@tujuan_perjalanan,@catatan,@bilangan_penumpang,@nama_penyelia,@email_penyelia,@status,@lulus,@FileName,@MIME,@BinaryData,@pangkat)";

            updatecommand2.Parameters.Clear();

            updatecommand2.Parameters.AddWithValue("@id", "TD" + Count_Row());
            updatecommand2.Parameters.AddWithValue("@username_pegawai", User.Identity.Name);
            updatecommand2.Parameters.AddWithValue("@nama", name);
            updatecommand2.Parameters.AddWithValue("@tarikh_tempahan", DateTime.Now);
            updatecommand2.Parameters.AddWithValue("@masa_tempahan", DateTime.Now.ToString("h:mm tt"));
            updatecommand2.Parameters.AddWithValue("@tempat_perjalanan", TxtTempat.Text);
            updatecommand2.Parameters.AddWithValue("@arah_perjalanan", TxtKe.Text);
            updatecommand2.Parameters.AddWithValue("@jenis", TxtJenis.Text);
            updatecommand2.Parameters.AddWithValue("@tarikh_pergi", TxtTarikhPergi.Text);
            updatecommand2.Parameters.AddWithValue("@waktu_perjalanan1", waktuperjalanan1.Text);
            updatecommand2.Parameters.AddWithValue("@tarikh_balik", TxtTarikhBalik.Text);
            updatecommand2.Parameters.AddWithValue("@waktu_perjalanan2", waktuperjalanan2.Text);
            updatecommand2.Parameters.AddWithValue("@cara_perjalanan", "Udara");
            updatecommand2.Parameters.AddWithValue("@tujuan_perjalanan", TxtTujuanPerjalanan.Text);
            updatecommand2.Parameters.AddWithValue("@catatan", TxtCatatan.Text);
            updatecommand2.Parameters.AddWithValue("@bilangan_penumpang", bilangan_penumpang.Text);
            updatecommand2.Parameters.AddWithValue("@nama_penyelia", namapenyelia.Text);
            updatecommand2.Parameters.AddWithValue("@email_penyelia", email_penyelia.Text);
            updatecommand2.Parameters.AddWithValue("@status", "Dalam Pertimbangan");
            updatecommand2.Parameters.AddWithValue("@lulus", "Dalam Pertimbangan");
            updatecommand2.Parameters.AddWithValue("@pangkat", "pegawai");
            updatecommand2.Parameters.AddWithValue("@FileName", FileUploadTujuan.FileName);
            updatecommand2.Parameters.AddWithValue("@MIME", FileUploadTujuan.PostedFile.ContentType);

            byte[] imageBytes = new byte[FileUploadTujuan.PostedFile.InputStream.Length + 1];
            FileUploadTujuan.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length);

            updatecommand2.Parameters.AddWithValue("@BinaryData", imageBytes);

            if (reader3.Read())
            {
                MessageBox.Show("Pegawai ini telah membuat penempahan tiket pada tarikh tersebut. Sila pilih tarikh lain.");
            }
            else if (reader3a.Read())
            {
                MessageBox.Show("Pegawai ini telah membuat penempahan tiket pada tarikh tersebut. Sila pilih tarikh lain.");
            }
            else if (reader3b.Read())
            {
                MessageBox.Show("Pegawai ini telah membuat penempahan tiket pada tarikh tersebut. Sila pilih tarikh lain.");
            }
            else if (reader4.Read())
            {
                MessageBox.Show("Pegawai ini telah membuat penempahan tiket pada tarikh tersebut. Sila pilih tarikh lain.");
            }
            else if (reader4a.Read())
            {
                MessageBox.Show("Pegawai ini telah membuat penempahan tiket pada tarikh tersebut. Sila pilih tarikh lain.");
            }
            else if (reader4b.Read())
            {
                MessageBox.Show("Pegawai ini telah membuat penempahan tiket pada tarikh tersebut. Sila pilih tarikh lain.");
            }
            else
            {     
                DateTime datepick = Convert.ToDateTime(TxtTarikhPergi.Text);
                DateTime datepick2 = Convert.ToDateTime(TxtTarikhBalik.Text);

                try
                {
                    if (DateTime.Now.AddDays(-1) > datepick || datepick > DateTime.Now.AddMonths(5) || datepick > datepick2)
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
                                MessageBox.Show("Proses tempahan tiket berjaya! ");
                            }
                            else
                                MessageBox.Show("Maaf, proses tempahan tiket gagal!");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Maaf, sistem sedang sibuk. Sila cuba sekali lagi");
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
            }
        }
        protected void assign_Click(object sender, EventArgs e)
        {
            if (!FileUploadTujuan.HasFile)
            {
                MessageBox.Show("Fail sokongan perlu disertakan.");
            }
            else
            {
                tempah();
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
        protected void Clear_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookingApplication.aspx");
        }
    }
}