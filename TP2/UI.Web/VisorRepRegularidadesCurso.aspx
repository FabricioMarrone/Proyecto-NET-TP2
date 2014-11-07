<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorRepRegularidadesCurso.aspx.cs" Inherits="UI.Web.VisorRepRegularidadesCurso" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <rsweb:ReportViewer ID="rvReportesAcademia" runat="server" Height="371px" SizeToReportContent="True" Width="592px">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
