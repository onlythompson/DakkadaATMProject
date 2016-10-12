using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain
{
    public class AutomatedTellerMachine
    {
        public IScreen screen;
        public IKeypad keypad;
        CashDispenser dispenser;
        ReceiptPrinter printer;
        Bank bank;



        private ChipAndPinCard CurrentATMCard;




        //public AutomatedTellerMachine()
        //{

        //}

        public AutomatedTellerMachine(IScreen _screen, IKeypad _keypad)
        {
            screen = _screen;
            keypad = _keypad;
            bank = new Bank();
        }


        private void SaveCardInMemory(ChipAndPinCard card)
        {
            CurrentATMCard = card;
        }


        public void ProcessCardInCardReader(string _cardNo)
        {
            try
            {
                SaveCardInMemory(CardReader.ProcessCard(_cardNo));
            }
            catch (Exception)
            {
                throw;
            }

        }


        public ChipAndPinCard GetCardByCardNo(string _cardNo)
        {
            try
            {
                return CardManagementSystem.getCardByNo(_cardNo);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ChipAndPinCard GetCurrentCard()
        {
            if (CurrentATMCard != null)
            {
                return this.CurrentATMCard;
            }
            throw new InvalidOperationException("ATM found no card");
        }


        public void DisplayAfterCardReadingProcessingMessage()
        {
            this.screen.Display("------------Your Card Has Been Validated !!!----------");

            this.screen.Display(String.Format("Welcome {0}", this.CurrentATMCard.NameOnCard));

            
        }
        public bool AuthenticateCard(string PIN)
        {
            try
            {

                this.screen.Display("Enter PIN : ");
                int enteredPin = this.keypad.getNumberInput();

                return CardManagementSystem.validateCardPIN(CurrentATMCard, PIN);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public ATMTransactionType resolveATMUserTransaction(int transactionType)
        {
            switch (transactionType)
            {
                case 1:
                    return ATMTransactionType.DEPOSIT;
                case 2:
                    return ATMTransactionType.WITHDRAWAL;
                case 3:
                    return ATMTransactionType.CHECK_BALANCE;

                default:
                    throw new InvalidOperationException("Choose a valid transaction type");

            }
        }


        public void PerformTransaction(ATMTransactionType type)
        {
            switch (type)
            {

                case ATMTransactionType.WITHDRAWAL:
                    performATMWithdrawal();
                    break;
                case ATMTransactionType.CHECK_BALANCE:
                    performATMAccountBalanceCheck();
                    break;
                default:
                    ShowPossibleTransactions();
                    break;

            }
        }

        private void performATMWithdrawal()
        {

            var currentTrans = new WithdrawalTransaction();

            this.screen.Display("***********Enter Transaction Amount :**************");
            currentTrans.Amount = this.keypad.getNumberInput();


            if (bank.processAccountWithdrawal(this.CurrentATMCard.LinkedAccount, currentTrans))
            {
                screen.Display("Take your cash");
                screen.Display("Withdrawal Transaction Successful");
                screen.Display(String.Format("Your account balance: {0}", bank.GetAccountBalance(this.CurrentATMCard.LinkedAccount)));
            }

        }


        private void performATMAccountBalanceCheck()
        {

            screen.Display("Your account balance");
            screen.Display(bank.GetAccountBalance(this.CurrentATMCard.LinkedAccount));

            //screen.Clear();

            ShowPossibleTransactions();

        }

        public void ShowPossibleTransactions()
        {
            screen.Display("PRESS 1 FOR DEPOSIT");
            screen.Display("PRESS 2 FOR WITHDRAWAL");
            screen.Display("PRESS 3 FOR CHECK BALANCE");
            screen.Display("PRESS 4 FOR EXIT");

            //resolveATMUserTransaction(keypad.getNumberInput());
        }
    }



    public enum ATMTransactionType
    {
        DEPOSIT = 1,
        WITHDRAWAL = 2,
        CHECK_BALANCE = 3
    }

}
