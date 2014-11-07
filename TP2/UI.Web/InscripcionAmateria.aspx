<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscripcionAmateria.aspx.cs" Inherits="UI.Web.InscripcionAmateria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Label ID="lblMsg" runat="server" Text="Seleccione la materia en la que se desea inscribir:"></asp:Label>
    <br />
    <asp:GridView ID="grdMateriass" runat="server" AutoGenerateColumns="False" OnRowCommand="grdMateriass_RowCommand">
        <Columns>
            <asp:BoundField DataField="id_materia" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="desc_materia" HeaderText="Nombre materia" ReadOnly="True" />
            <asp:BoundField DataField="hs_semanales" HeaderText="Horas semanales" ReadOnly="True" />
            <asp:ButtonField HeaderText="Inscripción" CommandName="Inscribirme" Text="Inscribirme" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <br />
</asp:Content>
