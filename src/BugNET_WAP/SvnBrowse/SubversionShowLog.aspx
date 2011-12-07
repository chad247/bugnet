<%@ Page Language="C#" Title="ShowLog" MasterPageFile="~/Shared/SingleColumn.master" AutoEventWireup="true" CodeBehind="SubversionShowLog.aspx.cs" Inherits="BugNET.SvnBrowse.SubversionShowLog" UICulture="auto" %>

 <asp:Content ContentPlaceHolderID="PageTitle" runat="server" ID="content5">
 
  </asp:Content>

  <asp:Content ContentPlaceHolderID="Content" runat="server" ID="content1">
<div>
      <asp:GridView ID="SvnLog" runat="server"
    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" 
           >
          <AlternatingRowStyle BackColor="White" />
    
    <Columns>    
        <asp:HyperLinkField  
            HeaderText="Rev" DataTextField="rev" DataNavigateUrlFields="pid,rev" 
            
            DataNavigateUrlFormatString="~/SvnBrowse/SubversionChangeDetail.aspx?pid={0}&id={1}"  >
        <ControlStyle Width="100px" />
        <HeaderStyle Width="100px" />
        </asp:HyperLinkField>
        <asp:TemplateField HeaderText="Message" InsertVisible="False">
            <ItemTemplate>           
            <a href =' <%# String.Format("./SubversionChangeDetail.aspx?pid={0}&id={1}",ProjectId,DataBinder.Eval(Container.DataItem,"rev")) %>' target="_self"> 
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Log") %>'> </asp:Label>
                </a> 
            </ItemTemplate>              
            <ControlStyle Width="800px" />
            <HeaderStyle Width="800px" />
        </asp:TemplateField>
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
</div>
</asp:Content>

