<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>

<%@ Register Src="~/UserControls/MyTextBoxValidate.ascx" TagPrefix="uc1" TagName="MyTextBoxValidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h1>
        <asp:Label ID="lblTitle" runat="server" Text="Comisiones"></asp:Label>
    </h1>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gvListar" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gvListar_SelectedIndexChanged" DataKeyNames="Id_comision" >
            <Columns>
                <asp:BoundField HeaderText ="ID" DataField="Id_comision" />
                <asp:BoundField HeaderText ="Comision" DataField="Desc_comision" />
                <asp:BoundField HeaderText ="Año Especialidad" DataField="Anio_especialidad" />
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
        <table style="width: 100%;">
            <tr>
                <td style="height: 26px; width: 136px;">
                    <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="IdCursoTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="height: 26px">
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 136px;">
                    <asp:Label ID="Label2" runat="server" Text="Comision:"></asp:Label>
                </td>
                <td colspan="2">
                    <uc1:MyTextBoxValidate runat="server" id="mtvComision" ErrorMessage="El campo Comison es invalido." />
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 136px;">
                    <asp:Label ID="Label5" runat="server" Text="Año Especialidad:"></asp:Label>
                </td>
                <td colspan="2">
                    <uc1:MyTextBoxValidate runat="server" id="mtvAnioEspecialidad" ErrorMessage="El campo Año Especialidad es invalido." />
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 136px;">
                    <asp:Label ID="Label3" runat="server" Text="Especialidad"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                </td>
                <td style="height: 26px">
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 136px;">
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
                        <asp:LinkButton ID="CancelarLinkButton" runat="server" OnClick="CancelarLinkButton_Click">Cancerlar</asp:LinkButton>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="messageArea" runat="server" Text=""></asp:Label>
</asp:Content>

