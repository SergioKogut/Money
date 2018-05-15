using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMenu = System.Collections.Generic.List<System.Tuple<string, GetMethod>>;
using ItemMenu = System.Tuple<string, GetMethod>;
using MenuSpace;
public delegate void GetMethod();

namespace MoneySpace
{




    partial class Program
    {

        static void Main(string[] args)
        {
            Money money = new Money();
            Money money2 = new Money(15.13);

            Console.WriteLine(money2);


        }
    }
}
