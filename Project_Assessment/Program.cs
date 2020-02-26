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

        public int playerMoney = 1000; //Default amounts of money that can be spent.
        public int shopKeeperMoney = 1000; //Default amounts of money that the shop keeper can hold.


        static public Item [] MovingArrays(Item [] a_Receiver, Item [] a_Giver) 
        {
            //Basically I want to move the value w from the location x to the location z whilst trying to 
            //find the length of it so it doesnt overwrite the variable 
            //I'd basically need to find the value of w from the statement and find it within the array and place it into another array. 
            


            for (int i = 0; i < a_Giver.Length; i++)
            {
                a_Receiver[i] = a_Giver[i];
            }




            return a_Receiver;

        }


        static public string ConvertingFiles(Item a_item) 
        {

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

            string total = WeapName1 + "," + WeapName2 + "," + WeapName3 + "," + armourName1 + "," + armourName2 + "," + armourName3 + "," +
                potionName1 + "," + potionName2 + "," + potionName3 + ",";
            // total = name + "," + ....;
            return "";
        }


        //This is the main function of the program.
        static public void Main()
        {
            using (StreamWriter playerFile = new StreamWriter(@"D:\AIE programming course\Shop-Keeper\Project_Assessment.txt"))
            {
                for (int i = 0; i < itemArrayPlayer.Length; i++)
                {
                    //This is to get all the values within the array and to save it onto a text file.
                    OpenFile(ConvertingFiles(itemArrayPlayer[i]));

                }
            }
            



            //This is adding the multiple different items into a list from the array. This list is from a function called Addinventory
            playerInventory.AddInventory(crossBow, holyHeadGear);
            shopKeeperInventory.AddInventory(longSwordOfDestiny, deathbringerAxe,
            holyChestPeice, holyPants, godAlmightyPotion, deadlyPoisonOfTheWest, theEnchantedPotion);
            shopKeeperInventory.SearchInventory("");

            //if (!File.Exists("ShopKeeper.txt"))
            //{
            //    //Within this, it creates a text file called shopkeeper that keeps the inventory of the shopkeeper.
            //    StreamWriter shopKeeperValue;
            //    shopKeeperValue = new StreamWriter("ShopKeeper.txt");
            //    shopKeeperValue.WriteLine("Long Sword Of Destiny");
            //    shopKeeperValue.WriteLine("Deathbringer Axe");
            //    shopKeeperValue.WriteLine("CrossBow");
            //    shopKeeperValue.WriteLine("Holy HeadGear");
            //    shopKeeperValue.WriteLine("Holy ChestPeice");
            //    shopKeeperValue.WriteLine("Holy Pants");
            //    shopKeeperValue.WriteLine("God Almighty Potion");
            //    shopKeeperValue.WriteLine("DeadlyPoisonOfTheWest");
            //    shopKeeperValue.WriteLine("The Enchanted Potion");

            //    //DataTable datatable = new DataTable();
            //    // StreamReader

            //    shopKeeperValue.Close();
            //}

            //if (!File.Exists("Player.txt"))
            //{
            //    //This is to create a player text file.
            //    StreamWriter playerValue;
            //    playerValue = new StreamWriter("Player.txt");
            //    playerValue.WriteLine("Long Sword Of Destiny");
            //    playerValue.Close();
            //    //Closing the text file is alwats needed.

            //}

            Program p = new Program();
            p.beginningMessage();
            //This naturally begins the beginningmessage function.
        }


            public virtual void beginningMessage()
            {
            int newPlayerMoney; //This is the updated value for the players new money
            int newShopKeeperMoney; //This is the updated value for the shops money

            for (int i = 0; i < 2; i++)
            {
                //This will be the beginning dialogue of the program.
                Console.WriteLine("Welcome young traveller. How can I help you today?");
                Console.WriteLine("I have a range of goods that might interest you.");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("The goods that I have available are Armour, weapons of any kind and potions.");
                Console.WriteLine("Hope I encapsulate your taste of equipment.");
                Console.WriteLine("");
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
                                Console.WriteLine($"{k}: {shopKeeperInventory.inventory[k].Name}");

                            }
                        }
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("Would you like to have a look at any of these? [Write the number next to the item.]");
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
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("You have, $" + playerMoney + ".");
                            Console.WriteLine("");
                            Console.WriteLine("Do you want to buy this item? Yes or No. [Y] [N]");
                            _playerInteraction = Console.ReadLine();
                            playerInteraction = _playerInteraction.ToUpper();

                            for (int l = 0; l < 2; l++)
                            {

                                //Thiys is for checking if the player has input Yes or No.
                                if (playerInteraction == "Y" && playerMoney >= shopKeeperInventory.inventory[l].Cost)
                                {

                                    //If this is activated, use the calculation to activate the cost of the item and minus it from the players money value
                                    //Program.MoneyCalculator(playerMoney, shopKeeperInventory.inventory[l].Cost, shopKeeperMoney);

                                    newPlayerMoney = playerMoney - shopKeeperInventory.inventory[l].Cost;
                                    newShopKeeperMoney = shopKeeperMoney + shopKeeperInventory.inventory[l].Cost;


                                    Console.WriteLine($"Congratulations, you have received the {shopKeeperInventory.inventory[l].Name} " +
                                        $"and now have {newPlayerMoney} left.");
                                    Console.WriteLine("Would you like to continue? Yes or No. [Y] [N]");
                                    _playerInteraction = Console.ReadLine();
                                    playerInteraction = _playerInteraction.ToUpper();
                                    for (int m = 0; m < 1; m++)
                                    {
                                        if (playerInteraction == "Y")
                                        {
                                            //Write a statement here to update the two arrays with the new interaction
                                            newPlayerMoney = playerMoney; //I need to ask about why the money is not updating globally.
                                            newShopKeeperMoney = shopKeeperMoney; //This is updating the shops money from the transaction.
                                            Program startAgain = new Program();
                                            startAgain.beginningMessage();
                                            i = 0;
                                        }
                                        else if (playerInteraction == "N")
                                        {
                                            //If the player presses N exit program.
                                            System.Environment.Exit(0);
                                        }

                                        else
                                        {
                                            Console.WriteLine("Sorry could you repeat that? Y or N.");
                                            _playerInteraction = Console.ReadLine();
                                            playerInteraction = _playerInteraction.ToUpper();
                                            m = 0;
                                        }
                                    }
                                }
                                else if (playerInteraction == "Y" && playerMoney < shopKeeperInventory.inventory[l].Cost)
                                {
                                    Console.WriteLine($"Sorry you do not have enough money for {shopKeeperInventory.inventory[l].Name}.");
                                    Console.WriteLine($"You have {playerMoney} left, ");
                                }


                                else if (playerInteraction == "N")
                                {
                                    //This will return the players interaction back to the beginning of the begin message loop.
                                    Console.WriteLine("Would you like to continue looking around in the shop? [Y] [N]");
                                    _playerInteraction = Console.ReadLine();
                                    playerInteraction = _playerInteraction.ToUpper();

                                    if (playerInteraction == "Y")
                                    {
                                        Program p = new Program();
                                        p.beginningMessage();
                                        i = 0;
                                        //This is to call the function beginningmessage again

                                    }

                                    else if (playerInteraction == "N")
                                    {
                                        System.Environment.Exit(0);
                                        //This is to exit the console and the program when the player wants to exit.
                                    }

                                }

                                else
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine("Stop wasting my time, tell me Y or N if you want something!");
                                    //In case the player presses the wrong key or something has gone wrong.
                                    l = 0;
                                    _playerInteraction = Console.ReadLine();
                                    playerInteraction = _playerInteraction.ToUpper();
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Sorry, you have wasted my time helping you, please leave!!!");
                            System.Environment.Exit(0);

                        }

                    }
                    //If the player presses sell, use this statement.
                    if(playerInteraction == "S")
                    {
                        Console.WriteLine("You have:");
                        for (int n = 0; n < playerInventory.InventoryLength; n++)
                        {
                            if (playerInventory.inventory[n] != null)
                            {

                                //If there is something in the inventory, print it to the screen.
                                Console.WriteLine($"{n}: {playerInventory.inventory[n].Name}");
                            }

                            //This is for checking if theres nothing in the array.
                            else if (playerInventory.inventory == null)
                            {
                                Console.WriteLine("Sorry, you have nothing to offer me, would you like to look around? [Y] [N]");
                                _playerInteraction = Console.ReadLine();
                                playerInteraction = _playerInteraction.ToUpper();
                                if (playerInteraction == "Y")
                                {
                                    Program p = new Program();
                                    p.beginningMessage();
                                    i = 0;
                                }
                                else if (playerInteraction == "N")
                                {
                                    System.Environment.Exit(0);
                                }
                            }

                        }
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("Which item would you like to sell? [Write the number next to the item.]");
                        _playerInteraction = Console.ReadLine();
                        playerInteraction = _playerInteraction.ToUpper();

                        int playerSellValue = Convert.ToInt32(playerInteraction);

                        if (playerInventory.inventory[playerSellValue] != null)
                        {
                            playerInventory.inventory[playerSellValue].Print();
                            Console.WriteLine("");
                            Console.WriteLine("");

                            for (int o = 0; o < 1; o++)
                            {
                                Console.WriteLine($"I like the looks of this item, could i take it? You will get " +
                                $"{playerInventory.inventory[o].Cost} in return. Yes or No [Y] [N].");
                                _playerInteraction = Console.ReadLine();
                                playerInteraction = _playerInteraction.ToUpper();
                                for (int p = 0; p < 1; p++)
                                {
                                    if (playerInteraction == "Y")
                                    {
                                        newPlayerMoney = playerMoney + playerInventory.inventory[o].Cost;
                                        newShopKeeperMoney = shopKeeperMoney - playerInventory.inventory[o].Cost;
                                        Console.WriteLine("");
                                        Console.WriteLine("");
                                        Console.WriteLine($"Thank you, this is your new balence: {newPlayerMoney}.");
                                        Console.WriteLine("Would you like to continue? [Y] [N]");
                                        if (playerInteraction == "Y")
                                        {
                                            newPlayerMoney = playerMoney;
                                            newShopKeeperMoney = shopKeeperMoney;
                                            Program startAgain = new Program();
                                            startAgain.beginningMessage();
                                            i = 0;
                                        }
                                        else if (playerInteraction == "N")
                                        {
                                            Console.WriteLine("Goodbye.");
                                            System.Environment.Exit(0);
                                        }

                                        else
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("Can you repeat that? [Y] [N]");
                                            _playerInteraction = Console.ReadLine();
                                            playerInteraction = _playerInteraction.ToUpper();
                                            p = 0;

                                        }

                                    }
                                }

                            }


                        }

                    }
                    else if(playerInteraction != "S" || playerInteraction != "B")
                    {
                        //This is a incase funtion if the player does not write the correct word or letter.
                        Console.WriteLine("What did you say? Buy [B] or Sell [S]? Press the letter and then enter.");
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

            
    
