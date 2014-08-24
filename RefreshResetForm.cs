using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class RefreshResetForm : Form
    {
        public RefreshResetForm()
        {
            InitializeComponent();
            btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnRefresh.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnReset.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnReset.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Refresh this computer?" + 
                " All programs will be removed!", "Are you sure?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Process.Start("systemreset");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Reset this computer?" +
                " EVERYTHING will be removed!", "Are you sure?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Process.Start("systemreset", "-factoryreset");
            }
        }
    }
}
