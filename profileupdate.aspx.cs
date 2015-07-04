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
    public partial class profileupdate : System.Web.UI.Page
    {
        private SqlConnection userconnection, loginconnection, updateconnection;
        private SqlCommand usercommand, logincommand, updatecommand;
        private SqlDataReader userreader, loginreader;

        protected void Page_Load(object sender, EventArgs e)
        {
            userconnection = new SqlConnection();
            userconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf;Trusted_Connection=True;User Instance=True";
            usercommand = new SqlCommand();
            usercommand.Connection = userconnection;

            usercommand.CommandText = "SELECT * FROM profil_pegawai WHERE username=@username";
            usercommand.Parameters.Clear();
            usercommand.Parameters.AddWithValue("@username", User.Identity.Name);

            loginconnection = new SqlConnection();
            loginconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aspnetdb.mdf; Trusted_Connection=True;User Instance=True";
            logincommand = new SqlCommand();
            logincommand.Connection = loginconnection;

            logincommand.CommandText = "SELECT UserName FROM aspnet_Users WHERE UserName=@UserName";
            logincommand.Parameters.Clear();
            logincommand.Parameters.AddWithValue("@UserName", User.Identity.Name);

            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;

            if (!IsPostBack)
            {
                try
                {
                    loginconnection.Open();
                    loginreader = logincommand.ExecuteReader(CommandBehavior.SingleRow);

                    if (loginreader.Read())
                    {
                        try
                        {
                            userconnection.Open();
                            userreader = usercommand.ExecuteReader(CommandBehavior.SingleRow);

                            if (userreader.Read())
                            {
                                TxtNama.Text = userreader["nama"].ToString();
                                TxtEmail.Text = userreader["email"].ToString();
                                KumpulanPerkhidmatan.Text = userreader["kumpulan_perkhidmatan"].ToString();
                                Jawatan.Text = userreader["jawatan"].ToString();
                                Bahagian.Text = userreader["bahagian"].ToString();
                                GredJawatan.Text = userreader["gred_jawatan"].ToString();
                                TxtSektor.Text = userreader["sektor"].ToString();
                                TxtPhone.Text = userreader["telefon_bimbit"].ToString();
                                TxtPhone2.Text = userreader["telefon_pejabat"].ToString();
                                
                                update.Enabled = true;
                                TxtNama.Enabled = true;
                                TxtEmail.Enabled = true;
                                KumpulanPerkhidmatan.Enabled = true;
                                Jawatan.Enabled = true;
                                Bahagian.Enabled = true;
                                GredJawatan.Enabled = true;
                                TxtSektor.Enabled = true;
                                TxtPhone.Enabled = true;
                                TxtPhone2.Enabled = true;
                            }
                            else
                                MessageBox.Show("Profil anda tiada dalam rekod. Sila isikan data profil.");

                            userreader.Close();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Data pengguna tiada dalam rekod.");
                        }
                        finally
                        {
                            userconnection.Close();
                        }
                    }
                    else
                        MessageBox.Show("Anda perlu log masuk");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Maaf, sistem tergendala. Sila cuba sekali lagi");
                }
                finally
                {
                    loginconnection.Close();
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

        protected void update_Click(object sender, EventArgs e)
        {
            updatecommand.CommandText = "UPDATE profil_pegawai SET nama=@nama,email=@email,kumpulan_perkhidmatan=@kumpulan_perkhidmatan,jawatan=@jawatan,bahagian=@bahagian,gred_jawatan=@gred_jawatan,sektor=@sektor,telefon_bimbit=@telefon_bimbit,telefon_pejabat=@telefon_pejabat WHERE username=@username";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@nama", TxtNama.Text);
            updatecommand.Parameters.AddWithValue("@email", TxtEmail.Text);
            updatecommand.Parameters.AddWithValue("@kumpulan_perkhidmatan", KumpulanPerkhidmatan.Text);
            updatecommand.Parameters.AddWithValue("@jawatan", Jawatan.Text);
            updatecommand.Parameters.AddWithValue("@bahagian", Bahagian.Text);
            updatecommand.Parameters.AddWithValue("@gred_jawatan", GredJawatan.Text);
            updatecommand.Parameters.AddWithValue("@sektor", TxtSektor.Text);
            updatecommand.Parameters.AddWithValue("@telefon_bimbit", TxtPhone.Text);
            updatecommand.Parameters.AddWithValue("@telefon_pejabat", TxtPhone2.Text);
            updatecommand.Parameters.AddWithValue("@username", User.Identity.Name);

            try
            {
                updateconnection.Open();
                int change = updatecommand.ExecuteNonQuery();
                if (change > 0)
                {
                    MessageBox.Show("Profil berjaya dikemaskini!");
                }
                else
                    MessageBox.Show("Kemaskini profil gagal. Sila cuba lagi!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Harap maaf. Sistem tergendala");
            }
            finally
            {
                updateconnection.Close();
            }
        }
    }
}