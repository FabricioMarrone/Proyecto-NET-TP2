<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>

<%@ Register src="UserControls/LabelText.ascx" tagname="LabelText" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h1 id="titulo">Especialidades</h1>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gvEspecialidades" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="id_especialidad" OnSelectedIndexChanged="gvEspecialidades_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="id_especialidad" />
                <asp:BoundField HeaderText="Especialidad" DataField="desc_especialidad" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="NuevoLinkButton" runat="server" OnClick="NuevoLinkButton_Click">Nuevo</asp:LinkButton>
            <asp:LinkButton ID="EditarLinkButton" runat="server" OnClick="EditarLinkButton_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="EliminarLinkButton" runat="server" OnClick="EliminarLinkButton_Click">Eliminar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <table style="width: 50%;">
            <tr>
                <td style="height: 26px">
                    <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtId" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="height: 26px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Especialidad:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEspecialidad" runat="server" TabIndex="1"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revEspecialidad" runat="server" ControlToValidate="txtEspecialidad" ErrorMessage="El campo Especialidad es invalido." ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="formActionsPanel" runat="server">
                        <asp:LinkButton ID="AceptarLinkButton" runat="server" OnClick="lbAceptar_Click">Aceptar</asp:LinkButton>
                        <asp:LinkButton ID="CancelarLinkButton" runat="server" OnClick="lbCancelar_Click" CausesValidation="False">Cancerlar</asp:LinkButton>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="messageArea" runat="server" Text=""></asp:Label>

</asp:Content>

