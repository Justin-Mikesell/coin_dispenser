using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Dispenser
{
    class Receipt
    {
        //user entry variable to determine whether or not to quit
        public static string anotherTransaction;
        //amount dispensed this transaction
        public static double moneyDispensed;

        //Method to print the receipt to the user
        public static void Print()
        {
            //update moneyDispensed back to a floating point value
            moneyDispensed += Dispenser.moneyDispensed / 100;
            // displays the total amount received, the amount remaining in bank, and prompts the user to quit
            // or continue
            Console.WriteLine("You have recieved: {0:c2}", moneyDispensed);
            Console.WriteLine("You have {0:c2} left in the bank!", Bank.moneyInBank - moneyDispensed);
            Console.WriteLine("Thank you for using Justins Bank!");
            Console.WriteLine("Type \"quit\" to exit, or press enter to complete another transaction");
            Bank.moneyInBank = Bank.moneyInBank - moneyDispensed;
            
            anotherTransaction = Console.ReadLine().ToLower();
            // if user types quit, program ends
            if (anotherTransaction == "quit")
            {
                
            }
            // otherwise user is prompted for another withdraw
            else
            {
                Dispenser.moneyDispensed = 0;
                moneyDispensed = 0;
                Console.Clear();
                Dispenser.Withdraw();                
                Receipt.Print();
            }
        }
    }
}
