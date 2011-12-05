<%@ Page Language="C#" Title="ShowLog" MasterPageFile="~/Shared/SingleColumn.master" AutoEventWireup="true" CodeBehind="SubversionShowLog.aspx.cs" Inherits="BugNET.SvnBrowse.SubversionShowLog" %>

 <asp:Content ContentPlaceHolderID="PageTitle" runat="server" ID="content5">
 <asp:GridView ID="SvnLog" runat="server" 
    AutoGenerateColumns="False">
    <Columns>      
        <asp:BoundField DataField="Rev" 
            HeaderText="Rev" ReadOnly="True" />
        <asp:BoundField DataField="Log" 
            HeaderText="Message" InsertVisible="False"
            ReadOnly="True" />
        <asp:BoundField DataField="Date" 
            HeaderText="Date"  />
        <asp:BoundField DataField="User" 
            HeaderText="User" />      
    </Columns>
</asp:GridView>
  </asp:Content>
