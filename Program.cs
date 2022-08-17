using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgHW1v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculate calculate = new Calculate();

            string anyKeyOrEscape = "Для продолжения выберите пункт меню (для выхода нажмите ESCAPE): ";
            string wrongInput = "\nНекорректный ввод";
            bool isExitFromConsole = false;
            ConsoleKeyInfo cki;
            char charFromConsole = ' ';
            ShowMenu();
            while (true)
            {
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape) 
                    return;
                charFromConsole = cki.KeyChar;

                switch (charFromConsole)
                {
                    case '0':
                        Console.Clear();
                        ShowMenu();
                        break;
                    case '1':
                        calculate.Sum();
                        break;
                    case '2':
                        calculate.Square();
                        break;
                    case '3':
                        calculate.Division();
                        break;
                    case '4':
                        calculate.Sinus();
                        break;
                    case '5':
                        calculate.Cosinus();
                        break;
                    case '6':
                        calculate.Pow();
                        break;
                    case '7':
                        calculate.Ln();
                        break;
                    case '8':
                        calculate.Lg();
                        break;
                    case '9':
                        calculate.Log();
                        break;
                    default:
                        Console.WriteLine(wrongInput);
                        break;

                }
                Console.Write(anyKeyOrEscape);
                /*
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    isExitFromConsole = true;
                }
                */
            }
        }
        static void ShowMenu()
        {
            string askSelectItem = "Наберите цифру соответствующей операции и нажмите ENTER (для выхода нажмите ESCAPE):";
            string[] menuItems = new string[10];
            menuItems[0] = "0. Очистка экрана";
            menuItems[1] = "1. Сложение";
            menuItems[2] = "2. Возведение в квадрат";
            menuItems[3] = "3. Деление второго числа на первое";
            menuItems[4] = "4. Синус числа";
            menuItems[5] = "5. Косинус числа";
            menuItems[6] = "6. Возведение в степень";
            menuItems[7] = "7. Извлечение натурального логарифма";
            menuItems[8] = "8. Извлечение десятичного логарифма";
            menuItems[9] = "9. Извлечение логарифма";
            foreach (string menuItem in menuItems)
            {
                Console.WriteLine(menuItem);
            }
            Console.WriteLine(askSelectItem);
        }
    }

    internal class Calculate
    {
        double firstNumber;
        double secondNumber;
        double result = 0;
        static readonly string askNumber = "Введите число:";
        static readonly string askFirstNumber = "Введите первое число:";
        static readonly string askSecondtNumber = "Введите второе число:";
        static readonly string askPow = "Введите степень числа:";
        static readonly string askLogBase = "Введите основание логарифма:";

        private static double GetOnlyNumber(string _str)
        {
            while (true)
            {
                if (Console.CursorLeft > 0) Console.WriteLine();
                Console.WriteLine(_str);
                if (double.TryParse(Console.ReadLine(), out double _result))
                {
                    return _result;
                }
                Console.WriteLine("Некорректный ввод");
            }
        }


        internal void Sum()
        {
            firstNumber = GetOnlyNumber(askFirstNumber);
            secondNumber = GetOnlyNumber(askSecondtNumber);
            result = firstNumber + secondNumber;
            Console.WriteLine($"\nРезультат сложения равен: {result} ");
        }

        internal void Square()
        {
            firstNumber = GetOnlyNumber(askNumber);
            result = firstNumber * firstNumber;
            Console.WriteLine($"\nРезультат возведения в квадрат равен: {result} ");
        }
        internal void Division()
        {
            firstNumber = GetOnlyNumber(askFirstNumber);
            secondNumber = GetOnlyNumber(askSecondtNumber);
            if (firstNumber == 0)
            {
                Console.WriteLine($"\nРезультат деления стремится к бесконечности");
            }
            if (firstNumber != 0)
            {
                result = secondNumber / firstNumber;
                Console.WriteLine($"\nРезультат деления равен: {result} ");
            }
        }
        internal void Sinus()
        {
            firstNumber = GetOnlyNumber(askNumber);
            result = Math.Sin(firstNumber);
            Console.WriteLine($"\nСинус равен: {result}");
        }
        internal void Cosinus()
        {
            firstNumber = GetOnlyNumber(askNumber);
            result = Math.Cos(firstNumber);
            Console.WriteLine($"\nКосинус равен: {result}");
        }
        internal void Pow()
        {
            firstNumber = GetOnlyNumber(askNumber);
            secondNumber = GetOnlyNumber(askPow);
            result = Math.Pow(firstNumber, secondNumber);
            Console.WriteLine($"\nЧисло {firstNumber} в степени {secondNumber} равно: {result}");
        }
        internal void Ln()
        {
            firstNumber = GetOnlyNumber(askNumber);
            result = Math.Log(firstNumber);
            Console.WriteLine($"\nНатуральный логарифм от числа {firstNumber} равен: {result}");
        }
        internal void Lg()
        {
            firstNumber = GetOnlyNumber(askNumber);
            result = Math.Log10(firstNumber);
            Console.WriteLine($"\nДесятичный логарифм от числа {firstNumber} равен: {result}");
        }
        internal void Log()
        {
            firstNumber = GetOnlyNumber(askNumber);
            secondNumber = GetOnlyNumber(askLogBase);
            result = Math.Log(firstNumber, secondNumber);
            Console.WriteLine($"\nЛогарифм от числа {firstNumber} по основанию {secondNumber} равен: {result}");
        }
    }
}
