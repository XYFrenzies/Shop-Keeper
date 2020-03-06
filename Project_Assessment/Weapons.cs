using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Assessment
{
    public class Weapon : Item
    {
        private string weaponName; //This is as a placeholder for the name in the item class.
        private int weightOfWeapon; //This is as a placeholder for the value of weight in item.
        private int costOfWeapon; //This is as a placeholder for the value of cost in item.
        private int range; //This is per meter.
        private int damage; //This is dependant on the varient of the weapon.
        private int attackSpeed; //How fast can the player attack. Attacks per second.

        public override void Print()
        {//This is a function that overrides a dialogue within the program beginning message.
            Console.WriteLine($"{Name} is a weapon that weighs about {Weight} Kg's.");
            Console.WriteLine($"This weapon deals {Damage} damage to enemies as well as having a range of {Range} metres.");
            Console.WriteLine($"The attack speed of this weapon is {AttackSpeed} per second.");
            Console.WriteLine($"The cost of this weapon is {Cost} coins.");

        }



        public Weapon()
        {
            //The values in here are defults for multiple reaons.
            //If the code isnt working properly and refers back to these values, at least we know that theres an issue within this class.
            //This is also used as a constructor for the code.
            weaponName = "Undefined Weapon!";
            weightOfWeapon = 1000;
            costOfWeapon = 20000;
            range = 5;
            damage = 100;
            attackSpeed = 2;
        }

        public Weapon(string a_nameOfWeapon, int a_weightOfWeapon, int a_costOfWeapon,int a_rangeOfWeapon,
            int a_damageOfWeapon, int a_attackSpeedOfWeapon) : base (a_nameOfWeapon, a_weightOfWeapon, a_costOfWeapon)
        //The a_ at the front represents an argument to show that the details are an argument.
        {
            weaponName = a_nameOfWeapon;
            weightOfWeapon = a_weightOfWeapon;
            costOfWeapon = a_costOfWeapon;
            range = a_rangeOfWeapon;
            damage = a_damageOfWeapon;
            attackSpeed = a_attackSpeedOfWeapon;

        }
        //These references will be used in the program to define the range, damage and the attackspeed of the weapon.
        public int Range
        {
            get { return range; }
            set { this.range = value; }
            //This will be used to define the range of the child weapon.
            //It can easily be used in a writeline statement.
        }

        public int Damage
        {
            get { return damage; }
            set { this.damage = value; }
            //This will be used to define the damage of the child weapon.
            //It can easily be used in a writeline statement.
        }

        public int AttackSpeed
        {
            get { return attackSpeed; }
            set { this.attackSpeed = value; }
            //This will be used to define the attackspeed of the child weapon. 
            //It can easily be used in a writeline statement.
        }
    }
}
