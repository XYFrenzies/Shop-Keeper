using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Assessment
{
    public class Armour : Items
    {
        private string armourName; //This is as a placeholder for the name in the item class.
        private int weightOfArmour; //This is as a placeholder for the value of weight in item.
        private int costOfArmour; //This is as a placeholder for the value of cost in item.
        private string armourType; //Whether it is a helmet, boots or chestpiece.
        private int armourHealth; // How much damage can it withstand.
        private string armourResistence; //What type of Weapon can it withstand.
        public Armour() 
        {
            //The values in here are defults for multiple reaons.
            //If the code isnt working properly and refers back to these values, at least we know that theres an issue within this class.
            //This is also used as a constructor for the code.
            armourName = "Undefined Armour!";
            weightOfArmour = 2000;
            costOfArmour = 12;
            armourType = "It can be anything";
            armourHealth = 9001;
            armourResistence = "Im invincible";

        }

        //This is comparing the armour and items deatils. Where Items is the parent and armour is the child.
        public Armour(string a_armourName, int a_weightOfArmour, int a_costOfArmour, string a_armourType, int a_armourHealth, string a_armourResistence) : 
            base(a_armourName, a_weightOfArmour, a_costOfArmour)
        {
            armourName = a_armourName;
            weightOfArmour = a_weightOfArmour;
            costOfArmour = a_costOfArmour;
            armourType = a_armourType;
            armourHealth = a_armourHealth;
            armourResistence = a_armourResistence;
        }

        public string ArmourType
        {
            get { return armourType; }
            set { this.armourType = value; }
            //This will be used to define the type of armour when creating the armour through item.
            //It can easily be used in a writeline statement.
        }

        public int ArmourHealth
        {
            get { return armourHealth; }
            set { this.armourHealth = value; }
            //This will be used to define the armours health when creating the armour through item.
            //It can easily be used in a writeline statement.
        }

        public string ArmourResistence
        {
            get { return armourResistence; }
            set { this.armourResistence = value; }
            //This will be used to define the armours resistences when creating the armour through item.
            //It can easily be used in a writeline statement.
        }
    }
}
