<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargarNotas.aspx.cs" Inherits="UI.Web.CargarNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Label ID="lblMsg" runat="server" Text="Seleccione uno de sus cursos:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlCursos" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlCursos_SelectedIndexChanged" Width="276px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblMsg2" runat="server" Text="Ingrese notas y condiciones:"></asp:Label>
    <br />
    <asp:GridView ID="grdAlumnos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id_inscripcion" HeaderText="ID inscripcion" ReadOnly="True" Visible="true" />
            <asp:BoundField DataField="Legajo" HeaderText="Legajo" ReadOnly="True" />
            <asp:BoundField DataField="Alumno" HeaderText="Alumno" ReadOnly="True" />
            <asp:TemplateField HeaderText="Condicion">
                <ItemTemplate>
                     <asp:DropDownList ID="ddlCondicion" runat="server"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nota">
                <ItemTemplate>
                     <asp:DropDownList ID="ddlNota" runat="server"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
    <br />
</asp:Content>
