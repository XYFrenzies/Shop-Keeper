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

namespace Project_Assessment
{
    class Program
    {
        //This is adding the multiple different items into a list from the array. This list is from a function called Addinventory          
        //These are the different Items that will be available for you in the shop or on the player.
        //For weapons, the categories are displayed as Name, Weight, Cost, Range, Damage, AttackSpeed.
        static public Weapon longSwordOfDestiny = new Weapon("Long Sword Of Destiny", 20, 900, 20, 100, 1);//This will be put onto the shop Keeper
        static public Weapon deathbringerAxe = new Weapon("The Last DeathBringer", 25, 1000, 3, 150, 2);//This will be put onto the shop Keeper
        static public Weapon crossBow = new Weapon("Enchanted CrossBow of Truth", 10, 1000, 500, 70, 1);//This will be put onto the player
        static public Weapon goldenGloves = new Weapon("Speedy Golden Gloves", 1, 600, 1, 1000, 4);//This will be apart of the secret inventory

        // For armour the categories are displayed as Name, Weight, Cost, Type of Gear, Health, What it resists.
        static public Armour holyHeadGear = new Armour("The Holy Headset", 15, 500, "HeadGear", 250, "CrossBow");//This will be put onto the shop Keeper
        static public Armour holyChestPeice = new Armour("The Holy ChestGuard", 25, 900, "ChestPeice", 500, "CrossBow");//This will be put onto the shop Keeper
        static public Armour holyPants = new Armour("The Holy Leggings", 10, 600, "Leggings", 400, "CrossBow");//This will be put onto the player
        static public Armour holyShoes = new Armour("The Holy Boots", 2, 300, "Boots", 250, "CrossBow");//This will be apart of the secret inventory

        //For Potions, the categories are displayed as Name, Weight, Cost, Type of Potion, Stat changes, Description.
        static public Potion godAlmightyPotion = new Potion("God Almighty Potion", 1, 300, "gives you health of about ", 200,
            "Its so strong that it would only be used in a life or death situation.");//This will be put onto the shop Keeper
        static public Potion deadlyPoisonOfTheWest = new Potion("Deadly Poison of The West", 2, 1000,
            "deals increasing amounts of damage over 5 seconds, adding x2 damage each time", 20,
            "If you want a deadly toxin that can pressure anyone into fleeing this is the potion for you.");//This will be put onto the shop Keeper
        static public Potion theEnchantedPotion = new Potion("The Enchanted Potion of the Neverworlds", 1, 2000,
            "It increases the level of the player by", 1,
            "If your needing a high enough level for some of the upcoming fights this potion should do the trick.");//This will be put onto the player

        //This is split into two different arrays. One is for the shopkeeper, the other is for the player.
        //With reference to the inventory class, its the amount of space that the individual can hold.
        static public Inventory playerInventory = new Inventory(20); //This is the players inventory space defult at 20.
        static public Inventory shopKeeperInventory = new Inventory(25); //This is the shop keepers inventory space default at 25.
        static public Inventory shopKeeperSecretInventory = new Inventory(25);//This is holding the inventory of the shop keepers secret stash to the default 25.

        //This is a undefined variable that is used as part of the checking for what the player says.
        static public string _playerInteraction;
        private string playerInteraction;
        static public ulong playerMoney = 1000; //Default amounts of money that can be spent.
        static public ulong shopKeeperMoney = 1000; //Default amounts of money that the shop keeper can hold.        

        static public int counting = 0;


        //This is the main function of the program.
        static public void Main()
        {
            //This is commented out to restart the text files to the file.             
            FileExistStatement();
            beginningMessage();
            //This naturally begins the beginningmessage function.
        }

        //This function acts as a "If the player wants to leave, they can leave." If not, they can continue lookin in the shop.
        public void EndStatement()
        {
            for (int i = 0; i < 2; i++)
            {
                //This will return the players interaction back to the beginning of the begin message loop.
                Console.WriteLine("\nWould you like to continue looking around in the shop? [Y] [N]\n");
                _playerInteraction = Console.ReadLine();
                playerInteraction = _playerInteraction.ToUpper();
                switch (playerInteraction)
                {
                    case ("Y"):
                        //Console.Clear is to romove the words from the console so it is easier to see what is on the next version of the interaction.
                        Console.Clear();
                        beginningMessage();
                        //This is to call the function beginningmessage again
                        break;
                    case ("N"):
                        MovingArrayToFile();
                        System.Environment.Exit(0);
                        //This is to exit the console and the program when the player wants to exit.
                        break;
                    default:
                        //Incase the player does not produce the correct letter, y or n.
                        Console.WriteLine("\nSorry, let me say it again.");
                        i = 0;
                        break;
                }
            }
            
        }
        //This is a statement to help out the superuser function within the beginningmessage to catch any of the errors that the player may have done.
        static public void TryandCatch(ref ulong integerPlayerValue, string stringPlayerValue) 
        {
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    stringPlayerValue = Console.ReadLine();//The player is said to input a weapons range.
                    integerPlayerValue = Convert.ToUInt64(stringPlayerValue);//Converts the interaction to an integer.
                    break;
                }
                catch
                {
                    Console.WriteLine("Sorry, what did you say?");//In case an error occurs
                    i = 0;
                }
            }

        }


        //Beginningmessage is where all the dialouge and the movement between the different functions occur. This is referenced in the main function to start.
        
    }
}



