using System;

namespace Moneyclass
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
            this.Cent = (int)((amount - Math.Floor(amount)) * 100);
        }
        public Money(int amount)
        {
            this.Grivna = (int)amount/100;
            this.Cent = amount- 100*((int)amount / 100);
        }
        
        public Money(int grn, int kop)
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
        private static int AsCent(Money amount)
        {
            return amount.Grivna * 100 + amount.Cent;
        }

        private int PartGrivna(double amount)
        {
            return (int)amount;
        }

        private int PartCent(double amount)
        {
            return (int)amount;
        }

        public static Money operator +(Money m1, Money m2)
        {
            return new Money(m1.Grivna + m2.Grivna, m1.Cent + m2.Cent);
        }

        public static Money operator -(Money m1, Money m2)
        {
            return new Money(m1.Grivna - m2.Grivna, m1.Cent - m2.Cent);
        }

        public static Money operator /(Money m1,int number)
        {
            int temp = AsCent(m1) / number;
            return new Money(temp);
        }
        public static Money operator *(Money m1, int number)
        {
            int temp = AsCent(m1)*number;

            return new Money(temp);
        }



    }

}
