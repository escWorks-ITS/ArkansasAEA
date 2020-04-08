<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="catalog_browse, App_Web_n2n0cp2d" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" Runat="Server">
  <asp:Panel runat="server" ID="pFirst"> 
<em>Please choose the method you would like to use to browse our offerings.</em>  <br /><br />
  I would like to browse by:  <br />
    <asp:DropDownList ID="ddlType" runat="server" />
    <asp:DropDownList ID="ddlSort" runat="server" /><br /><asp:CheckBox runat="server" ID="displayWithSessions"/>
      <br /><br />
    <asp:ImageButton ID="btnSubmit" runat="server" AlternateText="Browse" />
    </asp:Panel>

 <asp:Panel runat="server" ID="pSummary" Visible="false">
<asp:ImageButton runat="server" ID="btnNewSearch" AlternateText="Previous" /> 
<table runat="server" id="tblResults" class="mainBody" />
 </asp:Panel> 
</asp:Content>

