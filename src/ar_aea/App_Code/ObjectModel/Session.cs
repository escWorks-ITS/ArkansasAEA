using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace escWeb.ar_aea.ObjectModel
{
    [Serializable]
    public class Session : region4.ObjectModel.Session
    {
        public Session(int session_id) : base(session_id)
        {
                    
        }


        public override DateTime RegistrationEndDate
        {
            get
            {
                if (_regEnd == region4.ObjectModel.modelConstants.DefaultMaxDateTime)
                {
                    DateTime time;
                    if (!region4.escWeb.SiteVariables.EndRegistrationAtMidnight)
                        time = (IsOnline || IsMultiVenueOnline) ? new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, EndDate.Hour, EndDate.Minute, EndDate.Second)
                            : new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartDate.Hour, StartDate.Minute, StartDate.Second);
                    else
                        time = (IsOnline || IsMultiVenueOnline) ? new DateTime(EndDate.Year, EndDate.Month, EndDate.Day)
                            : new DateTime(StartDate.Year, StartDate.Month, StartDate.Day);

                    return time.AddHours(-region4.escWeb.SiteVariables.NumOfHoursBeforeRegistrationClosed);
                }
                else
                {
                    return _regEnd.AddHours(region4.escWeb.SiteVariables.NumOfHoursBeforeRegistrationClosed);
                }
            }

        }
    }
}