using ATM.Application;
using ATM.Domain;
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

namespace DakkadaATM.Bank
{
    public partial class frmNewAccount : Form
    {

        AccountSystem _accountSystem;
        public frmNewAccount()
        {
            InitializeComponent();

            _accountSystem = new AccountSystem();


        }

        private void pbPassport_Click(object sender, EventArgs e)
        {

        }

        private void pbPassport_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                this.ofdPhotoSelector.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (ofdPhotoSelector.ShowDialog() == DialogResult.OK)
                {

                    var Photo = new ImageProcessingEngine().getResizedImage(ofdPhotoSelector.FileName, 150, 150);
                    MemoryStream stream = new MemoryStream(Photo);
                    this.pbPassport.Image = Image.FromStream(stream);
                    //txtFileName.Text = PictureSelector.FileName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbSignature_Click(object sender, EventArgs e)
        {
       
        }

        private void ProcessSignature()
        {
            try
            {
                this.ofdPhotoSelector.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (ofdPhotoSelector.ShowDialog() == DialogResult.OK)
                {

                    var signature = new ImageProcessingEngine().getResizedImage(ofdPhotoSelector.FileName, 70, 70);
                    MemoryStream stream = new MemoryStream(signature);
                    this.pbSignature.Image = Image.FromStream(stream);
                    //txtFileName.Text = PictureSelector.FileName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbSignature_DoubleClick(object sender, EventArgs e)
        {
            ProcessSignature();
        }


        void ProcessStates(){
            List<State> states = new List<State>();

            states.Add(new State("AK", "Akwa Ibom"));
            states.Add(new State("AB", "Abia"));
            states.Add(new State("EN", "Enugu"));
            states.Add(new State("CS", "Cross River"));

            cmbState.DataSource = states;
            cmbState.DisplayMember = "Name";
            cmbState.ValueMember = "Code";
        }

        private void frmNewAccount_Load(object sender, EventArgs e)
        {
            ProcessStates();
        }

        bool ValidateEntry()
        {
            return true;
        }


        void SaveEntry()
        {
            if (ValidateEntry())
            {
                var account = new Account();
                account.FirstName = txtFirstName.Text;
                account.Surname = txtSurname.Text;
                account.Address = txtAddess.Text;
                account.BVN = txtBVN.Text;
                account.TypeofAccount = getAccountType();


                _accountSystem.SaveAccount(account);

                
            }
        }


        AccountType getAccountType()
        {
            if (rdbCurrent.Checked)
            {
                return AccountType.Current;
            }
            else if(rdbSavings.Checked)
            {
                return AccountType.Savings;
            }
            else
            {
                 throw new InvalidOperationException("Select a valid account type");
               
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveEntry();
        }
    }
}
