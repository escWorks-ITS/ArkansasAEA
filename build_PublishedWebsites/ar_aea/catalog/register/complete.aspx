<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="catalog_register_complete, App_Web_agcss30h" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" Runat="Server">
<h1 class="heading">Thank you for your registration</h1>
<br />
You have been registered for:
<table runat="server" id="registrationTable" />
<br />
You may visit your <a href="~/shoebox/registration/default.aspx" runat="server" class="link">Registration History</a> to print a confirmation page for each <%# Resources.Names.Session %> for which you are registered.
<br /><br />
<asp:Panel runat="server" ID="panelPaymentVoucher">
If you are paying by check, money order, or purchase order please include the payment voucher with your payment.  You can download the payment voucher by clicking <a runat="server" id="aVoucher">here</a>
</asp:Panel>

</asp:Content>

