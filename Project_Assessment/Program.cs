using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Project_Assessment
{
    class Program
    {
        //These are the different Items that will be available for you in the shop or on the player.
        //For weapons, the categories are displayed as Name, Weight, Cost, Range, Damage, AttackSpeed.
        static public Weapon longSwordOfDestiny = new Weapon("Long Sword Of Destiny", 20, 900, 20, 100, 1);
        static public Weapon deathbringerAxe = new Weapon("The Last DeathBringer", 25, 1000, 3, 150, 2);
        static public Weapon crossBow = new Weapon("Enchanted CrossBow of Truth", 10, 1000, 500, 70, 1);

        //For Armour, the categories are displayed as Name, Weight, Cost, Type of Gear, Health, What it resists.
        static public Armour holyHeadGear = new Armour("The Holy Headset", 15, 500, "HeadGear", 250, "CrossBow");
        static public Armour holyChestPeice = new Armour("The Holy ChestGuard", 25, 900, "ChestPeice", 500, "CrossBow");
        static public Armour holyPants = new Armour("The Holy Leggings", 10, 600, "Leggings", 400, "CrossBow");

        //For Potions, the categories are displayed as Name, Weight, Cost, Type of Potion, Stat changes, Description.
        static public Potion godAlmightyPotion = new Potion("God Almighty Potion", 1, 300, "gives you health of about ", 200,
            "Its so strong that it would only be used in a life or death situation.");
        static public Potion deadlyPoisonOfTheWest = new Potion("Deadly Poison of The West", 2, 1000,
            "deals increasing amounts of damage over 5 seconds, adding x2 damage each time", 20,
            "If you want a deadly toxin that can pressure anyone into fleeing, this is the potion for you.");
        static public Potion theEnchantedPotion = new Potion("The Enchanted Potion of the Neverworlds", 1, 2000,
            "It increases the level of the player by", 1,
            "If your needing a high enough level for some of the upcoming fights, this potion should do the trick.");

        //This is split into two different arrays. One is for the shopkeeper, the other is for the player.
        static public Item[] itemArrayShopKeeper = new Item[] { longSwordOfDestiny, deathbringerAxe,  
            holyChestPeice, holyPants, godAlmightyPotion, deadlyPoisonOfTheWest, theEnchantedPotion};
        static public Item[] itemArrayPlayer = new Item[] { crossBow, holyHeadGear};

        //With reference to the inventory class, its the amount of space that the individual can hold.
        static public Inventory playerInventory = new Inventory(20); //This is the players inventory space defult at 20.
        static public Inventory shopKeeperInventory = new Inventory(25); //This is the shop keepers inventory space default at 25.


        //This is a undefined variable that is used as part of the checking for what the player says.
        static public string _playerInteraction;
        private string playerInteraction;
        static public int playerMoney = 1000; //Default amounts of money that can be spent.
        static public int shopKeeperMoney = 1000; //Default amounts of money that the shop keeper can hold.

        //This is the main function of the program.
        static public void Main()
        {
            using (StreamWriter playerFile = new StreamWriter(@"D:\AIE programming course\Shop-Keeper\Project_Assessment.txt"))
            {
                for (int i = 0; i < itemArrayPlayer.Length; i++)
                {
                    //This is to get all the values within the array and to save it onto a text file.
                    //OpenFile(ConvertingFiles(itemArrayPlayer[i]));

                }
            }

            //This is adding the multiple different items into a list from the array. This list is from a function called Addinventory
            playerInventory.AddInventory(crossBow, holyHeadGear);
            shopKeeperInventory.AddInventory(longSwordOfDestiny, deathbringerAxe,
            holyChestPeice, holyPants, godAlmightyPotion, deadlyPoisonOfTheWest, theEnchantedPotion);
            shopKeeperInventory.SearchInventory("");

            Program p = new Program();
            p.beginningMessage();
            //This naturally begins the beginningmessage function.
        }

        public void EndStatement()
        {
            //This will return the players interaction back to the beginning of the begin message loop.
            Console.WriteLine("\nWould you like to continue looking around in the shop? [Y] [N]\n");
            _playerInteraction = Console.ReadLine();
            playerInteraction = _playerInteraction.ToUpper();

            if (playerInteraction == "Y")
            {
                //Console.Clear is to romove the words from the console so it is easier to see what is on the next version of the interaction.
                Console.Clear();
                Program p = new Program();
                p.beginningMessage();

                //This is to call the function beginningmessage again

            }
            else if (playerInteraction == "N")
            {
                System.Environment.Exit(0);
                //This is to exit the console and the program when the player wants to exit.
            }
            else 
            {
                //Incase the player does not produce the correct letter, y or n.
                Console.WriteLine("\nSorry could you repeat that? Y or N.");
                _playerInteraction = Console.ReadLine();
                playerInteraction = _playerInteraction.ToUpper();

            }
        }



        public void MovingArrays(ref Item [] a_seller, ref Item [] a_buyer, int newLocation) 
        {
        //Within this function, its job is to move an item between the two different arrays.
        //When a player buys or sells an item, the item is found within the array, the function finds space in the other array and then places it in there.
        //This then makes the location equal to null.

            for (int j = 0; j < a_buyer.Length; j++)
            {
                if (a_buyer[j] == null)
                {
                    a_buyer[j] = a_seller[newLocation];
                    a_seller[newLocation] = null;

                    return;
                }
            }

        }


        static public string ConvertingFiles(Item a_item) 
        {
            //This is to display the items and their unique options onto the textfile.
            //name = itemName;
            Item WeapName1 = longSwordOfDestiny;
            Item WeapName2 = deathbringerAxe;
            Item WeapName3 = crossBow;

            Item armourName1 = holyHeadGear;
            Item armourName2 = holyChestPeice;
            Item armourName3 = holyPants;

            Item potionName1 = godAlmightyPotion;
            Item potionName2 = deadlyPoisonOfTheWest;
            Item potionName3 = theEnchantedPotion;

            string totalShopKeeper = WeapName1 + "," + WeapName2 + "," + armourName2 + "," + armourName3 + "," +
                potionName1 + "," + potionName2 + "," + potionName3;
            // total = name + "," + ....;

            string totalPlayer = WeapName3 + "," + armourName1;
            if (!File.Exists("ShopKeeper.txt"))
            {
                using (FileStream text = File.Create("ShopKeeper.txt"))
                {
                    return totalShopKeeper;
                }
            }
            
            return "";
        }
        public virtual void beginningMessage()
        {

            for (int i = 0; i < 2; i++)
            {
                //This will be the beginning dialogue of the program.
                Console.WriteLine("Welcome young traveller. How can I help you today?");
                Console.WriteLine("I have a range of goods that might interest you.\n");
                Console.WriteLine("\nThe goods that I have available are Armour, weapons of any kind and potions.");
                Console.WriteLine("Hope I encapsulate your taste of equipment.\n");
                Console.WriteLine("What would you like to look at first, you can either buy or sell? [B] or [S]");
                //This is to check for the players response.
                for (int j = 0; j < 2; j++)
                {
                    _playerInteraction = Console.ReadLine();
                    string playerInteraction = _playerInteraction.ToUpper();
                    //If they player presses buy, use this statement.
                    if (playerInteraction == "B")
                    {
                        for (int k = 0; k < shopKeeperInventory.InventoryLength; k++)
                        {
                            if (shopKeeperInventory.inventory[k] != null)
                            {
                                //If there is something in the inventory, print it to the screen.
                                Console.WriteLine($"{k}: {shopKeeperInventory.inventory[k].Name} which cost {shopKeeperInventory.inventory[k].Cost} coins.");

                            }
                        }
                        Console.WriteLine("\nWould you like to have a look at any of these? [Write the number next to the item.]\n");
                        playerInteraction = Console.ReadLine();


                        //This is a check for if the playersInteraction is the same as the shopKeeper, then the print function will work.
                        int playerValue = Convert.ToInt32(playerInteraction);
                        //If the inventory space of the playervalue has something in it, then it will display whats in the statement.
                        if (shopKeeperInventory.inventory[playerValue] != null)
                        {
                            //This uses the function within inventory called print.
                            //Within every other class, the use of overrride is being able to read the line called print.
                            //Allowing that when the player presses a value, that it receives the value and it displays a message from the classes.
                            shopKeeperInventory.inventory[playerValue].Print();
                            Console.WriteLine("\nYou have, $" + playerMoney + ".\n");
                            Console.WriteLine("Do you want to buy this item? Yes or No. [Y] [N]");
                            _playerInteraction = Console.ReadLine();
                            playerInteraction = _playerInteraction.ToUpper();

                            for (int l = 0; l < 2; l++)
                            {
                                
                                //Thiys is for checking if the player has input Yes or No.
                                if (playerInteraction == "Y" && playerMoney >= shopKeeperInventory.inventory[playerValue].Cost)
                                {
                                    //This is to decrease the playerMoney by the shopKeepers Item whilst 
                                    playerMoney -= shopKeeperInventory.inventory[playerValue].Cost;
                                    shopKeeperMoney += shopKeeperInventory.inventory[playerValue].Cost;
                                    Console.WriteLine($"\nCongratulations, you have received the {shopKeeperInventory.inventory[playerValue].Name} " +
                                        $"and now have {playerMoney} left.\n");

                                    Program buyerArrayChange = new Program();
                                    buyerArrayChange.MovingArrays(ref shopKeeperInventory.inventory, ref playerInventory.inventory, playerValue);

                                    for (int m = 0; m < 1; m++)
                                    {
                                        Program continueShop = new Program();
                                        continueShop.EndStatement();
                                        m = 0;
                                    }
                                }
                                else if (playerInteraction == "Y" && playerMoney < shopKeeperInventory.inventory[l].Cost)
                                {
                                    Console.WriteLine($"\nSorry you do not have enough money for {shopKeeperInventory.inventory[l].Name}.");
                                    Console.WriteLine($"\nYou have {playerMoney} left, ");

                                    Program noStatement = new Program();
                                    noStatement.EndStatement();
                                }

                                else if (playerInteraction == "N")
                                {
                                    Program nostatement = new Program();
                                    nostatement.EndStatement();
                                    i = 0;

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
                            Console.WriteLine("\nSorry, you have wasted my time helping you, please leave!!!\n");
                            Program redoBegin = new Program();
                            redoBegin.beginningMessage();

                        }

                    }
                    //If the player presses sell, use this statement.
                    if(playerInteraction == "S")
                    {
                        Console.WriteLine("\nYou have:");
                        for (int n = 0; n < playerInventory.InventoryLength; n++)
                        {
                            if (playerInventory.inventory[n] != null)
                            {

                                //If there is something in the inventory, print it to the screen.
                                Console.WriteLine($"{n}: {playerInventory.inventory[n].Name} which is worth {playerInventory.inventory[n].Cost} coins.");
                            }

                            //This is for checking if theres nothing in the array.
                            else if (playerInventory.inventory == null)
                            {
                                Console.WriteLine("\nSorry, you have nothing to offer me.");
                                Program endStatement = new Program();
                                endStatement.EndStatement();
                            }

                        }
                        Console.WriteLine("\nWhich item would you like to sell? [Write the number next to the item.]");
                        _playerInteraction = Console.ReadLine();
                        playerInteraction = _playerInteraction.ToUpper();

                        int playerSellValue = Convert.ToInt32(playerInteraction);

                        if (playerInventory.inventory[playerSellValue] != null)
                        {
                            playerInventory.inventory[playerSellValue].Print();
                            for (int o = 0; o < 1; o++)
                            {
                                Console.WriteLine($"\nI like the looks of this item, could i take it? You will get " +
                                $"{playerInventory.inventory[o].Cost} in return. Yes or No [Y] [N].\n");
                                _playerInteraction = Console.ReadLine();
                                playerInteraction = _playerInteraction.ToUpper();
                                for (int p = 0; p < 1; p++)
                                {
                                    if (playerInteraction == "Y")
                                    {
                                        playerMoney += playerInventory.inventory[playerSellValue].Cost;
                                        shopKeeperMoney -= playerInventory.inventory[playerSellValue].Cost;
                                        Console.WriteLine($"\nThank you, this is your new balence: {playerMoney}.");
                                        Program buyerArrayChange = new Program();
                                        buyerArrayChange.MovingArrays(ref playerInventory.inventory, ref shopKeeperInventory.inventory, playerSellValue);

                                        Program endStatement = new Program();
                                        endStatement.EndStatement();
                                    }
                                    else if (playerInteraction == "N")
                                    {
                                        Program noStatement = new Program();
                                        noStatement.EndStatement();
                                    }
                                }

                            }


                        }

                    }
                    else
                    {
                        //This is a incase funtion if the player does not write the correct word or letter.
                        Console.WriteLine("\nWhat did you say? Buy [B] or Sell [S]? Press the letter and then enter.");
                        i = 0;
                    }
                }
                //The next statement is for the reading of whatever is in the text file.
                StreamReader optionsAvailable = new
                    StreamReader("ShopKeeper.txt");
                //while (optionsAvailable.EndOfStream == false)
                //{
                //    string line = optionsAvailable.ReadLine();
                //    //This is the reading from the text file.
                //    //Whenever the stream is still not at the end, it continually reads it and prints it.
                //    Console.WriteLine(line);
                //}
                //optionsAvailable.Close();
            }
        }
    }
}

            
    
