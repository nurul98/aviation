<%@ Page Title="" Language="C#" MasterPageFile="~/supervisor_access/supervisor.Master" AutoEventWireup="true" CodeBehind="statussehala.aspx.cs" Inherits="aviation.supervisor_access.statussehala" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Tiket Sehala</h2>
   <table>
           <tr> <td class="style3">&nbsp;No. Rujukan : 
            </td>
           <td>
               &nbsp;&nbsp;<asp:TextBox ID="txtSearch2" runat="server" 
                   Width="131px"></asp:TextBox>
             &nbsp;
           </td> <td> 
               <asp:Button ID="Search2" runat="server" Text="Cari" onclick="Search2_Click" /> </td>
           
           </tr>
           </table> <br />
Sila 
<asp:HyperLink ID="linkpermohonan" runat="server" 
        NavigateUrl="~/supervisor_access/status.aspx">klik di sini </asp:HyperLink>untuk status permohonan tiket dua hala
&nbsp;<br />
    <asp:GridView ID="gridtempah" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
        AllowPaging="True" onpageindexchanging="gridtempah_PageIndexChanging">
                   <Columns>
                       <asp:BoundField DataField="id" HeaderText="No. Rujukan" SortExpression="id" />
                        <asp:TemplateField HeaderText="Tarikh Tempahan" SortExpression="tarikh_tempahan">
                           <ItemTemplate>
                           <asp:Label ID="txttarikhtempah" runat="server" Text='<%# Bind("tarikh_tempahan","{0:d}") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tempat" SortExpression="tempat_perjalanan">
                           <ItemTemplate>
                           <asp:Label ID="txttempat" runat="server" Text='<%# Bind("tempat_perjalanan") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Destinasi" SortExpression="arah_perjalanan">
                           <ItemTemplate>
                           <asp:Label ID="txtarah" runat="server" Text='<%# Bind("arah_perjalanan") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Tarikh Pergi" SortExpression="tarikh_pergi">
                        <ItemTemplate>
                            <asp:Label ID="txttarikhpergi" runat="server" Enabled="False" 
                                Text='<%# Bind("tarikh_pergi","{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit-icon.png" 
                            onclick="btnEdit_Click" CausesValidation="False" />
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
 <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label><br /><br />
    <asp:Label ID="LabelStatus2" runat="server" Text="Sila " Visible="False"></asp:Label>
<asp:HyperLink
        ID="LinkTempahTiket" runat="server" Visible="False" 
        NavigateUrl="~/supervisor_access/superbooksehala.aspx">klik di sini </asp:HyperLink>
    <asp:Label ID="LabelStatus3" runat="server" Text="untuk membuat permohonan sekali lagi." Visible="False"></asp:Label>
 <br /><br />

<table class="style1">
             
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelId" runat="server" Text="No. Rujukan:" Visible="False"></asp:Label>   
                </td>
                <td>
                    <asp:TextBox ID="id" runat="server" Width="50px" Visible="False"></asp:TextBox>
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
                    <asp:Label ID="LabelTempat" runat="server" Text="Tempat:" Visible="False"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="tempat" runat="server" Width="229px" Visible="False"></asp:TextBox>
                </td>
            </tr>
           
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelArah" runat="server" Text="Destinasi:" Visible="False"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="arah" runat="server" Width="229px" Visible="False"></asp:TextBox>
                </td>
            </tr>
              <tr>
                 <td class="style8">
                   <asp:Label ID="LabelJenis" runat="server" Text="Jenis Penerbangan:" Visible="False"></asp:Label> 
                </td>
                <td class="style6">
                   <asp:TextBox ID="jenis" runat="server" Width="60px" Visible="False"></asp:TextBox>
                </td>
            </tr> 
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelTarikhPergi" runat="server" Text="Tarikh Pergi:" Visible="False"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="tarikhpergi" runat="server" Width="60px" Visible="False"></asp:TextBox>
                </td>
            </tr>
           <tr>
                <td class="style3">
                    <asp:Label ID="LabelWaktuPerjalanan1" runat="server" Text="Waktu Perjalanan:" Visible="False"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="waktuperjalanan1" runat="server" Width="115px" Visible="False"></asp:TextBox>
                </td>
            </tr>
           <tr>
                <td class="style3">
                    <asp:Label ID="LabelTujuanPerjalanan" runat="server" Text="Tujuan Perjalanan:" Visible="False"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="tujuanperjalanan" runat="server" Width="300px" Visible="False" 
                        Height="50px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelCatatan" runat="server" Text="Catatan:" Visible="False"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="catatan" runat="server" Width="300px" Visible="False" 
                        Height="100px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelBilanganPenumpang" runat="server" Text="Bilangan Penumpang:" Visible="False"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="bilanganpenumpang" runat="server" Width="50px" Visible="False"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelFail" runat="server" Text="Fail sokongan:" 
                        Visible="False" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:LinkButton ID="linkfile" runat="server" onclick="linkfile_Click" Visible="False">Lihat Fail</asp:LinkButton>
                </td>
            </tr>
        </table>
         <br />
         
&nbsp;

<asp:Button ID="btnShowPopup2" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopup2" PopupControlID="pnlpopup2" BackgroundCssClass="modalBackground"
CancelControlID="canceldelete">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlpopup2" runat="server" BackColor="White" Height="269px" Width="400px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #0000A0; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#0000A0">
<td colspan="2" style=" height:10%; color:Black; font-weight:bold; font-size:larger" align="center">Batal Tempahan</td>
</tr>
<tr>
<td align="center">
<h4>Anda pasti mahu batalkan tiket? 
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
 
</asp:Content>

