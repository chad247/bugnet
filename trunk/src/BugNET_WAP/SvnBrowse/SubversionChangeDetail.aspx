<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SingleColumn.master" AutoEventWireup="true" CodeBehind="SubversionChangeDetail.aspx.cs" Inherits="BugNET.SvnBrowse.SubversionChangeDetail" %>

<%@ Register Assembly="BugNET" Namespace="BugNET.UserInterfaceLayer" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    
     
        <asp:DetailsView ID="ChangeView" runat="server" AutoGenerateRows="false" >
        <HeaderStyle BackColor="Navy" ForeColor="White" />
            <RowStyle BackColor="White" />
            <AlternatingRowStyle BackColor="LightGray" />
            <EditRowStyle BackColor="LightCyan" />

        <Fields>
              <asp:BoundField DataField="Rev" HeaderText="Rev" ReadOnly="True" />
              <asp:BoundField DataField="User" HeaderText="User"   ReadOnly="True" />
              <asp:BoundField DataField="Date" HeaderText="Date"  ReadOnly="True" />
              <asp:BoundField DataField="Log" HeaderText="Log"  ReadOnly="True" ItemStyle-VerticalAlign="Top" />
              <asp:BoundField DataField="Change" HeaderText="Change" ReadOnly="True"  ItemStyle-VerticalAlign="Top" ItemStyle-Height="50px"/>              
            </Fields>

        </asp:DetailsView>
        
    
</asp:Content>
