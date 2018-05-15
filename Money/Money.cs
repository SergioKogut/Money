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
            this.Grivna = (int)amount / 100;
            this.Cent = amount - 100 * ((int)amount / 100);
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


        //додавання грошей    
        public static Money operator +(Money m1, Money m2)
        {

            return new Money(AsCent(m1) + AsCent(m2));
        }

        //віднімання грошей
        public static Money operator -(Money m1, Money m2)
        {
            try
            {
                if (AsCent(m1) < AsCent(m2))
                {
                    throw new Exception("Сударь, вы банкрот!");
                }
                else
                {
                    return new Money(AsCent(m1) - AsCent(m2));
                }
            }
            catch (Exception)
            {
                throw;
            }


        }

        //ділення грошей на число
        public static Money operator /(Money m1, int number)
        {
            int temp = AsCent(m1) / number;
            return new Money(temp);
        }

        //множення грошей на число
        public static Money operator *(Money m1, int number)
        {
            int temp = AsCent(m1) * number;

            return new Money(temp);
        }

        //перезавантаження інкремента
        public static Money operator ++(Money m)
        {
            int temp = AsCent(m);
            temp++;
            return new Money(temp);
        }


        //перезавантаження декремента
        public static Money operator --(Money m)
        {
            try
            {
                if (AsCent(m) <= 0)
                {
                    throw new Exception("Сударь, вы банкрот!");
                }
                else
                {
                    int temp = AsCent(m);
                    temp--;
                    return new Money(temp);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public override bool Equals(object m)
        {
            return AsCent(this) == AsCent(m as Money);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();  
        }

       

        public static bool operator ==(Money m1, Money m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(Money m1, Money m2)
        {
            return !(m1==m2);
        }

        public static bool operator >(Money m1, Money m2)
        {
            return AsCent(m1)> AsCent(m2);
        }

        public static bool operator <(Money m1, Money m2)
        {
            return AsCent(m1) < AsCent(m2);
        }


    }

}
