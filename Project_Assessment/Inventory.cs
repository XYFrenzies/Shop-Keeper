using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Project_Assessment
{
    public class Inventory
    {
        public Item[] inventory;

        public int InventoryLength => inventory.Length;

        //THis is defining inventory as Items array. This being one of the two different arrays.
        public Inventory(int sizeOfInventory)
        {
            inventory = new Item[sizeOfInventory];
            //This is a reference for the size of the inventory
        }

        //This function is to see if there is a free spot in the inventory.
        //This is to prevent an error and for checking if a spare space exists.

        static public int SearchingInventory(ref int count, ref Inventory inv)
        {
            count = 0;// reverting count back to 0.
            for (int i = 0; i < inv.InventoryLength; i++)
            {
                if (inv.inventory[i] != null)
                {
                    count += 1;//Adds to the count for every item in the array.
                }
            }
            return count;
        }


        public void AddInventory (params Item[] itemsToAdd) 
        {
            for (int i = 0; i < itemsToAdd.Length; i++)
            {
                int freeSpot = CheckForFreeSpot();
                //This is using the function of checkforfreespace to find a inventory space and place the item in there.
                if (freeSpot >= 0)
                //If the inventory function is above zero and theres space, display code. 
                {
                    this.inventory[freeSpot] = itemsToAdd[i];
                    //Add item to the inventory
                }
                else
                //If the inventory spot is only available below zero then display this code.
                {

                    //Tell user no free space
                }
            }
            
        }

        //check for free spot
        public int CheckForFreeSpot()
        {
            for (int i = 0; i < this.inventory.Length; i++)
            {
                //This is a check if the inventory space within the length of the given array is available.
                if (inventory[i] == null)
                {
                    //If the inventory space is available, return the variable passed in.
                    return i;
                }
            }

            return -1;
        }
    }
}
