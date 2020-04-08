<%@ page language="C#" autoeventwireup="true" inherits="shoebox_registration_paymentVoucher, App_Web_e4buh4wl" title="Payment Voucher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
<head runat="server">
    <title>Payment Voucher</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:PlaceHolder ID ="printvoucher" runat="server"></asp:PlaceHolder>
         <asp:Panel runat="server" ID="pError" Visible="false">
       Unable to locate payment voucher
        <br />
        <br />
             </asp:Panel>
    </form>
</body>
</html>