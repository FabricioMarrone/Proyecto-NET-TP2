﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyTextBoxValidate.ascx.cs" Inherits="UI.Web.UserControls.MyTextBoxValidate" %>
<label><asp:TextBox ID="TextBox" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="" ControlToValidate="TextBox" Font-Bold="True" ForeColor="#CC0000"></asp:RegularExpressionValidator></label>