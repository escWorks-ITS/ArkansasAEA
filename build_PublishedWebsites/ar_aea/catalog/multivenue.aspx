<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="catalog_multivenue, App_Web_n2n0cp2d" title="Multi-Venue Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <asp:Label runat="server" ID="txtTitle" CssClass="heading" />
    <br />
    <asp:Label runat="server" ID="txtDescription" Font-Italic="true" />
    <br />
    <escWorks:MultiVenueSessions runat="server" ID="sessionDisplay" />
</asp:Content>
