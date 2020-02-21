using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Assessment
{
    public class Item
    {
        //This will be publically used
        public string name;
        public int weightOfItem;
        public int costOfItem;


        public Item()
        {
            name = "Undefined Item!";
            weightOfItem = 10000;
            costOfItem = 1;
        }

        public Item(string a_nameOfItem, int a_weightOfItem, int a_costOfItem)
        {
            //This is a reference to ever class that uses these universally used definitions.

            name = a_nameOfItem;
            weightOfItem = a_weightOfItem;
            costOfItem = a_costOfItem;


        }
        public virtual void Print() 
        {
            Console.WriteLine(Name);
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
       
    }
}
