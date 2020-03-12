using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using static Project_Assessment.Inventory;
using static Project_Assessment.MovingFilesToArrays;
using static Project_Assessment.Program;
using static Project_Assessment.Buy;

namespace Project_Assessment
{
    class Dialogue
    {
        static public void beginningMessage()
        {

            for (int i = 0; i < 2; i++)
            {//This is a repetitive statement for if the player wants to continue buying.
                //This will be the beginning dialogue of the program.
                Console.WriteLine("Welcome young traveller. How can I help you today?");
                Console.WriteLine("I have a range of goods that might interest you.\n");
                Console.WriteLine("\nThe goods that I have available are Armour, weapons of any kind and potions.");
                Console.WriteLine("Hope I encapsulate your taste of equipment.\n");
                Console.WriteLine("What would you like to look at first, you can either buy or sell? [B] or [S]");
                //This is to check for the players response.
                for (int j = 0; j < 2; j++)
                {//Repetitive statement for asking the player, what they would rather, buy or sell.
                    _playerInteraction = Console.ReadLine(); //Calls the string value _playerInteraction as a readLine as it is a null.
                    string playerInteraction = _playerInteraction.ToUpper();//This is then used to put all the inputted values into uppercase through playerInteraction.
                    //If they player presses buy, use this statement.
                    switch (playerInteraction)
                    {
                        case "B":
                            Buy newBuy = new Buy();
                            newBuy.BuyFromShop();
                            break;
                        case "S":
                            Sell newSell = new Sell();
                            newSell.SellForShop();                            
                            break;
                        case "SUPERUSER":
                            SuperUser newSuperUser = new SuperUser();
                            newSuperUser.SuperUserCreating();
                            break;
                        case "SECRETSTASH":
                            SecretStash newSecretStash = new SecretStash();
                            newSecretStash.HiddenSecretStash();
                            break;
                        default:
                            //This is a incase funtion if the player does not write the correct word or letter.
                            Console.WriteLine("\nWhat did you say? Buy [B] or Sell [S]? Press the letter and then enter.");
                            j = 0;//Restarts the value J so that the program starts again.
                        break;

                    }
                }
            }
        }
    }
}
