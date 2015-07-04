<%@ Page Title="" Language="C#" MasterPageFile="~/admin_access/admin.Master" AutoEventWireup="true" CodeBehind="link.aspx.cs" Inherits="aviation.link" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            color: #FF00FF;
        }
        .style3
        {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <body> 
    <div>
<br >


<!-- Here's the box for some pics, remove if not a photo gallery -->
    <div class="picboxouter">

        <!-- Here's where you can place ur thumbnails -->
        <!-- All should be uniformly sized ;-) -->
        <div class="picbox">
        Laman ini untuk rujukan anda bagi membolehkan anda menyemak jadual penerbangan sebelum membuat tempahan tiket melalui sistem ini.
            <span class="style2">Sila Klik Link Di Bawah Untuk Melihat Jadual Penerbangan :</span><br />

   
    <p class="style3">


     &nbsp;<img src="images/airasia.png" alt="help" class="pickboxcontrol" 
             width="80px" /> &nbsp; &nbsp;&nbsp;<asp:HyperLink ID="airasiaadmin" runat="server" 
                    
            NavigateUrl="http://booking.airasia.com/Search.aspx?gclid=CO3f5Pbsra4CFQV66wodT3ZYPQ">Jadual Penerbangan Air Asia</asp:HyperLink>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      </p>
        <p class="style3">
           &nbsp;</a>&nbsp;
            <img src="images/mas.jpg" alt="help" class="pickboxcontrol" width="140px" /> &nbsp;
            <asp:HyperLink ID="masadmin" runat="server" 
                
                NavigateUrl="http://www.malaysiaairlines.com/my/en.html?s_kwcid=TC|16774|reservation%20malaysia%20airlines||S|b|7467104897">Jadual Penerbangan Mas</asp:HyperLink>
           </p>
        <p class="style3">
          &nbsp;</a>&nbsp;
            <img src="images/firefly.png" alt="help" class="pickboxcontrol" width="100px" /> 
            &nbsp;&nbsp;<asp:HyperLink ID="fireflyadmin" runat="server" 
                NavigateUrl="http://firefly.com.my">Jadual Penerbangan FireFly</asp:HyperLink>
&nbsp;</p>
          </div>
    </div>
    
    </div>
    </body></p>
</asp:Content>
