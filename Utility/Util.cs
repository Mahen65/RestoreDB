using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{
    public static class Util
    {
        public static void ClearFields(Form frm)
        {
            foreach (Control c in frm.Controls)
            {
                ClearControls(c);
            }
        }

        private static void ClearControls(Control c)
        {
            if (c.GetType() == typeof(ComboBox))
            {
                ((ComboBox)c).SelectedIndex = -1;
            }
            else if (c.GetType() == typeof(TextBox))
            {
                c.Text = string.Empty;
            }
            else if (c.GetType() == typeof(TreeView))
            {
                ((TreeView)c).Nodes.Clear();
            }
            else if (c.GetType() == typeof(DataGridView))
            {
                ((DataGridView)c).DataSource = null;
            }
            else if (c.GetType() == typeof(Panel) || c.GetType() == typeof(GroupBox))
            {
                foreach (Control crc in c.Controls)
                {
                    ClearControls(crc);
                }
            }
        }
    }
}
