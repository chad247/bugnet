<%@ Page Language="C#" MasterPageFile="~/Shared/SingleColumn.master" AutoEventWireup="true" Inherits="BugNET.Errors.Error" Title="<%$ Resources:ApplicationError %>" Codebehind="Error.aspx.cs" UICulture="auto" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <h1><asp:literal ID="litTitle" runat="server" Text="<%$ Resources:ApplicationError %>"></asp:literal> - <%=Request.QueryString["aspxerrorpath"]%></h1>
    <p style="margin-top:1em"><asp:Label id="Label1" runat="server" Text="<%$ Resources:Message %>" /></p> 
    <p style="margin-top:1em"><asp:Label id="Label2" runat="server" /></p>
</asp:Content>


