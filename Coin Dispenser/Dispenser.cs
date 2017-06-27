using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Dispenser
{
    class Dispenser
    {
        // Conversion variables to change the values from string to double to int.
        public static string userEntry;
        public static int withdrawAmount;
        public static double withdrawConversion;
        public static double castWithdrawAmount;
        public static double moneyDispensed;
        public static double totalMoneyDispensed = moneyDispensed * 100.00;
        // array index variable
        public static int coin = 0;

        public static bool running = true;

        //Method the user can call to begin a transaction
        public static void Withdraw()
        {
            while (running)
            {
                //Displays the total in bank and promts the user to enter a withdraw amount.
                Console.WriteLine("You have {0:c2} in the bank.", Bank.GetBankAmount());
                Console.WriteLine("Enter the amount you wish to withdraw: ");

                //Converts user entry into a double then casts it as an int to avoid the math issues that
                //can occur when adding and subtracting doubles. This will keep the information the most accurate.
                userEntry = Console.ReadLine();
                double.TryParse(userEntry, out withdrawConversion);
                castWithdrawAmount = withdrawConversion * 100;
                withdrawAmount = (int)castWithdrawAmount;
                Console.Clear();
                //Should the user try to withdraw more than they have in the bank total it will display an error.
                if (withdrawAmount > Bank.moneyInBank * 100)
                {
                    Console.WriteLine("You do not have that much money! Press enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                //Should the user attempt to withdraw a negative amount it will display an error
                else if (withdrawAmount < 0)
                {
                    Console.WriteLine("You must enter a positive number! Press enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                //The transaction will be processed and the Dispense method will be called
                else
                {
                    Dispense();
                    break;
                }
            }
        }
        //Processes the users withdraw amount and checks it against the total amount of each type of coin in the bank.
        public static double Dispense()
        {                       
            while (running)
            {
                //while subtracting the current coin selected does NOT produce a negative number 
                //AND
                //the amount of that type of coin Eg(quarter) is greater than 0...
                while (withdrawAmount - Bank.coins[coin] >= 0 && Bank.coinCount[coin] > 0)
                {
                    //..subtract that coin amount from the withdraw amount and add it to the dispensed amount.
                    withdrawAmount -= Bank.coins[coin];
                    moneyDispensed += Bank.coins[coin];

                    //Will check the value of the coin in the current instance of the loop against the following
                    //statements and subtract the proper coin from the coin count total.
                    //EG. If the coin selected in coins[] is == 25 then 1 will be subtracted from the quarter counter.
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
                //when the withdraw amount - the coin value will create a negative number
                //it will continue here and run a check.
                //if the value of the coin is greater than the withdraw amount increment coin by 1 (in this case the array
                // index will be incremented and a new coin will be selected)
                if (Bank.coins[coin] > withdrawAmount || Bank.coinCount[coin] < 1)
                {
                    coin++;
                }
                // Runs the final check to ensure the withdraw amount has been fully dispensed.
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
