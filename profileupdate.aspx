<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="profileupdate.aspx.cs" Inherits="aviation.profileupdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Profil Pegawai</h1><br />
        <table class="style1">
            
            <tr>
                <td class="style1">
                    Nama Pegawai:
                </td>
                <td>
                    <asp:TextBox ID="TxtNama" runat="server" CssClass="style2" Width="390px"></asp:TextBox>
                </td>
                <td> <asp:RequiredFieldValidator ID="RequiredNama" runat="server" ErrorMessage="*" ForeColor="Red"
     ControlToValidate="TxtNama" CssClass="ErrorMessage">Sila masukkan nama anda</asp:RequiredFieldValidator> </td>
            </tr>
    <tr>
                <td class="style1">
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
                <td class="style1">
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
                <td class="style1">
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
                <td class="style1">
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
                <td class="style1">
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
                <td class="style1">
                    Sektor:</td>
                <td>
                    <asp:TextBox ID="TxtSektor" runat="server" CssClass="style2" Width="106px"></asp:TextBox>
                   </td>
                    <td> </td>
            </tr>
            <tr>
                <td class="style1">
                    Telefon Bimbit:</td>
                <td>
                    <asp:TextBox ID="TxtPhone" runat="server"  
                        CssClass="style2" Width="123px"></asp:TextBox>
                </td>
                <td> <asp:RegularExpressionValidator ID="RegularExpressionPhone" runat="server" 
        ErrorMessage="Nombor tidak sah" ForeColor="Red" ControlToValidate="TxtPhone" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator></td>
            </tr>
             <tr>
                <td class="style1">
                    Telefon Pejabat:</td>
                <td>
                    <asp:TextBox ID="TxtPhone2" runat="server"  
                        CssClass="style2" Width="123px"></asp:TextBox>
                </td>
                <td> <asp:RegularExpressionValidator ID="RegularExpressionPhone2" runat="server" 
        ErrorMessage="Nombor tidak sah" ForeColor="Red" ControlToValidate="TxtPhone2" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator></td>
            </tr>
        </table>
        <br />
       
        <asp:Button ID="update" runat="server" Text="Simpan" onclick="update_Click" Width="85px"  />
       &nbsp&nbsp
        <br />
    <br />
    &nbsp;<asp:ChangePassword ID="ChangePassword1" runat="server" 
        style="color: #000000">
        <ChangePasswordTemplate>
            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Tukar Kata Laluan</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="CurrentPasswordLabel" runat="server" 
                                        AssociatedControlID="CurrentPassword">Kata laluan:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" 
                                        ControlToValidate="CurrentPassword" ErrorMessage="Sila masukkan kata laluan." 
                                        ToolTip="Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="NewPasswordLabel" runat="server" 
                                        AssociatedControlID="NewPassword">Kata laluan baru:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" 
                                        ControlToValidate="NewPassword" ErrorMessage="Sila masukkan kata laluan yang baru." 
                                        ToolTip="New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmNewPasswordLabel" runat="server" 
                                        AssociatedControlID="ConfirmNewPassword">Sahkan kata laluan:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" 
                                        ControlToValidate="ConfirmNewPassword" 
                                        ErrorMessage="Sila sahkan kata laluan yang baru." 
                                        ToolTip="Confirm New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="NewPasswordCompare" runat="server" 
                                        ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                        Display="Dynamic" 
                                        ErrorMessage="Kata laluan tidak sama." 
                                        ValidationGroup="ChangePassword1" style="color: #000000"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="ChangePasswordPushButton" runat="server" 
                                        CommandName="ChangePassword" Text="Tukar kata laluan" 
                                        ValidationGroup="ChangePassword1" />
                                </td>
                                <td>
                                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" 
                                        CommandName="Cancel" Text="Batal" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ChangePasswordTemplate>
        <SuccessTemplate>
            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Change Password Complete</td>
                            </tr>
                            <tr>
                                <td>
                                    Your password has been changed!</td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" 
                                        CommandName="Continue" PostBackUrl="~/profileupdate.aspx" Text="Continue" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </SuccessTemplate>
    </asp:ChangePassword>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:Table_Connection %>" 
                        
    SelectCommand="SELECT [nama] FROM [kumpulan_perkhidmatan]">
                    </asp:SqlDataSource>  
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
