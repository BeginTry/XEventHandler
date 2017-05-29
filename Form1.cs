/*
 * LICENSE: https://github.com/BeginTry/XEventHandler/blob/master/LICENSE
 * GitHub repository: https://github.com/BeginTry/XEventHandler
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.XEvent.Linq;

namespace XEventHandler
{
    public partial class Form1 : Form
    {
        SqlConnectionDialog scd = new SqlConnectionDialog();
        Sql.ExtendedEvents.Session session;
        bool monitoring = false;
        XEventReader xEventProcess;
        bool balloonTipShown = false;
        readonly string[] sysSoundNames = new string[] { "Asterisk", "Beep", "Exclamation", "Hand", "Question" };

        public Form1()
        {
            InitializeComponent();
        }

        private void connectToSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dlg = scd.ShowDialog();

                if (dlg == DialogResult.OK)
                {
                    SetToolStrip();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetToolStrip()
        {
            tsslConnected.Text = "Connected";
            tsslPipe.Text = "|";
            tsslSqlHost.Text = scd.ConnectionStringBuilder.DataSource;

            if (scd.ConnectionStringBuilder.IntegratedSecurity)
            {
                tsslLogin.Text = Environment.UserName;
            }
            else
            {
                tsslLogin.Text = scd.ConnectionStringBuilder.UserID;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                tsslConnected.Alignment = ToolStripItemAlignment.Left;
                tsslLogin.Alignment = ToolStripItemAlignment.Right;
                tsslSqlHost.Alignment = ToolStripItemAlignment.Right;

                notifyIcon1.BalloonTipText = "Double-click to open.";
                notifyIcon1.BalloonTipTitle = "Extended Events Handler";
                notifyIcon1.Text = "Extended Events Handler";
                notifyIcon1.Visible = false;

                cboSounds.Items.AddRange(sysSoundNames);
                LoadAppConfigItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAppConfigItems()
        {
            bool minToSysTray = false;
            string emailRecipients = "";
            string defConn = "";

            try
            {
                minToSysTray = Convert.ToBoolean(ConfigurationManager.AppSettings["MinimizeToSystemTray"]);
            }
            catch { }
            
            try
            {
                emailRecipients = ConfigurationManager.AppSettings["EmailRecipients"];
            }
            catch { }

            try
            {
                defConn = ConfigurationManager.AppSettings["DefaultConnectionString"];
            }
            catch { }
            
            minimizeToSystemTrayToolStripMenuItem.Checked = minToSysTray;
            txtEmail.Text = emailRecipients;
            
            System.Data.SqlClient.SqlConnectionStringBuilder csb =
                new System.Data.SqlClient.SqlConnectionStringBuilder(defConn);

            if (string.IsNullOrEmpty(defConn) ||
                !SqlConnectionDialog.ValidConnection(csb))
            {
                tsslLogin.Text = "";
                tsslSqlHost.Text = "";
                tsslPipe.Text = "";
            }
            else
            {
                scd.ConnectionStringBuilder = csb;
                SetToolStrip();
            }
        }

        private void btnPickSession_Click(object sender, EventArgs e)
        {
            try
            {
                if (scd.ConnectionStringBuilder == null || string.IsNullOrEmpty(scd.ConnectionStringBuilder.ConnectionString))
                {
                    MessageBox.Show("You must connect to an instance of SQL Server", "Not Connected",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connectToSQLToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    DialogResult dlg = new DialogResult();
                    SessionPickerDialog spd = new SessionPickerDialog(scd.ConnectionStringBuilder);

                    dlg = spd.ShowDialog();

                    if (dlg == DialogResult.OK)
                    {
                        txtXEventSession.Text = spd.SelectedSession.Name;
                        session = spd.SelectedSession;

                        //Add event names to the list box.
                        clbEvents.Items.Clear();
                        clbEvents.Items.AddRange(session.SelectedEvents.ToArray());

                        //All event names checked by default.
                        for (int i = 0; i < clbEvents.Items.Count; i++)
                        {
                            clbEvents.SetItemChecked(i, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (About a = new XEventHandler.About())
                {
                    a.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetControlState(bool enabled)
        {
            btnStart.Enabled = enabled;
            btnCancel.Enabled = !enabled;
            btnPickSession.Enabled = enabled;
            fileToolStripMenuItem.Enabled = enabled;
            helpToolStripMenuItem.Enabled = enabled;
            grpEventResponses.Enabled = enabled;
            grpEventsHandled.Enabled = enabled;
        }

        private void ResetErrors()
        {
            errProvider.SetError(btnPickSession, "");
            errProvider.SetError(grpEventsHandled, "");
            errProvider.SetError(grpEventResponses, "");
            errProvider.SetError(cboSounds, "");
            errProvider.SetError(txtEmail, "");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("btnCancel_Click();");
                monitoring = false;
                this.Cursor = Cursors.Default;
                btnStart.Enabled = true;
                btnPickSession.Enabled = true;

                xEventProcess.CancelProcessing();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (monitoring)
                {
                    this.Cursor = Cursors.WaitCursor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            try
            {
                if (minimizeToSystemTrayToolStripMenuItem.Checked)
                {
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        notifyIcon1.Visible = true;

                        if (!balloonTipShown)
                        {
                            notifyIcon1.ShowBalloonTip(2000);
                            balloonTipShown = true;
                        }

                        this.Hide();
                    }
                    else if (this.WindowState == FormWindowState.Normal)
                    {
                        notifyIcon1.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (minimizeToSystemTrayToolStripMenuItem.Checked)
                {
                    this.WindowState = FormWindowState.Normal;
                    notifyIcon1.Visible = false;
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!FormValidated())
                {
                    this.Cursor = Cursors.Default;
                    return;
                }

                SetControlState(false);

                monitoring = true;
                xEventProcess = new XEventHandler.XEventReader(GetHandledEvents(), GetResponses());

                var progress = new Progress<string>(s => lblLastEventHandled.Text = s);
                await Task.Factory.StartNew(() => xEventProcess.ReadEventStream(progress, session.Name, scd.ConnectionStringBuilder),
                                            TaskCreationOptions.LongRunning);

                lblLastEventHandled.Text = "...";
                this.Cursor = Cursors.Default;
                SetControlState(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Returns a string list of selected event names.
        /// </summary>
        /// <returns></returns>
        private List<string> GetHandledEvents()
        {
            List<string> ret = new List<string>();

            foreach (int i in clbEvents.CheckedIndices)
            {
                ret.Add(clbEvents.Items[i].ToString());
            }

            return ret;
        }

        private ResponseOptions GetResponses()
        {
            System.Media.SystemSound sound = null;
            string email = null;

            #region Assign the system sound.
            if (ckPlaySysSound.Checked)
            {
                switch (cboSounds.SelectedItem.ToString())
                {
                    case "Asterisk":
                        sound = System.Media.SystemSounds.Asterisk;
                        break;
                    case "Beep":
                        sound = System.Media.SystemSounds.Beep;
                        break;
                    case "Exclamation":
                        sound = System.Media.SystemSounds.Exclamation;
                        break;
                    case "Hand":
                        sound = System.Media.SystemSounds.Hand;
                        break;
                    case "Question":
                        sound = System.Media.SystemSounds.Question;
                        break;

                    default:
                        break;
                }
            }
            #endregion

            if (ckSendEmail.Checked)
            {
                email = txtEmail.Text;
            }

            return new ResponseOptions(sound, email, scd.ConnectionStringBuilder);
        }

        private bool FormValidated()
        {
            bool ret = true;

            ResetErrors();

            if (scd.ConnectionStringBuilder == null ||
                !SqlConnectionDialog.ValidConnection(scd.ConnectionStringBuilder))
            {
                ret = false;
                MessageBox.Show("Unable to connect to SQL Server. Invalid credentials or none proviced.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(txtXEventSession.Text))
            {
                ret = false;
                errProvider.SetError(btnPickSession, "Choose an XEvent session.");
            }
            else
            {
                //TODO: validate appropriate form data is entered.
                if (clbEvents.CheckedIndices.Count == 0)
                {
                    ret = false;
                    errProvider.SetError(grpEventsHandled, "Choose at least one event to handle.");
                }

                if (!ckPlaySysSound.Checked && !ckSendEmail.Checked)
                {
                    ret = false;
                    errProvider.SetError(grpEventResponses, "Choose at least one response for events.");
                }

                if (ckPlaySysSound.Checked && cboSounds.SelectedIndex == -1)
                {
                    ret = false;
                    errProvider.SetError(cboSounds, "Choose the sound to play.");
                }

                if (ckSendEmail.Checked && string.IsNullOrEmpty(txtEmail.Text))
                {
                    ret = false;
                    errProvider.SetError(txtEmail, "Enter a valid email address.");
                }
            }

            return ret;
        }
    }
}
