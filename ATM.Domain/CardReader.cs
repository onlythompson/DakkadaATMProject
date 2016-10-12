using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM.Domain
{
    public static class CardReader
    {
        //public bool read(ChipAndPinCard card)
        //{
        //    return IsValideCard(card);
        //}

        public static ChipAndPinCard ProcessCard(string _cardNo)
        {
            if (!String.IsNullOrEmpty(_cardNo))
            {
                var card = CardManagementSystem.getCardByNo(_cardNo);
                if (IsValidCard(card))
                {
                    return card;
                }


            }
            throw new InvalidOperationException("No valid card no for processing");
        }

        public static bool IsValidCard(ChipAndPinCard card)
        {
           
            if (card.HasExpired())
            {
                return false;
            }

            return true;
        }
    }
}
