using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Функция для вычисления факториала
    static int Factorial(int n)
    {
        if (n <= 1)
            return 1;
        return n * Factorial(n - 1);
    }

    // Функция для генерации перестановок
    static string GetPermutation(int n, int k)
    {
        string result = "";
        List<int> nums = Enumerable.Range(1, n).ToList();

        // Генерируем k-ую перестановку
        do
        {
            k--;
            if (k == 0)
            {
                foreach (int num in nums)
                {
                    result += num.ToString();
                }
                break;
            }
        } while (NextPermutation(nums));

        return result;
    }

    // Функция для генерации следующей перестановки
    static bool NextPermutation(List<int> nums)
    {
        int i = nums.Count - 2;
        while (i >= 0 && nums[i] >= nums[i + 1])
        {
            i--;
        }
        if (i < 0)
        {
            return false;
        }

        int j = nums.Count - 1;
        while (nums[j] <= nums[i])
        {
            j--;
        }

        Swap(nums, i, j);
        Reverse(nums, i + 1, nums.Count - 1);
        return true;
    }

    // Функция для обмена значений в списке
    static void Swap(List<int> nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    // Функция для разворота части списка
    static void Reverse(List<int> nums, int start, int end)
    {
        while (start < end)
        {
            Swap(nums, start, end);
            start++;
            end--;
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Введите значение 1 <= n <= 9: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите значение 1 <= k <= n!: ");
        int k = int.Parse(Console.ReadLine());

        // Проверка на корректность ввода k
        if (k < 1 || k > Factorial(n) || n < 1 || n > 9)
        {
            Console.WriteLine("Несоответствие условию!");
            return;
        }

        string permutation = GetPermutation(n, k);
        Console.WriteLine($"Перестановка под номером {k} для n = {n}: {permutation}");
    }
}
