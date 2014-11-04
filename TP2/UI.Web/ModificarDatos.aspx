<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarDatos.aspx.cs" Inherits="UI.Web.ModificarDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Label ID="Label3" runat="server" Text="Legajo:"></asp:Label>
    <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Apellido:"></asp:Label>
    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Dirección:"></asp:Label>
    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Teléfono:"></asp:Label>
    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Fecha nac.:"></asp:Label>
    <asp:TextBox ID="txtFechaNac" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Tipo:"></asp:Label>
    <asp:DropDownList ID="ddlTipo" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Plan:"></asp:Label>
    <asp:DropDownList ID="ddlPlan" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
    <br />
</asp:Content>
