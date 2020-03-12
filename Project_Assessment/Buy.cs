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
using static Project_Assessment.Dialogue;

namespace Project_Assessment
{
    class Buy
    {
        private string playerInteraction;
        //If the player presses b or B.
        //This is for checking if theres nothing in the array.
        public void BuyFromShop() 
        {
            SearchingInventory(ref counting, ref shopKeeperInventory);
            if (counting == 0)
            {
                Console.WriteLine("\nSorry, I have nothing to sell you.");
                Program endStatement = new Program();
                endStatement.EndStatement();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("I have:\n");
                for (int k = 0; k < shopKeeperInventory.InventoryLength; k++)
                {//This is checking through the shopKeepers inventory length of the array.

                    if (shopKeeperInventory.inventory[k] != null)
                    {//If the shopKeeper does have stuff in stock.
                     //If there is something in the inventory, print it to the screen.
                        Console.WriteLine($"{k}: {shopKeeperInventory.inventory[k].Name} which cost {shopKeeperInventory.inventory[k].Cost} coins.");
                        //This is printing for every item name, a number before it and the cost of it.
                    }

                }
            }
            //This is to check if the player wants to buy the item by the item number before it.
            Console.WriteLine("\nWould you like to have a look at any of these? Or do you want to go Back to the Main Menu or Leave the program? \n");
            Console.WriteLine("[Write the number next to the item to inspect.] [Back] [Leave]");
            for (int b = 0; b < 2; b++)
            {//Looping the statement as it will give the player a chance to redo what they accidentally wrote.
                try
                {//Try and catch is used in order to detect if the player had written the correct type of value.
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
                        ulong playerValue = Convert.ToUInt64(playerInteraction);
                        //If the inventory space of the playervalue has something in it, then it will display whats in the statement.
                        if (shopKeeperInventory.inventory[playerValue] != null)
                        {
                            Console.Clear();
                            //This uses the function within inventory called print.
                            //Within every other class, the use of overrride is being able to read the line called print.
                            //Allowing that when the player presses a value, that it receives the value and it displays a message from the classes.
                            shopKeeperInventory.inventory[playerValue].Print();//This is calling the function print from inventory which is a overrride to all the other classes.
                            Console.WriteLine("\nYou have, $" + playerMoney + ".\n");//Showing the players money.
                            Console.WriteLine("Do you want to buy this item? Yes or No or return Back to the shop. ");
                            Console.WriteLine("[Y] [N] [Back]");
                            _playerInteraction = Console.ReadLine();//Calls the string value _playerInteraction as a readLine as it is a null.
                            playerInteraction = _playerInteraction.ToUpper();//This is then used to put all the inputted values into uppercase through playerInteraction.

                            for (int l = 0; l < 2; l++)
                            {//This is a repetitive loop for when the player wants to buy the item or not.
                                if (playerInteraction == "Y" && playerMoney >= shopKeeperInventory.inventory[playerValue].Cost)
                                {//This is checking if the player has written yes and that they have enough money to afford the cost of the item.
                                 //This is to decrease the playerMoney by the shopKeepers Item whilst 
                                    playerMoney -= shopKeeperInventory.inventory[playerValue].Cost;//This is maths to minus the players money from the shopkeepers items value.
                                    shopKeeperMoney += shopKeeperInventory.inventory[playerValue].Cost;//This is to add the shopKeepers money from the profits of the items value.
                                    Console.WriteLine($"\nCongratulations, you have received the {shopKeeperInventory.inventory[playerValue].Name} " +
                                        $"and now have {playerMoney} left.\n");//Displaying to the player that they have purchased the item.

                                    //This is creating buyerArrayChange to a definition of calling a function. This is called when a transaction occurs. 
                                    MovingArrays(ref shopKeeperInventory.inventory, ref playerInventory.inventory, playerValue);

                                    //Calling upon the playersinventory and the shopkeepers inventory whilst getting the vlaue of where the item was.
                                    for (int m = 0; m < 1; m++)
                                    {
                                        Program continueShop = new Program();//This is creating continueShop to a definition of calling a method.
                                        continueShop.EndStatement();//This is calling the function EndStatement.
                                        m = 0;
                                    }
                                }
                                else if (playerInteraction == "Y" && playerMoney < shopKeeperInventory.inventory[playerValue].Cost)
                                {
                                    //If the players cost is greater than the cost of the item in the shop and you have said yes.
                                    Console.WriteLine($"\nSorry you do not have enough money for {shopKeeperInventory.inventory[playerValue].Name}.");
                                    Console.WriteLine($"\nYou have {playerMoney} left. ");
                                    //After this, the end statement will be called where it askes if the player wants to interact again.
                                    Program noStatement = new Program();
                                    noStatement.EndStatement();
                                }
                                else if (playerInteraction == "N")
                                {//Checking if the player wants to continue or not through the endstatement function.
                                    Program nostatement = new Program();
                                    nostatement.EndStatement();
                                }
                                else if (playerInteraction == "BACK")
                                {//A back option for the player to return back to the options of the items.
                                    BuyFromShop();
                                }
                                else
                                {
                                    Console.WriteLine("\nStop wasting my time, tell me Y or N if you want something!\n");
                                    l = 0;//If the player doesnt press yes or no or the player does not have enough money for the item.
                                    _playerInteraction = Console.ReadLine();
                                    playerInteraction = _playerInteraction.ToUpper();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nSorry, what did u say? I am going to say it again. What number of item do you want?\n");
                            r = 0;
                        }
                    }
                }
                catch
                {//Try and catch is used in order to detect if the player had written the correct type of value. In this case, it was incorrect.
                    Console.WriteLine("You have written the wrong value type, try again.");
                    b = 0;//Resetting the loop
                }
            }
        }
        
    }
}
