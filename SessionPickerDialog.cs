/*
 * LICENSE: https://github.com/BeginTry/XEventHandler/blob/master/LICENSE
 * GitHub repository: https://github.com/BeginTry/XEventHandler
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XEventHandler
{
    public partial class SessionPickerDialog : Form
    {
        public SessionPickerDialog(System.Data.SqlClient.SqlConnectionStringBuilder csb)
        {
            InitializeComponent();
            sessions = Sql.ExtendedEvents.Sessions.Get(csb);
        }

        private Sql.ExtendedEvents.Session session;

        public Sql.ExtendedEvents.Session SelectedSession
        {
            get { return session; }
        }

        List<Sql.ExtendedEvents.Session> sessions;

        private void btnOK_Click(object sender, EventArgs e)
        {
            Sql.ExtendedEvents.Session s = (Sql.ExtendedEvents.Session)lbSessions.SelectedItem;

            if (s.Started)
            {
                this.DialogResult = DialogResult.OK;
                session = s;
                this.Close();
            }
            else
            {
                MessageBox.Show("Selected Extended Events Session is stopped.",
                    "XEvents", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SessionPickerDialog_Load(object sender, EventArgs e)
        {

            foreach (Sql.ExtendedEvents.Session s in this.sessions)
            {
                lbSessions.Items.Add(s);
            }
        }

        private void lbSessions_DrawItem(object sender, DrawItemEventArgs e)
        {
            //Sql.ExtendedEvents.Session s = (Sql.ExtendedEvents.Session)sender;

            Sql.ExtendedEvents.Session s = (Sql.ExtendedEvents.Session)lbSessions.Items[e.Index];

            e.DrawBackground();
            Graphics g = e.Graphics;

            if(!s.Started)
            {
                g.FillRectangle(new SolidBrush(Color.LightGray), e.Bounds);
            }

            // Listbox item text.
            g.DrawString(s.Name, lbSessions.Font, Brushes.Black, lbSessions.GetItemRectangle(e.Index).Location);
            
            e.DrawFocusRectangle();

        }
    }
}
