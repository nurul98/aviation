<%@ Page Title="" Language="C#" MasterPageFile="~/supervisor_access/supervisor.Master" AutoEventWireup="true" CodeBehind="pengesahansokongansehala.aspx.cs" Inherits="aviation.supervisor_access.pengesahansokongansehala" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<br /><br />Sila
  <asp:HyperLink ID="linksehalaadmin" runat="server" 
        NavigateUrl="~/supervisor_access/pengesahansokongan.aspx">klik di sini </asp:HyperLink>untuk sahkan permohonan tiket dua hala<br />
   <br />
    <asp:GridView ID="gdvPending" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
        ShowFooter="True" AllowPaging="True" 
        onpageindexchanging="gdvPending_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="No.Rujukan" />
            <asp:BoundField DataField="username_pegawai" HeaderText="IC Pegawai" />
            <asp:BoundField DataField="tarikh_tempahan" HeaderText="Tarikh Tempahan" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="tarikh_pergi" HeaderText="Tarikh Pergi" DataFormatString="{0:d}"/>
             <asp:TemplateField HeaderText="Dokumen Sokongan">
                        <ItemTemplate>
                             <asp:LinkButton ID="linkfile" runat="server" onclick="linkfile_Click" 
                        Visible="True" CausesValidation="False">Lihat Dokumen</asp:LinkButton>
                        </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Lihat Data">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit-icon.png" 
                            onclick="btnEdit_Click" CausesValidation="False" />
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tindakan">
                <FooterTemplate>
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
                        Text="Sahkan" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="drpdwnDecision" runat="server" DataValueField="decision" 
                        Height="18px" Width="99px">
                        <asp:ListItem Value="1">Dalam Pertimbangan</asp:ListItem>
                        <asp:ListItem Value="2">Disokong</asp:ListItem>
                        <asp:ListItem Value="3">Tidak Disokong</asp:ListItem> 
                    </asp:DropDownList>
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
 
<asp:GridView ID="gdvApproved" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
        ShowFooter="True" AllowPaging="True" 
        onpageindexchanging="gdvApproved_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="No.Rujukan" />
            <asp:BoundField DataField="username_pegawai" HeaderText="IC Pegawai" />
            <asp:BoundField DataField="tarikh_tempahan" HeaderText="Tarikh Tempahan" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="tarikh_pergi" HeaderText="Tarikh Pergi" DataFormatString="{0:d}"/>
              <asp:TemplateField HeaderText="Dokumen Sokongan">
                        <ItemTemplate>
                             <asp:LinkButton ID="linkfile" runat="server" onclick="linkfile_Click" 
                        Visible="True" CausesValidation="False">Lihat Dokumen</asp:LinkButton>
                        </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Lihat Data">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit-icon.png" 
                            onclick="btnEdit_Click" CausesValidation="False" />
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tindakan">
                <FooterTemplate>
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
                        Text="Sahkan" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="drpdwnDecision" runat="server" DataValueField="decision" 
                        Height="18px" Width="99px">
                        <asp:ListItem Value="1">Disokong</asp:ListItem>
                        <asp:ListItem Value="2">Tidak Disokong</asp:ListItem>
                        <asp:ListItem Value="3">Dalam Pertimbangan</asp:ListItem>
                    </asp:DropDownList>
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
    
    <asp:GridView ID="gdvRejected" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
        ShowFooter="True" AllowPaging="True" 
        onpageindexchanging="gdvRejected_PageIndexChanging">
        <Columns>
        <asp:BoundField DataField="id" HeaderText="No.Rujukan" />
            <asp:BoundField DataField="username_pegawai" HeaderText="IC Pegawai" />
            <asp:BoundField DataField="tarikh_tempahan" HeaderText="Tarikh Tempahan" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="tarikh_pergi" HeaderText="Tarikh Pergi" DataFormatString="{0:d}"/>
             <asp:TemplateField HeaderText="Dokumen Sokongan">
                        <ItemTemplate>
                             <asp:LinkButton ID="linkfile" runat="server" onclick="linkfile_Click" 
                        Visible="True" CausesValidation="False">Lihat Dokumen</asp:LinkButton>
                        </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Lihat Data">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit-icon.png" 
                            onclick="btnEdit_Click" CausesValidation="False" />
                        </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tindakan">
                <FooterTemplate>
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
                        Text="Sahkan" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="drpdwnDecision" runat="server" DataValueField="decision" 
                        Height="18px" Width="99px">
                        <asp:ListItem Value="1">Tidak Disokong</asp:ListItem>
                        <asp:ListItem Value="2">Disokong</asp:ListItem>
                        <asp:ListItem Value="3">Dalam Pertimbangan</asp:ListItem>
                    </asp:DropDownList>
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

<asp:Button ID="btnShowPopup" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup" BackgroundCssClass="modalBackground"
CancelControlID="kembali">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="650px" Width="600px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #3366FF; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#3366FF">
<td colspan="2" style=" height:5%; color:White; font-weight:bold; font-size:larger" align="center">Data Permohonan <asp:Label ID="Labelpermohonan" runat="server" Text="Permohonan "></asp:Label> </td>
</tr>

 <tr>
                <td class="style3">
                    <asp:Label ID="LabelIC" runat="server" Text="IC Pegawai:" Visible="True"></asp:Label>   
                </td>
                <td>
                    <asp:TextBox ID="ic" runat="server" Width="170px" Visible="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelNama" runat="server" Text="Nama:" Visible="True"></asp:Label>   
                </td>
                <td>
                    <asp:TextBox ID="nama" runat="server" Width="229px" Visible="True"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelId" runat="server" Text="No. Rujukan:" Visible="True" 
                        CssClass="style1"></asp:Label>   
                </td>
                <td>
                    <asp:TextBox ID="id" runat="server" Width="50px" Visible="True"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelTarikhTempah" runat="server" Text="Tarikh Tempahan:" Visible="True"></asp:Label>   
                </td>
                <td>
                    <asp:TextBox ID="tarikhtempah" runat="server" Width="60px" Visible="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelMasaTempah" runat="server" Text="Masa Tempahan:" Visible="True"></asp:Label>   
                </td>
                <td>
                    <asp:TextBox ID="masatempah" runat="server" Width="60px" Visible="True"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelTempat" runat="server" Text="Tempat:" Visible="True" 
                        CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="tempat" runat="server" Width="229px" Visible="True"></asp:TextBox>
                </td>
            </tr>
           
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelArah" runat="server" Text="Destinasi:" Visible="True" 
                        CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="arah" runat="server" Width="229px" Visible="True"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelJenis" runat="server" Text="Jenis Penerbangan:" Visible="True" 
                        CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="jenis" runat="server" Width="229px" Visible="True"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelTarikhPergi" runat="server" Text="Tarikh Pergi:" 
                        Visible="True" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="tarikhpergi" runat="server" Width="60px" Visible="True"></asp:TextBox>
                </td>
            </tr>
           <tr>
                <td class="style3">
                    <asp:Label ID="LabelWaktuPerjalanan1" runat="server" Text="Waktu Perjalanan:" 
                        Visible="True" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="waktuperjalanan1a" runat="server" Width="60px"></asp:TextBox>
                    
                </td>
            </tr>
           <tr>
                <td class="style3">
                    <asp:Label ID="LabelTujuanPerjalanan" runat="server" Text="Tujuan Perjalanan:" 
                        Visible="True" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="tujuanperjalanan" runat="server" Width="300px" Visible="True" 
                        Height="50px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelCatatan" runat="server" Text="Catatan:" Visible="True" 
                        CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="catatan" runat="server" Width="300px" Visible="True" 
                        Height="100px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelBilanganPenumpang" runat="server" 
                        Text="Bilangan Penumpang:" Visible="True" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="bilanganpenumpang" runat="server" Width="50px" Visible="True"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelNamaPenyelia" runat="server" Text="Nama Penyelia:" 
                        Visible="True" CssClass="style1"></asp:Label>  </td>
                <td>
                   
                    <asp:TextBox ID="namapenyelia" runat="server" Width="450px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelEmailPenyelia" runat="server" Text="E-mail Penyelia:" 
                        Visible="True" CssClass="style1"></asp:Label>  </td>
                <td>
                    <asp:TextBox ID="emailpenyelia" runat="server" Width="170px" Visible="True"></asp:TextBox>
                </td>
            </tr>
           
<tr>
<td align="center">

<asp:Button ID="kembali" runat="server" Text="Kembali" CssClass="myButton" />
</td>
</tr>
</table>
   
</asp:Panel>      
</asp:Content>

