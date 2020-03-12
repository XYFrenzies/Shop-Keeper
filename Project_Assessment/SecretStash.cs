using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using static Project_Assessment.Inventory;
using static Project_Assessment.MovingFilesToArrays;
using static Project_Assessment.Dialogue;
using static Project_Assessment.Program;

namespace Project_Assessment
{
    class SecretStash
    {
        private string playerInteraction;
        public void HiddenSecretStash()
        {
            int trysLeft = 3;
            for (int a = 0; a < 2; a++)
            {
                Console.WriteLine("Whats the password?");//The player is asked for a password to continue.
                _playerInteraction = Console.ReadLine();
                playerInteraction = _playerInteraction.ToUpper();//The players input is converted to an uppercase.
                switch (playerInteraction)
                {
                    case ("FORHONOR"):
                        //If the player says forhonor without any spaces. This statement will continue.
                        Console.Clear();//Clears the console.

                        SearchingInventory(ref counting, ref shopKeeperSecretInventory);
                        //This is for checking if theres nothing in the array.
                        if (counting == 0)
                        {
                            Console.WriteLine("\nSorry, I have nothing to sell you.");
                            Program endStatement = new Program();
                            endStatement.EndStatement();
                        }
                        else
                        {
                            Console.WriteLine("I agree, now down to business.\n");
                            Console.WriteLine("These are my secret stash that I have available.\n");
                            Console.WriteLine("\n These are what I have available:");//Says to the player what is available to them.

                            for (int n = 0; n < shopKeeperSecretInventory.InventoryLength; n++)
                            {
                                if (shopKeeperSecretInventory.inventory[n] != null)
                                {
                                    //If there is something in the inventory, print it to the screen.
                                    Console.WriteLine($"{n}: {shopKeeperSecretInventory.inventory[n].Name} which is worth {shopKeeperSecretInventory.inventory[n].Cost} coins.");
                                }
                            }
                        }
                        Console.WriteLine("\nWould you like to have a look at any of these? Or do you want to exit to the Main Menu or Leave the program? \n");
                        Console.WriteLine("[Write the number next to the item.] [Back] [Leave]");
                        for (int d = 0; d < 2; d++)
                        {
                            try
                            {
                                for (int r = 0; r < 2; r++)
                                {
                                    _playerInteraction = Console.ReadLine();
                                    playerInteraction = _playerInteraction.ToUpper();
                                    switch (playerInteraction)
                                    {//This is to check if the user wants to leave the store or return back to the main menu.
                                        case ("BACK")://Returns back to the main menu.
                                            Console.Clear();
                                            beginningMessage();
                                            break;
                                        case ("LEAVE")://Leaves the program.
                                            MovingArrayToFile();
                                            System.Environment.Exit(0);
                                            break;
                                        default://Continues the program.
                                            break;
                                    }
                                    ulong playerSecretBuyValue = Convert.ToUInt64(playerInteraction);
                                    //If the inventory space of the playervalue has something in it, then it will display whats in the statement.
                                    if (shopKeeperSecretInventory.inventory[playerSecretBuyValue] != null)
                                    {
                                        Console.Clear();
                                        //This uses the function within inventory called print.
                                        //Within every other class, the use of overrride is being able to read the line called print.
                                        //Allowing that when the player presses a value, that it receives the value and it displays a message from the classes.
                                        shopKeeperSecretInventory.inventory[playerSecretBuyValue].Print();//This is calling the function print from inventory which is a overrride to all the other classes.
                                        Console.WriteLine("\nYou have, $" + playerMoney + ".\n");//Showing the players money.
                                        Console.WriteLine("Do you want to buy this item? Yes or No.");
                                        Console.WriteLine("\n [Y] [N] [Back]");
                                        _playerInteraction = Console.ReadLine();//Calls the string value _playerInteraction as a readLine as it is a null.
                                        playerInteraction = _playerInteraction.ToUpper();//This is then used to put all the inputted values into uppercase through playerInteraction.

                                        for (int l = 0; l < 2; l++)
                                        {//This is a repetitive loop for when the player wants to buy the item or not.
                                            if (playerInteraction == "Y" && playerMoney >= shopKeeperSecretInventory.inventory[playerSecretBuyValue].Cost)
                                            {//This is checking if the player has written yes and that they have enough money to afford the cost of the item.
                                             //This is to decrease the playerMoney by the shopKeepers Item whilst 
                                                playerMoney -= shopKeeperSecretInventory.inventory[playerSecretBuyValue].Cost;//This is maths to minus the players money from the shopkeepers items value.
                                                shopKeeperMoney += shopKeeperSecretInventory.inventory[playerSecretBuyValue].Cost;//This is to add the shopKeepers money from the profits of the items value.
                                                Console.WriteLine($"\nCongratulations, you have received the {shopKeeperSecretInventory.inventory[playerSecretBuyValue].Name} " +
                                                    $"and now have {playerMoney} left.\n");//Displaying to the player that they have purchased the item.

                                                //This is creating buyerArrayChange to a definition of calling a function. This is called when a transaction occurs. 
                                                MovingArrays(ref shopKeeperSecretInventory.inventory, ref playerInventory.inventory, playerSecretBuyValue);
                                                Program continueShop = new Program();//This is creating continueShop to a definition of calling a method.
                                                continueShop.EndStatement();//This is calling the function EndStatement.
                                            }
                                            else if (playerInteraction == "Y" && playerMoney < shopKeeperSecretInventory.inventory[playerSecretBuyValue].Cost)
                                            {
                                                //If the player didnt have enough money for the item but said yes.
                                                Console.WriteLine($"\nSorry you do not have enough money for {shopKeeperSecretInventory.inventory[playerSecretBuyValue].Name}.");
                                                Console.WriteLine($"\nYou have {playerMoney} left, ");
                                                Program noStatement = new Program();
                                                noStatement.EndStatement();
                                            }

                                            else if (playerInteraction == "N")
                                            {
                                                //In case the player didnt want to buy the item.
                                                Program nostatement = new Program();
                                                nostatement.EndStatement();
                                            }
                                            else if (playerInteraction == "BACK")
                                            {//A back option for the player to return back to the options of the items.
                                                HiddenSecretStash();
                                            }
                                            else
                                            {
                                                Console.WriteLine("\nStop wasting my time, tell me Y or N if you want something!\n");
                                                //In case the player presses the wrong key or something has gone wrong.
                                                l = 0;
                                                _playerInteraction = Console.ReadLine();
                                                playerInteraction = _playerInteraction.ToUpper();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry, what did u say? I am going to say it again.What number of the item do you want?\n");
                                        r = 0;//This is if the player didnt put in yes or no.
                                    }
                                }

                            }
                            catch
                            {//This cathces the wrong values added instead of the numbers.
                                Console.WriteLine("You have written the wrong value type, try again.");
                                d = 0;
                            }
                        }
                        break;
                    default:
                        trysLeft -= 1;//If the player gets the password wrong, they lose a try.
                        a = 0;
                        Console.WriteLine($"Incorrect, try again if you want. You have {trysLeft} trys left.");//Displaying message
                        if (trysLeft <= 0)
                        {
                            Console.WriteLine("Sorry no more trys.");//In case the player doesnt get the password within the 3 lives.
                            Program p = new Program();
                            p.EndStatement();
                        }
                        break;
                }
            }
        }
    }
}
