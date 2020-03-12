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
using static Project_Assessment.Program;

namespace Project_Assessment
{
    class SuperUser
    {
        private string playerInteraction;
        public void SuperUserCreating() 
        {
            //This is a statement that allows the superusers to be able to add items to the store.
            Console.Clear();
            Console.WriteLine("Name of the Item:");
            _playerInteraction = Console.ReadLine();//The player is said to input new item name.
            string newName = _playerInteraction;//Stores the new name of the item thats inputted.

            Console.WriteLine("Weight of the Item [write it in just numbers and no letters and other characters]:");
            ulong playerValueW = 0;//The player value is default at 0.
            TryandCatch(ref playerValueW, playerInteraction);//This is a function in case the player accidentally puts in a value that isnt a number.
            ulong newWeight = playerValueW;//Stores the new weight of the item thats inputted.

            Console.WriteLine("Cost of the Item [write it in just numbers and no letters and other characters]: ");
            ulong playerValueC = 0;//The playerValue is default at 0.
            TryandCatch(ref playerValueC, playerInteraction);//This is a function in case the player accidentally puts in a value that isnt a number.
            ulong newCost = playerValueC;//Stores the new cost of the item thats inputted.

            //This asks for what type of item that the player would like to classify it as.
            bool playerInteractionIsCorrect = false;
            while (playerInteractionIsCorrect == false)
            {
                Console.WriteLine("What type of Item is it? Is it a Weapon or Armour or Potion? [Write the word of the type of item.]");
                _playerInteraction = Console.ReadLine();//The player is said to input what type of item they are making.
                playerInteraction = _playerInteraction.ToUpper();//Stores the weapon class into the playerInteraction string.
                if (playerInteraction == "WEAPON" || playerInteraction == "ARMOUR" || playerInteraction == "POTION")
                {
                    playerInteractionIsCorrect = true;
                }
            }
            while (playerInteractionIsCorrect == true)
            {
                switch (playerInteraction)//Depending on what the person says.
                {
                    case "WEAPON":
                        //If the user says they want to make a weapon.
                        //This is divised into - range damage attackspeed looking downwards.
                        Console.WriteLine("Okay, awesome. What is the range in metres? [write it in just NUMBERS and no letters and other characters]");
                        ulong playerValueR = 0; ;//The playerValue of the range is 0;
                        TryandCatch(ref playerValueR, playerInteraction);//This is a function in case the player accidentally puts in a value that isnt a number.
                        ulong newRange = playerValueR;//Stores the new range of the weapon thats inputted.

                        Console.WriteLine("What is the damage of the Weapon? [write it in just NUMBERS and no letters and other characters]");
                        ulong playerValueD = 0;//Converts the interaction to an integer.
                        TryandCatch(ref playerValueD, playerInteraction);//This is a function in case the player accidentally puts in a value that isnt a number.
                        ulong newDamage = playerValueD;//Stores the new damage of the weapon thats inputted.

                        Console.WriteLine("What is the Attack Speed of the Weapon? [write it in just NUMBERS and no letters and other characters]");
                        ulong playerValueAS = 0;//Converts the interaction to an integer.
                        TryandCatch(ref playerValueAS, playerInteraction);//This is a function in case the player accidentally puts in a value that isnt a number.
                        ulong newAttackSpeed = playerValueAS;//Stores the new attack speed of the weapon thats inputted.

                        Weapon newWeapon = new Weapon(newName, newWeight, newCost, newRange, newDamage, newAttackSpeed);//Converts the name, weight, cost, range, damage and as into an array
                        shopKeeperSecretInventory.AddInventory(newWeapon);//Keeps the new weapon in the secret inventory.
                        playerInteractionIsCorrect = false;
                        break;

                    case "ARMOUR":
                        //If the user says they want to make a peice of armour.
                        //This is divised into - Type of Gear, Health, What it resists.
                        Console.WriteLine("Okay, awesome. What is the gear type?");
                        _playerInteraction = Console.ReadLine();//This would be asking what type of gear the new armour is.
                        string newTypeOfArmour = _playerInteraction;//Stores the type of armour in a string.

                        Console.WriteLine("What is the Health of the armour? [write it in just NUMBERS and no letters and other characters]");
                        ulong playerValueH = 0;//Converts the interaction to an integer.
                        TryandCatch(ref playerValueH, playerInteraction);//This is a function in case the player accidentally puts in a value that isnt a number.
                        ulong newHealth = playerValueH;//Saves the armous health in newHealth.

                        Console.WriteLine("What weapon does it resist?");
                        _playerInteraction = Console.ReadLine();//Asks what weapon this armour resists.
                        string newResistence = _playerInteraction;//This resistence is then saved in newResistence.

                        Armour newArmour = new Armour(newName, newWeight, newCost, newTypeOfArmour, newHealth, newResistence);//Converts the name, weight, cost, armourtype, health and resistence into an array.
                        shopKeeperSecretInventory.AddInventory(newArmour);//Keeps the new armour in the secret inventory.
                        playerInteractionIsCorrect = false;
                        break;

                    case "POTION":
                        //If the user says they want to make a potion.
                        //This is divised into - Type of Potion, Stat changes, Description.
                        Console.WriteLine("Okay, awesome. What is the Potion type? [does it heal or does it do damage?]");
                        _playerInteraction = Console.ReadLine();//Asking the player what the potion varient is "what the benefits or do damage".
                        string newTypeOfPotion = _playerInteraction;//This stores the potion type into a string called newTypeOfPotion.

                        Console.WriteLine("What are the stat changes by default? [write it in just NUMBERS and no letters and other characters]");
                        ulong playerValuePSC = 0;//Converts the interaction to an integer.
                        TryandCatch(ref playerValuePSC, playerInteraction);//This is a function in case the player accidentally puts in a value that isnt a number.
                        ulong newPStatChange = playerValuePSC;//Saves the the stat changes newPStatChange.

                        Console.WriteLine("What is the description of the item? [What does it do?]");
                        _playerInteraction = Console.ReadLine();//Asking the player what the description is of the item.
                        string newDescription = _playerInteraction;//Saves the description under the string newDescription.

                        Potion newPotion = new Potion(newName, newWeight, newCost, newTypeOfPotion, newPStatChange, newDescription);//COnverts the name, weight, cost, typeofpotion, statchanges and description into an array.
                        shopKeeperSecretInventory.AddInventory(newPotion);//Keeps the new armour in the secret inventory.
                        playerInteractionIsCorrect = false;
                        break;//Gets out of the loop.
                    default://In case the player did not write the correct item type.
                        Console.WriteLine("Sorry I don't think you understand the purpose of making a new item. Test error{}{}");//In case the player does not write the correct item type.
                        break;
                }
            }
            Console.WriteLine("Congratulations, you have created a new item.");
            Program EndStatement = new Program();
            EndStatement.EndStatement();//Once the player hase completed the item, they are returned to the endstatement function.
        }
    }
}
