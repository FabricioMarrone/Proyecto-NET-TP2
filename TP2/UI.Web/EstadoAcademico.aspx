<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.Web.EstadoAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h1 id="titulo">Estado Academico</h1>
<br />
<asp:GridView ID="grdEstadoAcademico" runat="server">
</asp:GridView>
<br />
    <asp:Button ID="btnEstadoAcad" runat="server" Text="Emitir Estado Academico" OnClick="btnEstadoAcad_Click" Width="162px" />
</asp:Content>
