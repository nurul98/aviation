<%@ Page Title="" Language="C#" MasterPageFile="~/supervisor_access/supervisor.Master" AutoEventWireup="true" CodeBehind="statistiktiket.aspx.cs" Inherits="aviation.supervisor_access.statistiktiket" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" 
        Height="450px" Width="700px">
        <Series>
            <asp:Series Name="Series1" XValueMember="bulan" 
                YValueMembers="bil_tiket_duahala" IsValueShownAsLabel="True" 
                Legend="Legend1" LegendText="Jumlah Tempahan">
            </asp:Series>
             <asp:Series Name="Series2" XValueMember="bulan" 
                YValueMembers="duahala_lulus" IsValueShownAsLabel="True" Legend="Legend1" 
                LegendText="Bil. Tiket Dikeluarkan">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisY Title="Bil. Tempahan Tiket Dua Hala">
                    <MajorGrid Enabled="False" />
                    <MajorTickMark Enabled="False" />
                </AxisY>
                <AxisX IsLabelAutoFit="False" Title="Bulan">
                    <MajorGrid Enabled="False" />
                    <MajorTickMark Enabled="False" />
                    <LabelStyle Angle="-90" Interval="1" />
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
        </Legends>
    </asp:Chart>
    <br />
    <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2" 
        Height="450px" Width="700px">
        <Series>
            <asp:Series Name="Series1a" XValueMember="bulan" 
                YValueMembers="bil_tiket_sehala" IsValueShownAsLabel="True" 
                Legend="Legend1a" LegendText="Jumlah Tempahan">
            </asp:Series>
             <asp:Series Name="Series2a" XValueMember="bulan" 
                YValueMembers="sehala_lulus" IsValueShownAsLabel="True" Legend="Legend1a" 
                LegendText="Bil. Tiket Dikeluarkan">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisY Title="Bil. Tempahan Tiket Sehala">
                    <MajorGrid Enabled="False" />
                    <MajorTickMark Enabled="False" />
                </AxisY>
                <AxisX IsLabelAutoFit="False" Title="Bulan">
                    <MajorGrid Enabled="False" />
                    <MajorTickMark Enabled="False" />
                    <LabelStyle Angle="-90" Interval="1" />
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1a">
            </asp:Legend>
        </Legends>
    </asp:Chart>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Table_Connection %>" 
        SelectCommand="SELECT * FROM [laporanbulanan]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Table_Connection %>" 
        SelectCommand="SELECT * FROM [laporanbulanan]">
    </asp:SqlDataSource>
</asp:Content>

