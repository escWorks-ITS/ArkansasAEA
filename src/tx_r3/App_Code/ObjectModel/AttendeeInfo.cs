﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace escWeb.tx_r3.ObjectModel
{
    /// <summary>
    /// Summary description for AttendeeInfo
    /// </summary>
    [Serializable]
    public class AttendeeInfo : region4.ObjectModel.AttendeeInfo
    {
        public AttendeeInfo(DataRow reader) : base(reader)
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public override void AddOnlineInProgressTile(HtmlTableRowCollection htmlTableRowCollection)
        {
            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());

            row.Cells[0].Attributes.Add("class", "onlineHeading");
            //  row.Cells[0].Attributes.Add("bgcolor","black");
            row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Session ID:")));

            row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0}", SessionID)));
            row.Cells[1].Attributes.Add("class", "onlineContent");
            row.Cells[2].Attributes.Add("class", "onlineContent");
            row.Cells[2].Align = "right";

            if (IsOnline)
            {

                if (IsInstructorLedOnline || IsSelfPacedOnline)
                {
                    Button link = new Button();
                    link.Text = "Open";
                    link.ID = "CourseLink" + ID.ToString();
                    link.CommandArgument = ID.ToString();

                    if (OnlineCourseUrl.StartsWith("http://") || OnlineCourseUrl.StartsWith("https://"))
                    {
                        link.OnClientClick = String.Format("javascript:window.open('{0}'); return false;", OnlineCourseUrl);
                    }
                    else
                    {
                        link.OnClientClick = String.Format("javascript:alert('{0}'); return false;", OnlineCourseUrl);
                    }
                    row.Cells[2].Controls.Add(link);
                }
                else
                {
                    if (_PrevSessionID > 0 && !_PrevSessionIDAttended)
                    {
                        Button link = new Button();
                        link.Text = "Locked";
                        link.ID = "OpenMessageForPrerequisiteSession" + ID.ToString();
                        link.CommandArgument = ID.ToString();
                        link.OnClientClick = String.Format("javascript: alert('Please complete Session {0} first.'); return false;", _PrevSessionID);
                        row.Cells[2].Controls.Add(link);
                    }
                    else
                    {
                        Button link = new Button();
                        link.Text = "Play";
                        link.ID = "OpenTraining" + ID.ToString();
                        link.CommandArgument = ID.ToString();
                        link.OnClientClick = String.Format("javascript:OpenTraining('{0}', this); return false;", OnDemandOrgOrAtt);
                        row.Cells[2].Controls.Add(link);
                    }
                }

            }
            else
            {
                Button link = new Button();
                link.Text = "Play";
                link.ID = "OpenTraining" + ID.ToString();
                link.CommandArgument = ID.ToString();
                link.OnClientClick = String.Format("javascript:OpenTraining('{0}', this); return false;", OnDemandOrgOrAtt);
                row.Cells[2].Controls.Add(link);
            }

            htmlTableRowCollection.Add(row);
            //space
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            htmlTableRowCollection.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());

            row.Cells[0].Attributes.Add("class", "onlineHeading");

            row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Session Title:")));

            row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0} - {1}", Title, Subtitle)));
            row.Cells[1].ColSpan = 2;
            row.Cells[1].Attributes.Add("class", "onlineContent");

            htmlTableRowCollection.Add(row);
            //space
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            htmlTableRowCollection.Add(row);

            if (IsInstructorLedOnline)
            {
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].Attributes.Add("class", "onlineHeading");
                row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Start Date:")));
                row.Cells[1].ColSpan = 2;
                row.Cells[1].Attributes.Add("class", "onlineContent");

                if (StartDate.Hour == 0) //Midnight
                    row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0}", StartDate.ToLongDateString())));
                else
                    row.Cells[1].Controls.Add(new LiteralControl(String.Format("{0:d} {1:t}", StartDate.ToLongDateString(), StartDate)));
                htmlTableRowCollection.Add(row);
                //space
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                htmlTableRowCollection.Add(row);

                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].Attributes.Add("class", "onlineHeading");
                row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "End Date:")));
                row.Cells[1].ColSpan = 2;
                row.Cells[1].Attributes.Add("class", "onlineContent");

                if (StartDate.Hour == 0) //Midnight
                    row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0}", EndDate.ToLongDateString())));
                else
                    row.Cells[1].Controls.Add(new LiteralControl(String.Format("{0:d} {1:t}", EndDate.ToLongDateString(), EndDate)));
                htmlTableRowCollection.Add(row);

                if (ShowChangeRegistrationLink) //For instructor led online event, if event type is multi velue, we can switch registration
                {
                    row = new HtmlTableRow();
                    row.Cells.Add(new HtmlTableCell());

                    PlaceHolder pLinks = new PlaceHolder();
                    LinkButton link = new LinkButton();
                    link.Text = "Change Registration";
                    link.CommandArgument = ID.ToString();
                    link.CssClass = "link";
                    link.ID = "changeregistration_" + ID.ToString();
                    link.Click += new EventHandler(changeRegistrationLink_Click);
                    AddLink(pLinks, link);
                    row.Cells[0].Controls.Add(pLinks);
                    htmlTableRowCollection.Add(row);
                }
                //space
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                htmlTableRowCollection.Add(row);
            }
            else
            {
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());
                row.Cells[0].Attributes.Add("class", "onlineHeading");
                row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Expiration Date:")));
                row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0}", OnlineExpirationDate.ToString())));
                row.Cells[1].ColSpan = 2;
                row.Cells[1].Attributes.Add("class", "onlineContent");
                htmlTableRowCollection.Add(row);
                //space
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                htmlTableRowCollection.Add(row);
            }

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.BgColor = "#909090";
            row.Cells[0].ColSpan = 3;
            htmlTableRowCollection.Add(row);

        }
    }
}