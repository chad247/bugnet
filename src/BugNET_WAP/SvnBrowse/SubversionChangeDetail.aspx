<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SingleColumn.master" AutoEventWireup="true" CodeBehind="SubversionChangeDetail.aspx.cs" Inherits="BugNET.SvnBrowse.SubversionChangeDetail" %>

<%@ Register Assembly="BugNET" Namespace="BugNET.UserInterfaceLayer" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    
<div id="DivTabs1" 
        style="border-left: 1px solid #3183C6; border-right: 1px solid #3183C6; border-top: 1px none #3183C6; border-bottom: 1px solid #3183C6; height:319px; background-color: White;"  
        align="left">    
   <table style="width: 100%; height: 100%" > 
   <tr>
     <td style="height:5px;" colspan="4"></td>   
   </tr>
   <tr >
   <td style="height: 100%; width:30%" valign="top"  >
   <table>
   <tr>
   <td style="width: 20%;" >  
       <asp:Label ID="Label2" runat="server" Style="text-align: left;"  Text="User" />
         
      </td>
      <td>
      <asp:Label ID="User" runat="server" Style="text-align: left;" Text="UserName" />
      </td>
      </tr>
      <tr>
      <td>
        <asp:Label ID="Label3" runat="server" Style="text-align: left;"  Text="Date" />
      </td>
      <td>
       <asp:Label ID="Date" runat="server" Style="text-align: left;"  Text="DateText" />
      </td>
      </tr>
      </table> 
   </td>       
   <td valign="top"> 
   <div>
    <table style="width:100%;">
      <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Log Message" Font-Bold="True"></asp:Label>
        </td>
       </tr>
      <tr>
        <td style="height:30px">
            <asp:Label ID="Log" runat="server" Text="Log Message" ></asp:Label>
        </td>
       </tr>
      <tr>
        <td>
             <asp:Label ID="Label4" runat="server" Text="Affected files" Font-Bold="True"></asp:Label>
        </td>
       </tr>
       <tr>
        <td style="height:150px" valign="top">
            <asp:Label ID="Change" runat="server" Text="Modified Files" ></asp:Label>
        </td>
       </tr>
    </table>   
    </div>
   </td>
   </tr>
   
   </table>    
    </div>
</asp:Content>
