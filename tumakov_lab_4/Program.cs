using System;

namespace tumakov_lab_4
{
    internal class Program
    {
        /// <summary>
        /// Метод, возвращающий наибольшее из двух чисел
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        static void searchmax(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
            {
                Console.WriteLine($"({firstNumber})");
            }
            else if (firstNumber < secondNumber)
            {
                Console.WriteLine($"({secondNumber})");
            }
            else
            {
                Console.WriteLine("Они равны");
            }
        }
        /// <summary>
        /// метод, который меняет местами значения двух передаваемых параметров.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        /// <summary>
        /// метод вычисления факториала числа
        /// </summary>
        /// <param name="number"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        static bool Factorial(int number, out long result)
        {
            result = 1;
            if (number < 0)
                return false;
            try
            {
                checked
                {
                    for (int i = 1; i <= number; i++)
                    {
                        result *= i;
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// метод вычисления факториала числа (рекурсия)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static int FactorialR(int number)
        {
            if (number == 0) return 1;
            return number * FactorialR(number - 1);
        }
        static int NOD(int FirstNumber, int SecondNumber)
        {
            while (FirstNumber != SecondNumber)
            {
                if (FirstNumber > SecondNumber)
                {
                    FirstNumber = FirstNumber - SecondNumber;
                }
                else
                {
                    SecondNumber = SecondNumber - FirstNumber;
                }
            }
            return SecondNumber;
        }
        /// <summary>
        /// метод, который вычисляет НОД трех натуральных чисел.
        /// </summary>
        /// <param name="firstNumber1"></param>
        /// <param name="secondNumber1"></param>
        /// <param name="thirdNumber1"></param>
        /// <returns></returns>
        static int NOD(int firstNumber1, int secondNumber1, int thirdNumber1)
        {
            thirdNumber1 = NOD(NOD(firstNumber1, secondNumber1), thirdNumber1);
            return thirdNumber1;
        }
        /// <summary>
        /// рекурсивный метод, вычисляющий значение n-го числа ряда Фибоначчи.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int Fibonacci(int n)
        {
            if (n <= 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void Main()
        {
            Console.WriteLine("Упражнение 5.1");
            Console.Write("Введите первое число: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int secondNumber = int.Parse(Console.ReadLine());
            searchmax(firstNumber, secondNumber);

            Console.WriteLine("\nУпражнение 5.2");
            Console.Write("Введите первое число: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"До обмена: Первое число - {a}, Второе число - {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"После обмена: Первое число - {a}, Второе число - {b}");

            Console.WriteLine("\nУпражнение 5.3");
            Console.Write("Введите число: ");
            int input = int.Parse(Console.ReadLine());
            long factorial;

            if (Factorial(input, out factorial))
            {
                Console.WriteLine($"Факториал: {factorial}");
            }
            else
            {
                Console.WriteLine("Ошибка при вычислении.");
            }

            Console.WriteLine("\nУпражнение 5.4");
            Console.Write("Введите число: ");
            if (int.TryParse(Console.ReadLine(), out int input1) && input1 >= 0)
            {
                Console.WriteLine($"Факториал: {FactorialR(input1)}");
            }
            else
            {
                Console.WriteLine("Факториал не существует для отрицательных чисел или введено неверное значение.");
            }

            Console.WriteLine("\nДомашнее задание 5.1_1 ");
            Console.WriteLine("Введите первое число");
            int FirstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число");
            int SecondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"НОД {FirstNumber} и {SecondNumber} равен {NOD(FirstNumber, SecondNumber)}");

            Console.WriteLine("\nДомашнее задание 5.1_2 ");
            Console.WriteLine("Введите первое число");
            int firstNumber1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число");
            int secondNumber1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите третье число");
            int thirdNumber1 = int.Parse(Console.ReadLine());
            Console.WriteLine($"НОД чисел {firstNumber1} и {secondNumber1} и {thirdNumber1} равен {NOD(firstNumber1, secondNumber1, thirdNumber1)}");

            Console.WriteLine("\nДомашнее задание 5.2 ");
            Console.Write("Введите число для вычисления числа Фибоначчи: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"F({n}) = {Fibonacci(n)}");
        }

    }
}
