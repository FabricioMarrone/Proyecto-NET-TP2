<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.Web.EstadoAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Label ID="lblEstadoAcademico" runat="server" Text="Estado académico"></asp:Label>
<br />
<br />
<asp:GridView ID="grdEstadoAcademico" runat="server">
</asp:GridView>
<br />
    <asp:Button ID="btnEstadoAcad" runat="server" Text="Emitir Estado Academico" OnClick="btnEstadoAcad_Click" Width="162px" />
</asp:Content>
