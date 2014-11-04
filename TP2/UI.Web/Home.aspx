<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Label ID="lblMsg" runat="server" Text="Ingrese sus datos para comenzar"></asp:Label>
    <br />
    <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblPass" runat="server" Text="Contraseña:"></asp:Label>
    <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Button ID="btnIniciarSesion" runat="server" OnClick="btnIniciarSesion_Click" Text="Iniciar Sesión" />
&nbsp;
</asp:Content>
