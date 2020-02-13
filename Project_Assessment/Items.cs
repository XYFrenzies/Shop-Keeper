using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Assessment
{
    public class Items
    {
        //This will be publically used
        public string name;
        public int weightOfItem;
        public int costOfItem;
        public Items()
        {
            name = "Undefined Item!";
            weightOfItem = 10000;
            costOfItem = 1;
        }

        public Items(string a_nameOfItem, int a_weightOfItem, int a_costOfItem)
        {
            //This is a reference to ever class that uses these universally used definitions.

            name = a_nameOfItem;
            weightOfItem = a_weightOfItem;
            costOfItem = a_costOfItem;


        }
        //The following is used if the value of the variable is changed and called upon, it can be used through their "keywords"
        //Which in this case, it will be for saying what is on sale as well as what you have available for selling.
        public string Name 
        {
            get { return name; }
            set { this.name = value; }
        }

        public int Weight
        {
            get { return weightOfItem; }
            set { this.weightOfItem = value; }
        }

        public int Cost
        {
            get { return costOfItem; }
            set { this.costOfItem = value; }
        }

 /*    

        public string TypeOfPotion 
        {
            get { return typeOfPotion; }
            set { this.typeOfPotion = value; }
        }

        public int ChangedSatsOfPotion
        {
            get { return changedStatsOfPotion; }
            set { this.changedStatsOfPotion = value; }
        }

        public string PotionDescription
        {
            get { return potionDescription; }
            set { this.potionDescription = value; }
        }

/*/        
    }
}
