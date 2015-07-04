<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="profilecreate.aspx.cs" Inherits="aviation.profilecreate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: left;
        }
        .style2
        {
            text-align: left;
            color: #000000;
        }
        .style3
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Profil Pegawai</h1><br />
        <table class="style1">
            
            <tr>
                <td class="style2">
                    Nama Pegawai:
                </td>
                <td>
                    <asp:TextBox ID="TxtNama" runat="server" CssClass="style2" Width="390px"></asp:TextBox>
                </td>
                <td> <asp:RequiredFieldValidator ID="RequiredNama" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtNama" CssClass="ErrorMessage">Sila masukkan nama anda</asp:RequiredFieldValidator> </td>
            </tr>
    <tr>
                <td class="style2">
                    E-mail:
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
                <td class="style2">
                    Kumpulan Perkhidmatan:</td>
                <td>
                    <asp:DropDownList ID="KumpulanPerkhidmatan" runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="nama" DataValueField="nama" 
                        Width="276px">
                       
                    </asp:DropDownList>  
                </td>
                <td> &nbsp;</td>
            </tr>
              <tr>
                <td class="style2">
                    Jawatan:</td>
                <td>
                    <asp:DropDownList ID="Jawatan" runat="server" 
                        DataSourceID="SqlDataSource2" DataTextField="nama" DataValueField="nama" 
                        Width="276px">
                       
                    </asp:DropDownList>
                  
                </td>
                <td> &nbsp;</td>
            </tr>
              <tr>
                <td class="style2">
                    Bahagian:</td>
                <td>
                      <asp:DropDownList ID="Bahagian" runat="server" 
                        DataSourceID="SqlDataSource3" DataTextField="nama" DataValueField="nama" 
                        Width="276px">
                       
                    </asp:DropDownList>
                </td>
                <td> &nbsp;</td>
            </tr>
              <tr>
                <td class="style2">
                    Gred Jawatan:</td>
                <td>
                    <asp:DropDownList ID="GredJawatan" runat="server" 
                        DataSourceID="SqlDataSource4" DataTextField="no" DataValueField="no" 
                        Width="276px">
                       
                    </asp:DropDownList>
                  
                </td>
                <td> &nbsp;</td>
            </tr>
             <tr>
                <td class="style2">
                    Sektor:</td>
                <td>
                    <asp:TextBox ID="TxtSektor" runat="server" CssClass="style2" Width="106px"></asp:TextBox>
                   </td>
                    <td> </td>
            </tr>
            <tr>
                <td class="style2">
                    Telefon Bimbit:</td>
                <td>
                    <asp:DropDownList ID="DropDownListPhone" runat="server">
                        <asp:ListItem>010</asp:ListItem>
                        <asp:ListItem>011</asp:ListItem>
                        <asp:ListItem>012</asp:ListItem>
                        <asp:ListItem>013</asp:ListItem>
                        <asp:ListItem>014</asp:ListItem>
                        <asp:ListItem>015</asp:ListItem>
                        <asp:ListItem>016</asp:ListItem>
                        <asp:ListItem>017</asp:ListItem>
                        <asp:ListItem>018</asp:ListItem>
                        <asp:ListItem>019</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtPhone" runat="server"  
                        CssClass="style2" Width="123px"></asp:TextBox>
                </td>
                <td> <asp:RegularExpressionValidator ID="RegularExpressionPhone" runat="server" 
        ErrorMessage="Nombor tidak sah" ForeColor="Red" ControlToValidate="TxtPhone" ValidationExpression="^[0-9]{7}$"></asp:RegularExpressionValidator></td>
            </tr>
             <tr>
                <td class="style2">
                    Telefon Pejabat:</td>
                <td>
                    <asp:DropDownList ID="DropDownListPhone2" runat="server">
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtPhone2" runat="server"  
                        CssClass="style2" Width="123px"></asp:TextBox>
                </td>
                <td> <asp:RegularExpressionValidator ID="RegularExpressionPhone2" runat="server" 
        ErrorMessage="Nombor tidak sah" ForeColor="Red" ControlToValidate="TxtPhone2" ValidationExpression="^[0-9]{8}$"></asp:RegularExpressionValidator></td>
            </tr>
        </table>
        <br />
       <center>
        <asp:Button ID="Submit_Register" runat="server" Text="Hantar" onclick="Submit_Register_Click" Width="85px"  />
       &nbsp&nbsp
        <asp:Button ID="Submit_Clear" runat="server" Text="Batal" 
        onclick="Clear_Click" Width="85px"  />
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

                        </center>
       
</asp:Content>

