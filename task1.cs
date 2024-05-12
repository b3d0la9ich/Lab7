using System;
using System.Collections.Generic;

class Program
{
    static bool FindExpression(List<int> numbers, int target, int currentSum, string currentExpression, List<bool> used)
    {
        if (currentSum == target)
        {
            Console.WriteLine(currentExpression + " = " + target);
            return true;
        }

        for (int i = 0; i < numbers.Count; i++)
        {
            if (used[i])
                continue;

            used[i] = true;

            if (FindExpression(numbers, target, currentSum + numbers[i], currentExpression + "+" + numbers[i], used))
                return true;

            used[i] = false;

            used[i] = true;

            if (FindExpression(numbers, target, currentSum * numbers[i], currentExpression + "*" + numbers[i], used))
                return true;

            used[i] = false;
        }
        return false;
    }

    static void Main(string[] args)
    {
        Console.Write("Введите количество двузначных чисел: ");
        int n = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>(n);
        List<bool> used = new List<bool>(n);
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите {i + 1}-е двузначное число: ");
            numbers.Add(int.Parse(Console.ReadLine()));
            used.Add(false);
        }

        Console.Write("Введите целевое число: ");
        int target = int.Parse(Console.ReadLine());

        // Пробуем каждое число в качестве начального числа в выражении
        for (int i = 0; i < numbers.Count; i++)
        {
            used[i] = true;
            if (FindExpression(numbers, target, numbers[i], numbers[i].ToString(), used))
                return;
            used[i] = false;
        }

        Console.WriteLine("Невозможно получить заданное число используя эти числа и операции сложения и умножения.");
    }
}