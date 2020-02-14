using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        Weapon[] weaponsArray = new Weapon[3] { longSwordOfDestiny, deathbringerAxe, crossBow };
        Armour[] armourArray = new Armour[3] { holyHeadGear, holyChestPeice, holyPants };
        Potion[] potionArray = new Potion[3] { godAlmightyPotion, deadlyPoisonOfTheWest, theEnchantedPotion };

        static void Main()
        {
            int i;
            if (!File.Exists("ShopKeeper.txt"))
            {
                StreamWriter shopKeeperValue;
                shopKeeperValue = new StreamWriter("ShopKeeper.txt");
                shopKeeperValue.WriteLine(longSwordOfDestiny);
                shopKeeperValue.WriteLine(deathbringerAxe);
                shopKeeperValue.WriteLine(crossBow);
                shopKeeperValue.WriteLine(holyHeadGear);
                shopKeeperValue.WriteLine(holyChestPeice);
                shopKeeperValue.WriteLine(holyPants);
                shopKeeperValue.WriteLine(godAlmightyPotion);
                shopKeeperValue.WriteLine(deadlyPoisonOfTheWest);
                shopKeeperValue.WriteLine(theEnchantedPotion);
                shopKeeperValue.Close();
            }

            else if (!File.Exists("Player.txt"))
            {
                StreamWriter playerValue;
                playerValue = new StreamWriter("Player.txt");
                playerValue.WriteLine(longSwordOfDestiny);
                playerValue.Close();

            }

           /* for (i = 0; i < 100; i++)
            {
                Console.ReadLine();

                if( )
            }/*/
            //This is the start of the checking of the input. Will take a few days to make sure that it works successfully.



            holyChestPeice.beginningMessage();
            Console.ReadKey();
        }
    }
}
