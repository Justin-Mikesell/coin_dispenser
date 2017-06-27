using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Dispenser
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank.AmountInBank(10, 16, 13, 10);
            Dispenser.Withdraw();                      
            Receipt.Print();
        }
    }
}
