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
    public class SessionInfo : region4.ObjectModel.SessionInfo
    {
        public SessionInfo(DataRow reader) : base(reader)
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}