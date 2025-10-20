using System;

class Program
{
    // 1. Метод функції (приклад: f(x) = x^3 - 2x - 5)
    static double f(double x)
    {
        return x * x * x - 2 * x - 5;
    }

    // 2. Метод першої похідної 
    static double fp(double x, double D)
    {
        return (f(x + D) - f(x)) / D;
    }

    // 3. Метод другої похідної 
    static double f2p(double x, double D)
    {
        return (f(x + D) + f(x - D) - 2 * f(x)) / (D * D);
    }

    static void Main(string[] args)
    {
        // 4. Поля дійсного типу
        double a, b;              // Межі локалізації
        double Eps;               // Точність
        double x, D, Dx;          // Робочі поля

        // Поля цілочислові
        int i;                    // Параметр циклу
        int Kmax;                 // Максимальна кількість ітерацій

        // 5. Введення значень
        Console.Write("Введiть a: "); a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введiть b: "); b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введiть точнiсть Eps: "); Eps = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введiть Kmax: "); Kmax = Convert.ToInt32(Console.ReadLine());

        // 6. Обчислення D
        D = Eps / 100.0;

        // 7. Вибір початкового наближення
        x = b; // Початкове значення x = b

        // Перевірка умови збіжності: f(x)*f2p(x) > 0
        if (f(x) * f2p(x, D) < 0)
        {
            x = a; // Якщо умова порушена для b, беремо a
        }

        if (f(x) * f2p(x, D) <= 0)
        {
           
            Console.WriteLine("\nДля заданого рівняння збiжнiсть методу Ньютона не гарантується з початкової точки.");
            Console.ReadLine(); 
            return; // Завершення роботи
        }

        // 8. Початок циклу ітерацій
        for (i = 1; i <= Kmax; i++)
        {
            // Обчислення поправки: Dx = f(x) / fp(x)
            Dx = f(x) / fp(x, D);

            // Ітерація Ньютона: x = x - Dx
            x = x - Dx;

            Console.WriteLine($"iтерацiя {i}: x = {x:F10}, |Dx| = {Math.Abs(Dx):E2}");

            // Перевірка критерію зупинки: |Dx| <= Eps
            if (Math.Abs(Dx) <= Eps)
            {
                // Знайдено
                Console.WriteLine("\n*** Корiнь знайдено ***");
                Console.WriteLine($"Наближене значення кореня: {x:F10}");
                Console.WriteLine($"Кiлькiсть iтерацiй: {i}");
                Console.ReadLine();
                return; // Завершення програми
            }
        }

        Console.WriteLine($"\nЗа задану кiлькiсть iтерацiй Kmax = {Kmax} корiнь з точнiстю Eps не знайдено.");
        Console.ReadLine();
        // 8. Завершуємо роботу
    }
}