<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Inicio de sesión"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Usuario:"></asp:Label>
    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Contraseña:"></asp:Label>
    <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Button ID="btnIniciarSesion" runat="server" OnClick="btnIniciarSesion_Click" Text="Iniciar Sesión" />
&nbsp;
</asp:Content>
