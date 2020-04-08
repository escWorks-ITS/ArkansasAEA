<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="confirmuserprofile.aspx.cs" Inherits="catalog_register_confirmuserprofile"
    EnableEventValidation="false" Title="Confirm User Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <br />
    <br />
    <asp:Label runat="server" ID="lblErrorMessage" CssClass="error" />
    <br />
    <asp:Label ID="labelPleaseVerify" runat="server"><strong><big>Please help us verify your information to ensure you receive proper credit for your professional development. 
        </big></strong></asp:Label><br />
    <br />
    <br />
    <table width="75%" class="mainBody">
        <tr>
            <td colspan="3" valign="top">
                <strong>
                    <%# region4.escWeb.SiteVariables.ObjectProvider.OrganizationNameCapitalized %>
                </strong>(Select Region 4 ESC if you do not know your region.)
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:DropDownList ID="ddlRegion" runat="server" CssClass="formInput" />
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRegion"
                    CssClass="error" ErrorMessage="Region is a required field"></asp:RequiredFieldValidator>
                <cc1:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="ddlRegion"
                    Category="Org" PromptText="Please select a region..." ServicePath="~/services/locationservice.asmx"
                    ServiceMethod="GetRegions" />
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <strong>
                    <%# region4.escWeb.SiteVariables.ObjectProvider.SiteNameCapitalized %>
                </strong>(Select Other Organizations if you do not know your District.)
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="formInput" />
                <br />
                <br />
                <cc1:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlDistrict"
                    ParentControlID="ddlRegion" PromptText="Please select a district..." ServicePath="~/services/locationservice.asmx"
                    ServiceMethod="GetDistrictsForRegion" Category="Site" />
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <strong>
                    <%# region4.escWeb.SiteVariables.ObjectProvider.SchoolNameCapitalized %>
                </strong>(Select Other Organizations if you do not know your Campus.)
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:DropDownList ID="ddlSchool" runat="server" CssClass="formInput" />
                <br />
                <br />
                <cc1:CascadingDropDown ID="CascadingDropDown3" runat="server" TargetControlID="ddlSchool"
                    ParentControlID="ddlDistrict" PromptText="Please select a campus..." ServicePath="~/services/locationservice.asmx"
                    ServiceMethod="GetSchoolsFromDistricts" Category="Room" />
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <strong>Position:</strong>
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:DropDownList ID="ddlPosition" runat="server" CssClass="formInput">
                </asp:DropDownList>
                <br />
            </td>
        </tr>
             <tr>
                <td  colspan="3" valign="top">
                    <strong>Required Accommodations:</strong>
                </td>
            </tr>
             <tr>
                <td style="height: 45px" valign="top" colspan="3">
                    <asp:TextBox ID="txtSpecialNeeds" runat="server" CssClass="formInput" Width="510px"/><br />
                </td>
            </tr>
        <tr>
            <td colspan="3" valign="top">
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <asp:CheckBox runat="server" ID="checkboxCertify" AutoPostBack="True" Text="I certify the above information to be accurate"
                    OnCheckedChanged="OnCheckedChanged" />
            </td>
        </tr>
        <tr>
            <td colspan="3" valign="top">
                <br />
                <br />
            </td>
        </tr>
    </table>
    <asp:Button runat="server" ID="btnSaveUserProfile" Text="Continue" OnClick="btnSaveUserProfileClick"
        Visible="false" />
</asp:Content>
