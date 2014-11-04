<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.Web.EstadoAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Label ID="lblEstadoAcademico" runat="server" Text="Estado académico"></asp:Label>
<br />
<br />
<asp:GridView ID="grdEstadoAcademico" runat="server">
</asp:GridView>
<br />
<br />
</asp:Content>
