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

        Account _account;

        public frmNewAccount()
        {
            InitializeComponent();

            _accountSystem = new AccountSystem();

            initAccount();

        }

        void initAccount()
        {
            _account = new Account();
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

                    _account.Passport = new ImageProcessingEngine().getResizedImage(ofdPhotoSelector.FileName, 150, 150);
                    MemoryStream stream = new MemoryStream(_account.Passport);
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

                   _account.Signature = new ImageProcessingEngine().getResizedImage(ofdPhotoSelector.FileName, 70, 70);
                    MemoryStream stream = new MemoryStream(_account.Signature);
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
            assignValues();

            if(String.IsNullOrEmpty(_account.FirstName) && String.IsNullOrEmpty(_account.Surname)){
                return false;
                }

            if (String.IsNullOrEmpty(_account.AccountNos) && String.IsNullOrEmpty(_account.BVN))
            {
                return false;
            }

            if (_account.Passport == null && _account.Signature == null)
            {
                return false;
            }

            if (_account.StateOfOrigin == null && (int)_account.Gender == 0)
            {
                return false;
            }
            return true;
        }


        void SaveEntry()
        {
            if (ValidateEntry())
            {
                
                _accountSystem.SaveAccount(_account);

                
            }
        }

        private void assignValues()
        {
            _account.FirstName = txtFirstName.Text;
            _account.Surname = txtSurname.Text;
            _account.Address = txtAddess.Text;
            _account.BVN = txtBVN.Text;
            _account.TypeofAccount = getAccountType();

            _account.Gender = getGender();

            _account.AccountNos = txtAccountNos.Text;
            _account.BirthDate = dtpDoB.Value.Date;

            _account.StateOfOrigin = ((State)cmbState.SelectedItem).Code;
            _account.Height = Convert.ToDouble(txtHeight.Value);

        }

        private Gender getGender()
        {
            if (rdbMale.Checked)
            {
                return Gender.Male;
            }
            else
            {
                return Gender.Female;
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
