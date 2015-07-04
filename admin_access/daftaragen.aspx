<%@ Page Title="" Language="C#" MasterPageFile="~/admin_access/admin.Master" AutoEventWireup="true" CodeBehind="daftaragen.aspx.cs" Inherits="aviation.admin_access.daftaragen" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {}
        .style4
    {
        color: #000000;
    }
    .style5
    {
        width: 181px;
        color: #000000;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Daftar Agen</h1><br />
  Sila isi maklumat syarikat<br />
&nbsp;<table class="style1">
            
            <tr>
                <td class="style5">
                    Nama Syarikat:
                </td>
                <td>
                    <asp:TextBox ID="TxtNama" runat="server" CssClass="style2" Width="390px"></asp:TextBox>
                </td>
                <td> <asp:RequiredFieldValidator ID="RequiredNama" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtNama" CssClass="ErrorMessage">Sila masukkan nama syarikat</asp:RequiredFieldValidator> </td>
            </tr>
              <tr>
                <td class="style5">
                    Alamat Syarikat:
                </td>
                <td>
                    <asp:TextBox ID="TxtAlamat" runat="server" CssClass="style2" Width="390px" 
                        Height="102px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td> <asp:RequiredFieldValidator ID="RequiredAlamat" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtAlamat" CssClass="ErrorMessage">Sila masukkan alamat syarikat</asp:RequiredFieldValidator> </td>
            </tr>
             <tr>
                <td class="style5">
                    Nombor Untuk Dihubungi:</td>
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
        ErrorMessage="Masukkan nombor yang sah" ForeColor="Red" ControlToValidate="TxtPhone2" ValidationExpression="^[0-9]{8}$"></asp:RegularExpressionValidator></td>
            </tr>
              <tr>
                <td class="style5">
                    Faks:</td>
                <td>
                    <asp:DropDownList ID="DropDownListFaks" runat="server">
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="TxtFaks" runat="server"  
                        CssClass="style2" Width="123px"></asp:TextBox>
                </td>
                <td> <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Masukkan nombor yang sah" ForeColor="Red" ControlToValidate="TxtFaks" ValidationExpression="^[0-9]{8}$"></asp:RegularExpressionValidator></td>
            </tr>
    <tr>
                <td class="style5">
                    E-mail:
                </td>
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="style2" Width="170px"></asp:TextBox>
                </td>
                 <td>
                     <asp:RegularExpressionValidator ID="RegularEmail" runat="server" 
        ErrorMessage="Masukkan e-mail yang sah" ForeColor="Red" 
        ControlToValidate="TxtEmail" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> </td>
            </tr>
      <tr>
                <td class="style5">
                    Catatan:
                </td>
                <td>
                    <asp:TextBox ID="TxtCatatan" runat="server" CssClass="style2" Width="225px" 
                        Height="78px" TextMode="MultiLine"></asp:TextBox>
                </td>   
            </tr>
            <tr><td class="style5">
                <br />
                <br />
                Tempoh Sah Laku/Nombor Sijil<br />
                <br />
                </td></tr>
            <tr>
                <td class="style5">
                    Tarikh Kewangan:</td>
                    
                <td class="style4">
                    Dari:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TxtTarikhKewangan1" runat="server" CssClass="style2" Width="86px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp; Ke:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TxtTarikhKewangan2" runat="server" CssClass="style2" Width="86px"></asp:TextBox>
                </td>
               
               </tr>
               <tr>
                <td class="style5">
                    Tarikh TDC:</td>
                    
                <td class="style4">
                    Dari:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TarikhTDC1" runat="server" CssClass="style2" Width="86px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp; Ke:&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TarikhTDC2" runat="server" CssClass="style2" Width="86px"></asp:TextBox>
                </td>
               
               </tr>
           <tr>
                <td class="style4">Nilai Perolehan Semasa</td><td>
                    <span class="style4">RM</span>&nbsp;&nbsp; <asp:TextBox ID="TxtGaji" runat="server" CssClass="style2" Width="106px"></asp:TextBox>
                   </td>
                    <td> <asp:RangeValidator ID="RangeSalary" runat="server" 
        ErrorMessage="Masukkan jumlah amaun yang sah" ForeColor="Red" ControlToValidate="TxtGaji" MaximumValue="99999" MinimumValue="0"></asp:RangeValidator></td>
          
           </tr>
        </table>
           <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtTarikhKewangan1" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
      <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TxtTarikhKewangan2" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
     <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TarikhTDC1" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
     <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TarikhTDC2" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
        <br />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Submit_Register" runat="server" Text="Daftar" 
        onclick="assign_Click" Width="85px" style="text-align: center"  />
       &nbsp&nbsp
        <asp:Button ID="Submit_Clear" runat="server" Text="Batal" 
        onclick="Clear_Click" Width="85px"  />
          
</asp:Content>

