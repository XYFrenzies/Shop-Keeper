using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Assessment
{
    public class Potions : Items
    {
        private string typeOfPotion; //This can be a good potion or bad potion.
        private int changedStatsOfPotion; //This is what the Potion can do in terms of stats.
        private string potionDescription; //This is where the user can see what it does.
        public Potions() 
        {
            name = "UndefinedPotion!";
            typeOfPotion = "Makes me powerful";
            changedStatsOfPotion = 10000;
            potionDescription = "Maybe it can be good, we will see";
        }

        public Potions(string a_nameOfPotion, string a_statIncreaseOfPotion, int a_increasedBonusesOfPotion, string a_potionDescription) : 
            base(a_nameOfPotion, a_statIncreaseOfPotion, a_increasedBonusesOfPotion, a_potionDescription)
        {
            name = a_nameOfPotion;
            typeOfPotion = a_statIncreaseOfPotion;
            changedStatsOfPotion = a_increasedBonusesOfPotion;
            potionDescription = a_potionDescription;
        }
    }
}
