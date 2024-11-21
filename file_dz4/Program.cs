using System;


namespace file_dz4
{
    internal class Program
    {
        /// <summary>
        /// метод, где в качества аргумента будет передан массив
        /// </summary>
        /// <param name="product"></param>
        /// <param name="average"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        static int CalculateArrayStatistics(ref int product, out double average, params int[] numbers)
        {
            int sum = 0;
            product = 1;
            foreach (var number in numbers)
            {
                sum += number;
                product *= number;
            }
            average = numbers.Length > 0 ? (double)sum / numbers.Length : 0;
            return sum;
        }
        /// <summary>
        ///  метод принимает целое число number (от 0 до 9) и отображает его в виде текстового рисунка.
        /// </summary>
        /// <param name="number"></param>
        static void DrawNumber(int number)
        {
            string[] digitPatterns = new string[]
            {
            "###\n# #\n###\n# #\n###", // 0
            "  #\n  #\n  #\n  #\n  #", // 1 и тд.
            "###\n  #\n###\n#  \n###",
            "###\n  #\n###\n  #\n###",
            "# #\n# #\n###\n  #\n  #",
            "###\n#  \n###\n  #\n###",
            "###\n#  \n###\n# #\n###",
            "###\n  #\n  #\n  #\n  #",
            "###\n# #\n###\n# #\n###",
            "###\n# #\n###\n  #\n  #",
            };

            Console.WriteLine(digitPatterns[number]);
        }
        /// <summary>
        ///  метод принимает параметр color, чтобы установить цвет текста в консоли.
        /// </summary>
        /// <param name="color"></param>
        static void SetConsoleColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        /// <summary>
        /// метод сбрасывает настройки цвета консоли на значения по умолчанию
        /// </summary>
        static void ResetConsoleColor()
        {
            Console.ResetColor();
        }
        static void Main()
        {
            Console.WriteLine("Задание 1");
            //Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива,
            //которые нужно поменять местами.Вывести на экран получившийся массив.
            Random rnd = new Random();
            int[] ints = new int[20];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = rnd.Next(1, 502);
            }
            Console.WriteLine("Исходный массив:" + string.Join(", ", ints));

            Console.Write("Введите первое число для обмена: ");
            int firstNum = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число для обмена: ");
            int secondNum = int.Parse(Console.ReadLine());

            int firstIndex = Array.IndexOf(ints, firstNum);
            int secondIndex = Array.IndexOf(ints, secondNum);

            if (firstIndex != -1 && secondIndex != -1)
            {
                ints[firstIndex] = secondNum;
                ints[secondIndex] = firstNum;
            }
            Console.WriteLine("Измененный массив: " + string.Join(", ", ints));

            Console.WriteLine("\nЗадание 2");
            //Написать метод, где в качества аргумента будет передан массив(ключевое слово
            //params). Вывести сумму элементов массива(вернуть). Вывести(ref) произведение
            //массива.Вывести(out) среднее арифметическое в массиве.
            int product = 1;
            double average;
            int sum = CalculateArrayStatistics(ref product, out average, 1, 2, 3, 4, 5);
            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Произведение: {product}");
            Console.WriteLine($"Среднее арифметическое: {average}");

            Console.WriteLine("\nЗадание 3");
            //Пользователь вводит числа.Если числа от 0 до 9, то необходимо в консоли нарисовать
            //изображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль
            //должна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке. Если
            //пользователь ввёл не цифру, то программа должна выпасть в исключение. Программа
            //завершает работу, если пользователь введёт слово: exit или закрыть(оба варианта
            //должны сработать) - консоль закроется.
            while (true)
            {
                Console.Write("Введите число (для окончания работы с консолью напишите 'exit'): ");
                string input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("закрыть", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                try
                {
                    int number = int.Parse(input);

                    if (number >= 0 && number <= 9)
                    {
                        DrawNumber(number);
                    }
                    else
                    {
                        SetConsoleColor(ConsoleColor.Red);
                        Console.WriteLine("Ошибка: число должно быть от 0 до 9.");
                        ResetConsoleColor();
                        System.Threading.Thread.Sleep(3000);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введено не число.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
                }
            }
        }
    }
}
