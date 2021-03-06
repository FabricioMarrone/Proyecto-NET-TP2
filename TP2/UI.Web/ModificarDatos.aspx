﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarDatos.aspx.cs" Inherits="UI.Web.ModificarDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <h1 id="titulo">Modificar Datos Personales</h1>
    <table>
        <tr>
            <td style="height: 26px">
                <asp:Label ID="Label3" runat="server" Text="Legajo:"></asp:Label>
            </td>
            <td style="height: 26px">
                <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
            </td>
            <td style="height: 26px">
                <asp:RegularExpressionValidator ID="revLegajo" runat="server" ErrorMessage="El campo Legajo es Invalido" ControlToValidate="txtLegajo" Font-Bold="True" ForeColor="#CC0000" ></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revNombre" runat="server" ErrorMessage="El campo Nombre es Invalido" ControlToValidate="txtNombre" Font-Bold="True" ForeColor="#CC0000" ></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Apellido:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revApellido" runat="server" ErrorMessage="El campo Apellido es Invalido" ControlToValidate="txtApellido" Font-Bold="True" ForeColor="#CC0000" ></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Dirección:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revDireccion" runat="server" ErrorMessage="El campo Direccion es Invalido" ControlToValidate="txtDireccion" Font-Bold="True" ForeColor="#CC0000" ></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Email:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="El campo Email es Invalido" ControlToValidate="txtEmail" Font-Bold="True" ForeColor="#CC0000" ></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Teléfono:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ErrorMessage="El campo Telefono es Invalido" ControlToValidate="txtTelefono" Font-Bold="True" ForeColor="#CC0000" ></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Fecha nac.:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaNac" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RegularExpressionValidator ID="revFechaNac" runat="server" ErrorMessage="El campo Fecha de Nacimiento es Invalido" ControlToValidate="txtFechaNac" Font-Bold="True" ForeColor="#CC0000" ></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="height: 26px">
                <asp:Label ID="Label8" runat="server" Text="Tipo:"></asp:Label>
            </td>
            <td style="height: 26px">
                <asp:DropDownList ID="ddlTipo" runat="server"></asp:DropDownList>
            </td>
            <td style="height: 26px">
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Plan:"></asp:Label>
            </td>
            
            <td>
                <asp:DropDownList ID="ddlPlan" runat="server"></asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblOperationMessage" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
