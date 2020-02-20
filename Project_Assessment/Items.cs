using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        public virtual void beginningMessage()
        {
            int playerMoney = 1000;
            int shopKeeperMoney = 1000;
            for (int i = 0; i < 20; i++)
            {


                //This will be the beginning dialogue of the program.
                Console.WriteLine("Welcome young traveller. How can I help you today?");
                Console.WriteLine("I have a range of goods that might interest you.");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("The goods that I have available are Armour, weapons of any kind and potions.");
                Console.WriteLine("Hope I encapsulate your taste of equipment.");
                Console.WriteLine("");
                Console.WriteLine("What would you like to look at first?");
                Console.WriteLine("Options are: ");


                //The next statement is for the reading of whatever is in the text file.
                StreamReader optionsAvailable = new
                    StreamReader("ShopKeeper.txt");
                while (optionsAvailable.EndOfStream == false)
                {
                    string line = optionsAvailable.ReadLine();
                    //This is the reading from the text file.
                    //Whenever the stream is still not at the end, it continually reads it and prints it.
                    Console.WriteLine(line);
                }
                optionsAvailable.Close();

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("You have, $" + playerMoney + ".");
                Console.WriteLine("What would you like to shop for now player or would you like to sell?");

                playerInteraction = Console.ReadLine();

                Program.CheckingForItems();

                Console.WriteLine("Would you like to buy this item? [Y] [N]");

                Program.CheckingYN();

                Program.MoneyCalculator(playerMoney, Cost, shopKeeperMoney);
                Console.WriteLine("Done, you have " + playerMoney + " left. Would you like to continue? [Y] [N]");

                Console.WriteLine("");
                Console.WriteLine("");
            }
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
