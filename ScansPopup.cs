using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class ScansPopup : Form
    {
        public ScansPopup()
        {
            InitializeComponent();
            btnSfc.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnSfc.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnChkdsk.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnChkdsk.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnDism.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnDism.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
        }

        private void btnSfc_Click(object sender, EventArgs e)
        {
            const string sfcCommands = "/c sfc /scannow&pause";
            Process.Start("cmd.exe", sfcCommands);
        }

        private void btnChkdsk_Click(object sender, EventArgs e)
        {
            const string chkdskCommands = "/c chkdsk&pause";
            Process.Start("cmd.exe", chkdskCommands);
        }

        private void btnDism_Click(object sender, EventArgs e)
        {
            const string dismCommands = "/c dism /online /cleanup-image /scanhealth" + 
                "&dism /online /cleanup-image /startcomponentcleanup" +
                "&dism /online /cleanup-image /restorehealth&pause";
            Process.Start("cmd.exe", dismCommands);
        }
    }
}
