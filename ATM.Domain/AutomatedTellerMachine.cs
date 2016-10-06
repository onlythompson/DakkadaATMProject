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


        //public AutomatedTellerMachine(IScreen _screen)
        //{
        //    screen = _screen;
        //}

        public AutomatedTellerMachine(IScreen _screen, IKeypad _keypad)
        {
            screen = _screen;
            keypad = _keypad;
        }


        public void SaveCardInMemory(ChipAndPinCard card)
        {
            CurrentATMCard = card;
        }


        public bool ReadCard(ChipAndPinCard card)
        {
            try
            {
                return CardReader.IsValidCard(card);
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
        public bool Authenticate(string PIN)
        {
            try
            {
                return CardManagementSystem.validateCardPIN(CurrentATMCard, PIN);

            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
   
}
