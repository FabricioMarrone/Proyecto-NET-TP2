<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    
    <h1 id="titulo">Usuarios</h1>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="id_usuario" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="apellido" />
                <asp:BoundField HeaderText="EMail" DataField="email" />
                <asp:BoundField HeaderText="Usuario" DataField="nombre_usuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
    </asp:Panel>

    <br />
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    </asp:Panel>

    <br />
    <asp:Panel ID="formPanel" Visible="false" runat="server">        
        <table style="width: 50%;">
            <tr>
                <td>
                    <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revNombre" runat="server" ErrorMessage="El campo Nombre es Invalido" ControlToValidate="nombreTextBox" Font-Bold="True" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revApellido" runat="server" ErrorMessage="El campo Apellido es Invalido" ControlToValidate="apellidoTextBox" Font-Bold="True" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="El campo Email es Invalido" ControlToValidate="emailTextBox" Font-Bold="True" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
                </td>
                <td colspan="2">
                    <asp:CheckBox ID="habilitadoCheckBox" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revNombUsuario" runat="server" ErrorMessage="El campo Nombre Usuario es Invalido" ControlToValidate="nombreUsuarioTextBox" Font-Bold="True" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="claveTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revClave" runat="server" ErrorMessage="El campo Clave es Invalido" ControlToValidate="claveTextBox" Font-Bold="True" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir clave: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="repetirClaveTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator ID="CompareValidatorClave" runat="server" ControlToCompare="repetirClaveTextBox" ControlToValidate="claveTextBox" EnableClientScript="False" ErrorMessage="Las contraseñas no son iguales">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:ValidationSummary ID="ValidationSummary" runat="server" EnableClientScript="False" />
    </asp:Panel>

</asp:Content>
