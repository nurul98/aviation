<%@ Page Title="" Language="C#" MasterPageFile="~/director_access/director.Master" AutoEventWireup="true" CodeBehind="dprofilpegawai.aspx.cs" Inherits="aviation.director_access.dprofilpegawai" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Senarai Pegawai</h2>
    <table><tr> <td class="style3">&nbsp;IC Pegawai : 
            </td>
           <td>
               &nbsp;&nbsp;<asp:TextBox ID="txtSearch" runat="server" 
                   Width="131px"></asp:TextBox>
             &nbsp;
           </td> <td> 
               <asp:Button ID="Search" runat="server" Text="Cari" onclick="Search_Click" /> </td>
           
           </tr></table> 
<asp:GridView ID="gridpegawai" runat="server" AutoGenerateColumns="False" 
         CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
         PageSize="10" AllowPaging="True" 
         onpageindexchanging="gridpegawai_PageIndexChanging">
                   <Columns>
                       <asp:BoundField DataField="username" HeaderText="IC Pegawai" SortExpression="username" />
                       <asp:BoundField DataField="nama" HeaderText="Nama" SortExpression="nama" />
                       <asp:TemplateField HeaderText="Jawatan" SortExpression="jawatan">
                           <ItemTemplate>
                           <asp:Label ID="txtjawatan" runat="server" Text='<%# Bind("jawatan") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Bahagian" SortExpression="bahagian">
                        <ItemTemplate>
                            <asp:Label ID="txtbahagian" runat="server" Enabled="False" 
                                Text='<%# Bind("bahagian") %>'></asp:Label>
                        </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Telefon Bimbit" SortExpression="telefon_bimbit">
                        <ItemTemplate>
                            <asp:Label ID="txttelefonbimbit" runat="server" Enabled="False" 
                                Text='<%# Bind("telefon_bimbit") %>'></asp:Label>
                        </ItemTemplate>
                         </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefon Pejabat" SortExpression="telefon_pejabat">
                        <ItemTemplate>
                            <asp:Label ID="txttelefonpejabat" runat="server" Enabled="False" 
                                Text='<%# Bind("telefon_pejabat") %>'></asp:Label>
                        </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kemaskini">
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
   <br />
 <table class="style1">
            
            <tr>
                <td class="style1">
                    <asp:Label ID="LabelIC" runat="server" Text="IC Pegawai:" Visible="False" 
                        CssClass="style3"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtIC" runat="server" CssClass="style2" Width="170px"></asp:TextBox>
                </td>
                <td> <asp:RegularExpressionValidator ID="RangeIC1" runat="server" 
        ErrorMessage="Sila masukkan IC yang sah" ForeColor="Red" ControlToValidate="TxtIC" ValidationExpression="^[0-9]{12}$"></asp:RegularExpressionValidator> </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="LabelNamaPegawai" runat="server" Text="Nama Pegawai:" 
                        Visible="False" CssClass="style3"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtNama" runat="server" CssClass="style2" Width="390px"></asp:TextBox>
                </td>
               
            </tr>
    <tr>
                <td class="style1">
                    <asp:Label ID="LabelEmail" runat="server" Text="E-Mail:" Visible="False" 
                        CssClass="style3"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="style2" Width="170px"></asp:TextBox>
                </td>
                 <td>
                     <asp:RegularExpressionValidator ID="RegularEmail" runat="server" 
        ErrorMessage="Sila masukkan email yang sah" ForeColor="Red" 
        ControlToValidate="TxtEmail" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> </td>
            </tr>
             <tr>
                <td class="style1">
                    <asp:Label ID="LabelKumpulanPerkhidmatan" runat="server" 
                        Text="Kumpulan Perkhidmatan:" Visible="False" CssClass="style3"></asp:Label>
                 </td>
                <td>
                    <asp:DropDownList ID="KumpulanPerkhidmatan" runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="nama" DataValueField="nama" 
                        Width="276px">
                       
                    </asp:DropDownList>  
                </td>
                <td> &nbsp;</td>
            </tr>
              <tr>
                <td class="style1">
                    <asp:Label ID="LabelJawatan" runat="server" Text="Jawatan:" Visible="False" 
                        CssClass="style3"></asp:Label>
                  </td>
                <td>
                    <asp:DropDownList ID="Jawatan" runat="server" 
                        DataSourceID="SqlDataSource2" DataTextField="nama" DataValueField="nama" 
                        Width="276px">
                       
                    </asp:DropDownList>
                  
                </td>
                <td> &nbsp;</td>
            </tr>
              <tr>
                <td class="style1">
                    <asp:Label ID="LabelBahagian" runat="server" Text="Bahagian:" Visible="False" 
                        CssClass="style3"></asp:Label>
                  </td>
                <td>
                      <asp:DropDownList ID="Bahagian" runat="server" 
                        DataSourceID="SqlDataSource3" DataTextField="nama" DataValueField="nama" 
                        Width="276px">
                       
                    </asp:DropDownList>
                </td>
                <td> &nbsp;</td>
            </tr>
              <tr>
                <td class="style1">
                    <asp:Label ID="LabelGredJawatan" runat="server" Text="Gred Jawatan:" 
                        Visible="False" CssClass="style3"></asp:Label>
                  </td>
                <td>
                    <asp:DropDownList ID="GredJawatan" runat="server" 
                        DataSourceID="SqlDataSource4" DataTextField="no" DataValueField="no" 
                        Width="276px">
                       
                    </asp:DropDownList>
                  
                </td>
                <td> &nbsp;</td>
            </tr>
             <tr>
                <td class="style1">
                    <asp:Label ID="LabelSektor" runat="server" Text="Sektor" Visible="False" 
                        CssClass="style3"></asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="TxtSektor" runat="server" CssClass="style2" Width="106px"></asp:TextBox>
                   </td>
                    <td> </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="LabelTelefonBimbit" runat="server" Text="Telefon Bimbit:" 
                        Visible="False" CssClass="style3"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPhone" runat="server"  
                        CssClass="style2" Width="123px"></asp:TextBox>
                </td>
                <td> <asp:RegularExpressionValidator ID="RegularExpressionPhone" runat="server" 
        ErrorMessage="Nombor tidak sah" ForeColor="Red" ControlToValidate="TxtPhone" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator></td>
            </tr>
             <tr>
                <td class="style1">
                    <asp:Label ID="LabelTelefonPejabat" runat="server" Text="Telefon Pejabat:" 
                        Visible="False" CssClass="style3"></asp:Label>
                 </td>
                <td>
                    <asp:TextBox ID="TxtPhone2" runat="server"  
                        CssClass="style2" Width="123px"></asp:TextBox>
                </td>
                <td> <asp:RegularExpressionValidator ID="RegularExpressionPhone2" runat="server" 
        ErrorMessage="Nombor tidak sah" ForeColor="Red" ControlToValidate="TxtPhone2" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator></td>
            </tr>
        </table>
        <br />
       
        <asp:Button ID="update" runat="server" Text="Simpan" onclick="update_Click" 
         Width="85px" Visible="False"  />
       &nbsp&nbsp
        <br />
         
  
<asp:Button ID="btnShowPopup2" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopup2" PopupControlID="pnlpopup2" BackgroundCssClass="modalBackground"
CancelControlID="canceldelete">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlpopup2" runat="server" BackColor="White" Height="269px" Width="400px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #0000A0; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#0000A0">
<td colspan="2" style=" height:10%; color:Black; font-weight:bold; font-size:larger" align="center">Padamkan Profil</td>
</tr>
<tr>
<td align="center">
<h4>Anda pasti mahu padamkan data profil? 
    <asp:Label ID="DeleteProfil" runat="server" Text="Profil"></asp:Label>? </h4>
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
                        SelectCommand="SELECT [nama] FROM [kumpulan_perkhidmatan]"></asp:SqlDataSource>  
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:Table_Connection %>" 
                        SelectCommand="SELECT [nama] FROM [jawatan]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:Table_Connection %>" 
                        SelectCommand="SELECT [nama] FROM [bahagian]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:Table_Connection %>" 
                        SelectCommand="SELECT [no] FROM [gred_jawatan]"></asp:SqlDataSource>   
</asp:Content>

