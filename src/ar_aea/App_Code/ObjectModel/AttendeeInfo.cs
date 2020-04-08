using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace escWeb.ar_aea.ObjectModel
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

      public override bool ShowChangeRegistrationLink
        {
            get
            {
                if (IsInstructorLedOnline && IsMultiVenue)
                    return ((DateTime.Now < RegistrationEndDate)
                    && (DateTime.Now < CancellationEndDate));
                else
                    return ((DateTime.Now < RegistrationEndDate)
                    && (DateTime.Now < CancellationEndDate)
                    && !(IsOnline)
                    && (CheckAvailableSessionsCount()));
            }
        }

      protected virtual bool CheckAvailableSessionsCount()
        {
            region4.ObjectModel.Attendee _attendee = region4.escWeb.SiteVariables.ObjectProvider.ReturnAttendee(ID);
           // escWeb.demo.ObjectModel.Attendee _attendee = attendee as escWeb.demo.ObjectModel.Attendee;
            List<region4.ObjectModel.Session> sessions = _attendee.Session.Event.UpcomingSessions;
            bool retVal = false;
            foreach (ObjectModel.Session session in sessions)
            {
                if (session == _attendee.Session)
                    continue;

                bool breakOutTheSame = true;
                if (session.Event is ObjectModel.Conference || session.Event is ObjectModel.MultiVenue)
                    breakOutTheSame &= session.BreakoutSession == _attendee.Session.BreakoutSession;
                region4.ObjectModel.SessionRegistration registration = region4.escWeb.SiteVariables.ObjectProvider.ReturnSessionRegistration(session, _attendee.User);

                if (registration.ReturnUserFee() == _attendee.Fee && session.DisplayOnWeb && DateTime.Now < session.RegistrationEndDate && !session.SessionFull && !session.IsUserRegistered(_attendee.User.Sid) && breakOutTheSame)
                    //_rblSessions.Items.Add(new ListItem(ReturnSessionSummary(session), session.ID.ToString()));
                    retVal = true;
                    break;
            }
            return retVal;
        }

      public override bool ShowCancelRegistrationLink
      {
          get
          {
              return ((DateTime.Now < RegistrationEndDate)
                  && (DateTime.Now < CancellationEndDate)
                  //&& !IsConference
                  && !(IsOnline || IsMultiVenueOnline));
          }
      }

    }
}