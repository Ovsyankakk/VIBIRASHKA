using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите задание:");
            Console.WriteLine("1. Найти среднее значение между четырьмя числами");
            Console.WriteLine("2. Программа-калькулятор");
            Console.WriteLine("3. Конвертация температуры");
            Console.WriteLine("4. Определить имя файла по пути");
            Console.WriteLine("5. Нахождение самого длинного слова");
            Console.WriteLine("6. Перемножить два массива");
            Console.WriteLine("7. Найти максимальное и минимальное число из пяти введенных");
            Console.WriteLine("8. Вывод пирамиды чисел");
            Console.WriteLine("9, 2 часть. Полная таблица умножения");
            Console.WriteLine("10, 3 часть. Не поняла :). Его тут нет");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Ошибка! Введите номер задания.");
                continue;
            }

            switch (choice)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break; 
                case 6: Task6(); break;
                case 7: Task7(); break;
                case 8: Task8(); break;
                case 9: Task9(); break;
                default:
                    Console.WriteLine("Ошибка! Неверный выбор задания.");
                    break;
            }

            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }
    }

    static void Task1()
    {
        Console.Clear();
        Console.WriteLine("Введите четыре числа:");
        double[] numbers = new double[4];
        for (int i = 0; i < 4; i++)
        {
            numbers[i] = GetDoubleInput($"Число {i + 1}: ");
        }
        double average = numbers.Average();
        Console.WriteLine($"Среднее значение: {average}");
    }

    static void Task2()
    {
        Console.Clear();
        Console.WriteLine("Введите два числа:");
        double num1 = GetDoubleInput("Первое число: ");
        double num2 = GetDoubleInput("Второе число: ");

        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Сложение");
        Console.WriteLine("2. Вычитание");
        Console.WriteLine("3. Умножение");
        Console.WriteLine("4. Деление");
        Console.WriteLine("5. Нахождение остатка");

        int action = GetIntInput();
        double result = 0;

        switch (action)
        {
            case 1: result = num1 + num2; break;
            case 2: result = num1 - num2; break;
            case 3: result = num1 * num2; break;
            case 4:
                if (num2 != 0) result = num1 / num2;
                else { Console.WriteLine("Ошибка! Деление на ноль."); return; }
                break;
            case 5: result = num1 % num2; break;
            default: Console.WriteLine("Ошибка! Неверное действие."); return;
        }

        Console.WriteLine($"Результат: {result}");
    }

    static void Task3()
    {
        Console.Clear();
        Console.WriteLine("Выберите шкалу вводимой температуры:");
        Console.WriteLine("1. Цельсий");
        Console.WriteLine("2. Кельвин");
        Console.WriteLine("3. Фаренгейт");

        int scaleFrom = GetIntInput();
        double temp = GetDoubleInput("Введите показатель температуры (градусы): ");

        Console.WriteLine("Выберите тип шкалы для конвертации:");
        Console.WriteLine("1. Цельсий");
        Console.WriteLine("2. Кельвин");
        Console.WriteLine("3. Фаренгейт");

        int scaleTo = GetIntInput();

        double result = 0;
        if (scaleFrom == 1 && scaleTo == 3) // Цельсий - Фаренгейт
            result = temp * 9 / 5 + 32;
        else if (scaleFrom == 3 && scaleTo == 1) // Фаренгейт - Цельсий
            result = (temp - 32) * 5 / 9;
        else if (scaleFrom == 1 && scaleTo == 2) // Цельсий - Кельвин
            result = temp + 273.15;
        else if (scaleFrom == 2 && scaleTo == 1) // Кельвин - Цельсий
            result = temp - 273.15;
        else if (scaleFrom == 2 && scaleTo == 3) // Кельвин - Фаренгейт
            result = (temp - 273.15) * 9 / 5 + 32;
        else if (scaleFrom == 3 && scaleTo == 2) // Фаренгейт - Кельвин
            result = (temp - 32) * 5 / 9 + 273.15;

        Console.WriteLine($"Результат конвертации: {result}");
    }

    static void Task4()
    {
        Console.Clear();
        Console.WriteLine("Введите путь до файла:");
        string path = Console.ReadLine();
        string fileName = System.IO.Path.GetFileName(path);
        Console.WriteLine($"Имя файла: {fileName}");
    }

    static void Task5()
    {
        Console.Clear();
        Console.WriteLine("Введите предложение:");
        string input = Console.ReadLine();
        string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string longestWord = "";
        foreach (string word in words)
        {
            if (word.Length > longestWord.Length)
            {
                longestWord = word;
            }
        }
        Console.WriteLine($"Самое длинное слово: {longestWord}");
    }

    static void Task6()
    {
        Console.Clear();
        Console.WriteLine("Введите значения для первого массива через пробел:");
        double[] array1 = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);

        Console.WriteLine("Введите значения для второго массива через пробел:");
        double[] array2 = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);

        if (array1.Length != array2.Length)
        {
            Console.WriteLine("Ошибка! Массивы должны быть одинаковой длины.");
            return;
        }

        double[] resultArray = new double[array1.Length];
        for (int i = 0; i < array1.Length; i++)
        {
            resultArray[i] = array1[i] * array2[i];
        }

        Console.WriteLine("Результат: " + string.Join(" ", resultArray));
    }

    static void Task7()
    {
        Console.Clear();
        Console.WriteLine("Введите пять чисел через пробел:");
        double[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);

        if (numbers.Length != 5)
        {
            Console.WriteLine("Ошибка! Необходимо ввести ровно пять чисел.");
            return;
        }

        double maxNum = numbers[0];
        double minNum = numbers[0];

        foreach (var number in numbers)
        {
            if (number > maxNum) maxNum = number;
            if (number < minNum) minNum = number;
        }

        Console.WriteLine($"Максимальное число: {maxNum}");
        Console.WriteLine($"Минимальное число: {minNum}");
    }

    static void Task8()
    {
        Console.Clear();
        Console.WriteLine("Введите количество ступеней:");
        int levels = GetIntInput();

        for (int i = 1; i <= levels; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j);
            }
            Console.WriteLine();
        }
    }

    static void Task9()
    {
        Console.Clear();
        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= 9; j++)
            {
                Console.Write($"{i} x {j} = {i * j}\t");
            }
            Console.WriteLine();
        }
    }

    static void Task10()
    {
        int number;

        while (true)
        {
            try
            {
                Console.Write("Введите целое число: ");
                number = int.Parse(Console.ReadLine());
                break; 
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Написано не целое число!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка! Число слишком большое или слишком маленькое!");
            }
        }
    }

    static int GetIntInput()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;

            Console.WriteLine("Ошибка! Введите целое число.");
        }
    }

    static double GetDoubleInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double result))
                return result;

            Console.WriteLine("Ошибка! Введите корректное число.");
        }
    }
}

