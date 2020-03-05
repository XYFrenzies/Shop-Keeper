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
        //This is adding the multiple different items into a list from the array. This list is from a function called Addinventory          
        //These are the different Items that will be available for you in the shop or on the player.
        //For weapons, the categories are displayed as Name, Weight, Cost, Range, Damage, AttackSpeed.
        public Weapon longSwordOfDestiny = new Weapon("Long Sword Of Destiny", 20, 900, 20, 100, 1);//This will be put onto the shop Keeper
        public Weapon deathbringerAxe = new Weapon("The Last DeathBringer", 25, 1000, 3, 150, 2);//This will be put onto the shop Keeper
        public Weapon crossBow = new Weapon("Enchanted CrossBow of Truth", 10, 1000, 500, 70, 1);//This will be put onto the player
        public Weapon goldenGloves = new Weapon("Speedy Golden Gloves", 1, 600, 1, 1000, 4);//This will be apart of the secret inventory

        // For armour the categories are displayed as Name, Weight, Cost, Type of Gear, Health, What it resists.
        public Armour holyHeadGear = new Armour("The Holy Headset", 15, 500, "HeadGear", 250, "CrossBow");//This will be put onto the shop Keeper
        public Armour holyChestPeice = new Armour("The Holy ChestGuard", 25, 900, "ChestPeice", 500, "CrossBow");//This will be put onto the shop Keeper
        public Armour holyPants = new Armour("The Holy Leggings", 10, 600, "Leggings", 400, "CrossBow");//This will be put onto the player
        public Armour holyShoes = new Armour("The Holy Boots", 2, 300, "Boots", 250, "CrossBow");//This will be apart of the secret inventory

        //For Potions, the categories are displayed as Name, Weight, Cost, Type of Potion, Stat changes, Description.
        public Potion godAlmightyPotion = new Potion("God Almighty Potion", 1, 300, "gives you health of about ", 200,
            "Its so strong that it would only be used in a life or death situation.");//This will be put onto the shop Keeper
        public Potion deadlyPoisonOfTheWest = new Potion("Deadly Poison of The West", 2, 1000,
            "deals increasing amounts of damage over 5 seconds, adding x2 damage each time", 20,
            "If you want a deadly toxin that can pressure anyone into fleeing this is the potion for you.");//This will be put onto the shop Keeper
        public Potion theEnchantedPotion = new Potion("The Enchanted Potion of the Neverworlds", 1, 2000,
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
        static public int playerMoney = 1000; //Default amounts of money that can be spent.
        static public int shopKeeperMoney = 1000; //Default amounts of money that the shop keeper can hold.        

        //This is the main function of the program.
        static public void Main()
        {
            //This is commented out to restart the text files to the file. 
            Program fileExists = new Program();
            fileExists.FileExistStatement();

            beginningMessage();
            //This naturally begins the beginningmessage function.
        }

        //This function is used so that it doesnt have to be put into the main program directly but rather indirectly.
        public void FileExistStatement()
        {
            //This checks if the shopKeeper and player text's exist. If so execute the program.
            if(File.Exists("ShopKeeper.txt") && File.Exists("Player.txt") && File.Exists("SecretShopKeeper.txt"))
            {
                //This will load the files of shopKeeper and player text via thr loadingInventoryFromFile function.
                LoadingInventoryFromFile("ShopKeeper.txt", ref shopKeeperInventory);
                LoadingInventoryFromFile("Player.txt", ref playerInventory);
                LoadingInventoryFromFile("SecretShopKeeper.txt", ref shopKeeperSecretInventory);

            }
            //This check executes if neither of the two files exist. 
            else if(!File.Exists("ShopKeeper.txt") && !File.Exists("Player.txt") && !File.Exists("SecretShopKeeper.txt"))
            {
                //This will add these items to the inventory of the player and shopKeeper.
                playerInventory.AddInventory(crossBow, holyPants, theEnchantedPotion);
                shopKeeperInventory.AddInventory(longSwordOfDestiny, deathbringerAxe, holyHeadGear, holyChestPeice, godAlmightyPotion, deadlyPoisonOfTheWest);
                shopKeeperSecretInventory.AddInventory(goldenGloves, holyShoes);

            }
            else    
            {
                //Incase neither of these statements work, it means that the player or the shopKeeper text file didnt load properly.
                Console.WriteLine("One or two of the three text files didnt load properly.");
            }
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
                beginningMessage();

                //This is to call the function beginningmessage again

            }
            else if (playerInteraction == "N")
            {
                MovingArrayToFile();
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



        static public void MovingArrays(ref Item[] a_seller, ref Item[] a_buyer, int newLocation)
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
        static public void MovingArrayToFile()
        {
            //This is to save the array of shopKeeper items onto a text file called ShopKeeper.txt

            //If the shopKeeper text doesnt exist...
            StreamWriter shopKeeperWriter = new StreamWriter("ShopKeeper.txt");//Create the text file shopKeeper.

            for (int i = 0; i < shopKeeperInventory.InventoryLength; i++)
            {//Going through the length of the array of the shopKeeper inventory.
                if (shopKeeperInventory.inventory[i] != null)
                {//This checks is the inventory is not equal to nothing.
                 //This is a manual way of placing the values of the items onto the text file.
                    string theItemTypeSK = shopKeeperInventory.inventory[i].GetType().ToString();//The type of string is defined first.
                    string theNameSK = shopKeeperInventory.inventory[i].Name;//This is the name of the item.
                    int theWeightSK = shopKeeperInventory.inventory[i].Weight;//This is the Weight of the item.
                    int theCostSK = shopKeeperInventory.inventory[i].Cost;//This is the cost of the item.
                    string a1 = "|";//This is the attributes of the other variables that are with the class/Item.
                    string a2 = "|";
                    string a3 = "|";

                    switch (theItemTypeSK)//Depending on the type within the inventory.
                    {
                        //This is the switch statement for when the item type is changed when its displayed to the text file. 
                        case "Project_Assessment.Weapon"://Accessing the weapons class under the project assessment.
                            Weapon redefinedWeaponSK = (Weapon)shopKeeperInventory.inventory[i];//Defining redefinedWeaponSK is a weapon within the shopKeeperInventory.
                            a1 = redefinedWeaponSK.Range.ToString();//Adds the range to the text file and uses it as a string.
                            a2 = redefinedWeaponSK.Damage.ToString();//Adds the damage to the text file and uses it as a string.
                            a3 = redefinedWeaponSK.AttackSpeed.ToString();//Adds the AttackSpeed to the text file and uses it as a string.
                            break;//Leaves the array.

                        case "Project_Assessment.Armour"://Accessing the Armour class under the project assessment.
                            Armour redefinedArmourSK = (Armour)shopKeeperInventory.inventory[i];//Defining redefinedArmourSK is a armour within the shopKeeperInventory.
                            a1 = redefinedArmourSK.ArmourType.ToString();//Adds the ArmourType to the text file and uses it as a string.
                            a2 = redefinedArmourSK.ArmourHealth.ToString();//Adds the ArmourHealth to the text file and uses it as a string.
                            a3 = redefinedArmourSK.ArmourResistence.ToString();//Adds the ArmourResistence to the text file and uses it as a string.
                            break;//Leaves the array.

                        case "Project_Assessment.Potion"://Accessing the Potions class under the project assessment.
                            Potion redefinedPotionsSK = (Potion)shopKeeperInventory.inventory[i];//Defining redefinedPotionsSK is a potion within the shopKeeperInventory.
                            a1 = redefinedPotionsSK.TypeOfPotion.ToString();//Adds the TypeOfPotion to the text file and uses it as a string.
                            a2 = redefinedPotionsSK.ChangedStatsOfPotion.ToString();//Adds the ChangeStatsOfPotion to the text file and uses it as a string.
                            a3 = redefinedPotionsSK.PotionDescription.ToString();//Adds the PotionDescription to the text file and uses it as a string.
                            break;//Leaves the array.

                        default://If neither of the case statements are true.
                            break;//Leaves the array.

                    }

                    //This displays on the writeLine, the item type, the name, the cost, the weight, and the additional information from the child classes.
                    shopKeeperWriter.WriteLine($"{theItemTypeSK}|{theNameSK}|{theWeightSK}|{theCostSK}|{a1}|{a2}|{a3}");
                }
            }
            //Closes the writer so that it stops writing. Also flushes it to the text file before it closes the program.
            shopKeeperWriter.Flush();
            shopKeeperWriter.Close();

            //This is to save the array of player items onto a text file called player.txt
            //If the player text doesnt exist...
            //Create a new file called player.txt
            StreamWriter playerWriter = new StreamWriter("Player.txt");

            for (int j = 0; j < playerInventory.InventoryLength; j++)
            {//THis is a loop of the players inventory length and the items within that array.
                if (playerInventory.inventory[j] != null)
                {//If it isnt equal to null.
                    string theItemTypeP = playerInventory.inventory[j].GetType().ToString();//The type of string is defined first.
                    string theNameP = playerInventory.inventory[j].Name;//This is the name of the item.
                    int theWeightP = playerInventory.inventory[j].Weight;//This is the Weight of the item.
                    int theCostP = playerInventory.inventory[j].Cost;//This is the cost of the item.
                    string a1 = "|";//This is the attributes of the other variables that are with the class/Item.
                    string a2 = "|";
                    string a3 = "|";

                    //This is the switch statement for when the item type is changed when its displayed to the text file. 
                    switch (theItemTypeP)//Depending on the type within the inventory.
                    {
                        case "Project_Assessment.Weapon"://Accessing the weapons class under the project assessment.
                            Weapon redefinedWeaponP = (Weapon)playerInventory.inventory[j];//Defining redefinedWeaponP is a weapon within the playerInventory.
                            a1 = redefinedWeaponP.Range.ToString();//Adds the range to the text file and uses it as a string.
                            a2 = redefinedWeaponP.Damage.ToString();//Adds the Damage to the text file and uses it as a string.
                            a3 = redefinedWeaponP.AttackSpeed.ToString();//Adds the AttackSpeed to the text file and uses it as a string.
                            break;//Leaves the array.

                        case "Project_Assessment.Armour":
                            Armour redefinedArmourP = (Armour)playerInventory.inventory[j];//Defining redefinedArmourP is a weapon within the playerInventory.
                            a1 = redefinedArmourP.ArmourType.ToString();//Adds the ArmourType to the text file and uses it as a string.
                            a2 = redefinedArmourP.ArmourHealth.ToString();//Adds the ArmourHealth to the text file and uses it as a string.
                            a3 = redefinedArmourP.ArmourResistence.ToString();//Adds the ArmourResistence to the text file and uses it as a string.
                            break;//Leaves the array.

                        case "Project_Assessment.Potion":
                            Potion redefinedPotionsP = (Potion)playerInventory.inventory[j];//Defining redefinedPotionsP is a weapon within the playerInventory.
                            a1 = redefinedPotionsP.TypeOfPotion.ToString();//Adds the TypeOfPoions to the text file and uses it as a string.
                            a2 = redefinedPotionsP.ChangedStatsOfPotion.ToString();//Adds the ChangedStatsOfPotion to the text file and uses it as a string.
                            a3 = redefinedPotionsP.PotionDescription.ToString();//Adds the PotionDescription to the text file and uses it as a string.
                            break;//Leaves the array.

                        default://If neither of the case statements are true.
                            break;//Leaves the array.
                    }
                    //This displays on the writeLine, the item type, the name, the cost, the weight, and the additional information from the child classes.
                    playerWriter.WriteLine($"{theItemTypeP}|{theNameP}|{theWeightP}|{theCostP}|{a1}|{a2}|{a3}");
                }

            }
            //Closes the writer so that it stops writing. Also flushes it to the text file before it closes the program.
            playerWriter.Flush();
            playerWriter.Close();

            StreamWriter secretShopKeeperWriter = new StreamWriter("SecretShopKeeper.txt");//Create the text file shopKeeper.

            for (int k = 0; k < shopKeeperSecretInventory.InventoryLength; k++)
            {//Going through the length of the array of the shopKeeper inventory.
                if (shopKeeperSecretInventory.inventory[k] != null)
                {//This checks is the inventory is not equal to nothing.
                 //This is a manual way of placing the values of the items onto the text file.
                    string theItemTypeSSK = shopKeeperSecretInventory.inventory[k].GetType().ToString();//The type of string is defined first.
                    string theNameSSK = shopKeeperSecretInventory.inventory[k].Name;//This is the name of the item.
                    int theWeightSSK = shopKeeperSecretInventory.inventory[k].Weight;//This is the Weight of the item.
                    int theCostSSK = shopKeeperSecretInventory.inventory[k].Cost;//This is the cost of the item.
                    string a1 = "|";//This is the attributes of the other variables that are with the class/Item.
                    string a2 = "|";
                    string a3 = "|";

                    switch (theItemTypeSSK)//Depending on the type within the inventory.
                    {
                        //This is the switch statement for when the item type is changed when its displayed to the text file. 
                        case "Project_Assessment.Weapon"://Accessing the weapons class under the project assessment.
                            Weapon redefinedWeaponSSK = (Weapon)shopKeeperSecretInventory.inventory[k];//Defining redefinedWeaponSK is a weapon within the shopKeeperInventory.
                            a1 = redefinedWeaponSSK.Range.ToString();//Adds the range to the text file and uses it as a string.
                            a2 = redefinedWeaponSSK.Damage.ToString();//Adds the damage to the text file and uses it as a string.
                            a3 = redefinedWeaponSSK.AttackSpeed.ToString();//Adds the AttackSpeed to the text file and uses it as a string.
                            break;//Leaves the array.

                        case "Project_Assessment.Armour"://Accessing the Armour class under the project assessment.
                            Armour redefinedArmourSSK = (Armour)shopKeeperSecretInventory.inventory[k];//Defining redefinedArmourSK is a armour within the shopKeeperInventory.
                            a1 = redefinedArmourSSK.ArmourType.ToString();//Adds the ArmourType to the text file and uses it as a string.
                            a2 = redefinedArmourSSK.ArmourHealth.ToString();//Adds the ArmourHealth to the text file and uses it as a string.
                            a3 = redefinedArmourSSK.ArmourResistence.ToString();//Adds the ArmourResistence to the text file and uses it as a string.
                            break;//Leaves the array.

                        case "Project_Assessment.Potion"://Accessing the Potions class under the project assessment.
                            Potion redefinedPotionsSSK = (Potion)shopKeeperSecretInventory.inventory[k];//Defining redefinedPotionsSK is a potion within the shopKeeperInventory.
                            a1 = redefinedPotionsSSK.TypeOfPotion.ToString();//Adds the TypeOfPotion to the text file and uses it as a string.
                            a2 = redefinedPotionsSSK.ChangedStatsOfPotion.ToString();//Adds the ChangeStatsOfPotion to the text file and uses it as a string.
                            a3 = redefinedPotionsSSK.PotionDescription.ToString();//Adds the PotionDescription to the text file and uses it as a string.
                            break;//Leaves the array.

                        default://If neither of the case statements are true.
                            break;//Leaves the array.

                    }

                    //This displays on the writeLine, the item type, the name, the cost, the weight, and the additional information from the child classes.
                    secretShopKeeperWriter.WriteLine($"{theItemTypeSSK}|{theNameSSK}|{theWeightSSK}|{theCostSSK}|{a1}|{a2}|{a3}");
                }
            }
            //Closes the writer so that it stops writing. Also flushes it to the text file before it closes the program.
            secretShopKeeperWriter.Flush();
            secretShopKeeperWriter.Close();



        }

        //This function is for the loading of the array items back onto the array.
        //This will act as a save file.

        static public void LoadingInventoryFromFile(string newFileName, ref Inventory inv)
        {
            //This is the function for loading the text file onto a array and rewriting the default one every time you open the program.
            if (File.Exists(newFileName))
            {
                //Withing this feature, the called variable newFileName is defined as the streamReader called reader.
                StreamReader reader = new StreamReader(newFileName);
                while (reader.EndOfStream == false)
                {//Whilst the reader of the streamReader newFileName is not at the end of the text file.
                    string reading = reader.ReadLine();//This saves the line called reading.
                    string[] args = reading.Split('|');//Splits the variables using the commers.

                    string projectDefiner = args[0];//Grabs the file location of the different items so that it can be defined within a case statement.

                    switch (projectDefiner)
                    {
                        case "Project_Assessment.Weapon"://If the projectDefiner is named Project_Assessment.Weapon...
                                                         //Converting a string to a int.
                            int convertToIntWeightW = Int32.Parse(args[2]);//Converting the weapon weight to a int from string.
                            int convertToIntCostW = Int32.Parse(args[3]);//Converting the weapon Cost to a int from string.
                            int convertToIntRangeW = Int32.Parse(args[4]);//Converting the weapon Range to a int from string.
                            int convertToIntDamageW = Int32.Parse(args[5]);//Converting the weapon Damage to a int from string.
                            int convertToIntAttackSpeedW = Int32.Parse(args[6]);//Converting the weapon AttackSpeed to a int from string.


                            //For weapons, the categories are displayed as Name, Weight, Cost, Range, Damage, AttackSpeed.
                            Item tempWeap = new Weapon(args[1], convertToIntWeightW, convertToIntCostW, convertToIntRangeW, convertToIntDamageW, convertToIntAttackSpeedW);

                            inv.AddInventory(tempWeap);
                            break;//Leaves the array.

                        case "Project_Assessment.Armour"://If the projectDefiner is named Project_Assessment.Armour...
                            int convertToIntWeightA = Int32.Parse(args[2]);//Converting the Armour weight to a int from string.
                            int convertToIntCostA = Int32.Parse(args[3]);//Converting the Armour Cost to a int from string.
                            int convertToIntHealthA = Int32.Parse(args[5]);//Converting the Armour Health to a int from string.


                            //For Armour, the categories are displayed as Name, Weight, Cost, Type of Gear, Health, What it resists.
                            Item tempArmour = new Armour(args[1], convertToIntWeightA, convertToIntCostA, args[4], convertToIntHealthA, args[6]);
                            inv.AddInventory(tempArmour);
                            break;//Leaves the array.

                        case "Project_Assessment.Potion"://If the projectDefiner is named Project_Assessment.Potion...
                                                         //For Potions, the categories are displayed as Name, Weight, Cost, Type of Potion, Stat changes, Description.
                            int convertToIntWeightP = Int32.Parse(args[2]);//Converting the Potion weight to a int from string.
                            int convertToIntCostP = Int32.Parse(args[3]);//Converting the Potion Cost to a int from string.
                            int convertToIntIBOP = Int32.Parse(args[5]);//Converting the Potion increased bonuses to a int from string.

                            //For Armour, the categories are displayed as Name, Weight, Cost, Type of Gear, Health, What it resists.
                            Item tempPotion = new Potion(args[1], convertToIntWeightP, convertToIntCostP, args[4], convertToIntIBOP, args[6]);
                            inv.AddInventory(tempPotion);
                            break;//Leaves the array.

                        default://If neither of the case statements are true.
                            break;//Leaves the array.
                    }

                }
                reader.Dispose();
                reader.Close();
            }

        }

        static public void beginningMessage()
        {
            int trysLeft = 3;
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

                        for (int r = 0; r < 2; r++)
                        {
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

                                    //This is creating buyerArrayChange to a definition of calling a function.
                                    MovingArrays(ref shopKeeperInventory.inventory, ref playerInventory.inventory, playerValue);

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
                                    //If the players cost is greater than the cost of the item in the shop and you have said yes.
                                    Console.WriteLine($"\nSorry you do not have enough money for {shopKeeperInventory.inventory[playerValue].Name}.");
                                    Console.WriteLine($"\nYou have {playerMoney} left. ");
                                    //After this, the end statement will be called where it askes if the player wants to interact again.
                                    Program noStatement = new Program();
                                    noStatement.EndStatement();
                                }

                                else if (playerInteraction == "N")
                                {
                                    //Checking if the player wants to continue or not through the endstatement function.
                                    i = 0;
                                    Program nostatement = new Program();
                                    nostatement.EndStatement();
                                }

                                else
                                {
                                    Console.WriteLine("\nStop wasting my time, tell me Y or N if you want something!\n");
                                    //If the player doesnt press yes or no or the player does not have enough money for the item.
                                    l = 0;
                                    _playerInteraction = Console.ReadLine();
                                    playerInteraction = _playerInteraction.ToUpper();
                                }
                            }

                        }
                        else
                        {
                            
                            Console.WriteLine("\nSorry, what did u say? I am going to say it again. Buy or Sell? [B] or [S]\n");
                            j = 0;

                        }
                        }
                        

                    }
                    //If the player presses sell, use this statement.
                    if (playerInteraction == "S")
                    {
                        for (int r = 0; r < 2; r++)
                        {
                            Console.WriteLine("\nYou have:");
                            for (int n = 0; n < playerInventory.InventoryLength; n++)
                            {//Checking the length of the array of the inventory to see if there is something in it.
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
                            playerInteraction = Console.ReadLine();                            
                            //This converts the players input into an integer as the player will be typing in the item number.

                            int playerSellValue = Convert.ToInt32(playerInteraction);//Converting the players interaction to an int.

                            if (playerInventory.inventory[playerSellValue] != null)
                            {//If the sell value does exist.
                                playerInventory.inventory[playerSellValue].Print();//Overrides the fuinction and uses the inherited item description from their class.
                                for (int o = 0; o < 1; o++)
                                {
                                    Console.WriteLine($"\nI like the looks of this item, could i take it? You will get " +
                                    $"{playerInventory.inventory[playerSellValue].Cost} in return. Yes or No [Y] [N].\n");
                                    _playerInteraction = Console.ReadLine();//Askes for player input.
                                    playerInteraction = _playerInteraction.ToUpper();//CHanges to an uppercase
                                    for (int p = 0; p < 1; p++)
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
                                        {//If the p[layer says no.
                                            Program noStatement = new Program();
                                            noStatement.EndStatement();//Goes to the endstatement function to see if the player wants to continue.
                                        }
                                    }

                                }


                            }
                            else
                            {
                                //If the player did not input the correct value of the item, the loop will start again.
                                Console.WriteLine("Sorry you dont have that available for offer. I'll repeat what you have again.");
                                r = 0;
                            }
                        }
                        


                    }

                    if(playerInteraction == "SUPERUSER")
                    {//This is a statement that allows the superusers to be able to add items to the store.
                        Console.WriteLine("Name of the Item:");
                        _playerInteraction = Console.ReadLine();//The player is said to input new item name.
                        string newName = _playerInteraction;//Stores the new name of the item thats inputted.
                        
                        
                        Console.WriteLine("Weight of the Item [write it in just numbers and no letters and other characters]:");
                        playerInteraction = Console.ReadLine();//The player is said to input a new item weight.
                        int playerValueW = Convert.ToInt32(playerInteraction);//Converts the interaction to an integer.
                        int newWeight = playerValueW;//Stores the new weight of the item thats inputted.

                        Console.WriteLine("Cost of the Item [write it in just numbers and no letters and other characters]: ");
                        playerInteraction = Console.ReadLine();//The player is said to input a new item Cost.
                        int playerValueC = Convert.ToInt32(playerInteraction);//Converts the interaction to an integer.
                        int newCost = playerValueC;//Stores the new cost of the item thats inputted.

                        Console.WriteLine("What type of Item is it? Is it a Weapon or armour or potion? [Write the word of the type of item.]");
                        _playerInteraction = Console.ReadLine();
                        playerInteraction = _playerInteraction.ToUpper();
                        switch (playerInteraction)
                        {
                            case "WEAPON":

                                //range damage attackspeed
                                Console.WriteLine("Okay, awesome. What is the range in metres? [write it in just numbers and no letters and other characters]");
                                playerInteraction = Console.ReadLine();
                                int playerValueR = Convert.ToInt32(playerInteraction);
                                int newRange = playerValueR;

                                Console.WriteLine("What is the damage of the Weapon? [write it in just numbers and no letters and other characters]");
                                playerInteraction = Console.ReadLine();
                                int playerValueD = Convert.ToInt32(playerInteraction);
                                int newDamage = playerValueD;

                                Console.WriteLine("What is the Attack Speed of the Weapon? [write it in just numbers and no letters and other characters]");
                                playerInteraction = Console.ReadLine();
                                int playerValueAS = Convert.ToInt32(playerInteraction);
                                int newAttackSpeed = playerValueAS;

                                Weapon newWeapon = new Weapon(newName, newWeight, newCost, newRange, newDamage, newAttackSpeed);
                                shopKeeperInventory.AddInventory(newWeapon);

                                break;


                            case "ARMOUR":

                                //Type of Gear, Health, What it resists.
                                Console.WriteLine("Okay, awesome. What is the gear type?");
                                _playerInteraction = Console.ReadLine();
                                string newTypeOfArmour = _playerInteraction;

                                Console.WriteLine("What is the Health of the armour? [write it in just numbers and no letters and other characters]");
                                playerInteraction = Console.ReadLine();
                                int playerValueH = Convert.ToInt32(playerInteraction);
                                int newHealth = playerValueH;

                                Console.WriteLine("What weapon does it resist?");
                                _playerInteraction = Console.ReadLine();
                                string newResistence = _playerInteraction;

                                Armour newArmour = new Armour(newName, newWeight, newCost, newTypeOfArmour, newHealth, newResistence);
                                shopKeeperInventory.AddInventory(newArmour);

                                break;

                            case "POTION":

                                //Type of Potion, Stat changes, Description.
                                Console.WriteLine("Okay, awesome. What is the Potion type?");
                                _playerInteraction = Console.ReadLine();
                                string newTypeOfPotion = _playerInteraction;

                                Console.WriteLine("What are the stat changes by default? [write it in just numbers and no letters and other characters]");
                                playerInteraction = Console.ReadLine();
                                int playerValuePSC = Convert.ToInt32(playerInteraction);
                                int newPStatChange = playerValuePSC;

                                Console.WriteLine("What weapon does it resist?");
                                _playerInteraction = Console.ReadLine();
                                string newDescription = _playerInteraction;

                                Armour newPotion = new Armour(newName, newWeight, newCost, newTypeOfPotion, newPStatChange, newDescription);
                                shopKeeperInventory.AddInventory(newPotion);

                                break;
                            default:

                                break;
                        }

                        Console.WriteLine("Congratulations, you have created a new item.");
                        Program EndStatement = new Program();
                        EndStatement.EndStatement();

                    }


                    if (playerInteraction == "SECRETSTASH")
                    {
                        for (int a = 0; a < 2; a++)
                        {
                            
                            Console.WriteLine("Whats the password?");
                            _playerInteraction = Console.ReadLine();
                            playerInteraction = _playerInteraction.ToUpper();
                            if (playerInteraction == "FORHONOR")
                            {
                                Console.Clear();
                                Console.WriteLine("I agree, now down to business.\n");
                                Console.WriteLine("These are my secret stash that I have available.\n");
                                Console.WriteLine("\n These are what I have available:");
                                for (int n = 0; n < shopKeeperSecretInventory.InventoryLength; n++)
                                {
                                    if (shopKeeperSecretInventory.inventory[n] != null)
                                    {

                                        //If there is something in the inventory, print it to the screen.
                                        Console.WriteLine($"{n}: {shopKeeperSecretInventory.inventory[n].Name} which is worth {shopKeeperSecretInventory.inventory[n].Cost} coins.");
                                    }

                                    //This is for checking if theres nothing in the array.
                                    else if (shopKeeperSecretInventory.inventory == null)
                                    {
                                        Console.WriteLine("\nSorry, nothing is left.");
                                        Program endStatement = new Program();
                                        endStatement.EndStatement();
                                    }

                                }

                                Console.WriteLine("\nWould you like to have a look at any of these? [Write the number next to the item.]\n");
                                playerInteraction = Console.ReadLine();
                                int playerSecretBuyValue = Convert.ToInt32(playerInteraction);

                                for (int r = 0; r < 2; r++)
                                {
                                    //If the inventory space of the playervalue has something in it, then it will display whats in the statement.
                                    if (shopKeeperSecretInventory.inventory[playerSecretBuyValue] != null)
                                    {
                                        //This uses the function within inventory called print.
                                        //Within every other class, the use of overrride is being able to read the line called print.
                                        //Allowing that when the player presses a value, that it receives the value and it displays a message from the classes.
                                        shopKeeperSecretInventory.inventory[playerSecretBuyValue].Print();//This is calling the function print from inventory which is a overrride to all the other classes.
                                        Console.WriteLine("\nYou have, $" + playerMoney + ".\n");//Showing the players money.
                                        Console.WriteLine("Do you want to buy this item? Yes or No. [Y] [N]");
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

                                                //This is creating buyerArrayChange to a definition of calling a function.
                                                MovingArrays(ref shopKeeperSecretInventory.inventory, ref playerInventory.inventory, playerSecretBuyValue);

                                                //This is called when a transaction occurs. 
                                                //Calling upon the playersinventory and the shopkeepers inventory whilst getting the vlaue of where the item was.
                                                for (int m = 0; m < 1; m++)
                                                {

                                                    Program continueShop = new Program();//This is creating continueShop to a definition of calling a method.
                                                    continueShop.EndStatement();//This is calling the function EndStatement.
                                                    m = 0;
                                                }
                                            }
                                            else if (playerInteraction == "Y" && playerMoney < shopKeeperSecretInventory.inventory[playerSecretBuyValue].Cost)
                                            {
                                                Console.WriteLine($"\nSorry you do not have enough money for {shopKeeperSecretInventory.inventory[playerSecretBuyValue].Name}.");
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
                                        Console.WriteLine("\nSorry, what did u say? I am going to say it again. Buy or Sell? [B] or [S]\n");
                                        j = 0;

                                    }
                                }


                            }
                            else
                            {
                                trysLeft -= 1;
                                a = 0;
                                Console.WriteLine($"Incorrect, try again if you want. You have {trysLeft} trys left.");
                                if (trysLeft <= 0)
                                {
                                    Console.WriteLine("Sorry no more trys.");
                                    Program p = new Program();
                                    p.EndStatement();

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



