<%@ Page Language="C#" Title="ShowLog" MasterPageFile="~/Shared/SingleColumn.master" AutoEventWireup="true" CodeBehind="SubversionShowLog.aspx.cs" Inherits="BugNET.SvnBrowse.SubversionShowLog" %>

 <asp:Content ContentPlaceHolderID="PageTitle" runat="server" ID="content5">
 
  </asp:Content>

  <asp:Content ContentPlaceHolderID="Content" runat="server" ID="content1">
      <asp:GridView ID="SvnLog" runat="server" 
    AutoGenerateColumns="False">
    <Columns>      
        <asp:BoundField DataField="Rev"  
            HeaderText="Rev" ReadOnly="True" >
        <ControlStyle Width="100px" />
        <HeaderStyle Width="100px" />
        </asp:BoundField>
        <asp:BoundField DataField="Log" 
            HeaderText="Message" InsertVisible="False"
            ReadOnly="True" > 
         <ControlStyle Width="1200px" />
        <HeaderStyle Width="1200px" />
            </asp:BoundField>
        <asp:BoundField DataField="Date" 
            HeaderText="Date"  >
            <ControlStyle Width="100px" />
        <HeaderStyle Width="100px" />
            </asp:BoundField>
        <asp:BoundField DataField="User" 
            HeaderText="User" >    
            <ControlStyle Width="100px" />
        <HeaderStyle Width="100px" />
            </asp:BoundField>  
    </Columns>
</asp:GridView>
</asp:Content>

