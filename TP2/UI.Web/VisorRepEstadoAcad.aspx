﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorRepEstadoAcad.aspx.cs" Inherits="UI.Web.VisorRepEstadoAcad" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 771px; height: 558px">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="rvEstadoAcademico" runat="server" Font-Names="Verdana" Font-Size="8pt" style="margin-right: 4px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="763px" Height="516px">
            <LocalReport ReportPath="Reportes\RepEstadoAcademico.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
