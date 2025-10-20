using System;

class Program
{

    // Функція f(x): f(x) = x^3 - 2x - 5
    static double F(double x)
    {
        return x * x * x - 2 * x - 5;
    }

    // Чисельна перша похідна f'(x)
    static double FP(double x, double D)
    {
        return (F(x + D) - F(x)) / D;
    }

    // Чисельна друга похідна f''(x)
    static double F2P(double x, double D)
    {
        // Використовуємо центральну різницеву формулу: (f(x+D) + f(x-D) - 2*f(x)) / D^2
        return (F(x + D) + F(x - D) - 2 * F(x)) / (D * D);
    }

    // === 2. МЕТОД ДІЛЕННЯ НАВПІЛ (МДН) ===

    /// <summary>
    /// Знаходить корінь функції F(x) методом ділення навпіл.
    /// </summary>
    /// <param name="a">Ліва межа інтервалу.</param>
    /// <param name="b">Права межа інтервалу.</param>
    /// <param name="Eps">Точність обчислення.</param>
    /// <param name="Kmax">Максимальна кількість ітерацій.</param>
    /// <param name="iterations">Повертає кількість виконаних ітерацій.</param>
    /// <returns>Знайдений корінь або NaN у разі помилки/перевищення Kmax.</returns>
    static double BisectionMethod(double a, double b, double Eps, int Kmax, out int iterations)
    {
        iterations = 0;
        double x = (a + b) / 2.0;

        // Перевірка умови існування кореня
        if (F(a) * F(b) > 0)
        {
            Console.WriteLine("Помилка МДН: Функція має однаковий знак на кінцях інтервалу.");
            return double.NaN;
        }

        while ((b - a) / 2.0 > Eps && iterations < Kmax)
        {
            x = (a + b) / 2.0;

            if (F(x) == 0) break; // Точний корінь знайдено

            if (F(a) * F(x) < 0)
            {
                b = x; // Корінь в лівій половині
            }
            else
            {
                a = x; // Корінь в правій половині
            }
            iterations++;
        }

        if (iterations >= Kmax)
        {
            Console.WriteLine($"МДН: Корiнь не знайдено за {Kmax} iтерацiй.");
            return double.NaN;
        }

        return x;
    }

    // === 3. МЕТОД НЬЮТОНА (МН) ===

    /// <summary>
    /// Знаходить корінь функції F(x) методом Ньютона.
    /// </summary>
    /// <param name="a">Ліва межа інтервалу (для перевірки збіжності).</param>
    /// <param name="b">Права межа інтервалу (для початкового наближення).</param>
    /// <param name="Eps">Точність обчислення.</param>
    /// <param name="Kmax">Максимальна кількість ітерацій.</param>
    /// <param name="iterations">Повертає кількість виконаних ітерацій.</param>
    /// <returns>Знайдений корінь або NaN у разі помилки/перевищення Kmax.</returns>
    static double NewtonMethod(double a, double b, double Eps, int Kmax, out int iterations)
    {
        iterations = 0;
        double D = Eps / 100.0;
        double x, Dx;

        // Вибір початкового наближення: x0
        x = b; // Початкове значення x = b

        if (F(x) * F2P(x, D) < 0)
        {
            x = a; // Якщо умова порушена для b, беремо a
        }

        if (F(x) * F2P(x, D) <= 0)
        {
            Console.WriteLine("Помилка МН: Умова збiжностi (f(x)*f''(x)>0) не гарантується для жодної з кiнцевих точок.");
            return double.NaN;
        }

        for (iterations = 1; iterations <= Kmax; iterations++)
        {
            // Захист від ділення на нуль
            double fp_x = FP(x, D);
            if (Math.Abs(fp_x) < 1e-10)
            {
                Console.WriteLine("Помилка МН: Нульове значення першої похiдної (дiлення на нуль).");
                return double.NaN;
            }

            Dx = F(x) / fp_x;
            x = x - Dx;

            if (Math.Abs(Dx) <= Eps)
            {
                return x; // Корінь знайдено
            }
        }

        Console.WriteLine($"МН: Корiнь не знайдено за {Kmax} iтерацiй.");
        return double.NaN;
    }

    // === 4. ОСНОВНА ПРОГРАМА (MAIN) ===

    static void Main(string[] args)
    {
        // 1. ДІАЛОГОВИЙ ВИБІР МЕТОДУ
        Console.WriteLine("=== Розв'язання нелiнiйного рiвняння F(x) = x^3 - 2x - 5 ===");
        Console.WriteLine("Оберiть метод:");
        Console.WriteLine("1. Метод дiлення навпiл (МДН)");
        Console.WriteLine("2. Метод Ньютона (МН)");
        Console.Write("Ваш вибiр (1 або 2): ");
        string choice = Console.ReadLine();

        // 2. СПІЛЬНИЙ БЛОК ВВЕДЕННЯ ВХІДНИХ ДАНИХ
        Console.WriteLine("\n--- Введення вхiдних даних ---");

        double a = 0, b = 0, Eps = 0;
        int Kmax = 0;

        try
        {
            Console.Write("Введiть a (лiва межа): ");
            a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введiть b (права межа): ");
            b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введiть точнiсть Eps: ");
            Eps = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введiть Kmax (макс. iтерацiй): ");
            Kmax = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: Некоректний формат вхiдних даних.");
            Console.ReadLine();
            return;
        }

        // 3. ВИКЛИК ОБРАНОГО МЕТОДУ
        Console.WriteLine("\n--- Обчислення ---");
        double root = double.NaN;
        int iterations = 0;
        string methodName = "";

        if (choice == "1")
        {
            root = BisectionMethod(a, b, Eps, Kmax, out iterations);
            methodName = "Метод дiлення навпiл (МДН)";
        }
        else if (choice == "2")
        {
            root = NewtonMethod(a, b, Eps, Kmax, out iterations);
            methodName = "Метод Ньютона (МН)";
        }
        else
        {
            Console.WriteLine("Невiрний вибiр методу. Робота програми завершена.");
            Console.ReadLine();
            return;
        }

        // 4. СПІЛЬНИЙ БЛОК ВИВЕДЕННЯ РЕЗУЛЬТАТІВ
        Console.WriteLine("\n--- Результат ---");
        Console.WriteLine($"Обраний метод: {methodName}");

        if (!double.IsNaN(root))
        {
            Console.WriteLine($"Знайдений корiнь: {root:F10}");
            Console.WriteLine($"Кiлькiсть iтерацiй: {iterations}");
            Console.WriteLine($"Перевiрка f({root:F10}) = {F(root):E2}");
        }
        else
        {
            Console.WriteLine("Кореня не знайдено або виникла помилка. Деталi вище.");
        }

        Console.WriteLine("Натиснiть Enter для завершення...");
        Console.ReadLine(); 
    }
}