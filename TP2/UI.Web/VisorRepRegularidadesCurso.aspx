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
    <div style="width: 606px">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <rsweb:ReportViewer ID="rvReportesAcademia" runat="server" Height="371px" SizeToReportContent="True" Width="592px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Reportes\RepRegulidadesDeCurso.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
