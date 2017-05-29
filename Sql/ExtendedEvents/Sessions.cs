using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XEventHandler.Sql.ExtendedEvents
{
    class Sessions
    {
        public static List<Session> Get(SqlConnectionStringBuilder csb)
        {
            List<Session> retVal = new List<Session>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = csb.ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT s.name, " +
                            "CAST(CASE WHEN (r.create_time IS NULL) THEN 0 ELSE 1 END AS BIT) AS IsRunning" + Environment.NewLine +
                        "FROM master.sys.server_event_sessions s" + Environment.NewLine +
                        "LEFT JOIN sys.dm_xe_sessions r" + Environment.NewLine +
                        "    ON r.name = s.name";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string nm = dr["name"].ToString();
                            bool started = Convert.ToBoolean(dr["IsRunning"]);
                            List<string> targs = GetTargets(csb, nm);
                            List<string> selEvents = GetSelectedEvents(csb, nm);

                            retVal.Add(new ExtendedEvents.Session(nm, targs, selEvents, started));
                        }
                    }
                }
            }
            return retVal;
        }

        private static List<string> GetSelectedEvents(SqlConnectionStringBuilder csb, string sessionName)
        {
            List<string> retVal = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = csb.ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT e.name" + Environment.NewLine +
                        "FROM master.sys.server_event_sessions s" + Environment.NewLine +
                        "JOIN master.sys.server_event_session_events e" + Environment.NewLine +
                        "   ON e.event_session_id = s.event_session_id" + Environment.NewLine +
                        "WHERE s.name = @name";
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@name";
                    param.Value = sessionName;
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    cmd.Parameters.Add(param);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            retVal.Add(dr["name"].ToString());
                        }
                    }
                }
            }
            return retVal;
        }

        private static List<string> GetTargets(SqlConnectionStringBuilder csb, string sessionName)
        {
            List<string> retVal = new List<string>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = csb.ConnectionString;
                conn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT t.name" + Environment.NewLine +
                        "FROM master.sys.server_event_sessions s" + Environment.NewLine +
                        "JOIN master.sys.server_event_session_targets t" + Environment.NewLine +
                        "    ON t.event_session_id = s.event_session_id" + Environment.NewLine +
                        "WHERE s.name = @name";
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@name";
                    param.Value = sessionName;
                    param.SqlDbType = System.Data.SqlDbType.VarChar;
                    cmd.Parameters.Add(param);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            retVal.Add(dr["name"].ToString());
                        }
                    }
                }
            }
            return retVal;
        }
    }
}
