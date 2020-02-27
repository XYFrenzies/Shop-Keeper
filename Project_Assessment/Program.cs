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
            playerInventory.AddInventory(crossBow, holyHeadGear);//The players Inventory
            shopKeeperInventory.AddInventory(longSwordOfDestiny, deathbringerAxe,
            holyChestPeice, holyPants, godAlmightyPotion, deadlyPoisonOfTheWest, theEnchantedPotion);//The shopKeepers Inventory

            Program fileManagement = new Program();
            fileManagement.CreatingFiles();


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
            {//Going through the length of the array buyer
                if (a_buyer[j] == null)
                {
                    //If the space of the buyer is blank...
                    a_buyer[j] = a_seller[newLocation];//The buyer's inventory location = the sellers inventory location (swapping the locations).
                    a_seller[newLocation] = null;//This is replacing the sellers item with nothing and leaving it null.

                    return;
                }
            }

        }


        public void CreatingFiles()
        {
            //This is to save the array of shopKeeper items onto a text file called ShopKeeper.txt
            if (!File.Exists("ShopKeeper.txt"))
            {//If the shopKeeper text doesnt exist...
                StreamWriter shopKeeperWriter;
                shopKeeperWriter = new StreamWriter("ShopKeeper.txt");//Create the text file shopKeeper.

                for (int i = 0; i < shopKeeperInventory.InventoryLength; i++)
                {//Going through the length of the array of the shopKeeper inventory.
                    if (shopKeeperInventory.inventory[i] != null)
                    {//This checks is the inventory is not equal to nothing.
                        //This is a manual way of placing the values of the items onto the text file.
                        string theItemTypeSK = shopKeeperInventory.inventory[i].GetType().ToString();//The type of string is defined first.
                        string theNameSK = shopKeeperInventory.inventory[i].Name;//This is the name of the item.
                        int theCostSK = shopKeeperInventory.inventory[i].Cost;//This is the cost of the item.
                        int theWeightSK = shopKeeperInventory.inventory[i].Weight;//This is the Weight of the item.
                        string theAdditionalInfoSK = "";//This is the attributes of the other variables that are with the class/Item.

                        switch (theItemTypeSK)//Depending on the type within the inventory.
                        {
                            //This is the switch statement for when the item type is changed when its displayed to the text file. 
                            case "Project_Assessment.Weapons"://Accessing the weapons class under the project assessment.
                                Weapon redefinedWeaponSK = (Weapon)shopKeeperInventory.inventory[i];//Defining redefinedWeaponSK is a weapon within the shopKeeperInventory.
                                theAdditionalInfoSK = redefinedWeaponSK.Range.ToString();//Adds the range to the text file and uses it as a string.
                                theAdditionalInfoSK = redefinedWeaponSK.Damage.ToString();//Adds the damage to the text file and uses it as a string.
                                theAdditionalInfoSK = redefinedWeaponSK.AttackSpeed.ToString();//Adds the AttackSpeed to the text file and uses it as a string.
                                break;//Leaves the array.

                            case "Project_Assessment.Armour"://Accessing the Armour class under the project assessment.
                                Armour redefinedArmourSK = (Armour)shopKeeperInventory.inventory[i];//Defining redefinedArmourSK is a armour within the shopKeeperInventory.
                                theAdditionalInfoSK = redefinedArmourSK.ArmourType.ToString();//Adds the ArmourType to the text file and uses it as a string.
                                theAdditionalInfoSK = redefinedArmourSK.ArmourHealth.ToString();//Adds the ArmourHealth to the text file and uses it as a string.
                                theAdditionalInfoSK = redefinedArmourSK.ArmourResistence.ToString();//Adds the ArmourResistence to the text file and uses it as a string.
                                break;//Leaves the array.

                            case "Project_Assessment.Potions"://Accessing the Potions class under the project assessment.
                                Potion redefinedPotionsSK = (Potion)shopKeeperInventory.inventory[i];//Defining redefinedPotionsSK is a potion within the shopKeeperInventory.
                                theAdditionalInfoSK = redefinedPotionsSK.TypeOfPotion.ToString();//Adds the TypeOfPotion to the text file and uses it as a string.
                                theAdditionalInfoSK = redefinedPotionsSK.ChangedStatsOfPotion.ToString();//Adds the ChangeStatsOfPotion to the text file and uses it as a string.
                                theAdditionalInfoSK = redefinedPotionsSK.PotionDescription.ToString();//Adds the PotionDescription to the text file and uses it as a string.
                                break;//Leaves the array.

                            default://If neither of the case statements are true.
                                break;//Leaves the array.

                        }

                        //This displays on the writeLine, the item type, the name, the cost, the weight, and the additional information from the child classes.
                        shopKeeperWriter.WriteLine($"{theItemTypeSK},{theNameSK},{theCostSK},{theWeightSK},{theAdditionalInfoSK}");
                    }
                }
                //Closes the writer so that it stops writing.
                shopKeeperWriter.Close();
            }
            //This is to save the array of player items onto a text file called player.txt
            if (!File.Exists("Player.txt"))
            {//If the player text doesnt exist...
                //Create a new file called player.txt
                StreamWriter playerWriter;
                playerWriter = new StreamWriter("Player.txt");

                for (int j = 0; j < playerInventory.InventoryLength; j++)
                {//THis is a loop of the players inventory length and the items within that array.
                    if (playerInventory.inventory[j] != null)
                    {//If it isnt equal to null.
                        string theItemTypeP = playerInventory.inventory[j].GetType().ToString();//The type of string is defined first.
                        string theNameP = playerInventory.inventory[j].Name;//This is the name of the item.
                        int theCostP = playerInventory.inventory[j].Cost;//This is the cost of the item.
                        int theWeightP = playerInventory.inventory[j].Weight;//This is the Weight of the item.
                        string theAdditionalInfoP = "";//This is the attributes of the other variables that are with the class/Item.

                        //This is the switch statement for when the item type is changed when its displayed to the text file. 
                        switch (theItemTypeP)//Depending on the type within the inventory.
                        {
                            case "Project_Assessment.Weapons"://Accessing the weapons class under the project assessment.
                                Weapon redefinedWeaponP = (Weapon)playerInventory.inventory[j];//Defining redefinedWeaponP is a weapon within the playerInventory.
                                theAdditionalInfoP = redefinedWeaponP.Range.ToString();//Adds the range to the text file and uses it as a string.
                                theAdditionalInfoP = redefinedWeaponP.Damage.ToString();//Adds the Damage to the text file and uses it as a string.
                                theAdditionalInfoP = redefinedWeaponP.AttackSpeed.ToString();//Adds the AttackSpeed to the text file and uses it as a string.
                                break;//Leaves the array.

                            case "Project_Assessment.Armour":
                                Armour redefinedArmourP = (Armour)playerInventory.inventory[j];//Defining redefinedArmourP is a weapon within the playerInventory.
                                theAdditionalInfoP = redefinedArmourP.ArmourType.ToString();//Adds the ArmourType to the text file and uses it as a string.
                                theAdditionalInfoP = redefinedArmourP.ArmourHealth.ToString();//Adds the ArmourHealth to the text file and uses it as a string.
                                theAdditionalInfoP = redefinedArmourP.ArmourResistence.ToString();//Adds the ArmourResistence to the text file and uses it as a string.
                                break;//Leaves the array.

                            case "Project_Assessment.Potions":
                                Potion redefinedPotionsP = (Potion)playerInventory.inventory[j];//Defining redefinedPotionsP is a weapon within the playerInventory.
                                theAdditionalInfoP = redefinedPotionsP.TypeOfPotion.ToString();//Adds the TypeOfPoions to the text file and uses it as a string.
                                theAdditionalInfoP = redefinedPotionsP.ChangedStatsOfPotion.ToString();//Adds the ChangedStatsOfPotion to the text file and uses it as a string.
                                theAdditionalInfoP = redefinedPotionsP.PotionDescription.ToString();//Adds the PotionDescription to the text file and uses it as a string.
                                break;//Leaves the array.

                            default://If neither of the case statements are true.
                                break;//Leaves the array.
                        }
                        //This displays on the writeLine, the item type, the name, the cost, the weight, and the additional information from the child classes.
                        playerWriter.WriteLine($"{theItemTypeP},{theNameP},{theCostP},{theWeightP},{theAdditionalInfoP}");
                    }
                    
                }
                //Closes the writer so that it stops writing.
                playerWriter.Close();
            }
        }

        //This function is for the loading of the array items back onto the array.
        //This will act as a save file.

        //public static void LoadingInventoryFromFile(string newFileName)
        //{
        //    try
        //    {
        //        StreamWriter reader = new StreamWriter(newFileName);
        //        while (reader.EndOfStream == false)
        //        {
        //            string reading = reader.ReadLine();
        //            string[] args = reading.Split(",");
        //        }
        //    }
        //    catch ()
        //    {

        //    }

        //}

        public virtual void beginningMessage()
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
                    if (playerInteraction == "B")
                    {//If the player presses b or B.
                        for (int k = 0; k < shopKeeperInventory.InventoryLength; k++)
                        {//This is checking through the shopKeepers inventory length of the array.
                            if (shopKeeperInventory.inventory[k] != null)
                            {//If the shopKeeper does have stuff in stock.
                                //If there is something in the inventory, print it to the screen.
                                Console.WriteLine($"{k}: {shopKeeperInventory.inventory[k].Name} which cost {shopKeeperInventory.inventory[k].Cost} coins.");
                                //This is printing for every item name, a number before it and the cost of it.
                            }
                        }
                        //This is to check if the player wants to buy the item by the item number before it.
                        Console.WriteLine("\nWould you like to have a look at any of these? [Write the number next to the item.]\n");
                        playerInteraction = Console.ReadLine();

                        //We dont need a _playerinteraction and the toupper as we need a integer not a string to compare.
                        //This is a check for if the playersInteraction is the same as the shopKeeper, then the print function will work.
                        int playerValue = Convert.ToInt32(playerInteraction);
                        //If the inventory space of the playervalue has something in it, then it will display whats in the statement.
                        if (shopKeeperInventory.inventory[playerValue] != null)
                        {
                            //This uses the function within inventory called print.
                            //Within every other class, the use of overrride is being able to read the line called print.
                            //Allowing that when the player presses a value, that it receives the value and it displays a message from the classes.
                            shopKeeperInventory.inventory[playerValue].Print();//This is calling the function print from inventory which is a overrride to all the other classes.
                            Console.WriteLine("\nYou have, $" + playerMoney + ".\n");//Showing the players money.
                            Console.WriteLine("Do you want to buy this item? Yes or No. [Y] [N]");
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

                                    Program buyerArrayChange = new Program();//This is creating buyerArrayChange to a definition of calling a function.
                                    buyerArrayChange.MovingArrays(ref shopKeeperInventory.inventory, ref playerInventory.inventory, playerValue);
                                    //This is called when a transaction occurs. 
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
                                    Console.WriteLine($"\nSorry you do not have enough money for {shopKeeperInventory.inventory[playerValue].Name}.");
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
            }
        }
    }
}

            
    
