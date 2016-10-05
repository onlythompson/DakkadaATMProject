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
        CashDispenser dispenser;
        ReceiptPrinter printer;
        Bank bank;

        private ChipAndPinCard CurrentATMCard;

        public AutomatedTellerMachine(IScreen _screen)
        {
            screen = _screen;
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


    public static class KeyPad
    {
        //public static const int[] keys = {0,1,2,3,4,5,6,7,8,9};

        public static DirectionKey DirectionKey;
    }


    public enum DirectionKey
    {
        Enter,
        Clear,
        Cancel,
        Right,
        Left,
        Up,
        Down
    }

   
}
