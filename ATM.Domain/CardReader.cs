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

        public static bool IsValidCard(ChipAndPinCard card)
        {
            if (String.IsNullOrEmpty(card.NameOnCard) && String.IsNullOrEmpty(card.CardNo))
            {
                return false;
            }

            if (card.HasExpired())
            {
                return false;
            }

            return true;
        }
    }
}
