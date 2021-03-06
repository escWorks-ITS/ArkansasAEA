using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Telerik.Web.UI;
using escWeb.ar_aea.ObjectModel;

public partial class Search : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["SearchCriteria"] != null)
            {
                txtSearch.Text = Request.QueryString["SearchCriteria"].ToString();
            }
        }
        LoadData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
            lbError.Visible = false;
            LoadData();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtSearch.Text = string.Empty;
    
        LoadData();
        lbError.Visible = false;
    }

    private void LoadData()
    {
        List<SessionInfo> sessionInfoList = LoadSearchSessions();
        grdSearch.DataSource = SearchInMemory(sessionInfoList, true, true, true, true, this.txtSearch.Text.Trim());
        grdSearch.DataBind();
    }

    private static List<SessionInfo> LoadSearchSessions()
    {
        string cacheKey = String.Format("objProvider_{0}_sessioninfoList_LoadSearchSessions", region4.escWeb.SiteVariables.customer_id);

        List<SessionInfo> SessionInfoList = HttpContext.Current.Cache[cacheKey] as List<SessionInfo>;
        if (SessionInfoList == null)
        {
            using (SqlConnection conn = region4.Common.DataConnection.DbConnection)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = region4.baseStoredProcedures.Session.GetSearchSessions;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date", DateTime.Today.ToShortDateString());

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    using (DataSet data = new DataSet())
                    {
                        da.Fill(data);

                        if (data != null)
                        {
                            SessionInfoList = new List<SessionInfo>();
                            foreach (DataRow dr in data.Tables[0].Rows)
                            {
                                SessionInfo sessionInfo = (SessionInfo)region4.ObjectModel.ObjectProvider.ReturnSessionInfo(dr);
                                SessionInfoList.Add(sessionInfo);
                            }
                        }
                    }
                }
            }
            HttpContext.Current.Cache.Add(cacheKey, SessionInfoList, null, DateTime.Now.AddSeconds(60), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
        }
        return SessionInfoList;
    }

    protected List<SessionInfo> SearchInMemory(List<SessionInfo> sessionInfoList, bool faceToFace, bool online, bool free, bool weekend, string Keywords)
    {
        List<SessionInfo> resultList = new List<SessionInfo>();
        int number;
        bool isNumber = false;
        if (Int32.TryParse(Keywords, out number))
            isNumber = true;
        foreach (SessionInfo sessionInfo in sessionInfoList)
        {
            //If Keywords is SessionID, then use DisplayOnWebOmitOnline, otherwise, use DisplayOnWeb
            bool OKtoAdd;
            if (isNumber)
                OKtoAdd = sessionInfo.DisplayOnWebOmitOnline;
            else
                OKtoAdd = sessionInfo.DisplayOnWeb;

           

            if (Keywords.Length > 0)
            {
                string[] SearchTerms = Keywords.Split(' ');
                string SearchField = sessionInfo.SessionID.ToString() + "|" + sessionInfo.EventID.ToString() + "|"
                    + sessionInfo.Title + " " + sessionInfo.Description + " "
                    + sessionInfo.EventTypeDisplay + " " + sessionInfo.Subtitle + " "
                    + sessionInfo.SearchField;
                foreach (string term in SearchTerms)
                {
                    OKtoAdd &= SearchField.ToLower().Contains(term.ToLower());
                }
            }
            if (OKtoAdd && sessionInfo.IsConference)//Conference only add once
            {
                foreach (SessionInfo temp in resultList)
                {
                    if (temp.EventID == sessionInfo.EventID)
                    {
                        OKtoAdd = false;
                        break;
                    }
                }
            }

            if (OKtoAdd)
                resultList.Add(sessionInfo);
        }
        return resultList;
    }
}
