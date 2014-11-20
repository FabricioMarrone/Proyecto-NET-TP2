<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>

<%@ Register src="UserControls/MyTextBoxValidate.ascx" tagname="MyTextBoxValidate" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <h1 id="titulo">Personas</h1>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gvListar" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gvListar_SelectedIndexChanged" DataKeyNames="Id_persona" >
            <Columns>
                <asp:BoundField HeaderText ="ID" DataField="Id_persona" />
                <asp:BoundField HeaderText ="Legajo" DataField="Legajo" />
                <asp:BoundField HeaderText ="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText ="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText ="Direccion" DataField="Direccion" />
                <asp:BoundField HeaderText ="E-mail" DataField="Email" />
                <asp:BoundField HeaderText ="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText ="Fecha Nacimiento" DataField="Fecha_nac" DataFormatString="{0:d}" />
                <asp:BoundField HeaderText ="Plan" DataField="Plan" />
                <asp:BoundField HeaderText ="Persona Tipo" DataField="Tipo_persona" />

                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true"/>
            </Columns>
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
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
                <td style="width: 119px;">
                    <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="IdPersonaTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 119px;">
                    <asp:Label ID="Label2" runat="server" Text="Legajo:"></asp:Label>
                </td>
                <td colspan="2">
                    <uc1:MyTextBoxValidate ID="mtvLegajo" runat="server" ErrorMessage="El campo Legajo es invalido" />
                </td>
            </tr>
            <tr>
                <td style="width: 119px;">
                    <asp:Label ID="Label4" runat="server" Text="Apellido:"></asp:Label>
                </td>
                <td colspan="2">
                    <uc1:MyTextBoxValidate ID="mtvApellido" runat="server" ErrorMessage="El campo Apellido es invalido" />
                </td>
            </tr>
            <tr>
                <td style="width: 119px;">
                    <asp:Label ID="Label5" runat="server" Text="Nombre:"></asp:Label>
                </td>
                <td colspan="2">
                    <uc1:MyTextBoxValidate ID="mtvNombre" runat="server" ErrorMessage="El campo Nombre es invalido" />
                </td>
            </tr>
            <tr>
                <td style="width: 119px;">
                    <asp:Label ID="Label6" runat="server" Text="Direccion:"></asp:Label>
                </td>
                <td colspan="2">
                    <uc1:MyTextBoxValidate ID="mtvDireccion" runat="server" ErrorMessage="El campo Direccion es invalido" />
                </td>
            </tr>
            <tr>
                <td style="width: 119px;">
                    <asp:Label ID="Label7" runat="server" Text="E-mail:"></asp:Label>
                </td>
                <td colspan="2">
                    <uc1:MyTextBoxValidate ID="mtvEmail" runat="server" ErrorMessage="El campo E-Mail es invalido" />
                </td>
            </tr>
            <tr>
                <td style="width: 119px;">
                    <asp:Label ID="Label8" runat="server" Text="Fecha Nacimiento:"></asp:Label>
                </td>
                <td colspan="2">
                    <uc1:MyTextBoxValidate ID="mtvFechaNac" runat="server" ErrorMessage="El campo Fecha Nacimiento es invalido" />
                </td>
            </tr>
            <tr>
                <td style="width: 119px;">
                    <asp:Label ID="Label10" runat="server" Text="Tipo Persona:"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlTipoPersona" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 119px;">
                    <asp:Label ID="Label3" runat="server" Text="Especialidad"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 119px;">
                    <asp:Label ID="Label15" runat="server" Text="Plan"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPlan" runat="server"></asp:DropDownList>
                </td>
                <td>
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
