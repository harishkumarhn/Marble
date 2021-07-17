<%--<%@ Page Language="C#" AutoEventWireup="false"   CodeBehind="CustomReport.aspx.cs" Inherits="Marble.WebReports.ReportPages.CustomReport" %>--%>

 <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Bootstrap.Master" AutoEventWireup="true" CodeBehind="CustomReport.aspx.cs" Inherits="Marble.WebReports.ReportPages.CustomReport" %>
 
<%@Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
  <%--   <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>--%>

</asp:Content> 

        
<asp:Content ID="MainContent_client" ContentPlaceHolderID="MainContent" runat="server">
       
  
       From Date<asp:TextBox runat="server" ClientIDMode="Static"  ID="txtFromDate" CssClass="datepicker"  AutoCompleteType="Disabled"  />
        To Date<asp:TextBox runat="server" ClientIDMode="Static"  ID="txtToDate" CssClass="datepicker"  AutoCompleteType="Disabled"   />
       <asp:Button Text="Search" runat="server"  ID="btnSearch" OnClick="btnSearch_Click" />

    <%-- <asp:Button  ID="btnExport" ClientIDMode="Static" runat="server"   OnClick="btnExport_Click" Text="Export"/> --%>
   
        <asp:ScriptManager ID="ScriptManager1" runat="server">


        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false"   Width="100%" Height="600" ShowFindControls="false"></rsweb:ReportViewer>
         
     <script type="text/javascript">
        $(".datepicker").datepicker({
      changeMonth: true,
          changeYear: true
      });
   </script>
</asp:Content>

<%--<!DOCTYPE html>
<%@Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<html xmlns="http://www.w3.org/1999/xhtml"> 
<head runat="server">
    <title></title>
     <meta http-equiv="X-UA-Compatible" content="IE=edge" /> 
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"> 

  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<script>
  $( function() {
      $(".datepicker").datepicker({
      changeMonth: true,
          changeYear: true
      });
  } );
  </script>
</head>
<body>
  <form id="form1" runat="server">
      
    
       From Date<asp:TextBox runat="server" ClientIDMode="Static"  ID="txtFromDate" CssClass="datepicker"  AutoCompleteType="Disabled"  />
        To Date<asp:TextBox runat="server" ClientIDMode="Static"  ID="txtToDate" CssClass="datepicker"  AutoCompleteType="Disabled"   />
       <asp:Button Text="Search" runat="server"  ID="btnSearch" OnClick="btnSearch_Click" />

  
   
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="false"   Width="100%" ShowFindControls="false"></rsweb:ReportViewer>
    </form>
</body>
</html>--%>
