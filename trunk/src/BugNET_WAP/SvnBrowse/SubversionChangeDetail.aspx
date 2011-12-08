<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SingleColumn.master" AutoEventWireup="true" CodeBehind="SubversionChangeDetail.aspx.cs" Inherits="BugNET.SvnBrowse.SubversionChangeDetail" UICulture="auto" %>

<%@ Register Assembly="BugNET" Namespace="BugNET.UserInterfaceLayer" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div >     
        <asp:DetailsView ID="ChangeView" runat="server" AutoGenerateRows="False" 
            Width="100%" CellPadding="3" GridLines="Horizontal" BackColor="White" 
            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" ForeColor="#F7F7F7" Font-Bold="True" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <AlternatingRowStyle BackColor="#F7F7F7" />    
            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <Fields>
              <asp:BoundField DataField="Rev" HeaderText="Rev" ReadOnly="True" HeaderStyle-Width="80" />
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
