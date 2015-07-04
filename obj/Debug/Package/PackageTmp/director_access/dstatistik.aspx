<%@ Page Title="" Language="C#" MasterPageFile="~/director_access/director.Master" AutoEventWireup="true" CodeBehind="dstatistik.aspx.cs" Inherits="aviation.director_access.dstatistik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<table align="center">
   <tr><td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/admin_access/images/flight_icon.jpg" 
           PostBackUrl="~/director_access/dstatistiktiket.aspx" /></td>
           <td><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/admin_access/images/company.jpg" 
           PostBackUrl="~/director_access/dstatistikbahagian.aspx" /></td></tr>
      <tr><td> <h4 style="text-align: center">Statistik Tempahan Tiket</h4></td>
      
      <td> <h4 style="text-align: center">Statistik Bahagian</h4></td></tr></table><br />
      <asp:GridView ID="gdvDuaHala" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
        ShowFooter="True" AllowPaging="True" 
        onpageindexchanging="gdvDuaHala_PageIndexChanging" Visible="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="No.Rujukan" />
            <asp:BoundField DataField="username_pegawai" HeaderText="IC Pegawai" />
            <asp:BoundField DataField="tarikh_tempahan" HeaderText="Tarikh Tempahan" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="bulan" HeaderText="Bulan Tempahan"/>
            <asp:BoundField DataField="nama_penyelia" HeaderText="Nama Penyelia" />
            <asp:BoundField DataField="lulus" HeaderText="Status Lulus" />
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
    <asp:GridView ID="gdvSehala" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
        ShowFooter="True" AllowPaging="True" 
        onpageindexchanging="gdvSehala_PageIndexChanging" Visible="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="No.Rujukan" />
            <asp:BoundField DataField="username_pegawai" HeaderText="IC Pegawai" />
            <asp:BoundField DataField="tarikh_tempahan" HeaderText="Tarikh Tempahan" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="bulan" HeaderText="Bulan Tempahan"/>
            <asp:BoundField DataField="nama_penyelia" HeaderText="Nama Penyelia" />
            <asp:BoundField DataField="lulus" HeaderText="Status Lulus" />
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
</asp:Content>

