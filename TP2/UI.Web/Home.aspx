<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="UI.Web.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Label ID="lblMsg" runat="server" Text="Ingrese sus datos para comenzar"></asp:Label>
    <br />
    <asp:Panel ID="loginPanel" CssClass="mainPanel" runat="server">
        <table>
               <tr>
                   <td>
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label ID="lblPass" runat="server" Text="Contraseña:"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
                   </td>
               </tr>
                <tr>
                    <td colspan="2"> 
                        <asp:Button ID="btnIniciarSesion" runat="server" OnClick="btnIniciarSesion_Click" Text="Iniciar Sesión" />
                    </td>
                </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="messageLoginPanel" runat="server" Visible="false">
            <asp:Label ID="messageLogin" runat="server" ForeColor="Red" Font-Bold="true" Text="" ></asp:Label>
    </asp:Panel>


</asp:Content>
