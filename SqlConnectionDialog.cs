/*
 * LICENSE: https://github.com/BeginTry/XEventHandler/blob/master/LICENSE
 * GitHub repository: https://github.com/BeginTry/XEventHandler
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XEventHandler
{
    public partial class SqlConnectionDialog : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlConnectionStringBuilder csb;

        public SqlConnectionStringBuilder ConnectionStringBuilder
        {
            get { return csb; }
            set { csb = value; }
        }

        private enum AuthenticationType
        {
            WindowsAuth = 0,
            SqlAuth = 1,
        }

        public SqlConnectionDialog()
        {
            InitializeComponent();
        }

        private void SqlConnectionDialog_Load(object sender, EventArgs e)
        {
            cboAuthentication.SelectedIndex = 0;

            if (csb == null)
            {
                csb = new SqlConnectionStringBuilder();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (ValidConnection())
            {
                MessageBox.Show("Connection succeeded.", "", MessageBoxButtons.OK);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidConnection())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool FormValidated()
        {
            if (string.IsNullOrEmpty(txtServerName.Text))
            {
                MessageBox.Show("Server Name must be specified.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (cboAuthentication.SelectedIndex == (int)AuthenticationType.SqlAuth &&
                string.IsNullOrEmpty(txtLoginName.Text))
            {
                MessageBox.Show("Login Name must be specified.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void cboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLoginName.Enabled = cboAuthentication.SelectedIndex == (int)AuthenticationType.SqlAuth;
            txtPassword.Enabled = cboAuthentication.SelectedIndex == (int)AuthenticationType.SqlAuth;
            lblUser.Enabled = cboAuthentication.SelectedIndex == (int)AuthenticationType.SqlAuth;
            lblPassword.Enabled = cboAuthentication.SelectedIndex == (int)AuthenticationType.SqlAuth;

            if (cboAuthentication.SelectedIndex == (int)AuthenticationType.WindowsAuth)
            {
                lblUser.Text = "User Name:";
                txtLoginName.Text = Environment.UserName;
            }
            else if (cboAuthentication.SelectedIndex == (int)AuthenticationType.SqlAuth)
            {
                lblUser.Text = "Login Name:";
                txtLoginName.Text = "";
            }

        }

        private bool ValidConnection()
        {
            if (!FormValidated())
                return false;

            bool retVal;

            this.Cursor = Cursors.WaitCursor;
            csb = new SqlConnectionStringBuilder();
            csb.DataSource = txtServerName.Text;
            csb.InitialCatalog = "master";
            csb.ConnectTimeout = 3;

            if (cboAuthentication.SelectedIndex == (int)AuthenticationType.WindowsAuth)
            {
                csb.IntegratedSecurity = true;
            }
            else if (cboAuthentication.SelectedIndex == (int)AuthenticationType.SqlAuth)
            {
                csb.IntegratedSecurity = false;
                csb.UserID = txtLoginName.Text;
                csb.Password = txtPassword.Text;
            }

            try
            {
                conn.ConnectionString = csb.ConnectionString;
                conn.Open();
                conn.Close();
                retVal = true;
            }
            catch (Exception ex)
            {
                retVal = false;
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return retVal;
        }

        public static bool ValidConnection(SqlConnectionStringBuilder csb)
        {

            //No need to wait the full 15 seconds (default behavior).
            csb.ConnectTimeout = 3;

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = csb.ConnectionString;

                try
                {
                    cn.Open();
                }
                catch
                {
                    return false;
                }

                cn.Close();
            }

            return true;
        }
    }
}
