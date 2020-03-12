using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using static Project_Assessment.Inventory;
using static Project_Assessment.Program;

namespace Project_Assessment
{
    class MovingFilesToArrays
    {
        //This function is used so that it doesnt have to be put into the main program directly but rather indirectly.
        static public void FileExistStatement()
        {
            //This checks if the shopKeeper and player text's exist. If so execute the program.
            if (File.Exists("ShopKeeper.txt") && File.Exists("Player.txt") && File.Exists("SecretShopKeeper.txt"))
            {
                //This will load the files of shopKeeper and player text via thr loadingInventoryFromFile function.
                LoadingInventoryFromFile("ShopKeeper.txt", ref shopKeeperInventory);
                LoadingInventoryFromFile("Player.txt", ref playerInventory);
                LoadingInventoryFromFile("SecretShopKeeper.txt", ref shopKeeperSecretInventory);

            }
            //This check executes if neither of the two files exist. 
            else if (!File.Exists("ShopKeeper.txt") && !File.Exists("Player.txt") && !File.Exists("SecretShopKeeper.txt"))
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
        //This is a function that moves the item from one array to another and declairs the new location.
        static public void MovingArrays(ref Item[] a_seller, ref Item[] a_buyer, ulong newLocation)
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
        //This is the function that moves all the items in the array to the allocated text files.
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
                    ulong theWeightSK = shopKeeperInventory.inventory[i].Weight;//This is the Weight of the item.
                    ulong theCostSK = shopKeeperInventory.inventory[i].Cost;//This is the cost of the item.
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
                    ulong theWeightP = playerInventory.inventory[j].Weight;//This is the Weight of the item.
                    ulong theCostP = playerInventory.inventory[j].Cost;//This is the cost of the item.
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
                    ulong theWeightSSK = shopKeeperSecretInventory.inventory[k].Weight;//This is the Weight of the item.
                    ulong theCostSSK = shopKeeperSecretInventory.inventory[k].Cost;//This is the cost of the item.
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
                            ulong convertToIntWeightW = UInt32.Parse(args[2]);//Converting the weapon weight to a int from string.
                            ulong convertToIntCostW = UInt32.Parse(args[3]);//Converting the weapon Cost to a int from string.
                            ulong convertToIntRangeW = UInt32.Parse(args[4]);//Converting the weapon Range to a int from string.
                            ulong convertToIntDamageW = UInt32.Parse(args[5]);//Converting the weapon Damage to a int from string.
                            ulong convertToIntAttackSpeedW = UInt32.Parse(args[6]);//Converting the weapon AttackSpeed to a int from string.


                            //For weapons, the categories are displayed as Name, Weight, Cost, Range, Damage, AttackSpeed.
                            Item tempWeap = new Weapon(args[1], convertToIntWeightW, convertToIntCostW, convertToIntRangeW, convertToIntDamageW, convertToIntAttackSpeedW);

                            inv.AddInventory(tempWeap);
                            break;//Leaves the array.

                        case "Project_Assessment.Armour"://If the projectDefiner is named Project_Assessment.Armour...
                            ulong convertToIntWeightA = UInt32.Parse(args[2]);//Converting the Armour weight to a int from string.
                            ulong convertToIntCostA = UInt32.Parse(args[3]);//Converting the Armour Cost to a int from string.
                            ulong convertToIntHealthA = UInt32.Parse(args[5]);//Converting the Armour Health to a int from string.


                            //For Armour, the categories are displayed as Name, Weight, Cost, Type of Gear, Health, What it resists.
                            Item tempArmour = new Armour(args[1], convertToIntWeightA, convertToIntCostA, args[4], convertToIntHealthA, args[6]);
                            inv.AddInventory(tempArmour);
                            break;//Leaves the array.

                        case "Project_Assessment.Potion"://If the projectDefiner is named Project_Assessment.Potion...
                                                         //For Potions, the categories are displayed as Name, Weight, Cost, Type of Potion, Stat changes, Description.
                            ulong convertToIntWeightP = UInt32.Parse(args[2]);//Converting the Potion weight to a int from string.
                            ulong convertToIntCostP = UInt32.Parse(args[3]);//Converting the Potion Cost to a int from string.
                            ulong convertToIntIBOP = UInt32.Parse(args[5]);//Converting the Potion increased bonuses to a int from string.

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
        //Within this function, the program checks if theres anything in the inventory or not. This will affect the variable count. 
    }
}
