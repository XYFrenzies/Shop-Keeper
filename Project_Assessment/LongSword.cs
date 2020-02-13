using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Assessment
{
    class Weapon
    {
        public string name; //This can be multiple different names as there can be multiple different weapons.
        public int range; //This is per meter.
        public int damage; //This is dependant on the varient of the long sword
        public int requiredLevel; //The player needs to be a certain level to aquire this long sword
        public int attackSpeed; //How fast can the player attack.


        public Weapon(string a_nameOfWeapon, int a_rangeOfWeapon, int a_damageOfWeapon, int a_requiredLevelOfWeapon, int a_attackSpeedOfWeapon)
        {
            name = a_nameOfWeapon;
            range = a_rangeOfWeapon;
            damage = a_damageOfWeapon;
            requiredLevel = a_requiredLevelOfWeapon;
            attackSpeed = a_attackSpeedOfWeapon;

        }
    }
}
