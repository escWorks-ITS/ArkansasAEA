<%@ page language="C#" autoeventwireup="true" inherits="evalmanager_session, App_Web_dibk41g3" masterpagefile="~/MasterPage.master" %>
<asp:Content runat="server" ContentPlaceHolderID="mainBody">
<h1 class="heading"><asp:Label runat="server" ID="lblTitle" /></h1>
    <br />
    <div style="width:100%; text-align:right"><a href="default.aspx" class="link">Return to Search</a></div>
    <asp:PlaceHolder runat="server" ID="pResultsTable" />
</asp:Content>