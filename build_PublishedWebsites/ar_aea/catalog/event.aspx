<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="catalog_event, App_Web_n2n0cp2d" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <asp:Label runat="server" ID="lblErrorMessage" CssClass="error" />
    <br />
    <table style="width: 100%; border-collapse: collapse;" runat="server" id="contentsTable" class="mainBody">
        <tr valign="top">
            <td>
               
                <asp:ImageButton runat="server" ID="btnNewSearch" AlternateText="New Search" />&nbsp;&nbsp;&nbsp;<%# base.SharePageButton %></td>
            <td rowspan="2" >
                <br />
                <br />
                
        </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblTitle" CssClass="mainBodyBold" /><br />
                <asp:Label runat="server" ID="lblDescription" CssClass="mainBodySmall" /><br /><br /><br />
            </td>
        </tr>
        <tr><td colspan="2" style="border-bottom: solid 1px black"><%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralNameCapitalized %> scheduled for this <%# region4.escWeb.SiteVariables.ObjectProvider.EventName %>:<br /></td></tr>
        <tr><td colspan="2"><asp:Panel runat="server" ID="pSessionControls" /></td></tr>
       <tr><td colspan="2"><escWorks:SessionSummary runat="server" ID="s" TypeOfButton="ImageButton" /></td></tr> 
    </table>
        
</asp:Content>
