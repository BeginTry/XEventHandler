/*
 * LICENSE: https://github.com/BeginTry/XEventHandler/blob/master/LICENSE
 * GitHub repository: https://github.com/BeginTry/XEventHandler
*/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.XEvent.Linq;

namespace XEventHandler
{
    /// <summary>
    /// Indicates one or more responses to an event of an Extended Events session.
    /// </summary>
    class ResponseOptions
    {
        private bool playSound;
        private System.Media.SystemSound sysSound;

        private bool sendEmail;
        private string emailAddress;
        private SqlConnectionStringBuilder csb;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlParameter recipient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sound">The system sound to be played when responding to an event.</param>
        /// <param name="emailAddress">Email address to send mail to when responding to an event.</param>
        /// <param name="csb">Connection to SQL for [msdb].[dbo].[sp_send_dbmail]</param>
        public ResponseOptions(System.Media.SystemSound sound, string emailAddress, SqlConnectionStringBuilder csb)
        {
            InitializeClass(sound, emailAddress, csb);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sound">The system sound to be played when responding to an event.</param>
        public ResponseOptions(System.Media.SystemSound sound)
        {
            InitializeClass(sound, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress">Email address to send mail to when responding to an event.</param>
        /// <param name="csb">Connection to SQL for [msdb].[dbo].[sp_send_dbmail]</param>
        public ResponseOptions(string emailAddress, System.Data.SqlClient.SqlConnectionStringBuilder csb)
        {
            InitializeClass(null, emailAddress, csb);
        }

        private void InitializeClass(System.Media.SystemSound sound, string emailAddress, SqlConnectionStringBuilder csb)
        {
            playSound = (sound != null);
            sysSound = sound;

            sendEmail = !string.IsNullOrEmpty(emailAddress);
            this.emailAddress = emailAddress;

            if (sendEmail)
            {
                if (csb == null)
                {
                    throw new Exception("Parameter csb (SqlConnectionStringBuilder) cannot be nulll.");
                }
                else
                {
                    this.csb = csb;
                    conn = new SqlConnection();
                    conn.ConnectionString = csb.ConnectionString;
                    conn.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "msdb.dbo.sp_send_dbmail";
                    recipient = new SqlParameter("@recipients", System.Data.SqlDbType.VarChar, -1);
                    recipient.Value = this.emailAddress;
                }
            }
        }

        /// <summary>
        /// Call this method when an event occurs to respond to it.
        /// </summary>
        public void Respond(PublishedEvent xEvent)
        {
            if (playSound)
            {
                sysSound.Play();
            }

            if (sendEmail)
            {
                #region SQL command parameters.
                cmd.Parameters.Clear();

                SqlParameter subject = new SqlParameter("@subject", System.Data.SqlDbType.NVarChar, 255);
                subject.Value = csb.DataSource + " - " + xEvent.Name + " Event";

                SqlParameter body = new SqlParameter("@body", System.Data.SqlDbType.NVarChar, -1);
                StringBuilder sb = new StringBuilder("Extended Event: " + xEvent.Name + Environment.NewLine);

                foreach (PublishedEventField fld in xEvent.Fields)
                {
                    sb.AppendLine("\t" + fld.Name + " = " + fld.Value.ToString());
                }

                foreach (PublishedAction act in xEvent.Actions)
                {
                    sb.AppendLine("\t" + act.Name + " = " + act.Value.ToString());
                }

                //https://stackoverflow.com/questions/2292850/c-sharp-what-does-0-equate-to
                sb.Replace("\0", "");

                body.Value = sb.ToString();
                #endregion

                cmd.Parameters.Add(recipient);
                cmd.Parameters.Add(subject);
                cmd.Parameters.Add(body);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
