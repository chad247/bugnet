<%@ Page Language="C#" Title="ShowLog" MasterPageFile="~/Shared/SingleColumn.master" AutoEventWireup="true" CodeBehind="SubversionShowLog.aspx.cs" Inherits="BugNET.SvnBrowse.SubversionShowLog" UICulture="auto" %>

 <asp:Content ContentPlaceHolderID="PageTitle" runat="server" ID="content5">
 
  </asp:Content>

  <asp:Content ContentPlaceHolderID="Content" runat="server" ID="content1">
      <asp:GridView ID="SvnLog" runat="server" 
    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
          <AlternatingRowStyle BackColor="White" />
    <Columns>     
        <asp:HyperLinkField  
            HeaderText="Rev" DataTextField="rev" DataNavigateUrlFields="rev" 
            DataNavigateUrlFormatString="~/SvnBrowse/SubversionChangeDetail.aspx?id={0}"  >
        <ControlStyle Width="100px" />
        <HeaderStyle Width="100px" />
        </asp:HyperLinkField>
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
          <EditRowStyle BackColor="#7C6F57" />
          <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
          <RowStyle BackColor="#E3EAEB" />
          <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
          <SortedAscendingCellStyle BackColor="#F8FAFA" />
          <SortedAscendingHeaderStyle BackColor="#246B61" />
          <SortedDescendingCellStyle BackColor="#D4DFE1" />
          <SortedDescendingHeaderStyle BackColor="#15524A" />
</asp:GridView>
</asp:Content>

