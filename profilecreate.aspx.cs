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

namespace aviation
{
    public partial class profilecreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public string GetConnectionString()
        {
            //sets the connection string from your web config file "Patient_Table_Connection" is the name of your Connection String
            return System.Configuration.ConfigurationManager.ConnectionStrings["Table_Connection"].ConnectionString;
        }
        private void ExecuteInsert(string ID, string name, string username, string email, string kumpulan_perkhidmatan, string jawatan, string bahagian, string gred_jawatan, string sektor, string telefon_bimbit, string telefon_pejabat, string pangkat)
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(GetConnectionString());

            string sql = "INSERT INTO profil_pegawai (id,nama,username,email,kumpulan_perkhidmatan,jawatan,bahagian,gred_jawatan,sektor,telefon_bimbit,telefon_pejabat,pangkat) VALUES "

                        + " (@id,@nama,@username,@email,@kumpulan_perkhidmatan,@jawatan,@bahagian,@gred_jawatan,@sektor,@telefon_bimbit,@telefon_pejabat,@pangkat)";
            try
            {
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn);
                System.Data.SqlClient.SqlParameter[] param = new System.Data.SqlClient.SqlParameter[12];

                param[0] = new System.Data.SqlClient.SqlParameter("@id", System.Data.SqlDbType.VarChar, 10);
                param[1] = new System.Data.SqlClient.SqlParameter("@nama", System.Data.SqlDbType.VarChar, 50);
                param[2] = new System.Data.SqlClient.SqlParameter("@username", System.Data.SqlDbType.VarChar, 30);
                param[3] = new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 50);
                param[4] = new System.Data.SqlClient.SqlParameter("@kumpulan_perkhidmatan", System.Data.SqlDbType.VarChar, 50);
                param[5] = new System.Data.SqlClient.SqlParameter("@jawatan", System.Data.SqlDbType.VarChar, 50);
                param[6] = new System.Data.SqlClient.SqlParameter("@bahagian", System.Data.SqlDbType.VarChar, 50);
                param[7] = new System.Data.SqlClient.SqlParameter("@gred_jawatan", System.Data.SqlDbType.VarChar, 50);
                param[8] = new System.Data.SqlClient.SqlParameter("@sektor", System.Data.SqlDbType.VarChar, 50);
                param[9] = new System.Data.SqlClient.SqlParameter("@telefon_bimbit", System.Data.SqlDbType.VarChar, 50);
                param[10] = new System.Data.SqlClient.SqlParameter("@telefon_pejabat", System.Data.SqlDbType.VarChar, 50);
                param[11] = new System.Data.SqlClient.SqlParameter("@pangkat", System.Data.SqlDbType.VarChar, 10);
                
                param[0].Value = ID;
                param[1].Value = name;
                param[2].Value = username;
                param[3].Value = email;
                param[4].Value = kumpulan_perkhidmatan;
                param[5].Value = jawatan;
                param[6].Value = bahagian;
                param[7].Value = gred_jawatan;
                param[8].Value = sektor;
                param[9].Value = telefon_bimbit;
                param[10].Value = telefon_pejabat;
                param[11].Value = pangkat;

                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Gagal menyimpan rekod!";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }
        public int Count_Row()
        {
            Random rand = new Random();

            System.Data.SqlClient.SqlConnection conn3 = new System.Data.SqlClient.SqlConnection(GetConnectionString());
            string sql = "SELECT COUNT(*) FROM profil_pegawai AS no";
            conn3.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, conn3);
            return Convert.ToInt32(cmd.ExecuteScalar()) + (rand.Next(1, 500));
        }
        protected void Submit_Register_Click(object sender, EventArgs e)
        {
            //call the method to execute insert to the database
            ExecuteInsert("PG" + Count_Row(), TxtNama.Text, User.Identity.Name, TxtEmail.Text, KumpulanPerkhidmatan.Text, Jawatan.Text, Bahagian.Text, GredJawatan.Text, TxtSektor.Text, DropDownListPhone.Text + TxtPhone.Text, DropDownListPhone2.Text + TxtPhone2.Text,"pegawai");
            Response.Redirect("profileprogress.aspx");
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
        protected void Clear_Click(object sender, EventArgs e)
        {
            Response.Redirect("profilecreate.aspx");
        }
    }
}