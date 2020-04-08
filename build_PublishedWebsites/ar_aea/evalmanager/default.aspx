<%@ page language="C#" autoeventwireup="true" inherits="evalmanager_default, App_Web_dibk41g3" masterpagefile="~/MasterPage.master" %>
<asp:Content runat="server"  ContentPlaceHolderID="mainBody">

    <asp:Label ID="SessionIdLabel"
text=<%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %>
AssociatedControlID="txtSessionID"
runat="server"></asp:Label> ID: 

<asp:TextBox runat="server" ID="txtSessionID" />&nbsp;&nbsp;<asp:Button runat="server" ID="btnFind" Text="Search" />
<br /><br />
<asp:PlaceHolder runat="server" ID="pResults" />

</asp:Content>

