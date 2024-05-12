#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

// Функция для вычисления факториала
int factorial(int n) {
    if (n <= 1)
        return 1;
    return n * factorial(n - 1);
}

// Функция для генерации перестановок
string getPermutation(int n, int k) {
    string result;
    vector<int> nums;

    // Заполняем вектор числами от 1 до n
    for (int i = 1; i <= n; ++i) {
        nums.push_back(i);
    }

    // Генерируем k-ую перестановку
    do {
        k--;
        if (k == 0) {
            for (int num : nums) {
                result += to_string(num);
            }
            break;
        }
    } while (next_permutation(nums.begin(), nums.end()));

    return result;
}

int main() {
    int n, k;
    cout << "Введите значение 1 <= n <= 9: ";
    cin >> n;
    cout << "Введите значение 1 <= k <= n!: ";
    cin >> k;

    // Проверка на корректность ввода k
    if (k < 1 || k > factorial(n) || n < 1 || n > 9) {
        cout << "Несоответствие условию!" << endl;
        return 1;
    }

    string permutation = getPermutation(n, k);
    cout << "Перестановка под номером " << k << " для n = " << n << ": " << permutation << endl;

    return 0;
}