using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace escWeb.ar_aea.ObjectModel
{
    [Serializable]
    public class User : region4.ObjectModel.User
    {
        private string _ssn;
        public string SSN
        {
            get { return _ssn; }
            set { _ssn = value; }
        }

        private bool _aeaMember;
        public bool AEAMember
        {
            get { return _aeaMember; }
            set { _aeaMember = value; }
        }

        public User(int user_pk)
            : base(user_pk)
        {
        }

        public User(Guid sid)
            : base(sid)
        {
        }

        protected override void LoadCustomerInfo(System.Data.SqlClient.SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "[p.objectModel.User.CustomerSpec.Load]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", this.Sid);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    _ssn = reader["empid"].ToString();
                    _aeaMember = (bool)reader["aea"];

                }
                reader.Close();
            }
            cmd.CommandText = "";
            cmd.Parameters.Clear();
        }

        protected override void SaveCustomerInfo(System.Data.SqlClient.SqlCommand cmd)
        {
            string query = string.Empty;

            cmd.Parameters.Clear();
            cmd.CommandText = "[p.objectModel.User.CustomerSpec.Save]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", this.Sid);
            cmd.Parameters.AddWithValue("@ssn", SSN);
            cmd.Parameters.AddWithValue("@aea", AEAMember);

            cmd.ExecuteNonQuery();

            cmd.CommandText = "";
            cmd.Parameters.Clear();
       
        }


    }
}