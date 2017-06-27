using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Dispenser
{
    class Bank
    {
        public static int[] coins = new int[] { 25, 10, 5, 1 };
        public static int[] coinCount = new int[4];
        public static double moneyInBank;
        public static int quarterCount;
        public static int dimeCount;
        public static int nickelCount;
        public static int pennyCount;

        
        public static void AmountInBank(int q, int d, int n, int p)
        {
            moneyInBank = ((q*coins[0]) + (d*coins[1]) + (n*coins[2]) + (p*coins[3])) / 100.00;
            coinCount[0] = q;
            coinCount[1] = d;
            coinCount[2] = n;
            coinCount[3] = p;
        }

        public static double GetBankAmount()
        {
            return moneyInBank;
        }        
    }
}
