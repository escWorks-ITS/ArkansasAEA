<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="catalog_calendar, App_Web_n2n0cp2d" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" Runat="Server">
<br />
<table width="100%" style="border-collapse: collapse;">
<%-- 
<tr>
<td colspan="2"><asp:Label runat="server" ID="lblCalendarTitle" /></td>
</tr>
<tr>
<td align="left"><asp:DropDownList runat="server" ID="ddlMonthList" /> <asp:DropDownList runat="server" ID="ddlYearList" /> <asp:ImageButton runat="server" ID="btnSetDate" AlternateText="Go" /></td>
<td align="right"><asp:ImageButton runat="server" ID="btnPrevious" AlternateText="Previous Month" /> <asp:ImageButton runat="server" ID="btnNext" AlternateText="Next Month" /></td>
</tr>
--%>
<tr>
<td colspan="2"><escWorks:Calendar runat="server" ID="cal1" PreviousText="&lt;&lt; Previous" NextText="Next &gt;&gt;" SetDateText="Go"  /></td>
</tr>
</table>

</asp:Content>

