<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="catalog_conference, App_Web_n2n0cp2d" title="Untitled Page" validaterequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" Runat="Server">
<asp:Label runat="server" ID="txtTitle" CssClass="heading" />
<br />
<asp:Label runat="server" ID="txtDescription" Font-Italic="true" />
<br />
<escWorks:ConferenceSelection runat="server" ID="sessionDisplay" CollapseBreakoutByDefault="false" />
</asp:Content>

