using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class shoebox_registration_default : region4.escWeb.BasePages.ShoeBox.registration.default_aspx
{

    protected override void AssignControlsToBase()
    {
        _regHistory = regHistory;
        _radTabStrip = radTabStrip;
        _hiddenFieldTabValue = hiddenFieldTabValue;
    }

    protected override void Page_Init(object sender, EventArgs e)
    {
        AssignControlsToBase();

        _regHistory.CurrentUser = this.CurrentUser;

        this._radTabStrip.FindTabByValue("FutureEvents").Text = "Upcoming " + region4.escWeb.SiteVariables.ObjectProvider.SessionPluralNameCapitalized;
        this._radTabStrip.FindTabByValue("PastEvents").Text = "Past " + region4.escWeb.SiteVariables.ObjectProvider.SessionPluralNameCapitalized;
        //this._radTabStrip.FindTabByValue("OnlineEvents").Text = "Online " + region4.escWeb.SiteVariables.ObjectProvider.SessionPluralNameCapitalized;

        if (Session["RegistrationHistoryCurrentTab"] != null)
        {
            this._regHistory.CurrentTab = Session["RegistrationHistoryCurrentTab"].ToString();
            this._radTabStrip.FindTabByValue(this._regHistory.CurrentTab).Selected = true;
            this._hiddenFieldTabValue.Value = this._regHistory.CurrentTab;

            Session.Remove("RegistrationHistoryCurrentTab");
        }
        else
        {
            string hiddenValue = Microsoft.Security.Application.Encoder.HtmlEncode(Request.Form[_hiddenFieldTabValue.UniqueID]);
            if (string.IsNullOrEmpty(hiddenValue))
                this._regHistory.CurrentTab = "FutureEvents";
            else
                this._regHistory.CurrentTab = hiddenValue;
        }
    }

}
