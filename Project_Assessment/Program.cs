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
        static public Weapon longSwordOfDestiny = new Weapon("Long Sword Of Destiny", 20, 900, 20, 100, 1);
        static public Weapon deathbringerAxe = new Weapon("The Last DeathBringer", 25, 1000, 3, 150, 2);
        static public Weapon crossBow = new Weapon("Enchanted CrossBow of Truth", 10, 1000, 500, 70, 1);
        static public Armour holyHeadGear = new Armour("The Holy Headset", 15, 500, "HeadGear", 250, "CrossBow");
        static public Armour holyChestPeice = new Armour("The Holy ChestGuard", 25, 900, "ChestPeice", 500, "CrossBow");
        static public Armour holyPants = new Armour("The Holy Leggings", 10, 600, "Leggings", 400, "CrossBow");
        static public Potion godAlmightyPotion = new Potion("God Almighty Potion", 1, 300, "It gives you health of about ", 200,
            "Its so strong that it would only be used in a life or death situation.");
        static public Potion deadlyPoisonOfTheWest = new Potion("Deadly Poison of The West", 2, 1000,
            "Deals increasing amounts of damage over 5 seconds, adding x2 damage each time", 20,
            "If you want a deadly toxin that can pressure anyone into fleeing, this is the potion for you.");
        static public Potion theEnchantedPotion = new Potion("The Enchanted Potion of the Neverworlds", 1, 2000,
            "It increases the level of the player by 1", 1,
            "If your needing a high enough level for some of the upcoming fights, this potion should do the trick.");

        //This is split into two different arrays. One is for the shopkeeper, the other is for the player.
        static public Items[] itemArrayShopKeeper = new Items[] { longSwordOfDestiny, deathbringerAxe,  
            holyChestPeice, holyPants, godAlmightyPotion, deadlyPoisonOfTheWest, theEnchantedPotion};
        static public Items[] itemArrayPlayer = new Items[] { crossBow, holyHeadGear};    

        //This is a undefined variable that is used as part of the checking for what the player says.
        static public string playerInteraction;

        static public void CheckingForItemsInShop(Items[] items)
        {

            //This is asking for a player input for what type of weapon you would need.
            for (int i = 0; i < 1; i++)
            {

                if (playerInteraction = items[Name])
                {
                    //This is asking that if the players input is the same as the name of the weapon in the array, print out this line.
                    Console.WriteLine("" + Name + " is worth $" + Cost + " and it weighs " + Weight + ".");
                    Console.WriteLine("");
                    i++;
                }
                else
                {
                    //This is a statement incase the player does not corectly write the correct name of the potion/weapon/armour.
                    Console.WriteLine("Sorry could you repeat that again?");

                    i = 0;
                }
            }
        }

        static public int MoneyCalculator(int x, int y, int z)
        {
            //This quick addition is for when the money is taken from the player, it updates and from minusing from the price.
            x = x - y;
            z = z + x;
            return x;

        }

        static public void CheckingYN()
        {
            //This is for checking if the player has input Yes or No.
            if (playerInteraction = Console.ReadKey("Y"))
            {
                
            }
            else if (playerInteraction = Console.ReadKey("N"))
            {
                
            }

            else 
            {
                Console.WriteLine("Stop Wasting my time, tell me Y or N if you want something!");
            }
        }

        static public void Main()
        {


            if (!File.Exists("ShopKeeper.txt"))
            {
                //Within this, it creates a text file called shopkeeper that keeps the inventory of the shopkeeper.
                StreamWriter shopKeeperValue;
                shopKeeperValue = new StreamWriter("ShopKeeper.txt");
                shopKeeperValue.WriteLine("Long Sword Of Destiny");
                shopKeeperValue.WriteLine("Deathbringer Axe");
                shopKeeperValue.WriteLine("CrossBow");
                shopKeeperValue.WriteLine("Holy HeadGear");
                shopKeeperValue.WriteLine("Holy ChestPeice");
                shopKeeperValue.WriteLine("Holy Pants");
                shopKeeperValue.WriteLine("God Almighty Potion");
                shopKeeperValue.WriteLine("DeadlyPoisonOfTheWest");
                shopKeeperValue.WriteLine("The Enchanted Potion");

                //DataTable datatable = new DataTable();
               // StreamReader

                shopKeeperValue.Close();
            }

            else if (!File.Exists("Player.txt"))
            {
                //This is to 
                StreamWriter playerValue;
                playerValue = new StreamWriter("Player.txt");
                playerValue.WriteLine("Long Sword Of Destiny");
                playerValue.Close();

            }

            holyChestPeice.beginningMessage();
            Console.ReadKey();
        }
    }
}
