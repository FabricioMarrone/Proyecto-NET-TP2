<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <h1>
        <asp:Label ID="lblTitle" runat="server" Text="Planes"></asp:Label>
    </h1>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gvListar" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gvListar_SelectedIndexChanged" DataKeyNames="Id_plan" >
            <Columns>
                <asp:BoundField HeaderText ="ID" DataField="Id_plan" />
                <asp:BoundField HeaderText ="Plan" DataField="Desc_plan" />
                <asp:BoundField HeaderText ="Especialidad" DataField="especialidad" />
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
        <table style="width: 50%;">
            <tr>
                <td style="height: 26px">
                    <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="IdPlanTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="height: 26px">
                </td>
            </tr>
            <tr>
                <td style="height: 26px">
                    <asp:Label ID="Label2" runat="server" Text="Plan:"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="PlanTextBox" runat="server"></asp:TextBox>
                </td>
                <td style="height: 26px">
                    <asp:RegularExpressionValidator ID="revPlan" ControlToValidate="PlanTextBox" runat="server" ErrorMessage="El campo Plan es Invalido." Font-Bold="True" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 26px">
                    <asp:Label ID="Label3" runat="server" Text="Especialidad"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:DropDownList ID="ddlEspecialidad" runat="server"></asp:DropDownList>
                </td>
                <td style="height: 26px">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="formActionsPanel" runat="server">
                        <asp:LinkButton ID="AceptarLinkButton" runat="server" OnClick="AceptarLinkButton_Click">Aceptar</asp:LinkButton>
                        <asp:LinkButton ID="CancelarLinkButton" runat="server" OnClick="CancelarLinkButton_Click">Cancerlar</asp:LinkButton>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="messageArea" runat="server" Text=""></asp:Label>
</asp:Content>
