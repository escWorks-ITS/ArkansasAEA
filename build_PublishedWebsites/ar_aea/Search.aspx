<%@ page language="C#" autoeventwireup="true" enableviewstate="false" masterpagefile="MasterPage.master" inherits="tx_esc_r4.Catalog.Search, App_Web_zgleeu25" %>

<%@ Register src="lib/Controls/Search.ascx" tagname="Search" tagprefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="ContentContainer" ContentPlaceHolderID="mainBody" Runat="Server">
    <table border="0" cellpadding="4" cellspacing="0" width="100%"> 
        <tr>
            <td>
                <uc1:Search ID="Search1" runat="server"/>
            </td>
        </tr>
    </table>
</asp:Content>
