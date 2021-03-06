<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="about_contact, App_Web_rhkafsqs" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <asp:Panel runat="server" ID="pStep1">
        <b>Category</b><br />
        <asp:DropDownList runat="server" ID="ddlCategory" CssClass="formInput" />
        <br />
        <br />
        <b>Enter your comments in the space provided below:</b>
        <br />
        <asp:TextBox runat="server" ID="txtComments" CssClass="formInput" TextMode="MultiLine"
            Height="99px" Width="282px" />
        <br />
        <br />
        <b>Please provide some information about yourself:</b><br />
        <br />
        <b>Name: </b>
        <asp:TextBox runat="server" ID="txtName" CssClass="formInput" />
        <br />
        <br />
        <b>E-mail: </b>
        <asp:TextBox runat="server" ID="txtEmail" CssClass="formInput" />
        <br />
        <br />
        <b>Telephone: </b>
        <asp:TextBox runat="server" ID="txtPhone" CssClass="formInput" />
        <br />
        <asp:CheckBox runat="server" ID="chkASAP" Text="Please contact me as soon as possible regarding this matter." />
        <br />
        <br />
        <div class="g-recaptcha" data-sitekey="6LeRZBETAAAAAKN3XmAIQW4yM6xh0icj4W6SOvsv">
        </div>
        <br />
        <br />
        <asp:Label runat="server" ID="lblError" CssClass="error" /><br />
        <br />
        <asp:Button runat="server" ID="btnSubmit" Text="Submit Comments" />
        <asp:Button runat="server" ID="btnCancel" Text="Cancel" /></asp:Panel>
    <asp:Panel runat="server" ID="pStep2">
        Thank you for your comments<br />
        <br />
        <a href="~/default.aspx" runat="server" class="link">Click here to continue</a>
    </asp:Panel>
</asp:Content>
