<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<%@ Register Src="~/UserControls/MyTextBoxValidate.ascx" TagPrefix="uc1" TagName="MyTextBoxValidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h1>
        <asp:Label ID="lblTitle" runat="server" Text="Cursos"></asp:Label>
    </h1>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gvListar" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gvListar_SelectedIndexChanged" DataKeyNames="ID_CURSO" >
            <Columns>
                <asp:BoundField HeaderText ="ID" DataField="ID_CURSO" />
                <asp:BoundField HeaderText ="Materia" DataField="Materia" />
                <asp:BoundField HeaderText ="Comision" DataField="Comision" />
                <asp:BoundField HeaderText ="Año Calendario" DataField="Anio_calendario" />
                <asp:BoundField HeaderText ="Cupo" DataField="Cupo" />
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
                    <asp:Label ID="Label2" runat="server" Text="Materia:"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlMateria" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 136px;">
                    <asp:Label ID="Label3" runat="server" Text="Comision:"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:DropDownList ID="ddlComision" runat="server" ></asp:DropDownList>
                </td>
                <td style="height: 26px">
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 136px;">
                    <asp:Label ID="Label5" runat="server" Text="Año Calendario:"></asp:Label>
                </td>
                <td colspan="2">
                    <uc1:MyTextBoxValidate runat="server" id="mtvAnioCalendario" ErrorMessage="El campo Año Calendario es invalido." />
                </td>
            </tr>
            <tr>
                <td style="height: 26px; width: 136px;">
                    <asp:Label ID="Label6" runat="server" Text="Cupo:"></asp:Label>
                </td>
                <td colspan="2">
                    <uc1:MyTextBoxValidate runat="server" ID="mtvCupo" ErrorMessage="El campo Cupo es invalido." />
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


