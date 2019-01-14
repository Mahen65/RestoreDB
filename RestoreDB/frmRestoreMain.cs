using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;
using Utility.DataService;

namespace RestoreDB
{
    public partial class frmRestoreMain : Form
    {
        public frmRestoreMain()
        {
            InitializeComponent();
        }

        private void btnSelectBackUp_Click(object sender, EventArgs e)
        {
            SelectFolder(txtPath);
        }

        private void btnSelectData_Click(object sender, EventArgs e)
        {
            SelectFolder(txtDataPath);
        }

        private void btnSelectLog_Click(object sender, EventArgs e)
        {
            SelectFolder(txtLogPath);
        }
        private void SelectFolder(TextBox tb)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = !String.IsNullOrEmpty(tb.Text) ? tb.Text : string.Empty;
                fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
                DialogResult result = fbd.ShowDialog();
                tb.Text = fbd.SelectedPath.ToString();
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateForm();
                Backup b = new Backup { Path = txtPath.Text, DataFilePath = txtDataPath.Text, LogFilePath = txtLogPath.Text };
                new DataService().RestoreDB(b);
                MessageBox.Show("Restored", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Util.ClearFields(this);
            }
            catch (ApplicationException apx)
            {
                MessageBox.Show(this, apx.Message, "RestoreDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "RestoreDB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateForm()
        {
            if (String.IsNullOrEmpty(txtPath.Text))
            {
                btnSelectBackUp.Focus();
                throw new ApplicationException("Select " + txtPath.AccessibleName);
            }
            else if (String.IsNullOrEmpty(txtDataPath.Text))
            {
                btnSelectData.Focus();
                throw new ApplicationException("Select " + txtDataPath.AccessibleName);
            }
            else if (String.IsNullOrEmpty(txtLogPath.Text))
            {
                btnSelectLog.Focus();
                throw new ApplicationException ("Select " + txtLogPath.AccessibleName);
            }
        }
    }
}
