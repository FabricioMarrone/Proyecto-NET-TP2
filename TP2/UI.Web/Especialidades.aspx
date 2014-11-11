<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>

<%@ Register src="UserControls/LabelText.ascx" tagname="LabelText" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">


    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server">
        <table style="width: 50%;">
            <tr>
                <td style="height: 26px">
                    <asp:Label ID="Label1" runat="server" Text="Id Especialidad:"></asp:Label>
                </td>
                <td style="height: 26px">
                    <asp:TextBox ID="txtId" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="height: 26px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtId" ErrorMessage="El campo"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Especialidad:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEspecialidad" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revEspecialidad" runat="server" ControlToValidate="txtEspecialidad" ErrorMessage="El campo Especialidad es invalido."></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="3" id="ltMyControl">
                    <uc1:LabelText ID="LabelText1" runat="server" />
                    <br />
                    <asp:LinkButton ID="lbAceptar" runat="server" OnClick="lbAceptar_Click">Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbCancelar" runat="server" OnClick="lbCancelar_Click">Cancerlar</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>

