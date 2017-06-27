using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Dispenser
{
    class Dispenser
    {
        public static string userEntry;
        public static int withdrawAmount;
        public static double withdrawConversion;
        public static double castWithdrawAmount;
        public static double moneyDispensed;
        public static double totalMoneyDispensed = moneyDispensed * 100.00;
        public static int coin = 0;
        public static bool running = true;

        public static void Withdraw()
        {
            while (running)
            {
                Console.WriteLine("You have {0:c2} in the bank.", Bank.GetBankAmount());
                Console.WriteLine("Enter the amount you wish to withdraw: ");
                userEntry = Console.ReadLine();
                double.TryParse(userEntry, out withdrawConversion);
                castWithdrawAmount = withdrawConversion * 100;
                withdrawAmount = (int)castWithdrawAmount;
                Console.Clear();
                if (withdrawAmount > Bank.moneyInBank * 100)
                {
                    Console.WriteLine("You do not have that much money! Press enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                else if (withdrawAmount < 0)
                {
                    Console.WriteLine("You must enter a positive number! Press enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                else
                {
                    break;
                }
            }
        }

        public static double Dispense()
        {                       
            while (running)
            {
                while (withdrawAmount - Bank.coins[coin] >= 0 && Bank.coinCount[coin] > 0)
                {
                    withdrawAmount -= Bank.coins[coin];
                    moneyDispensed += Bank.coins[coin];


                    if (Bank.coins[coin] == Bank.coins[0])
                    {
                        Bank.quarterCount--;
                    }
                    else if (Bank.coins[coin] == Bank.coins[1])
                    {
                        Bank.dimeCount--;
                    }
                    else if (Bank.coins[coin] == Bank.coins[2])
                    {
                        Bank.nickelCount--;
                    }
                    else if (Bank.coins[coin] == Bank.coins[3])
                    {
                        Bank.pennyCount--;
                    }
                }
                if (Bank.coins[coin] > withdrawAmount || Bank.coinCount[coin] < 1)
                {
                    coin++;
                }
                if (withdrawAmount == 0)
                {
                    coin = 0;
                    
                    break;
                }
                
            }
            
            return moneyDispensed;
        }
    }
}
