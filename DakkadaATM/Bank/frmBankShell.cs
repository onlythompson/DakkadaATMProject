using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DakkadaATM.Bank
{
    public partial class frmBankShell : Form
    {
        public frmBankShell()
        {
            InitializeComponent();
        }

        private void createAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewAccount frm = new frmNewAccount();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
