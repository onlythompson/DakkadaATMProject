using ATM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            AutomatedTellerMachine atm = new AutomatedTellerMachine(new ATMScreen());


            ChipAndPinCard fake_card = new ChipAndPinCard();
            fake_card.NameOnCard = "Ekemini Martins";
            fake_card.CardNo = "5399 2542 4857 8996";
            fake_card.ExpiryDate = new DateTime(2017, 3, 12);

            var fake_pin = "1111";

            if (atm.ReadCard(fake_card))
            {
                atm.SaveCardInMemory(fake_card);

                atm.screen.Display("------------Welcome !!!----------");
                atm.screen.Display(fake_card.NameOnCard);

                atm.screen.Display("Enter PIN : ");

                //Get Pin from User

              
                
                ////Authenticate PIN

                //if (atm.Authenticate(fake_pin))
                //{

                //    //Show Possible Transactions
                //    atm.screen.Display("Correct PIN, Proceed to other transaction");
                //}
                //else
                //{
                //    //request for correct pin

                //    atm.screen.Display("Wrong PIN, Insert Correct PIN");
                //}
            };


            //atm.screen.Display("Card Reading is successful");
            atm.screen.Wait();
            
           
        }

        //private static void CardReaderTesting()
        //{
        //    CardReader card_r = new CardReader();


        //    //fake Card
        //    ChipAndPinCard fake_card = new ChipAndPinCard();
        //    fake_card.NameOnCard = "Ekemini Martins";
        //    fake_card.CardNo = "5399 2542 4857 8996";
        //    fake_card.ExpiryDate = new DateTime(2017, 3, 12);

        //    if (card_r.IsValidCard(fake_card))
        //    {
        //        Console.WriteLine("It is a valid Card");
        //    }
        //    else
        //    {
        //        Console.WriteLine("It is not a valid Card");
        //    }


        //    Console.ReadLine();
        //}
    }
}
