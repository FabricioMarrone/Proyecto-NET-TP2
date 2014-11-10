<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ElegirComision.aspx.cs" Inherits="UI.Web.ElegirComision" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Label ID="lblMateria" runat="server" Text="Materia"></asp:Label>
    <br />
    <asp:Label ID="lblMsg" runat="server" Text="Seleccione una comisión:"></asp:Label>
    <br />
    <asp:RadioButtonList ID="rblComisiones" runat="server" Width="125px"></asp:RadioButtonList>
    <br />
    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
</asp:Content>
