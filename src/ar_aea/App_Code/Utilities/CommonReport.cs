using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace escWeb.ar_aea.ObjectModel
{
    /// <summary>
    /// Summary description for CommonReports
    /// </summary>
    public class CommonReports : region4.Utilities.Report.CommonReports
    {
        public CommonReports()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //public override void SendCertificate(int certificate_id, int attendee_id)
        //{
        //    System.Web.UI.Page myBasePage = ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler);
        //    region4.ObjectModel.User user = System.Web.HttpContext.Current.Session["profile"] as region4.ObjectModel.User;

        //    string strUrl = region4.escWeb.SiteVariables.escWebReportServer
        //        + "Reports.aspx?reportName=certificate"
        //        + "&instruction=download:pdf"
        //        + "&CustomerName=" + region4.escWeb.SiteVariables.customer_name
        //        + "&customerid=" + region4.escWeb.SiteVariables.customer_id
        //        + "&attendee_id=" + attendee_id;

        //    myBasePage.Response.Redirect(strUrl);
        //}

        //public override void SendCertificate(int attendee_id)
        //{
        //    this.SendCertificate(-1, attendee_id);//default certificate report id
        //}

        public override void SendOfficialTranscript(Guid sid, DateTime startDate, DateTime endDate, string paraValue)
        {
            System.Web.UI.Page myBasePage = ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler);
            region4.ObjectModel.User user = System.Web.HttpContext.Current.Session["profile"] as region4.ObjectModel.User;

            string strUrl = region4.escWeb.SiteVariables.escWebReportServer
                + "Reports.aspx?reportName=transcript.official"
                + "&instruction=download:pdf"
                + "&CustomerName=" + region4.escWeb.SiteVariables.customer_name
                + "&customerid=" + region4.escWeb.SiteVariables.customer_id
                + "&begin=" + startDate
                + "&user_id=" + user.UserID;

            myBasePage.Response.Redirect(strUrl);
        }

        public override void SendPersonalTranscript(Guid sid, DateTime startDate, DateTime endDate, bool includeOfficial, string paraValue)
        {
            System.Web.UI.Page myBasePage = ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler);
            region4.ObjectModel.User user = System.Web.HttpContext.Current.Session["profile"] as region4.ObjectModel.User;

            string strUrl = region4.escWeb.SiteVariables.escWebReportServer
                + "Reports.aspx?reportName=transcript.personal"
                + "&instruction=download:pdf"
                + "&CustomerName=" + region4.escWeb.SiteVariables.customer_name
                + "&customerid=" + region4.escWeb.SiteVariables.customer_id
                + "&begin=" + startDate
                + "&end=" + endDate
                + "&user_id=" + user.UserID;

            if (includeOfficial)
                strUrl += "&all=1";

            myBasePage.Response.Redirect(strUrl);
        }

        public override void SentSignInSheet(int session_id)
        {
            System.Web.UI.Page myBasePage = ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler);
            region4.ObjectModel.User user = System.Web.HttpContext.Current.Session["profile"] as region4.ObjectModel.User;

            string strUrl = region4.escWeb.SiteVariables.escWebReportServer
                + "Reports.aspx?reportName=signin"
                + "&instruction=download:doc"
                + "&customerid=" + region4.escWeb.SiteVariables.customer_id
                + "&session_id=" + session_id;

            myBasePage.Response.Redirect(strUrl);
        }
    }
}
