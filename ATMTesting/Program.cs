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
            try
            {
                AutomatedTellerMachine atm = new AutomatedTellerMachine(new ConsoleScreen(), new ConsoleKeypad());


                atm.screen.Display("******-----Welcome to Dakkada Bank ---------*****");
                atm.screen.Display("-----Automated Teller Machine ---------");

                atm.screen.Display("Enter Card No: ");

                var cardNo = atm.keypad.getStringInput();

                var currentCard = atm.GetCardByCardNo(cardNo);

                if (currentCard != null)
                {

                    if (atm.ReadCard(currentCard))
                    {
                        atm.SaveCardInMemory(currentCard);

                        atm.screen.Display("------------Your Card Has Been Validated !!!----------");
                        atm.screen.Display(currentCard.NameOnCard);

                        atm.screen.Display("Enter PIN : ");



                        //Get Pin from User

                        int enteredPin = atm.keypad.getNumberInput();

                        ////Authenticate PIN

                        if (atm.Authenticate(Convert.ToString(enteredPin)))
                        {

                            //Show Possible Transactions
                            atm.screen.Display("Correct PIN, Proceed to other transaction");
                        }
                        else
                        {
                            //request for correct pin

                            atm.screen.Display("Wrong PIN, Insert Correct PIN");
                        }
                    }
                    else
                    {
                        atm.screen.Display("Invalid Card..Incomplete Card Info");
                    }



                }
                else
                {
                    atm.screen.Display("Invalid Card.. this card does not exist");
                }

                //ChipAndPinCard fake_card = new ChipAndPinCard();
                //fake_card.NameOnCard = "Ekemini Martins";
                //fake_card.CardNo = "5399 2542 4857 8996";
                //fake_card.ExpiryDate = new DateTime(2017, 3, 12);

                //var fake_pin = "1111";

                //atm.screen.Display("Card Reading is successful");
                atm.screen.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            
            
           
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
