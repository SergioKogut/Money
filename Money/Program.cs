using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMenu = System.Collections.Generic.List<System.Tuple<string, GetMethod>>;
using ItemMenu = System.Tuple<string, GetMethod>;
using MenuSpace;
using Moneyclass;
public delegate void GetMethod();

/*
 Написать класс Money, предназначенный для хранения денежной суммы (в гривнах и копейках). Для класса
реализовать перегрузку операторов + (сложение денежных сумм), – (вычитание сумм), / (деление суммы на целое
число), * (умножение суммы на целое число), ++ (сумма
увеличивается на 1 копейку), -- (сумма уменьшается на
1 копейку), <, >, ==, !=.
Класс не может содержать отрицательную сумму.
В случае если при исполнении какой-либо операции получается отрицательная сумма денег, то класс генерирует
исключительную ситуацию «Банкрот».
Программа должна с помощью меню продемонстрировать все возможности класса Money.
Обработка исключительных ситуаций производится в программе.
 
 */


namespace MoneySpace
{

    class Wallet
    {
        private Money money;
        private Menu Menu1;// меню
        private IMenu Item1;//список елементов меню
        private bool ExitFlag = true; // флаг выхода из програмы


        public Wallet()
        {
            money = new Money(0, 0);
            Item1 = new IMenu
            {
                new ItemMenu(" Вывести деньги в кошельке", new GetMethod(Print)),
                new ItemMenu(" Добавить деньги", new GetMethod(Add)),
                new ItemMenu(" Забрать деньги", new GetMethod(Del)),
                new ItemMenu(" Умножить деньги", new GetMethod(Multiply)),
                new ItemMenu(" Поделить деньги", new GetMethod(Multiply)),
                new ItemMenu(" Сравнить деньги", new GetMethod(Multiply)),
                new ItemMenu(" Выход", new GetMethod(Exit))
            };

            Menu1 = new Menu(5, 5, Item1);


        }
        private void Add()
        {
            double temp;
            do
            {
                Console.WriteLine("Введите деньги для добавления в кошелек:");
            } while (!double.TryParse(Console.ReadLine(), out temp));

            money += new Money(temp);

            Console.WriteLine("Деньги добавлены!");
            Console.ReadKey();
            Console.Clear();
        }


        private void Del()
        {
            double temp;
            do
            {
                Console.WriteLine("Введите деньги для удаления из кошелек:");
            } while (!double.TryParse(Console.ReadLine(), out temp));

            money -= new Money(temp);

            Console.WriteLine("Деньги удалены!");
            Console.ReadKey();
            Console.Clear();
        }

        private void Multiply()
        {
           int temp;
            do
            {
                Console.WriteLine("Введите целый коефициент для умножения:");
            } while (!Int32.TryParse(Console.ReadLine(), out temp));

            money = money * temp;

            Console.WriteLine("Деньги умножены!");
            Console.ReadKey();
            Console.Clear();
        }
       

        private void Divide()
        {
            int temp;
            do
            {
                Console.WriteLine("Введите целый коефициент для деления:");
            } while (!Int32.TryParse(Console.ReadLine(), out temp));

            money = money / temp;

            Console.WriteLine("Деньги умножены!");
            Console.ReadKey();
            Console.Clear();
        }

        public void Print()
        {
            Console.WriteLine(money);
        }

        private void Exit()
        {
            Console.WriteLine("Выход\n Спасибо за пользование програмой!");

            ExitFlag = false;
        }

        public void Run()
        {
            do
            {
              //  Console.WriteLine("КОШЕЛЕК");
                Menu1.Show();
            } while (ExitFlag);

        }


    }





    partial class Program
    {

        static void Main(string[] args)
        {
          //  Money money = new Money();
          //  Money money2 = new Money(15.13);

           // Console.WriteLine(money2);

            Wallet wallet = new Wallet();

            wallet.Run();
            Console.ReadKey();


        }
    }
}
