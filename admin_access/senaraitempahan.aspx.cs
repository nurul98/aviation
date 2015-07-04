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
    public partial class senaraitempahan : System.Web.UI.Page
    {
        private SqlConnection userconnection, updateconnection, deleteconnection;
        private SqlCommand usercommand, updatecommand, deletecommand;
        private SqlDataReader userreader;

        static string tiketid,icpegawai,refertarikhbalik,refertarikhpergi;

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
            LabelNamaPenyelia.Visible = false;
            LabelEmailPenyelia.Visible = false;
            LabelFail.Visible = false;
          
            update.Visible = false;
            ic.Visible = false;
            id.Visible = false;
            nama.Visible = false;
            tarikhtempah.Visible = false;
            masatempah.Visible = false;
            tempat.Visible = false;
            arah.Visible = false;
            jenis.Visible = false;
            tarikhpergi.Visible = false;
            waktuperjalanan1a.Visible = false;
            tarikhbalik.Visible = false;
            waktuperjalanan2a.Visible = false;
            tujuanperjalanan.Visible = false;
            catatan.Visible = false;
            bilanganpenumpang.Visible = false;
            namapenyelia.Visible = false;
            emailpenyelia.Visible = false;
            linkfile.Visible = false;
            linkfailbaru.Visible = false;
            notes.Visible = false;
          
            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM application ORDER BY tarikh_tempahan,masa_tempahan", sqlConnection);

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
            Response.Redirect("lihatfail.aspx?tiketid=" + id.Text);
        }
        protected void linkfilebaru_Click(object sender, EventArgs e)
        {
            Labelfailbaru.Text = id.Text;
            this.ModalPopupExtenderfail.Show();
        }
        protected void okfailbaru_Click(object sender, EventArgs e)
        {
            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;

            updatecommand.CommandText = "UPDATE application SET FileName=@FileName,MIME=@MIME,BinaryData=@BinaryData WHERE id=@id";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@id", id.Text);
            updatecommand.Parameters.AddWithValue("@FileName", FileUploadbaru.FileName);
            updatecommand.Parameters.AddWithValue("@MIME", FileUploadbaru.PostedFile.ContentType);

            byte[] imageBytes = new byte[FileUploadbaru.PostedFile.InputStream.Length + 1];
            FileUploadbaru.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length);

            updatecommand.Parameters.AddWithValue("@BinaryData", imageBytes);

            updateconnection.Open();
            int change = updatecommand.ExecuteNonQuery();
            if (change > 0)
            {
                MessageBox.Show("Fail sokongan telah diperbaharui!");
            }
            else
                MessageBox.Show("Fail sokongan gagal diperbaharui.");

            updateconnection.Close();
        }
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            LabelIC.Visible = true;
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
            LabelNamaPenyelia.Visible = true;
            LabelEmailPenyelia.Visible = true;
            LabelFail.Visible = true;
          
            update.Visible = true;
            ic.Visible = true;
            id.Visible = true;
            nama.Visible = true;
            tarikhtempah.Visible = true;
            masatempah.Visible = true;
            tempat.Visible = true;
            arah.Visible = true;
            jenis.Visible = true;
            tarikhpergi.Visible = true;
            waktuperjalanan1a.Visible = true;
            tarikhbalik.Visible = true;
            waktuperjalanan2a.Visible = true;
            tujuanperjalanan.Visible = true;
            catatan.Visible = true;
            bilanganpenumpang.Visible = true;
            namapenyelia.Visible = true;
            emailpenyelia.Visible = true;
            linkfile.Visible = true;
            linkfailbaru.Visible = true;
            notes.Visible = true;
          
            update.Enabled = true;
            ic.Enabled = false;
            id.Enabled = false;
            nama.Enabled = false;
            tarikhtempah.Enabled = false;
            masatempah.Enabled = false;
            tempat.Enabled = true;
            arah.Enabled = true;
            jenis.Enabled = true;
            tarikhpergi.Enabled = false;
            waktuperjalanan1a.Enabled = true;
            tarikhbalik.Enabled = false;
            waktuperjalanan2a.Enabled = true;
            tujuanperjalanan.Enabled = true;
            catatan.Enabled = true;
            bilanganpenumpang.Enabled = true;
            namapenyelia.Enabled = true;
            emailpenyelia.Enabled = true;
            linkfile.Enabled = true;
            linkfailbaru.Enabled = true;
            notes.Enabled = true;

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
        protected void update_Click(object sender, EventArgs e)
        {
            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);

            SqlCommand sqlCommandread = new SqlCommand("SELECT status,lulus,id FROM application WHERE status=@status AND lulus=@lulus AND id=@id", sqlConnection);
            sqlCommandread.Parameters.Clear();
            sqlCommandread.Parameters.AddWithValue("@status", "Dalam Pertimbangan");
            sqlCommandread.Parameters.AddWithValue("@lulus", "Dalam Pertimbangan");
            sqlCommandread.Parameters.AddWithValue("@id", tiketid);

            if (sqlConnection.State.Equals(ConnectionState.Open))
                sqlConnection.Close();

            if (sqlConnection.State.Equals(ConnectionState.Closed))
                sqlConnection.Open();

            SqlDataReader reader = sqlCommandread.ExecuteReader();

            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;

            updatecommand.CommandText = "UPDATE application SET username_pegawai=@username_pegawai,tempat_perjalanan=@tempat_perjalanan,arah_perjalanan=@arah_perjalanan,jenis=@jenis,tarikh_pergi=@tarikh_pergi,waktu_perjalanan1=@waktu_perjalanan1,tarikh_balik=@tarikh_balik,waktu_perjalanan2=@waktu_perjalanan2,tujuan_perjalanan=@tujuan_perjalanan,catatan=@catatan,bilangan_penumpang=@bilangan_penumpang,nama_penyelia=@nama_penyelia,email_penyelia=@email_penyelia WHERE id=@id";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@id", id.Text);
            updatecommand.Parameters.AddWithValue("@username_pegawai", ic.Text);
            updatecommand.Parameters.AddWithValue("@tempat_perjalanan", tempat.Text);
            updatecommand.Parameters.AddWithValue("@arah_perjalanan", arah.Text);
            updatecommand.Parameters.AddWithValue("@jenis", jenis.Text);
            updatecommand.Parameters.AddWithValue("@tarikh_pergi", tarikhpergi.Text);
            updatecommand.Parameters.AddWithValue("@waktu_perjalanan1", waktuperjalanan1a.Text);
            updatecommand.Parameters.AddWithValue("@tarikh_balik", tarikhbalik.Text);
            updatecommand.Parameters.AddWithValue("@waktu_perjalanan2", waktuperjalanan2a.Text);
            updatecommand.Parameters.AddWithValue("@tujuan_perjalanan", tujuanperjalanan.Text);
            updatecommand.Parameters.AddWithValue("@catatan", catatan.Text);
            updatecommand.Parameters.AddWithValue("@bilangan_penumpang", bilanganpenumpang.Text);
            updatecommand.Parameters.AddWithValue("@nama_penyelia", namapenyelia.Text);
            updatecommand.Parameters.AddWithValue("@email_penyelia", emailpenyelia.Text);

            if (reader.Read())
            {
                try
                {
                    updateconnection.Open();
                    int change = updatecommand.ExecuteNonQuery();
                    if (change > 0)
                    {
                        MessageBox.Show("Rekod tempahan tiket berjaya dikemaskini!");
                    }
                    else
                        MessageBox.Show("Rekod tempahan tiket gagal dikemaskini.");
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
            else
            {
                MessageBox.Show("Permohonan telah dinilai oleh penyelia. Maklumat permohonan tidak boleh diubah.");
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
        protected void btnvalidstatus_Click(object sender, EventArgs e)
        {
            Button btndetails = sender as Button;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            pilihstatus.Text = ((Button)gvrow.FindControl("btnstatus")).Text;
            tiketid = gvrow.Cells[0].Text;
            Labelterima.Text = tiketid;

            this.ModalPopupExtender.Show();
        }
        protected void tukarstatus_Click(object sender, EventArgs e)
        {
            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);

            SqlCommand sqlCommandread = new SqlCommand("SELECT status,id FROM application WHERE status=@status AND id=@id", sqlConnection);
            sqlCommandread.Parameters.Clear();
            sqlCommandread.Parameters.AddWithValue("@status", "Disokong");
            sqlCommandread.Parameters.AddWithValue("@id", tiketid);

            if (sqlConnection.State.Equals(ConnectionState.Open))
                sqlConnection.Close();

            if (sqlConnection.State.Equals(ConnectionState.Closed))
                sqlConnection.Open();

            SqlDataReader reader = sqlCommandread.ExecuteReader();

            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;
            updatecommand.CommandText = "UPDATE application SET lulus=@lulus WHERE id=@id";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@id", tiketid);
            updatecommand.Parameters.AddWithValue("@lulus", pilihstatus.Text);
           
            if (reader.Read())
            {
                try
                {
                    updateconnection.Open();
                    int change = updatecommand.ExecuteNonQuery();
                    if (change > 0)
                    {
                        MessageBox.Show("Status terima berjaya dikemaskini! ");
                        onload();
                    }
                    else
                        MessageBox.Show("Status terima gagal dikemaskini!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Sistem sedang sibuk untuk mengemaskini status. Sila cuba sebentar lagi");
                }
                finally
                {
                    updateconnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Permohonan masih belum disokong oleh penyelia dan tidak boleh diluluskan untuk pembayaran.");
            }
        }
        protected void btntarikhpergi_Click(object sender, EventArgs e)
        {
            Button btndetails = sender as Button;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txttarikhpergi.Text = ((Button)gvrow.FindControl("btntarikhpergi")).Text;
            tiketid = gvrow.Cells[0].Text;
            icpegawai = gvrow.Cells[1].Text;
            statustarikhpergi.Text = tiketid;

            this.ModalPopupExtender1a.Show();
        }
        protected void oktarikhpergi_Click(object sender, EventArgs e)
        {
            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);

            SqlCommand sqlCommandread = new SqlCommand("SELECT * FROM application WHERE status=@status AND lulus=@lulus AND id=@id", sqlConnection);
            sqlCommandread.Parameters.Clear();
            sqlCommandread.Parameters.AddWithValue("@status", "Dalam Pertimbangan");
            sqlCommandread.Parameters.AddWithValue("@lulus", "Dalam Pertimbangan");
            sqlCommandread.Parameters.AddWithValue("@id", tiketid);

            if (sqlConnection.State.Equals(ConnectionState.Open))
                sqlConnection.Close();

            if (sqlConnection.State.Equals(ConnectionState.Closed))
                sqlConnection.Open();

            SqlDataReader reader = sqlCommandread.ExecuteReader();
            
            string strSQLconnection1 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection1 = new SqlConnection(strSQLconnection1);

            SqlCommand sqlCommandread1 = new SqlCommand("SELECT tarikh_balik FROM application WHERE id=@id", sqlConnection1);
            sqlCommandread1.Parameters.Clear();
            sqlCommandread1.Parameters.AddWithValue("@id", tiketid);
           
            if (sqlConnection1.State.Equals(ConnectionState.Open))
                sqlConnection1.Close();

            if (sqlConnection1.State.Equals(ConnectionState.Closed))
                sqlConnection1.Open();

            SqlDataReader reader1 = sqlCommandread1.ExecuteReader();
            reader1.Read();
            refertarikhbalik = reader1["tarikh_balik"].ToString();

            string strSQLconnection3 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection3 = new SqlConnection(strSQLconnection3);

            SqlCommand sqlCommandread3 = new SqlCommand("SELECT * FROM application WHERE tarikh_pergi=@tarikh_pergi AND username_pegawai=@username_pegawai", sqlConnection3);
            sqlCommandread3.Parameters.Clear();
            sqlCommandread3.Parameters.AddWithValue("@tarikh_pergi", txttarikhpergi.Text);
            sqlCommandread3.Parameters.AddWithValue("@username_pegawai",icpegawai );

            if (sqlConnection3.State.Equals(ConnectionState.Open))
                sqlConnection3.Close();

            if (sqlConnection3.State.Equals(ConnectionState.Closed))
                sqlConnection3.Open();

            SqlDataReader reader3 = sqlCommandread3.ExecuteReader();

            string strSQLconnection3a = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection3a = new SqlConnection(strSQLconnection3a);

            SqlCommand sqlCommandread3a = new SqlCommand("SELECT * FROM application WHERE tarikh_balik=@tarikh_balik AND username_pegawai=@username_pegawai", sqlConnection3a);
            sqlCommandread3a.Parameters.Clear();
            sqlCommandread3a.Parameters.AddWithValue("@tarikh_balik", txttarikhpergi.Text);
            sqlCommandread3a.Parameters.AddWithValue("@username_pegawai", icpegawai);

            if (sqlConnection3a.State.Equals(ConnectionState.Open))
                sqlConnection3a.Close();

            if (sqlConnection3a.State.Equals(ConnectionState.Closed))
                sqlConnection3a.Open();

            SqlDataReader reader3a = sqlCommandread3a.ExecuteReader();

            string strSQLconnection3c = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection3c = new SqlConnection(strSQLconnection3c);

            SqlCommand sqlCommandread3c = new SqlCommand("SELECT * FROM tiket_sehala WHERE tarikh_pergi=@tarikh_pergi AND username_pegawai=@username_pegawai", sqlConnection3c);
            sqlCommandread3c.Parameters.Clear();
            sqlCommandread3c.Parameters.AddWithValue("@tarikh_pergi", txttarikhpergi.Text);
            sqlCommandread3c.Parameters.AddWithValue("@username_pegawai", icpegawai);

            if (sqlConnection3c.State.Equals(ConnectionState.Open))
                sqlConnection3c.Close();

            if (sqlConnection3c.State.Equals(ConnectionState.Closed))
                sqlConnection3c.Open();

            SqlDataReader reader3c = sqlCommandread3c.ExecuteReader();

            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;

            updatecommand.CommandText = "UPDATE application SET tarikh_pergi=@tarikh_pergi WHERE id=@id";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@id", tiketid);
            updatecommand.Parameters.AddWithValue("@tarikh_pergi", txttarikhpergi.Text);
            
            DateTime datepick = Convert.ToDateTime(txttarikhpergi.Text);
            DateTime datepick2 = Convert.ToDateTime(refertarikhbalik);

            if (!reader.Read())
            {
                MessageBox.Show("Permohonan telah dinilai oleh penyelia. Maklumat permohonan tidak boleh diubah.");
            }
            else if (reader3.Read())
            {
                MessageBox.Show("Pegawai ini telah membuat penempahan tiket pada tarikh tersebut. Sila pilih tarikh lain.");
            }
            else if (reader3a.Read())
            {
                MessageBox.Show("Pegawai ini telah membuat penempahan tiket pada tarikh tersebut. Sila pilih tarikh lain.");
            }
            else if (reader3c.Read())
            {
                MessageBox.Show("Pegawai ini telah membuat penempahan tiket pada tarikh tersebut. Sila pilih tarikh lain.");
            }
            else
            {
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
                            updateconnection.Open();
                            int change = updatecommand.ExecuteNonQuery();
                            if (change > 0)
                            {
                                MessageBox.Show("Tarikh pergi berjaya dikemaskini!");
                            }
                            else
                                MessageBox.Show("Tarikh pergi gagal dikemaskini.");
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
                onload();
            }
        }
        protected void btntarikhbalik_Click(object sender, EventArgs e)
        {
            Button btndetails = sender as Button;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            txttarikhbalik.Text = ((Button)gvrow.FindControl("btntarikhbalik")).Text;
            tiketid = gvrow.Cells[0].Text;
            icpegawai = gvrow.Cells[1].Text;
            statustarikhbalik.Text = tiketid;

            this.ModalPopupExtender1b.Show();
        }
        protected void oktarikhbalik_Click(object sender, EventArgs e)
        {
            string strSQLconnection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection = new SqlConnection(strSQLconnection);

            SqlCommand sqlCommandread = new SqlCommand("SELECT * FROM application WHERE status=@status AND lulus=@lulus AND id=@id", sqlConnection);
            sqlCommandread.Parameters.Clear();
            sqlCommandread.Parameters.AddWithValue("@status", "Dalam Pertimbangan");
            sqlCommandread.Parameters.AddWithValue("@lulus", "Dalam Pertimbangan");
            sqlCommandread.Parameters.AddWithValue("@id", tiketid);

            if (sqlConnection.State.Equals(ConnectionState.Open))
                sqlConnection.Close();

            if (sqlConnection.State.Equals(ConnectionState.Closed))
                sqlConnection.Open();

            SqlDataReader reader = sqlCommandread.ExecuteReader();

            string strSQLconnection1 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection1 = new SqlConnection(strSQLconnection1);

            SqlCommand sqlCommandread1 = new SqlCommand("SELECT tarikh_pergi FROM application WHERE id=@id", sqlConnection1);
            sqlCommandread1.Parameters.Clear();
            sqlCommandread1.Parameters.AddWithValue("@id", tiketid);

            if (sqlConnection1.State.Equals(ConnectionState.Open))
                sqlConnection1.Close();

            if (sqlConnection1.State.Equals(ConnectionState.Closed))
                sqlConnection1.Open();
            
            SqlDataReader reader1 = sqlCommandread1.ExecuteReader();
            reader1.Read();
            refertarikhpergi = reader1["tarikh_pergi"].ToString();

            string strSQLconnection3 = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection3 = new SqlConnection(strSQLconnection3);

            SqlCommand sqlCommandread3 = new SqlCommand("SELECT * FROM application WHERE tarikh_balik=@tarikh_balik AND username_pegawai=@username_pegawai", sqlConnection3);
            sqlCommandread3.Parameters.Clear();
            sqlCommandread3.Parameters.AddWithValue("@tarikh_balik", txttarikhbalik.Text);
            sqlCommandread3.Parameters.AddWithValue("@username_pegawai", icpegawai);

            if (sqlConnection3.State.Equals(ConnectionState.Open))
                sqlConnection3.Close();

            if (sqlConnection3.State.Equals(ConnectionState.Closed))
                sqlConnection3.Open();

            SqlDataReader reader3 = sqlCommandread3.ExecuteReader();

            string strSQLconnection3a = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection3a = new SqlConnection(strSQLconnection3a);

            SqlCommand sqlCommandread3a = new SqlCommand("SELECT * FROM application WHERE tarikh_pergi=@tarikh_pergi AND username_pegawai=@username_pegawai", sqlConnection3a);
            sqlCommandread3a.Parameters.Clear();
            sqlCommandread3a.Parameters.AddWithValue("@tarikh_pergi", txttarikhbalik.Text);
            sqlCommandread3a.Parameters.AddWithValue("@username_pegawai", icpegawai);

            if (sqlConnection3a.State.Equals(ConnectionState.Open))
                sqlConnection3a.Close();

            if (sqlConnection3a.State.Equals(ConnectionState.Closed))
                sqlConnection3a.Open();

            SqlDataReader reader3a = sqlCommandread3a.ExecuteReader();

            string strSQLconnection3c = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnection3c = new SqlConnection(strSQLconnection3c);

            SqlCommand sqlCommandread3c = new SqlCommand("SELECT * FROM tiket_sehala WHERE tarikh_pergi=@tarikh_pergi AND username_pegawai=@username_pegawai", sqlConnection3c);
            sqlCommandread3c.Parameters.Clear();
            sqlCommandread3c.Parameters.AddWithValue("@tarikh_pergi", txttarikhbalik.Text);
            sqlCommandread3c.Parameters.AddWithValue("@username_pegawai", icpegawai);

            if (sqlConnection3c.State.Equals(ConnectionState.Open))
                sqlConnection3c.Close();

            if (sqlConnection3c.State.Equals(ConnectionState.Closed))
                sqlConnection3c.Open();

            SqlDataReader reader3c = sqlCommandread3c.ExecuteReader();

            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;

            updatecommand.CommandText = "UPDATE application SET tarikh_balik=@tarikh_balik WHERE id=@id";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@id", tiketid);
            updatecommand.Parameters.AddWithValue("@tarikh_balik", txttarikhbalik.Text);

            DateTime datepick = Convert.ToDateTime(refertarikhpergi);
            DateTime datepick2 = Convert.ToDateTime(txttarikhbalik.Text);

            if (!reader.Read())
            {
                MessageBox.Show("Permohonan telah dinilai oleh penyelia. Maklumat permohonan tidak boleh diubah.");
            }
            else if (reader3.Read())
            {
                MessageBox.Show("Pegawai ini telah membuat penempahan tiket pada tarikh tersebut. Sila pilih tarikh lain.");
            }
            else if (reader3a.Read())
            {
                MessageBox.Show("Pegawai ini telah membuat penempahan tiket pada tarikh tersebut. Sila pilih tarikh lain.");
            }
            else if (reader3c.Read())
            {
                MessageBox.Show("Pegawai ini telah membuat penempahan tiket pada tarikh tersebut. Sila pilih tarikh lain.");
            }
            else
            {
                try
                {
                    if (DateTime.Now.AddDays(-1) > datepick2 || datepick2 > DateTime.Now.AddMonths(5) || datepick > datepick2)
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
                                MessageBox.Show("Tarikh balik berjaya dikemaskini!");
                            }
                            else
                                MessageBox.Show("Tarikh balik gagal dikemaskini.");
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
                onload();
            }
        }
        protected void btnotes_Click(object sender, EventArgs e)
        {
            Labelnotes.Text = id.Text;
            notestxt.Text = catatan.Text;

            this.ModalPopupExtendernotes.Show();
        }
        protected void oknotes_Click(object sender, EventArgs e)
        {
            updateconnection = new SqlConnection();
            updateconnection.ConnectionString = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            updatecommand = new SqlCommand();
            updatecommand.Connection = updateconnection;
            updatecommand.CommandText = "UPDATE application SET catatan=@catatan WHERE id=@id";

            updatecommand.Parameters.Clear();
            updatecommand.Parameters.AddWithValue("@id", id.Text);
            updatecommand.Parameters.AddWithValue("@catatan", notestxt.Text);

                try
                {
                    updateconnection.Open();
                    int change = updatecommand.ExecuteNonQuery();
                    if (change > 0)
                    {
                        MessageBox.Show("Catatan berjaya dikemaskini! ");
                        catatan.Text = notestxt.Text;
                    }
                    else
                        MessageBox.Show("Catatan gagal dikemaskini!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Sistem sedang sibuk untuk mengemaskini catatan. Sila cuba sebentar lagi");
                }
                finally
                {
                    updateconnection.Close();
                }
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            LabelIC.Visible = false;
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
            LabelNamaPenyelia.Visible = false;
            LabelEmailPenyelia.Visible = false;
            LabelFail.Visible = false;
          
            update.Visible = false;
            ic.Visible = false;
            id.Visible = false;
            nama.Visible = false;
            tarikhtempah.Visible = false;
            masatempah.Visible = false;
            tempat.Visible = false;
            arah.Visible = false;
            jenis.Visible = false;
            tarikhpergi.Visible = false;
            waktuperjalanan1a.Visible = false;
            tarikhbalik.Visible = false;
            waktuperjalanan2a.Visible = false;
            tujuanperjalanan.Visible = false;
            catatan.Visible = false;
            bilanganpenumpang.Visible = false;
            namapenyelia.Visible = false;
            emailpenyelia.Visible = false;
            linkfile.Visible = false;
            linkfailbaru.Visible = false;
            notes.Visible = false;
         
            string strSQLconnectionstatus = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aviation.mdf; Trusted_Connection=True;User Instance=True";
            SqlConnection sqlConnectionstatus = new SqlConnection(strSQLconnectionstatus);

            SqlCommand sqlCommandreadstatus = new SqlCommand("SELECT * FROM application WHERE username_pegawai=@username_pegawai", sqlConnectionstatus);
            sqlCommandreadstatus.Parameters.Clear();
            sqlCommandreadstatus.Parameters.AddWithValue("@username_pegawai", txtSearch.Text);

            if (sqlConnectionstatus.State.Equals(ConnectionState.Open))
                sqlConnectionstatus.Close();

            if (sqlConnectionstatus.State.Equals(ConnectionState.Closed))
                sqlConnectionstatus.Open();

            SqlDataAdapter mySqlAdapter = new SqlDataAdapter(sqlCommandreadstatus);
            DataSet myDataSet = new DataSet();
            mySqlAdapter.Fill(myDataSet);

            gridtempah.DataSource = myDataSet;
            gridtempah.DataBind();

            SqlCommand sqlCommandreadstatus2 = new SqlCommand("SELECT * FROM application WHERE username_pegawai=@username_pegawai", sqlConnectionstatus);
            sqlCommandreadstatus2.Parameters.Clear();
            sqlCommandreadstatus2.Parameters.AddWithValue("@username_pegawai", txtSearch.Text);

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
                MessageBox.Show("IC pegawai yang anda cari tiada dalam rekod...");
            }

        }
        protected void Search2_Click(object sender, EventArgs e)
        {
            LabelIC.Visible = false;
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
            LabelNamaPenyelia.Visible = false;
            LabelEmailPenyelia.Visible = false;
            LabelFail.Visible = false;

            update.Visible = false;
            ic.Visible = false;
            id.Visible = false;
            nama.Visible = false;
            tarikhtempah.Visible = false;
            masatempah.Visible = false;
            tempat.Visible = false;
            arah.Visible = false;
            jenis.Visible = false;
            tarikhpergi.Visible = false;
            waktuperjalanan1a.Visible = false;
            tarikhbalik.Visible = false;
            waktuperjalanan2a.Visible = false;
            tujuanperjalanan.Visible = false;
            catatan.Visible = false;
            bilanganpenumpang.Visible = false;
            namapenyelia.Visible = false;
            emailpenyelia.Visible = false;
            linkfile.Visible = false;
            linkfailbaru.Visible = false;
            notes.Visible = false;

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