using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain
{
    public class Bank
    {
        List<Account> AccountList;

        const decimal _transactionLimit = 150000.00m;

        public Bank()
        {
            //Instatiate a new account list
            AccountList = new List<Account>();


            //create 3 fictitous accounts
            Account ek = new Account();

            ek.AccountNos = "0041758221";
            ek.BVN = "254144554848888";
            ek.TypeofAccount = AccountType.Current;
            ek.FirstName = "Ekemini";
            ek.Surname = "Martins";
            ek.AccountBalance = 200000.00m;
            ek.TransactionLimit = _transactionLimit;



            Account greg = new Account();

            greg.AccountNos = "0041585991";
            greg.BVN = "254144554848888";
            greg.TypeofAccount = AccountType.Current;
            greg.FirstName = "Gregory";
            greg.Surname = "Bassey";
            greg.AccountBalance = 300000.00m;
            greg.TransactionLimit = _transactionLimit;


            Account ini = new Account();

            ini.AccountNos = "0041587756";
            ini.BVN = "254144554848888";
            ini.TypeofAccount = AccountType.Savings;
            ini.FirstName = "Iniobong";
            ini.Surname = "James";
            ini.AccountBalance = 400000.00m;
            ini.TransactionLimit = _transactionLimit;


            //Add the accounts to the list;
            AccountList.Add(ek);
            AccountList.Add(greg);
            AccountList.Add(ini);
   
           
        }


        public bool processAccountWithdrawal(string accountNo, WithdrawalTransaction trans)
        {
            //enumerate thru the account list
            foreach (var _account in AccountList)
            {
                if (_account.AccountNos.Equals(accountNo))
                {
                   //Check if account balance is sufficient for the withdrawal
                    if (_account.AccountBalance > trans.Amount)
                    {
                        _account.AccountBalance = _account.AccountBalance - trans.Amount;
                        return true;
                    }

                    throw new InvalidOperationException("Insufficient Balance");
                }
            }

            throw new InvalidOperationException("Invalid Account");
        }


        public string GetAccountBalance(string accountNo)
        {
            foreach (var _account in AccountList)
            {
                if (_account.AccountNos.Equals(accountNo))
                {
                    return String.Format("=N {0}=", _account.AccountBalance);
                }
            }

            throw new InvalidOperationException("Invalid Account");
        }


        public Account GetAccountByAccountNo(string accountNo)
        {
            foreach (var _account in AccountList)
            {
                if (_account.AccountNos.Equals(accountNo))
                {
                    return _account;
                }
            }
            return null;
        }
    }
}
