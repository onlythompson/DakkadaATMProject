using DakkadaATM.Bank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DakkadaATM
{
    public partial class frmShell : Form
    {
        public frmShell()
        {
            InitializeComponent();
        }

        private void frmShell_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbs_Click(object sender, EventArgs e)
        {
            frmBankShell frm = new frmBankShell();
            frm.ShowDialog();
        }
    }
}
