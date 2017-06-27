using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Dispenser
{
    class Receipt
    {
        public static string anotherTransaction;
        public static double moneyDispensed;
        public static void Print()
        {
            moneyDispensed += Dispenser.moneyDispensed / 100;
            Console.WriteLine("You have recieved: {0:c2}", moneyDispensed);
            Console.WriteLine("You have {0:c2} left in the bank!", Bank.moneyInBank - moneyDispensed);
            Console.WriteLine("Thank you for using Justins Bank!");
            Console.WriteLine("Type \"quit\" to exit, or press enter to complete another transaction");
            Bank.moneyInBank = Bank.moneyInBank - moneyDispensed;

            anotherTransaction = Console.ReadLine().ToLower();
            if (anotherTransaction == "quit")
            {
                
            }
            else
            {
                Dispenser.moneyDispensed = 0;
                moneyDispensed = 0;
                Console.Clear();
                Dispenser.Withdraw();
                Dispenser.Dispense();
                Receipt.Print();
            }
        }
    }
}
