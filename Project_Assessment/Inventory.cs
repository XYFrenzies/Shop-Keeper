using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Assessment
{
    class Inventory
    {
        public Item[] inventory;

        public int InventoryLength => inventory.Length;

        //THis is defining inventory as Items array. This being one of the two different arrays.
        public Inventory(int sizeOfInventory)
        {
            inventory = new Item[sizeOfInventory];
            //This is a reference for the size of the inventory
        }

        public int[] SearchInventory(string itemToSearch)
        {
            //Iterate over inventory and find contains of itemToSearch
            //int[] results = new int[20];
            List<int> results = new List<int>();

            //search stuff magic
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null)
                {
                    //The next line is checking, if the inventory has an item within it that contains a keyword "name"
                    //Execute the code.
                    if (inventory[i].name.Contains(itemToSearch))
                    {
                        // true
                        results.Add(i);
                        //Adding the content to results.
                    }
                }
            }
            //Whatever that has been added to results will be added to a array.
            return results.ToArray();
        }
        //This function is to see if there is a free spot in the inventory.
        //This is to prevent an error and for checking if a spare space exists.
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
        //add


        //remove

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
