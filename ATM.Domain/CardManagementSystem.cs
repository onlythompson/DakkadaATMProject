using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain
{
    public static class CardManagementSystem
    {

        static VirtualCardInfo[] cards = new VirtualCardInfo[3];


        public static void  InitCardSystem()
        {
            cards[0] = new VirtualCardInfo();
            cards[0].NameOnCard = "Ekemini Martins";
            cards[0].CardNo = "5399 2542 4857 8996";
            cards[0].ExpiryDate = new DateTime(2017, 3, 12);
            cards[0].PIN = "1111";

           

            cards[1] = new VirtualCardInfo();
            cards[1].NameOnCard = "Gregory Bassey";
            cards[1].CardNo = "5399 2542 4857 5866";
            cards[1].ExpiryDate = new DateTime(2018, 4, 22);
            cards[1].PIN = "2222";

            cards[2] = new VirtualCardInfo();
            cards[2].NameOnCard = "Iniobong Jame";
            cards[2].CardNo = "5399 2542 4857 7844";
            cards[2].ExpiryDate = new DateTime(2019, 9, 18);
            cards[2].PIN = "3333";
        }

        public static bool validateCardPIN(ChipAndPinCard card, string PIN)
        {

            InitCardSystem();  

            for(var i=0; i < cards.Length; i++)
            {
                if(cards[i].CardNo.Equals(card.CardNo))
                {
                    if(cards[i].PIN == PIN)
                    {
                        return true;
                    }
                }
            }

            return false;

        }


    }
}
