<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <h1 id="titulo">Materia</h1>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gvListar" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gvListar_SelectedIndexChanged" DataKeyNames="Id_materia" >
            <Columns>
                <asp:BoundField HeaderText ="ID" DataField="Id_materia" />
                <asp:BoundField HeaderText ="Materia" DataField="Desc_materia" />
                <asp:BoundField HeaderText ="Hs Semanales" DataField="Hs_semanales" />
                <asp:BoundField HeaderText ="Hs Anuales" DataField="Hs_totales" />
                <asp:BoundField HeaderText ="Plan" DataField="Plan" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="NuevoLinkButton" runat="server" OnClick="NuevoLinkButton_Click1">Nuevo</asp:LinkButton>
            <asp:LinkButton ID="EditarLinkButton" runat="server" OnClick="EditarLinkButton_Click1">Editar</asp:LinkButton>
            <asp:LinkButton ID="EliminarLinkButton" runat="server" OnClick="EliminarLinkButton_Click1">Eliminar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <table style="width: 60%;">
            <tr>
                <td style="height: 26px; width: 94px;">
                    <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="IdMateriaTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="height: 26px">
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 94px;">
                    <asp:Label ID="Label2" runat="server" Text="Descripcion:"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="DescripcionTextBox" runat="server"></asp:TextBox>
                </td>
                <td style="height: 26px">
                    <asp:RegularExpressionValidator ID="revDescripcion" ControlToValidate="DescripcionTextBox" runat="server" ErrorMessage="El campo Descripcion es Invalido." Font-Bold="True" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 94px;">
                    <asp:Label ID="Label5" runat="server" Text="Hs Semanales:"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtHsSemanales" runat="server"></asp:TextBox>
                </td>
                <td style="height: 26px">
                    <asp:RegularExpressionValidator ID="revHsSemanales" runat="server" ControlToValidate="txtHsSemanales" ErrorMessage="El campo Hs Semanales es invalido." Font-Bold="True" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 94px;">
                    <asp:Label ID="Label6" runat="server" Text="Hs Totales:"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtHsTotales" runat="server"></asp:TextBox>
                </td>
                <td style="height: 26px">
                    <asp:RegularExpressionValidator ID="revHsTotales" ControlToValidate="txtHsTotales" runat="server" ErrorMessage="El campo Hs Totales es invalido." Font-Bold="True" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 94px;">
                    <asp:Label ID="Label3" runat="server" Text="Especialidad"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                </td>
                <td style="height: 26px">
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 94px;">
                    <asp:Label ID="Label4" runat="server" Text="Plan"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:DropDownList ID="ddlPlan" runat="server"></asp:DropDownList>
                </td>
                <td style="height: 26px">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="formActionsPanel" runat="server">
                        <asp:LinkButton ID="AceptarLinkButton" runat="server" OnClick="AceptarLinkButton_Click">Aceptar</asp:LinkButton>
                        <asp:LinkButton ID="CancelarLinkButton" runat="server" OnClick="CancelarLinkButton_Click" CausesValidation="False">Cancerlar</asp:LinkButton>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="messageArea" runat="server" Text=""></asp:Label>
</asp:Content>

