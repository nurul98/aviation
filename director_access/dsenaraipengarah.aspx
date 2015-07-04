<%@ Page Title="" Language="C#" MasterPageFile="~/director_access/director.Master" AutoEventWireup="true" CodeBehind="dsenaraipengarah.aspx.cs" Inherits="aviation.director_access.dsenaraipengarah" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<h2>Senarai Pengarah</h2>
   
<asp:GridView ID="gridpenyelia" runat="server" AutoGenerateColumns="False" 
         CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
         PageSize="10" AllowPaging="True" 
         onpageindexchanging="gridpenyelia_PageIndexChanging">
                   <Columns>
                       <asp:BoundField DataField="username" HeaderText="IC Penyelia" SortExpression="username" />
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
                       <asp:TemplateField HeaderText="E-Mail" SortExpression="email">
                        <ItemTemplate>
                            <asp:Label ID="txtemail" runat="server" Enabled="False" 
                                Text='<%# Bind("email") %>'></asp:Label>
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
</asp:Content>

