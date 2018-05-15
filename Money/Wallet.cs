using System;
using System.Linq;
using IMenu = System.Collections.Generic.List<System.Tuple<string, GetMethod>>;
using ItemMenu = System.Tuple<string, GetMethod>;
using MenuSpace;
using Moneyclass;

/*
 Написать класс Money, предназначенный для хранения денежной суммы (в гривнах и копейках).
 Для класса реализовать перегрузку операторов + (сложение денежных сумм), – (вычитание сумм),
 / (деление суммы на целое число), * (умножение суммы на целое число), ++ (сумма
увеличивается на 1 копейку), -- (сумма уменьшается на
1 копейку), <, >, ==, !=.
Класс не может содержать отрицательную сумму.
В случае если при исполнении какой-либо операции получается отрицательная сумма денег, то класс генерирует
исключительную ситуацию «Банкрот».
Программа должна с помощью меню продемонстрировать все возможности класса Money.
Обработка исключительных ситуаций производится в программе.
 
 */


namespace WalletSpace
{
    class Wallet
    {
        private Money money;//деньги
        private Menu Menu1;// меню
        private bool ExitFlag = true; // флаг выхода из програмы


        public Wallet()
        {
            money = new Money(0);
            

            Menu1 = new Menu(5, 5, new IMenu
            {
                new ItemMenu(" Вывести деньги в кошельке", new GetMethod(Print)),
                new ItemMenu(" Добавить деньги", new GetMethod(Add)),
                new ItemMenu(" Забрать деньги", new GetMethod(Del)),
                new ItemMenu(" Умножить деньги", new GetMethod(Multiply)),
                new ItemMenu(" Поделить деньги", new GetMethod(Divide)),
                new ItemMenu(" Инкрементировать деньги", new GetMethod(Increment)),
                new ItemMenu(" Декрементировать деньги", new GetMethod(Decrement)),
                new ItemMenu(" Сравнить деньги", new GetMethod(Compare)),
                new ItemMenu(" Помощь", new GetMethod(Help)),
                new ItemMenu(" Выход", new GetMethod(Exit))
            });


        }

        // дополнительная процедурка для вывода сообщения, ожидания нажатия клавиши и  очистки екрана
        private void SupportMessage(string message)
        {
            Console.WriteLine($"Деньги {message}!");
            Console.ReadKey();
            Console.Clear();
            Print();
        }

        // ввод денег разными способами
        private Money EnterMoney(string text)
        {
            int temp, temp1, temp2;

            if (Int32.TryParse(text, out temp)
)            {
                return new Money(temp);
             }
            else if (text.Contains(',') || text.Contains(' ') || text.Contains('.'))
            {
                // розділяємо стрічку      
                String[] parts = text.Split(',', ' ', '.');
                if (parts.Length == 2)
                {
                    //перевіряємо чи нормально пройшов парсинг
                    if (!Int32.TryParse(parts[0], out temp1) || !Int32.TryParse(parts[1], out temp2))
                    {
                        throw new FormatException("Bad parse string to int !");
                    }
                    else
                    {
                        return new Money(temp1, temp2);
                    }
                }
                else
                {
                    throw new FormatException("Bad string format.Too many or less parameters");
                }
            }
            else
            {
                throw new FormatException("Bad string format.");
            }

        }

        //помощь
        private void  Help()
        {
            string text = "Деньги можно ввести нескольками способами:\n" +
                           "1) формат целого числа (100) - 1 грн 00 копеек;\n" +
                           "2) формат действительного числа   (15,15) -  15 грн 15 копеек\n" +
                           "3) формат двух чисел через пробел (10 12) -  10 грн 12 копеек\n" +
                           "4) формат двух чисел через крапку (17.10) -  17 грн 10 копеек\n"+
                           "   Будьте внимательны при  вводу, пожалуйста !" ;
            Console.WriteLine(text);
            Console.ReadKey();
            Console.Clear();
        }


        //добавляем деньги в кошелек
        private void Add()
        {
            Console.WriteLine("Введите деньги для добавления в кошелек:");
            money += EnterMoney(Console.ReadLine());
            SupportMessage("добавлены");
        }

        //удаляем деньги из кошелька
        private void Del()
        {
            try
            {
                Console.WriteLine("Введите деньги для удаления из кошелек:");
                money -= EnterMoney(Console.ReadLine());
            }
            catch (Exception)
            {
                throw;
            }
       
            SupportMessage("удалены");
        }

        // множым деньги на число
        private void Multiply()
        {
           int temp;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите целый коефициент для умножения:");
            } while (!Int32.TryParse(Console.ReadLine(), out temp));
             money = money * temp;
             SupportMessage("умножены");
        }

        // делим деньги на число
        private void Divide()
        {
            int temp;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите целый коефициент для деления:");
            } while (!Int32.TryParse(Console.ReadLine(), out temp));

            money = money / temp;
            SupportMessage("поделены");
        }

        // инкремент
        private void Increment()
        {
            money++;
            SupportMessage("инкрементированы");
        }

        //декремент
        private void Decrement()
        {
            try
            {
                money--;
            }
            catch (Exception)
            {
                throw;
            }
            SupportMessage("декрементированы");
        }

        //сравнение двух чисел
        private void Compare()
        {
           
            Console.WriteLine("Введите деньги для сравнения с деньгами из кошелька :");
            Money tempmoney = EnterMoney(Console.ReadLine());

            if (money == tempmoney)
            {
                Console.WriteLine("Деньги равны между собой!");
            }
            else if (money > tempmoney)
            {
                Console.WriteLine("Денег в кошельке больше!");
            }
            else
            {
                Console.WriteLine("Денег в кошельке меньше!");
            }

            SupportMessage("сравнены");
        }

        //выход
            private void Exit()
        {
            Console.WriteLine("Выход\n Спасибо за пользование програмой!");

            ExitFlag = false;
        }

        //запуск класа кошелек
        public void Run()
        {
            do
            {
              //  Console.WriteLine("КОШЕЛЕК");
                Menu1.Show();
            } while (ExitFlag);

        }

        private void Print()
        {
            Console.WriteLine($"КОШЕЛЕК: {money}");
        }


    }
}
