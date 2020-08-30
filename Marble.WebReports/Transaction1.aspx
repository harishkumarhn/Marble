<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Transaction1.aspx.cs" Inherits="Marbale.WebReports.RDLC.Transaction" MasterPageFile="~/Bootstrap.Master""  %>

<%--<%@Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
 --%>
<%@Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"  %>
 
 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"> 
<head runat="server">
    <title></title>
     <meta http-equiv="X-UA-Compatible" content="IE=edge" /> 
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"> 
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<script>
  $( function() {
    $( ".datepicker" ).datepicker();
  } );
  </script>
</head>
<body>
  <form id="form1" runat="server">
        From Date<asp:TextBox runat="server" ClientIDMode="Static"  ID="txtFromDate" CssClass="datepicker"  AutoCompleteType="Disabled"  />
        To Date<asp:TextBox runat="server" ClientIDMode="Static"  ID="txtDate" CssClass="datepicker"  AutoCompleteType="Disabled"   />
        <asp:Button Text="Search" runat="server"  ID="btnSearch" OnClick="btnSearch_Click" />
      <asp:Button Text="Download" runat="server"  ID="bttestdownlad" OnClick="bttestdownlad_Click" />

   <%-- <asp:Button  ID="btnExport" ClientIDMode="Static" runat="server"   OnClick="btnExport_Click" Text="Export"/>--%>
   
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false" OnDrillthrough="ReportViewer1_Drillthrough" Width="100%" ShowFindControls="false"></rsweb:ReportViewer>
    </form>
</body>
</html>
