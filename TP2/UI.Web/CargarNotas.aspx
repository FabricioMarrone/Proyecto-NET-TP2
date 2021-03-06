﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargarNotas.aspx.cs" Inherits="UI.Web.CargarNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <h1 id="titulo">Cargar Notas</h1>
        <asp:Label ID="lblMsg" runat="server" Text="Seleccione uno de sus cursos:"></asp:Label>
    &nbsp;<asp:DropDownList ID="ddlCursos" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlCursos_SelectedIndexChanged" Width="276px">
        </asp:DropDownList>
        <br />
        <asp:Panel ID="GridPanel" runat="server">
            <asp:Label ID="lblMsg2" runat="server" Text="Ingrese notas y condiciones:"></asp:Label>
            <asp:GridView ID="grdAlumnos" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id_inscripcion" HeaderText="ID Inscripcion" ReadOnly="True" Visible="true" />
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
            <asp:Button ID="btnImprReporte" runat="server" OnClick="btnImprReporte_Click" Text="Emitir Reporte de Regularidades" Width="212px" />
        </asp:Panel>
        <br />
        <asp:Label ID="messageArea" runat="server" Visible="False" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>

</asp:Content>
