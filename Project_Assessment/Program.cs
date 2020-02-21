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
        static public string playerInteraction;

        static private int playerMoney = 1000; //Default amounts of money that can be spent.
        static private int shopKeeperMoney = 1000; //Default amounts of money that the shop keeper can hold.

        //THis is a quick and easy way to calculate the money transaction between the player, the item, the shopKeeper.
        static public int MoneyCalculator(int x, int y, int z)
        {
            //This quick addition is for when the money is taken from the player, it updates and from minusing from the price.
            x = x - y;
            z = z + x;
            return x;

        }

        public void CheckingYN()
        {
            
            for (int i = 0; i < 1; i++)
            {
                //This is for checking if the player has input Yes or No.
                if (playerInteraction.Contains("Y"))
                {
                    //If this is activated, use the calculation to activate the cost of the item and minus it from the pla
                    //Program.MoneyCalculator(playerMoney, shopKeeper.inventory.Cost , shopKeeperMoney);
                    break;
                }
                else if (playerInteraction.Contains("N"))
                {
                    //This will return the players interaction back to the beginning of the begin message loop.
                    Console.WriteLine("Would you like to continue looking around in the shop? [Y] [N]");

                    if (playerInteraction.Contains("Y"))
                    {
                        Program p = new Program();
                        p.beginningMessage();
                    }

                    else if (playerInteraction.Contains("N"))
                    {
                        System.Environment.Exit(0);
                    }

                }

                else
                {
                    Console.WriteLine("Stop Wasting my time, tell me Y or N if you want something!");
                    //In case this doesnt work.
                }
            }
        }



        static public void Main()
        {
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

            if (!File.Exists("Player.txt"))
            {
                //This is to create a player text file.
                StreamWriter playerValue;
                playerValue = new StreamWriter("Player.txt");
                playerValue.WriteLine("Long Sword Of Destiny");
                playerValue.Close();

            }

            Program p = new Program();
            p.beginningMessage();

        }


            public virtual void beginningMessage()
            {

            for (int i = 0; i < 20; i++)
            {
                //This will be the beginning dialogue of the program.
                Console.WriteLine("Welcome young traveller. How can I help you today?");
                Console.WriteLine("I have a range of goods that might interest you.");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("The goods that I have available are Armour, weapons of any kind and potions.");
                Console.WriteLine("Hope I encapsulate your taste of equipment.");
                Console.WriteLine("");
                Console.WriteLine("What would you like to look at first?");
                Console.WriteLine("Options are: ");


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


                for (int k = 0; k < shopKeeperInventory.InventoryLength; k++)
                {
                    if (shopKeeperInventory.inventory[k] != null)
                    {
                        Console.WriteLine($"{k}: {shopKeeperInventory.inventory[k].Name}");

                    }
                }


                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Would you like to have a look at any of these? [Write the number next to the item.]");
                playerInteraction = Console.ReadLine();
                //This is a check for if the playersInteraction is the same as the shopKeeper, then the print function will work.
                int playerValue = Convert.ToInt32(playerInteraction);
                if (shopKeeperInventory.inventory[playerValue] != null)
                {
                    shopKeeperInventory.inventory[playerValue].Print();

                    Console.WriteLine("You have, $" + playerMoney + ".");
                    Console.WriteLine("What would you like to shop for now player or would you like to sell? [B], [S]");

                    Program.playerInteraction = Console.ReadLine();


                    for (int j = 0; j < 100; j++)
                    {

                        if (Program.playerInteraction.Contains("B"))
                        {
                            Console.WriteLine("Would you like to buy this item? [Y] [N]");
                            Program.playerInteraction = Console.ReadLine();
                            Program checkingYN = new Program();
                            checkingYN.CheckingYN();

                            Console.WriteLine("Done, you have " + playerMoney + " left. Would you like to continue? [Y] [N]");
                            break;

                        }
                        else if (Program.playerInteraction.Contains("S"))
                        {
                            //Need to implement a sell function and the lot
                        }
                        else
                        {
                            Console.WriteLine("What did you say? Buy [B] or Sell [S]? Press the letter and then enter.");
                            Program.playerInteraction = Console.ReadLine();
                            j = 0;
                        }
                    }



                }
                else
                {

                }




                }


            }
    }
}

            
    
