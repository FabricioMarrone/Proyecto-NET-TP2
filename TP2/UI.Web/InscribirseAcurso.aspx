<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscribirseAcurso.aspx.cs" Inherits="UI.Web.InscribirseAcurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h1 id="titulo">Inscripcion a Curso</h1>
    <asp:Label ID="lblMsg" runat="server" Text="Seleccione el curso en el que se desea inscribir:"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Materia:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlMaterias" runat="server" AutoPostBack="True" Height="17px" OnSelectedIndexChanged="ddlMaterias_SelectedIndexChanged" Width="129px">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Curso:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlCursos" runat="server" Height="21px" Width="250px">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Cargo:"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlCargos" runat="server" Height="16px" Width="117px">
    </asp:DropDownList>
    <br />
    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
    <br />
    <asp:Label ID="messageArea" runat="server" Text="" ForeColor="Red" Font-Bold="True"></asp:Label>

</asp:Content>
