using System;
using System.Collections.Generic;
using System.Linq; // Додано для використання Linq, якщо потрібно, але в цьому коді не обов'язково

class Program
{
    // === 1. ФУНКЦІЇ ДЛЯ ОБЧИСЛЕННЯ ===

    // Функція f(x): f(x) = x^3 - 2x - 5
    static double F(double x)
    {
        return x * x * x - 2 * x - 5;
    }

    // Чисельна перша похідна f'(x) - Потрібна для МН, але залишаємо для повноти
    static double FP(double x, double D)
    {
        return (F(x + D) - F(x)) / D;
    }

    // Чисельна друга похідна f''(x) - Потрібна для МН, але залишаємо для повноти
    static double F2P(double x, double D)
    {
        // Використовуємо центральну різницеву формулу
        return (F(x + D) + F(x - D) - 2 * F(x)) / (D * D);
    }

    // === 2. МЕТОД ДІЛЕННЯ НАВПІЛ (МДН) - ДОДАНО ТІЛО МЕТОДУ ===

    static double BisectionMethod(double a, double b, double Eps, int Kmax, out int iterations)
    {
        iterations = 0;
        double x = (a + b) / 2.0;

        // Перевірка умови існування кореня
        if (F(a) * F(b) > 0)
        {
            Console.WriteLine("Помилка МДН: Функцiя має однаковий знак на кiнцях iнтервалу.");
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
            // У цьому контексті ми не повинні сюди потрапити, оскільки інтервал вже знайдено
            return double.NaN;
        }

        return x;
    }

    // === 3. ФУНКЦІЯ ЛОКАЛІЗАЦІЇ (БУЛА У ВАШОМУ КОДІ) ===

    static List<Tuple<double, double>> FindRootIntervals(double start, double end, double h)
    {
        var intervals = new List<Tuple<double, double>>();
        double x_i = start;

        while (x_i < end)
        {
            double x_next = x_i + h;

            if (x_next > end)
            {
                x_next = end;
            }

            double f_i = F(x_i);
            double f_next = F(x_next);

            // Умова зміни знака
            if (f_i * f_next < 0)
            {
                intervals.Add(Tuple.Create(x_i, x_next));
            }

            x_i = x_next;
        }

        return intervals;
    }

    // === 4. МЕТОД MAIN (ОНОВЛЕНО) ===

    static void Main(string[] args)
    {
        Console.WriteLine("=== Пошук iнтервалу локалiзацiї кореня ===");

        double startRange = 0, endRange = 0, stepH = 0;

        // Блок введення даних для табулювання
        try
        {
            Console.Write("Введiть початок загального дiапазону (напр. 0.0): ");
            startRange = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введiть кiнець загального дiапазону (напр. 5.0): ");
            endRange = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введiть крок табулювання h (напр. 0.5): ");
            stepH = Convert.ToDouble(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: Некоректний формат вхiдних даних.");
            Console.ReadLine();
            return;
        }

        // 2. ВИКЛИК ФУНКЦІЇ ЛОКАЛІЗАЦІЇ
        var foundIntervals = FindRootIntervals(startRange, endRange, stepH);

        Console.WriteLine("\n--- Знайденi iнтервали локалiзацiї ---");

        if (foundIntervals.Count == 0)
        {
            Console.WriteLine($"Корiнь не знайдено на дiапазонi [{startRange}, {endRange}] з кроком {stepH}.");
            Console.ReadLine();
            return;
        }

        // 3. ВИБІР ІНТЕРВАЛУ ДЛЯ МДН (вибираємо перший)
        Console.WriteLine("Знайдено наступнi iнтервали:");
        for (int i = 0; i < foundIntervals.Count; i++)
        {
            var interval = foundIntervals[i];
            Console.WriteLine($"{i + 1}. [{interval.Item1:F4}, {interval.Item2:F4}]");
        }

        var chosenInterval = foundIntervals[0];
        double a = chosenInterval.Item1;
        double b = chosenInterval.Item2;

        // --- ДАНІ ДЛЯ МДН ---
        // Ці дані повинні бути введені користувачем для повної універсальності, але використовуємо константи для прикладу.
        double Eps = 0.0001;
        int Kmax = 100;
        int iterations;

        // 4. ЗАПУСК МДН З ЛОКАЛІЗОВАНИМ ІНТЕРВАЛОМ
        Console.WriteLine($"\n--- Запуск МДН на iнтервалi [{a:F4}, {b:F4}] з Eps={Eps} ---");

        // ПОМИЛКА ВИПРАВЛЕНА: BisectionMethod тепер визначено вище.
        double root = BisectionMethod(a, b, Eps, Kmax, out iterations);

        // 5. ВИВЕДЕННЯ РЕЗУЛЬТАТУ
        if (!double.IsNaN(root))
        {
            Console.WriteLine("\n*** ЗНАЙДЕНО КОРIНЬ МДН ***");
            Console.WriteLine($"Корiнь: {root:F10}");
            Console.WriteLine($"Кiлькiсть iтерацiй: {iterations}");
            Console.WriteLine($"Перевiрка f({root:F10}) = {F(root):E2}");
        }
        else
        {
            Console.WriteLine("МДН: Не змiг знайти корiнь.");
        }

        Console.WriteLine("Натиснiть Enter для завершення...");
        Console.ReadLine();
    }
}