<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SingleColumn.master" AutoEventWireup="true" CodeBehind="SubversionChangeDetail.aspx.cs" Inherits="BugNET.SvnBrowse.SubversionChangeDetail" UICulture="auto" %>

<%@ Register Assembly="BugNET" Namespace="BugNET.UserInterfaceLayer" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div >     
        <asp:DetailsView ID="ChangeView" runat="server" AutoGenerateRows="False" 
            Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <AlternatingRowStyle BackColor="White" />    
            <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
            <EditRowStyle BackColor="#7C6F57" />
            <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
        <Fields>
              <asp:BoundField DataField="Rev" HeaderText="Rev" ReadOnly="True" />
              <asp:BoundField DataField="User" HeaderText="User"   ReadOnly="True" />
              <asp:BoundField DataField="Date" HeaderText="Date"  ReadOnly="True" />
             <asp:TemplateField HeaderText="Log">                       
              <ItemTemplate>
             <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" BorderWidth="0px" Text='<%# Bind("Log") %>' ReadOnly="true" BorderStyle="None"></asp:TextBox>
              </ItemTemplate>
              <ControlStyle Height="50px" Width="100%" />
              <ItemStyle Wrap="True" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Change">                       
              <ItemTemplate>
             <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" BorderWidth="0px" Text='<%# Bind("Change") %>' ReadOnly="true" BorderStyle="None"></asp:TextBox>
              </ItemTemplate>
              <ControlStyle Height="250px" Width="100%" />
              <ItemStyle Wrap="True" />
              </asp:TemplateField>
            </Fields>

        </asp:DetailsView>
        
   </div> 
</asp:Content>
