using ATM.Domain;
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
    public partial class frmAccountList : Form
    {
        public frmAccountList(IEnumerable<Account> _accounts)
        {
            InitializeComponent();

            bsAccounts.DataSource = _accounts;
            bnAccounts.BindingSource = bsAccounts;


        }

        private void frmAccountList_Load(object sender, EventArgs e)
        {
            dgvAccounts.DataSource = bsAccounts;
        }
    }
}
