using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace escWeb.ar_aea.ObjectModel
{
    [Serializable]
    public class Site : region4.ObjectModel.Site
    {
        //bool _noPOPayment = false;
        //public bool NoPOPayment { get { return _noPOPayment; } }

        public Site(int obj_id)
            : base(obj_id)
        {
        }

        //protected override void LoadCustomerData(SqlDataReader reader)
        //{
        //    _noPOPayment = Convert.ToBoolean(reader["NoPOPayment"]);
        //}

        //protected override void LoadCustomerData(System.Data.SqlClient.SqlCommand cmd)
        //{

        //}

        //protected override void SaveCustomerData(System.Data.SqlClient.SqlCommand cmd)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}


    }

    [Serializable]
    public class Room : region4.ObjectModel.Room
    {
        //bool _noPOPayment = false;
        //public bool NoPOPayment { get { return _noPOPayment; } }

        public Room(int obj_id)
            : base(obj_id)
        {
        }

        //protected override void LoadCustomerData(SqlDataReader reader)
        //{
        //    _noPOPayment = Convert.ToBoolean(reader["NoPOPayment"]);
        //}

        //protected override void LoadCustomerData(System.Data.SqlClient.SqlCommand cmd)
        //{

        //}

        //protected override void SaveCustomerData(System.Data.SqlClient.SqlCommand cmd)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

    }

    [Serializable]
    public class Organization : region4.ObjectModel.Organization
    {
        public Organization(int obj_id)
            : base(obj_id)
        {
        }


        //protected override void LoadCustomerData(System.Data.SqlClient.SqlCommand cmd)
        //{

        //}

        //protected override void SaveCustomerData(System.Data.SqlClient.SqlCommand cmd)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}


        //protected override bool IsEntityOrganization
        //{
        //    get { throw new Exception("The method or operation is not implemented."); }
        //}
    }


}