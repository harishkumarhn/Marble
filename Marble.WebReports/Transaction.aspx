<%@ Page Title="" Language="C#" MasterPageFile="~/Bootstrap.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="Marble.WebReports.Transaction" %>

 
<%@Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
  $( function() {
    $( ".datepicker" ).datepicker();
  });
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     From Date<asp:TextBox runat="server" ClientIDMode="Static"  ID="txtFromDate" CssClass="datepicker"  AutoCompleteType="Disabled"  />
        To Date<asp:TextBox runat="server" ClientIDMode="Static"  ID="txtDate" CssClass="datepicker"  AutoCompleteType="Disabled"   />
        <asp:Button Text="Search" runat="server"  ID="btnSearch" OnClick="btnSearch_Click" />
      <asp:Button Text="Download" runat="server"  ID="bttestdownlad" OnClick="bttestdownlad_Click" />

   <%-- <asp:Button  ID="btnExport" ClientIDMode="Static" runat="server"   OnClick="btnExport_Click" Text="Export"/>--%>
   
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" OnDrillthrough="ReportViewer1_Drillthrough" Width="100%" ShowFindControls="false"></rsweb:ReportViewer>
</asp:Content>
