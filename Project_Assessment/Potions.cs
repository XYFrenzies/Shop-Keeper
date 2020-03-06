using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Assessment
{
    public class Potion : Item
    {
        private string potionName;
        private int weightOfPotion;
        private int costOfPotion;
        private string typeOfPotion; //This can be a good potion or bad potion.
        private int changedStatsOfPotion; //This is what the Potion can do in terms of stats.
        private string potionDescription; //This is where the user can see what it does.

        public override void Print()
        {
            //This is a function that overrides a dialogue within the program beginning message.
            Console.WriteLine($"{Name} is a Potion that weighs about {Weight} Kg's.");
            Console.WriteLine($"This potion {TypeOfPotion} {ChangedStatsOfPotion}.");
            Console.WriteLine($"{PotionDescription}.");
            Console.WriteLine($"The cost of this Potion is {Cost} coins.");
        }


        public Potion() 
        {
            //The values in here are defults for multiple reaons.
            //If the code isnt working properly and refers back to these values, at least we know that theres an issue within this class.
            //This is also used as a constructor for the code.
            potionName = "UndefinedPotion!";
            weightOfPotion = 12000;
            costOfPotion = 32000;
            typeOfPotion = "Makes me powerful";
            changedStatsOfPotion = 10000;
            potionDescription = "Maybe it can be good, we will see";
        }
        //This is comparing the potions and items deatils. Where Items is the parent and the potion is the child.
        public Potion(string a_nameOfPotion, int a_weightOfPotion, int a_costOfPotion, string a_statIncreaseOfPotion, int a_increasedBonusesOfPotion, string a_potionDescription) : 
            base(a_nameOfPotion, a_weightOfPotion, a_costOfPotion)
        {

            potionName = a_nameOfPotion;
            weightOfPotion = a_weightOfPotion;
            costOfPotion = a_costOfPotion;
            typeOfPotion = a_statIncreaseOfPotion;
            changedStatsOfPotion = a_increasedBonusesOfPotion;
            potionDescription = a_potionDescription;
        }

        public string TypeOfPotion
        {
            get { return typeOfPotion; }
            set { this.typeOfPotion = value; }
        }
        //This will be used to define the type of potion when creating the potion through item.
        //It can easily be used in a writeline statement.

        public int ChangedStatsOfPotion
        {
            get { return changedStatsOfPotion; }
            set { this.changedStatsOfPotion = value; }
        }
        //This will be used to define the changed stats of the potion when creating the potion through item.
        //It can easily be used in a writeline statement.

        public string PotionDescription
        {
            get { return potionDescription; }
            set { this.potionDescription = value; }
        }
        //This will be used to define the potion description when creating the potion through item.
        //It can easily be used in a writeline statement.
    }
}
