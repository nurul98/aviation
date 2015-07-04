<%@ Page Title="" Language="C#" MasterPageFile="~/admin_access/admin.Master" AutoEventWireup="true" CodeBehind="senaraitempahan.aspx.cs" Inherits="aviation.admin_access.senaraitempahan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        color: #000000;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Tiket Dua Hala</h2>
    Sila 
    <asp:HyperLink ID="linksehalaadmin" runat="server" 
        NavigateUrl="~/admin_access/senaraitempahansehala.aspx">klik di sini </asp:HyperLink>untuk senarai tempahan tiket sehala<br />
&nbsp;<br />
    <table><tr> <td class="style3">&nbsp;IC Pegawai : 
            </td>
           <td>
               &nbsp;&nbsp;<asp:TextBox ID="txtSearch" runat="server" 
                   Width="131px"></asp:TextBox>
             &nbsp;
           </td> <td> 
               <asp:Button ID="Search" runat="server" Text="Cari" onclick="Search_Click" /> </td>
           </tr>
           <tr> <td class="style3">&nbsp;No. Rujukan : 
            </td>
           <td>
               &nbsp;&nbsp;<asp:TextBox ID="txtSearch2" runat="server" 
                   Width="131px"></asp:TextBox>
             &nbsp;
           </td> <td> 
               <asp:Button ID="Search2" runat="server" Text="Cari" onclick="Search2_Click" /> </td>
           
           </tr>
           </table> 
<asp:GridView ID="gridtempah" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
        AllowPaging="True" onpageindexchanging="gridtempah_PageIndexChanging">
                   <Columns>
                       <asp:BoundField DataField="id" HeaderText="No. Rujukan" SortExpression="id" />
                       <asp:BoundField DataField="username_pegawai" HeaderText="Pegawai" SortExpression="username_pegawai" />
                        <asp:TemplateField HeaderText="Tarikh Tempahan" SortExpression="tarikh_tempahan">
                           <ItemTemplate>
                           <asp:Label ID="txttarikhtempah" runat="server" Text='<%# Bind("tarikh_tempahan","{0:d}") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Tarikh Pergi" SortExpression="tarikh_pergi">
                         <ItemTemplate>
                         <asp:Button ID="btntarikhpergi" runat="server" Text='<%# Bind("tarikh_pergi","{0:d}") %>' onclick="btntarikhpergi_Click" CausesValidation="False"/>
                        </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Tarikh Balik" SortExpression="tarikh_balik">
                        <ItemTemplate>
                             <asp:Button ID="btntarikhbalik" runat="server" Text='<%# Bind("tarikh_balik","{0:d}") %>' onclick="btntarikhbalik_Click" CausesValidation="False"/>
                        </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Sokongan Penyelia" SortExpression="status">
                           <ItemTemplate>
                           <asp:Label ID="txtstatus" runat="server" Text='<%# Bind("status") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status Lulus" SortExpression="valid">
                        <ItemTemplate>
                            <asp:Button ID="btnstatus" runat="server" Text='<%# Bind("lulus") %>' onclick="btnvalidstatus_Click" CausesValidation="False"/>
                        </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kemaskini">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit-icon.png" 
                            onclick="btnEdit_Click" CausesValidation="False" ImageAlign="AbsMiddle" />
                        </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Batal">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server" 
                            ImageUrl="~/images/delete-icon.jpg" onclick="btnDelete_Click"/>
                        </ItemTemplate>
                       </asp:TemplateField>
                       
                   </Columns>
                    <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
<br />
   Sila <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/admin_access/adminbooking.aspx">klik di sini</asp:HyperLink>&nbsp; untuk membuat tempahan tiket baru<br /><br />
<table class="style1">
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelIC" runat="server" Text="IC Pegawai:" Visible="False"></asp:Label>   
                </td>
                <td>
                    <asp:TextBox ID="ic" runat="server" Width="170px" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelNama" runat="server" Text="Nama:" Visible="False"></asp:Label>   
                </td>
                <td>
                    <asp:TextBox ID="nama" runat="server" Width="229px" Visible="False"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelId" runat="server" Text="No. Rujukan:" Visible="False" 
                        CssClass="style1"></asp:Label>   
                </td>
                <td>
                    <asp:TextBox ID="id" runat="server" Width="50px" Visible="False"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelTarikhTempah" runat="server" Text="Tarikh Tempahan:" Visible="False"></asp:Label>   
                </td>
                <td>
                    <asp:TextBox ID="tarikhtempah" runat="server" Width="60px" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelMasaTempah" runat="server" Text="Masa Tempahan:" Visible="False"></asp:Label>   
                </td>
                <td>
                    <asp:TextBox ID="masatempah" runat="server" Width="60px" Visible="False"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelTempat" runat="server" Text="Tempat:" Visible="False" 
                        CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="tempat" runat="server" Width="229px" Visible="False"></asp:TextBox>
                </td>
            </tr>
           
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelArah" runat="server" Text="Destinasi:" Visible="False" 
                        CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="arah" runat="server" Width="229px" Visible="False"></asp:TextBox>
                </td>
            </tr>
              <tr>
                 <td class="style8">
                   <asp:Label ID="LabelJenis" runat="server" Text="Jenis Penerbangan:" Visible="False"></asp:Label> 
                </td>
                <td class="style6">
                <asp:RadioButtonList ID="jenis" runat="server" ForeColor="Black" 
                        RepeatDirection="Horizontal" Visible="False">
                        <asp:ListItem>MAS</asp:ListItem>
                        <asp:ListItem>AirAsia</asp:ListItem>
                        <asp:ListItem>Firefly</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr> 
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelTarikhPergi" runat="server" Text="Tarikh Pergi:" 
                        Visible="False" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="tarikhpergi" runat="server" Width="60px" Visible="False"></asp:TextBox>
                </td>
            </tr>
           <tr>
                <td class="style3">
                    <asp:Label ID="LabelWaktuPerjalanan1" runat="server" Text="Waktu Perjalanan:" 
                        Visible="False" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:RadioButtonList ID="waktuperjalanan1a" runat="server">
                        <asp:ListItem>Pagi</asp:ListItem>
                        <asp:ListItem>Tengah Hari</asp:ListItem>
                        <asp:ListItem>Petang</asp:ListItem>
                        <asp:ListItem>Malam</asp:ListItem>
                    </asp:RadioButtonList>
                    
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelTarikhBalik" runat="server" Text="Tarikh Balik:" 
                        Visible="False" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="tarikhbalik" runat="server" Width="60px" Visible="False"></asp:TextBox>
                </td>
            </tr>

           <tr>
                <td class="style3">
                    <asp:Label ID="LabelWaktuPerjalanan2" runat="server" Text="Waktu Perjalanan:" 
                        Visible="False" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:RadioButtonList ID="waktuperjalanan2a" runat="server">
                        <asp:ListItem>Pagi</asp:ListItem>
                        <asp:ListItem>Tengah Hari</asp:ListItem>
                        <asp:ListItem>Petang</asp:ListItem>
                        <asp:ListItem>Malam</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
           <tr>
                <td class="style3">
                    <asp:Label ID="LabelTujuanPerjalanan" runat="server" Text="Tujuan Perjalanan:" 
                        Visible="False" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="tujuanperjalanan" runat="server" Width="300px" Visible="False" 
                        Height="50px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelCatatan" runat="server" Text="Catatan:" Visible="False" 
                        CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="catatan" runat="server" Width="300px" Visible="False" 
                        Height="100px" TextMode="MultiLine"></asp:TextBox>
                    &nbsp;<asp:ImageButton ID="notes" runat="server" Height="25px" 
                        ImageUrl="~/admin_access/images/pencil-icon.jpg" Width="25px" onclick="btnotes_Click" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelBilanganPenumpang" runat="server" 
                        Text="Bilangan Penumpang:" Visible="False" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="bilanganpenumpang" runat="server" Width="50px" Visible="False"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelNamaPenyelia" runat="server" Text="Nama Penyelia:" 
                        Visible="False" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="namapenyelia" runat="server" Width="500px"></asp:TextBox> 
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelEmailPenyelia" runat="server" Text="E-mail Penyelia:" 
                        Visible="False" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="emailpenyelia" runat="server" Width="170px" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelFail" runat="server" Text="Dokumen sokongan:" 
                        Visible="False" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:LinkButton ID="linkfile" runat="server" onclick="linkfile_Click" 
                        Visible="False">Lihat Dokumen</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                         <asp:LinkButton ID="linkfailbaru" runat="server" onclick="linkfilebaru_Click" 
                        Visible="False">Tukar Dokumen</asp:LinkButton>
                </td>
            </tr>
        </table>
         <br />
         
   <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tarikhpergi" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
      <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="tarikhbalik" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>             
        <asp:Button ID="update" runat="server" Text="Simpan" onclick="update_Click" 
        Width="85px" Visible="False"  />
<asp:Button ID="btnShowPopup2" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopup2" PopupControlID="pnlpopup2" BackgroundCssClass="modalBackground"
CancelControlID="canceldelete">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlpopup2" runat="server" BackColor="White" Height="150px" Width="200px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #3366FF; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#3366FF">
<td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Batal Tempahan</td>
</tr>
<tr>
<td align="center">
<h4>Anda pasti mahu batalkan penempahan tiket 
    <asp:Label ID="DeleteTiket" runat="server" Text="Tempahan"></asp:Label>? </h4>
</td>

</tr>
<tr>
<td align="center">
<asp:Button ID="confirmdelete" runat="server" Text="OK" CssClass="myButton" onclick="confirmdelete_Click" />
<asp:Button ID="canceldelete" runat="server" Text="Kembali" CssClass="myButton" />
</td>
</tr>
</table>
   
</asp:Panel>        

<asp:Button ID="btnShowPopup" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup" BackgroundCssClass="modalBackground"
CancelControlID="bataltukar">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="150px" Width="200px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #3366FF; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#3366FF">
<td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Status Permohonan <asp:Label ID="Labelterima" runat="server" Text="Permohonan "></asp:Label></td>
</tr>

<tr>
<td align="center">
    <asp:DropDownList ID="pilihstatus" runat="server">
      <asp:ListItem>Dalam Pertimbangan</asp:ListItem>
      <asp:ListItem>Lulus</asp:ListItem>
      <asp:ListItem>Tidak Lulus</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
<tr>
<td align="center">
<asp:Button ID="tukarstatus" runat="server" Text="OK" CssClass="myButton" onclick="tukarstatus_Click" />
<asp:Button ID="bataltukar" runat="server" Text="Kembali" CssClass="myButton" />
</td>
</tr>
</table>
   
</asp:Panel>      

<asp:Button ID="btnpopup" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender1a" runat="server" TargetControlID="btnpopup" PopupControlID="Paneltarikhpergi" BackgroundCssClass="modalBackground"
CancelControlID="bataltarikhpergi">
</asp:ModalPopupExtender>
<asp:Panel ID="Paneltarikhpergi" runat="server" BackColor="White" Height="150px" Width="200px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #3366FF; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#3366FF">
<td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Tarikh Pergi <asp:Label ID="statustarikhpergi" runat="server" Text="Permohonan "></asp:Label></td>
</tr>

<tr>
<td align="center">
<h4>Tarikh Pergi: </h4>
    <asp:TextBox ID="txttarikhpergi" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="center">
<asp:Button ID="oktarikhpergi" runat="server" Text="OK" CssClass="myButton" onclick="oktarikhpergi_Click" />
<asp:Button ID="bataltarikhpergi" runat="server" Text="Kembali" CssClass="myButton" />
</td>
</tr>
</table>
   
</asp:Panel>    

<asp:Button ID="btnpopup2" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender1b" runat="server" TargetControlID="btnpopup2" PopupControlID="Paneltarikhbalik" BackgroundCssClass="modalBackground"
CancelControlID="bataltarikhbalik">
</asp:ModalPopupExtender>
<asp:Panel ID="Paneltarikhbalik" runat="server" BackColor="White" Height="150px" Width="200px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #3366FF; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#3366FF">
<td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Tarikh Balik <asp:Label ID="statustarikhbalik" runat="server" Text="Permohonan "></asp:Label> </td>
</tr>

<tr>
<td align="center">
<h4>Tarikh Balik: </h4>

    <asp:TextBox ID="txttarikhbalik" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="center">
<asp:Button ID="oktarikhbalik" runat="server" Text="OK" CssClass="myButton" onclick="oktarikhbalik_Click" />
<asp:Button ID="bataltarikhbalik" runat="server" Text="Kembali" CssClass="myButton" />
</td>
</tr>
</table>
</asp:Panel>  

<asp:Button ID="btnpopup3" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtenderfail" runat="server" TargetControlID="btnpopup3" PopupControlID="Panelfail" BackgroundCssClass="modalBackground"
CancelControlID="batalfail">
</asp:ModalPopupExtender>
<asp:Panel ID="Panelfail" runat="server" BackColor="White" Height="200px" Width="300px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #3366FF; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#3366FF">
<td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Fail Sokongan <asp:Label ID="Labelfailbaru" runat="server" Text="Permohonan "></asp:Label></td>
</tr>

<tr><td>Fail Baru:

    <asp:FileUpload ID="FileUploadbaru" runat="server" />
</td>
  </tr>
  <tr><td>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
  ControlToValidate="FileUploadbaru" ErrorMessage="Hanya file berbentuk pdf dan gambar sahaja yang diterima"             
  ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.png|.PNG|.pdf|.PDF)$" 
  ForeColor="Red"></asp:RegularExpressionValidator>
               </td></tr>

<tr>
<td align="center">
<asp:Button ID="okfailbaru" runat="server" Text="OK" CssClass="myButton" onclick="okfailbaru_Click" />
<asp:Button ID="batalfail" runat="server" Text="Kembali" CssClass="myButton" />
</td>
</tr>
</table> 
</asp:Panel>    

<asp:Button ID="btnotes" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtendernotes" runat="server" TargetControlID="btnotes" PopupControlID="pnlnotes" BackgroundCssClass="modalBackground"
CancelControlID="batalnotes">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlnotes" runat="server" BackColor="White" Height="150px" Width="350px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #3366FF; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#3366FF">
<td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Catatan <asp:Label ID="Labelnotes" runat="server" Text="Catatan "></asp:Label></td>
</tr>

<tr>
<td align="center">
    <asp:Label ID="Label1" runat="server" Text="Catatan: "></asp:Label>


<asp:TextBox ID="notestxt" runat="server" Width="229px" Visible="True" Height="66px" TextMode="MultiLine"></asp:TextBox>                 
</td>
</tr>

<tr>
<td align="center">
<asp:Button ID="oknotes" runat="server" Text="OK" CssClass="myButton" onclick="oknotes_Click" />
<asp:Button ID="batalnotes" runat="server" Text="Kembali" CssClass="myButton" />
</td>
</tr>
</table>
   
</asp:Panel>      
    
   <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttarikhpergi" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
      <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txttarikhbalik" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>                       
  </asp:Content>

