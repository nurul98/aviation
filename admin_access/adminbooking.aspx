<%@ Page Title="" Language="C#" MasterPageFile="~/admin_access/admin.Master" AutoEventWireup="true" CodeBehind="adminbooking.aspx.cs" Inherits="aviation.admin_access.adminbooking" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <style type="text/css">
        .style2
        {
            text-align: left;
        }
        .style3
        {
            width: 224px;
            text-align: left;
        }
        .style4
        {
            width: 127px;
            text-align: left;
        }
        .style6
        {
            width: 121px;
        }
        .style7
        {
            width: 196px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <h1>Tiket Pergi Balik</h1><br />
  Sila 
    <asp:HyperLink ID="linksehalaadmin" runat="server" 
        NavigateUrl="~/admin_access/tiketsehalaadmin.aspx">klik di sini </asp:HyperLink>untuk menempah tiket sehala<br />
&nbsp;
        <table class="style1">
            
           <tr>
                <td class="style4">
                    IC Pegawai:
                </td>
                <td class="style3">
                    <asp:DropDownList ID="TxtIC" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="username" DataValueField="username" AutoPostBack="True">
                    </asp:DropDownList> 
                   
                </td>
                
                </tr>
          <tr>
                <td class="style4">
                    Dari:
                </td>
                <td class="style3">
                    <asp:TextBox ID="TxtTempat" runat="server" CssClass="style2" Width="180px"></asp:TextBox>
                </td>
                <td> <asp:RequiredFieldValidator ID="RequiredTempat" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtTempat" CssClass="ErrorMessage">Sila masukkan tempat</asp:RequiredFieldValidator> </td>
                </tr>
                <tr>
                 <td class="style7">
                    Ke:&nbsp;
                </td>
                <td class="style6">
                    <asp:TextBox ID="TxtKe" runat="server" CssClass="style2" Width="180px"></asp:TextBox>
                </td>
               <td> <asp:RequiredFieldValidator ID="RequiredKe" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtKe" CssClass="ErrorMessage">Sila masukkan destinasi</asp:RequiredFieldValidator> </td>
            </tr> 
            <tr>
                 <td class="style8">
                    Jenis Penerbangan:&nbsp;
                </td>
                <td class="style6">
                    <asp:RadioButtonList ID="TxtJenis" runat="server" ForeColor="Black" 
                        RepeatDirection="Horizontal">
                        <asp:ListItem>MAS</asp:ListItem>
                        <asp:ListItem>AirAsia</asp:ListItem>
                        <asp:ListItem>Firefly</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
               <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtJenis" CssClass="ErrorMessage">Sila masukkan jenis penerbangan</asp:RequiredFieldValidator> </td>
            </tr> 
 <tr>
        <td class="style4">
            Tarikh Pergi:&nbsp;&nbsp;&nbsp;&nbsp; </td>
       <td class="style3"><asp:TextBox ID="TxtTarikhPergi" runat="server" Width="107px"></asp:TextBox>
        
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         </td>
         <td> <asp:RequiredFieldValidator ID="RequiredTarikhPergi" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtTarikhPergi" CssClass="ErrorMessage">Sila masukkan tarikh</asp:RequiredFieldValidator> </td>
        </tr>
        <tr>
        <td class="style7">
            Waktu Perjalanan: &nbsp;&nbsp;&nbsp; </td>
       <td class="style6">
           <asp:RadioButtonList ID="waktuperjalanan1" runat="server" 
               style="text-align: left">
               <asp:ListItem>Pagi</asp:ListItem>
               <asp:ListItem>Tengah Hari</asp:ListItem>
               <asp:ListItem>Petang</asp:ListItem>
               <asp:ListItem>Malam</asp:ListItem>
           </asp:RadioButtonList>
        
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         </td>
        </tr>
        <tr>
        <td class="style4">
            Tarikh Balik:&nbsp;&nbsp;&nbsp;&nbsp; </td>
       <td class="style3"><asp:TextBox ID="TxtTarikhBalik" runat="server" Width="107px"></asp:TextBox>
        
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         </td>
         <td> <asp:RequiredFieldValidator ID="RequiredTarikhBalik" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtTarikhBalik" CssClass="ErrorMessage">Sila masukkan tarikh</asp:RequiredFieldValidator> </td>
       </tr>
       <tr>
        <td class="style7">
            Waktu Perjalanan:&nbsp;&nbsp;&nbsp;&nbsp; </td>
       <td class="style3">
           <asp:RadioButtonList ID="waktuperjalanan2" runat="server">
               <asp:ListItem>Pagi</asp:ListItem>
               <asp:ListItem>Tengah Hari</asp:ListItem>
               <asp:ListItem>Petang</asp:ListItem>
               <asp:ListItem>Malam</asp:ListItem>
           </asp:RadioButtonList>
        
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         </td>
        </tr>
         <tr>
                <td class="style4">
                    Bilangan Penumpang:
                </td>
                <td class="style3">
                    <asp:TextBox ID="bilangan_penumpang" runat="server" CssClass="style2" 
                        Width="50px"></asp:TextBox>
                </td>
                <td>
                Sila muat naik dokumen sokongan senarai nama penumpang dan ic penumpang
                 <asp:RangeValidator ID="RangePenumpang" runat="server" 
        ErrorMessage="Angka tidak sah" ForeColor="Red" ControlToValidate="bilangan_penumpang" MaximumValue="99999" MinimumValue="0"></asp:RangeValidator></td>
                </tr>
         <tr>
                <td class="style4">
                    Cara Perjalanan:</td>
                <td class="style3">
                    Udara
                   </td>
                    <td class="style7"> </td>
            </tr>
        <tr>
                <td class="style4">
                    Tujuan Perjalanan:</td>
                <td class="style3">
                    <asp:TextBox ID="TxtTujuanPerjalanan" runat="server" CssClass="style2" 
                        Width="276px" TextMode="MultiLine" Height="56px"></asp:TextBox>
                   </td>
                    <td class="style7">
                    </td>
            </tr>
              <tr>
                <td class="style4">
                    Catatan:</td>
                <td class="style3">
                    <asp:TextBox ID="TxtCatatan" runat="server" CssClass="style2" 
                        Width="276px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                   </td>
                    <td class="style7">
                        Sila masukkan nombor penerbangan.Pihak kami berhak menempah tiket lain jika 
                        nombor penerbangan dipilih telah penuh.</td>
            </tr>
             <tr>
                <td class="style4">
                    Nama Penyelia:
                </td>
                <td class="style3">
                    <asp:DropDownList ID="namapenyelia" runat="server" 
                        Height="27px" Width="276px">
                    </asp:DropDownList>
                    
                </td>
                </tr>
             <tr>
                <td class="style4">
                    E-Mail Penyelia:
                </td>
                <td class="style3">
                    <asp:TextBox ID="email_penyelia" runat="server" CssClass="style2" Width="180px"></asp:TextBox>
                </td>
                <td>
                     <asp:RegularExpressionValidator ID="RegularEmail" runat="server" 
        ErrorMessage="Sila masukkan email yang sah" ForeColor="Red" 
        ControlToValidate="email_penyelia" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator> </td>
                </tr>
            <tr>
                <td class="style4">
                    Dokumen Sokongan:</td>
                <td class="style3">
                    <asp:FileUpload ID="FileUploadTujuan" runat="server" Width="277px" />
                   </td>
                     <td class="style7"> 
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="FileUploadTujuan" ErrorMessage="Hanya dokumen berbentuk pdf dan gambar sahaja yang diterima" 
                            
                            ValidationExpression="^.+(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.png|.PNG|.pdf|.PDF)$" 
                            ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
        <br />
      
        <asp:Button ID="assign" runat="server" Text="Tempah" onclick="assign_Click" Width="85px"  />
       &nbsp&nbsp
        <asp:Button ID="Submit_Clear" runat="server" Text="Batal" 
        onclick="Clear_Click" Width="85px"  />
 <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:Table_Connection %>" 
                        
        SelectCommand="SELECT [username], [pangkat] FROM [profil_pegawai] WHERE (([pangkat] = @pangkat) OR ([pangkat] = @pangkat2))">
     <SelectParameters>
         <asp:Parameter DefaultValue="pegawai" Name="pangkat" 
             Type="String" />
         <asp:Parameter DefaultValue="penyelia" Name="pangkat2" Type="String" />
     </SelectParameters>
    </asp:SqlDataSource>
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtTarikhPergi" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
     <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TxtTarikhBalik" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
     
</asp:Content>
