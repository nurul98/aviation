<%@ Page Title="" Language="C#" MasterPageFile="~/admin_access/admin.Master" AutoEventWireup="true" CodeBehind="nilaiagen.aspx.cs" Inherits="aviation.admin_access.nilaiagen" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {}
    .style3
    {
        color: #000000;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Nilai Agen</h2>
    <table><tr> <td class="style3">&nbsp;Nama Syarikat : 
            </td>
           <td>
               &nbsp;&nbsp;<asp:TextBox ID="txtSearch" runat="server" 
                   Width="131px"></asp:TextBox>
             &nbsp;
           </td> <td> 
               <asp:Button ID="Search" runat="server" Text="Cari" onclick="Search_Click" /> </td>
           </tr>
           <tr> <td class="style3">&nbsp;<span class="style3">Susun Berdasarkan :</span> 
            </td>
           <td>
               &nbsp;&nbsp;<asp:RadioButtonList ID="susunlist" runat="server" 
                   style="color: #000000">
                   <asp:ListItem>Nama Syarikat</asp:ListItem>
                   <asp:ListItem>Tarikh Tamat Kewangan</asp:ListItem>
               </asp:RadioButtonList>
               &nbsp;
           </td> <td> 
               <asp:Button ID="Susun" runat="server" Text="Paparkan" onclick="Susun_Click" /> </td>
           </tr>
           </table> <br />
<asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/admin_access/daftaragen.aspx">Sila klik di sini</asp:HyperLink>&nbsp; untuk mendaftar agen baru<br /><br />
  <asp:GridView ID="gridnilai" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
        AllowPaging="True" onpageindexchanging="gridnilai_PageIndexChanging">
                   <Columns>
                       <asp:BoundField DataField="id" HeaderText="No. Rujukan" SortExpression="id" />
                       <asp:TemplateField HeaderText="Nama" SortExpression="nama">
                           <ItemTemplate>
                           <asp:Label ID="txtnama" runat="server" Text='<%# Bind("nama") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Nombor" SortExpression="nombor">
                        <ItemTemplate>
                            <asp:Label ID="txtnombor" runat="server" Enabled="False" 
                                Text='<%# Bind("nombor") %>'></asp:Label>
                        </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Faks" SortExpression="faks">
                        <ItemTemplate>
                            <asp:Label ID="txtfaks" runat="server" Enabled="False" 
                                Text='<%# Bind("faks") %>'></asp:Label>
                        </ItemTemplate>
                         </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nilai Perolehan Semasa (RM)" SortExpression="amaun">
                        <ItemTemplate>
                            <asp:Label ID="txtamaun" runat="server" Enabled="False" 
                                Text='<%# Bind("amaun") %>'></asp:Label>
                        </ItemTemplate>
                       </asp:TemplateField>
                         <asp:TemplateField HeaderText="Tarikh Tamat Kewangan" SortExpression="tarikh_tamat_kewangan">
                        <ItemTemplate>
                            <asp:Label ID="txttarikhtamatkewangan" runat="server" Enabled="False" 
                                Text='<%# Bind("tarikh_tamat_kewangan","{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kod Prestasi" SortExpression="kod_prestasi">
                        <ItemTemplate>
                            <asp:Label ID="txtprestasi" runat="server" Enabled="False" 
                                Text='<%# Bind("kod_prestasi") %>'></asp:Label>
                        </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kemaskini">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit-icon.png" 
                            onclick="btnEdit_Click" CausesValidation="False" />
                        </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="Padam">
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

<table class="style1">
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelId" runat="server" Text="No. Rujukan Agen:" Visible="False"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="id" runat="server" Width="229px" Visible="False"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelSyarikat" runat="server" Text="Nama Syarikat:" 
                        Visible="False"></asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="nama" runat="server" Width="229px" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelAlamat" runat="server" Text="Alamat:" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="alamat" runat="server" Width="229px" Height="78px" 
                        TextMode="MultiLine" Visible="False"></asp:TextBox>
                </td>
                
             
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelNombor" runat="server" Text="Nombor" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="nombor" runat="server" Width="178px" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelFaks" runat="server" Text="Faks:" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="faks" runat="server" Width="178px" Visible="False"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="style3">
                    <asp:Label ID="LabelEmail" runat="server" Text="E-Mail" Visible="False"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="email" runat="server" Width="178px" Height="22px" 
                        Visible="False"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelCatatan" runat="server" Text="Catatan" Visible="False"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="catatan" runat="server" Width="229px" Height="75px" 
                        Visible="False" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelTarikhMulaKewangan" runat="server" Text="Tarikh Mula Kewangan:" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tarikh_mula_kewangan" runat="server" Width="65px" 
                        Height="22px" style="margin-left: 0px" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelTarikhTamatKewangan" runat="server" Text="Tarikh Tamat Kewangan:" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="tarikh_tamat_kewangan" runat="server" Width="65px" 
                        Visible="False" ></asp:TextBox>
                   
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelTarikhMulaTDC" runat="server" Text="Tarikh Mula TDC" Visible="False"></asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="tarikh_mula_tdc" runat="server"  
                        CssClass="style2" Width="65px" Visible="False"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelTarikhTamatTDC" runat="server" Text="Tarikh Tamat TDC:" Visible="False"></asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="tarikh_tamat_tdc" runat="server"  
                        CssClass="style2" Width="65px" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="LabelAmaun" runat="server" Text="Nilai Perolehan Semasa (RM):" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="amaun" runat="server"  
                        CssClass="style2" Width="65px" Visible="False"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    <asp:Label ID="LabelKodPrestasi" runat="server" Text="Kod Prestasi:" Visible="False"></asp:Label>
                 </td>
                <td>
                    <asp:DropDownList ID="kod_prestasi" runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="Keterangan_Prestasi" 
                        Visible="False"> 
                    </asp:DropDownList>
                   
                </td>
            </tr>
        </table>
         <br />
          <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tarikh_mula_kewangan" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
      <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="tarikh_tamat_kewangan" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
     <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="tarikh_mula_tdc" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
     <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="tarikh_tamat_tdc" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
&nbsp;<asp:Button ID="update" runat="server" Text="Kemaskini" 
        onclick="update_Click" Visible="False" />
<asp:Button ID="btnShowPopup2" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopup2" PopupControlID="pnlpopup2" BackgroundCssClass="modalBackground"
CancelControlID="canceldelete">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlpopup2" runat="server" BackColor="White" Height="269px" Width="400px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #0000A0; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#0000A0">
<td colspan="2" style=" height:10%; color:Black; font-weight:bold; font-size:larger" align="center">Padam Data Agen</td>
</tr>
<tr>
<td align="center">
<h4>Anda pasti mahu padam data? 
    <asp:Label ID="DeleteAgen" runat="server" Text="Agen"></asp:Label>? </h4>
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
 <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:Table_Connection %>" 
                        
        SelectCommand="SELECT [Keterangan_Prestasi] FROM [prestasi_agen]">
                    </asp:SqlDataSource>


</asp:Content>

