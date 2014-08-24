using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
            tbPassword.PasswordChar = '\u25CF';
            btnContinue.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnContinue.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text.Equals("ccu123"))
            {
                RefreshResetForm rrForm = new RefreshResetForm();
                rrForm.StartPosition = FormStartPosition.CenterParent;
                rrForm.ShowDialog(this);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Wrong password!", "Wrong password", MessageBoxButtons.OK);
                tbPassword.Text = "";
            }
        }
    }
}
