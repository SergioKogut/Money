using System;

namespace MoneySpace
{
    partial class Program
    {
        class Money
        {
            public int Grivna { get; private set; }
            public int Cent { get; private set; }

            public Money()
            {
                this.Grivna = 0;
                this.Cent = 0;
            }

            public Money(double amount)
            {
                this.Grivna = (int)(Math.Floor(amount));
                this.Cent = (int)((amount - Math.Floor(amount))*100);
            }


            public Money(int grn,int kop)
            {
                this.Grivna = grn;
                this.Cent = kop;
            }

            public override string ToString()
            {
                return $"{ this.Grivna} грн {this.Cent} копеек";
            }

            private int AsCent(double amount)
            {
                return (int)amount * 100;
            }

            private int PartGrivna(double amount)
            {
                return (int)amount;
            }

            private int PartCent(double amount)
            {
                return (int)amount;
            }


        }
    }
}
