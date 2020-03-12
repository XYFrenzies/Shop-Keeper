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
    class Sell
    {
        private string playerInteraction;
        public void SellForShop() 
        {
            SearchingInventory(ref counting, ref playerInventory);//Uses the function seachinginventory to find the amount of space left in the inventory.
            for (int r = 0; r < 2; r++)
            {//This is for checking if theres nothing in the array.
                if (counting == 0)
                {
                    Console.WriteLine("\nSorry, you have nothing to offer me.");
                    Program endStatement = new Program();
                    endStatement.EndStatement();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You have:\n");
                    for (int n = 0; n < playerInventory.InventoryLength; n++)
                    {//Checking the length of the array of the inventory to see if there is something in it.
                        if (playerInventory.inventory[n] != null)
                        {
                            //If there is something in the inventory, print it to the screen.
                            Console.WriteLine($"{n}: {playerInventory.inventory[n].Name} which is worth {playerInventory.inventory[n].Cost} coins.");
                        }
                        //This is for checking if theres nothing in the array.

                    }
                }
                Console.WriteLine("\nWhich item would you like to sell? Or do you want to go Back to the Main Menu or Leave the program?");
                Console.WriteLine("[Write the number next to the item.] [Back] [Leave] ");
                for (int c = 0; c < 2; c++)
                {
                    try
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
                        ulong playerSellValue = Convert.ToUInt64(playerInteraction);
                        //Defines the playerSellValue as an int of playerInterction.
                        if (playerInventory.inventory[playerSellValue] != null)
                        {//If the sell value does exist.
                            Console.Clear();
                            playerInventory.inventory[playerSellValue].Print();//Overrides the fuinction and uses the inherited item description from their class.
                            for (int o = 0; o < 2; o++)
                            {
                                Console.WriteLine($"\nI like the looks of this item, could i take it? You will get " +
                                $"{playerInventory.inventory[playerSellValue].Cost} in return.");
                                Console.WriteLine("[Y][N][Back]\n");
                                _playerInteraction = Console.ReadLine();//Askes for player input.
                                playerInteraction = _playerInteraction.ToUpper();//CHanges to an uppercase
                                for (int p = 0; p < 2; p++)
                                {
                                    if (playerInteraction == "Y")
                                    {//If the player says yes
                                        playerMoney += playerInventory.inventory[playerSellValue].Cost;//Player gets the money from the shop item.
                                        shopKeeperMoney -= playerInventory.inventory[playerSellValue].Cost;//The shop loses money.
                                        Console.WriteLine($"\nThank you, this is your new balence: {playerMoney}.");
                                        MovingArrays(ref playerInventory.inventory, ref shopKeeperInventory.inventory, playerSellValue);//The moving arrays function moves the sold item to the new array.
                                        Program endStatement = new Program();//Goes to the endstatement function to see if the player wants to continue.
                                        endStatement.EndStatement();
                                    }
                                    else if (playerInteraction == "N")
                                    {//If the player says no.
                                        Program noStatement = new Program();
                                        noStatement.EndStatement();//Goes to the endstatement function to see if the player wants to continue.
                                    }
                                    else if (playerInteraction == "BACK")
                                    {//A back option for the player to return back to the options of the items.
                                        SellForShop();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sorry what did you say? [Y] or [N]");
                                        p = 0;
                                        _playerInteraction = Console.ReadLine();//Askes for player input.
                                        playerInteraction = _playerInteraction.ToUpper();//Changes to an uppercase
                                    }
                                }
                            }
                        }
                        else
                        {
                            //If the player did not input the correct value of the item, the loop will start again.
                            Console.WriteLine("Sorry you dont have that available for offer. What item would you like to sell again?");
                            c = 0;
                        }
                    }
                    catch//Incase an error occurs.
                    {
                        Console.WriteLine("Sorry you dont have that available for offer. What item would you like to sell again?");
                        c = 0;
                    }
                }
            }
        }
    }
}
