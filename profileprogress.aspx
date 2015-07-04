<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="profileprogress.aspx.cs" Inherits="aviation.profileprogress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
        .style2
        {
            height: 23px;
        }
        .style3
        {
            height: 32px;
        }
        .style4
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Profil Pengguna</h1><br />
    <center>
        <table class="style1">
              <tr class="style4">
                 <td class="style3">
                    IC Pegawai:</td>
                <td class="style3">
                    <asp:Label ID="pegawai_ID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="style4">
                <td class="style2">
                    Nama Pegawai:</td>
                <td>
                    <asp:Label ID="name" runat="server"></asp:Label>
                </td>
            </tr>
           
            <tr class="style4">
                <td class="style2">
                    E-Mail:</td>
                <td>
                    <asp:Label ID="email" runat="server"></asp:Label>
                </td>
            </tr>
              <tr class="style4">
                <td class="style2">
                    Kumpulan Perkhidmatan:</td>
                <td>
                    <asp:Label ID="kumpulan_perkhidmatan" runat="server"></asp:Label>
                </td>
            </tr>
            
              <tr class="style4">
                <td class="style2">
                    Jawatan:</td>
                <td>
                    <asp:Label ID="jawatan" runat="server"></asp:Label>
                </td>
            </tr>
             <tr class="style4">
                <td class="style2">
                    Bahagian:</td>
                <td>
                    <asp:Label ID="bahagian" runat="server"></asp:Label>
                </td>
            </tr>
             <tr class="style4">
                <td class="style2">
                    Gred Jawatan:</td>
                <td>
                    <asp:Label ID="gred_jawatan" runat="server"></asp:Label>
                </td>
            </tr>
             <tr class="style4">
                <td class="style2">
                    Sektor:</td>
                <td>
                    <asp:Label ID="sektor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="style4">
                <td class="style2">
                    Telefon Bimbit:</td>
                <td>
                    <asp:Label ID="telefon_bimbit" runat="server"></asp:Label>
                </td>
            </tr>
            <tr class="style4">
                <td class="style2">
                    Telefon Pejabat:</td>
                <td>
                    <asp:Label ID="telefon_pejabat" runat="server"></asp:Label>
                </td>
            </tr>
           
        </table>
        <br />
    <asp:Button ID="update_profile" runat="server" Text="Kemaskini" PostBackUrl="~/profileupdate.aspx" />
    </center>
    </asp:Content>
