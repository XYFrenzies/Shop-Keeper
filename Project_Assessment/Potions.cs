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
        public Potion() 
        {
            potionName = "UndefinedPotion!";
            weightOfPotion = 12000;
            costOfPotion = 32000;
            typeOfPotion = "Makes me powerful";
            changedStatsOfPotion = 10000;
            potionDescription = "Maybe it can be good, we will see";
        }

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

        public int ChangedStatsOfPotion
        {
            get { return changedStatsOfPotion; }
            set { this.changedStatsOfPotion = value; }
        }

        public string PotionDescription
        {
            get { return potionDescription; }
            set { this.potionDescription = value; }
        }
    }
}
