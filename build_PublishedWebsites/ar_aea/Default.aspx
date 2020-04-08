<%@ page language="C#" autoeventwireup="true" inherits="_Default, App_Web_zgleeu25" masterpagefile="~/MasterPage.master" %>

<%@ Register TagPrefix="ucontrol" TagName="UploadFile" Src="~/lib/Controls/UploadFile.ascx" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="mainBody">
     <script language="javascript" type="text/javascript">
        if (typeof String.prototype.trim != 'function') { // detect native implementation
            String.prototype.trim = function () {
                return this.replace(/^\s+/, '').replace(/\s+$/, '');
            };
        }

        function FindSession() {
            var mSession = document.aspnetForm.findSession.value.trim();

            if (mSession.length < 1) {
                alert("Please type " + '<%# region4.escWeb.SiteVariables.ObjectProvider.SessionName %>' + " ID or Keyword");
                document.aspnetForm.findSession.focus();
                return;
            }
            if (isNaN(mSession))
                top.location.href = "search.aspx?SearchCriteria=" + mSession;
            else
                top.location.href = "./catalog/session.aspx?session_id=" + mSession;
        }
    </script>
    <div id="pageheader">
        <h1><span class="pageheadertxt">Welcome to Professional Development Online Registration</span></h1>
    </div>
    <div style="float: right; width: 784px; margin-bottom: 5px;">
        <div id="searchbox">
            <asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">
                <h2>
                   <label for="findSession">Search by Session ID or Keyword     </label>
                </h2>
                <input type="text" id="findSession"  />

                <asp:Button runat="server" ID="btnSearch" OnClientClick="FindSession();return false;"
                    Text="submit" />
                <br />
            </asp:Panel>
        </div>
    </div>
    <div style="float: right; width: 784px; border: 1px solid #999;">
        <table border="0" cellpadding="0" cellspacing="0" style="background-color: #e5e5e5;">
            <tr>
                <td width="70%">
                    <table border="0" cellpadding="16" cellspacing="0" width="550px">
                        <tr>
                            <td colspan="2">
                                <div class="ad-items" id="divAdItems" runat="server" style="width: 450px; height: 300px">
                                <img src="lib/standard/img/AEA-2018 PD Logo.png" alt="advertisement image"  height="300px"/>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="100%">
                                <table>
                                    <tr>
                                        <td valign="top" width="100%">
                                            <a href="http://www.aeaonline.org/contact" style="text-decoration: underline; color: #C80032;" target="_blank"><font
                                                size="3" color="#C80032"><b>Contact Us</b></font></a>
                                            <br />
                                            <span style="font-size: 9pt;">Contact us if you have questions regarding upcoming
                                                <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName %>
                                                or questions about this website.</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <br />
                    <h3>
                        <escWorks:UpcomingEvents runat="server" ID="UpcomingEvents1" ItemsToDisplay="10" />
                    </h3>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <script type="text/javascript" src="lib/js/swfobject.js"> 
    </script>
</asp:Content>
