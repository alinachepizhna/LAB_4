using System;
using System.Windows.Forms;

namespace LAB_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ======================= ФУНКЦІЇ ==========================
        // f(x) — ліва частина рівняння
        double f(double x, ref int k1)
        {
            switch (k1)
            {
                case 0: return x * x - 4;                       // x² - 4
                case 1: return 3 * x - 4 * Math.Log(x) - 5;     // 3x - 4ln(x) - 5
            }
            return 0;
        }

        // Перша похідна (чисельно)
        double fp(double x, double d, ref int k1)
        {
            return (f(x + d, ref k1) - f(x, ref k1)) / d;
        }

        // Друга похідна (чисельно)
        double f2p(double x, double d, ref int k1)
        {
            return (f(x + d, ref k1) + f(x - d, ref k1) - 2 * f(x, ref k1)) / (d * d);
        }

        // Метод ділення навпіл (MDP)
        double MDP(double a, double b, double Eps, ref int k1, ref int L)
        {
            double c = 0, Fc;
            while (b - a > Eps)
            {
                c = 0.5 * (b - a) + a;
                L++; // лічильник кількості поділів інтервалу [a, b]
                Fc = f(c, ref k1);
                if (Math.Abs(Fc) < Eps)
                    return c; // знайдено корінь
                if (f(a, ref k1) * Fc > 0) a = c;
                else b = c;
            }
            return c;
        }

        // Метод Ньютона (MN)
        double MN(double a, double b, double Eps, ref int k1, int Kmax, ref int L)
        {
            double x, Dx, D;
            int i;
            Dx = 0.0;
            D = Eps / 100.0;
            x = b;
            if (f(x, ref k1) * f2p(x, D, ref k1) < 0)
                x = a;
            if (f(x, ref k1) * f2p(x, D, ref k1) < 0)
                MessageBox.Show("Для цього рівняння збіжність ітерацій не гарантована");

            for (i = 1; i <= Kmax; i++)
            {
                Dx = f(x, ref k1) / fp(x, D, ref k1);
                x = x - Dx;
                if (Math.Abs(Dx) < Eps)
                {
                    L = i;
                    return x;
                }
            }
            MessageBox.Show("За задану кількість ітерацій кореня не знайдено");
            return -1000.0;
        }

        // ==================== ОБРОБКА ПОДІЙ =======================

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Вибір методу
            switch (comboBox1.SelectedIndex)
            {
                case 0: // Метод ділення навпіл
                    label7.Visible = false;
                    textBox4.Visible = false;
                    textBox1.Clear();
                    textBox2.Clear();
                    break;

                case 1: // Метод Ньютона
                    label7.Visible = true;
                    textBox4.Visible = true;
                    textBox1.Clear();
                    textBox2.Clear();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int L = 0, k = -1, Kmax = 0, m = -1;
            double D, Eps = 0, a, b;

            // Вибір методу
            switch (comboBox1.SelectedIndex)
            {
                case 0: m = 0; break; // Метод ділення навпіл
                case 1: m = 1; break; // Метод Ньютона
            }

            if (m == -1)
            {
                MessageBox.Show("Оберіть метод!");
                comboBox1.Focus();
                return;
            }

            // Вибір рівняння
            switch (comboBox2.SelectedIndex)
            {
                case 0: k = 0; break;
                case 1: k = 1; break;
            }

            if (k == -1)
            {
                MessageBox.Show("Оберіть рівняння!");
                comboBox2.Focus();
                return;
            }

            // Зчитування меж інтервалу
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введіть межі інтервалу [a, b]");
                return;
            }

            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);

            if (a > b)
            {
                D = a;
                a = b;
                b = D;
                textBox1.Text = a.ToString();
                textBox2.Text = b.ToString();
            }

            // Похибка
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Введіть похибку ε");
                textBox3.Focus();
                return;
            }

            Eps = Convert.ToDouble(textBox3.Text);
            if (Eps > 1e-1 || Eps <= 0)
            {
                Eps = 1e-4;
                textBox3.Text = Eps.ToString();
            }

            // Перевірка, чи є корінь на інтервалі
            if (m == 0 && (f(a, ref k)) * (f(b, ref k)) > 0)
            {
                MessageBox.Show("Введіть правильний інтервал [a, b]!");
                return;
            }

            // Якщо одна з меж — корінь
            if (Math.Abs(f(a, ref k)) < Eps)
            {
                textBox5.Text = a.ToString();
                textBox6.Text = L.ToString();
                return;
            }
            if (Math.Abs(f(b, ref k)) < Eps)
            {
                textBox5.Text = b.ToString();
                textBox6.Text = L.ToString();
                return;
            }

            // Основна частина — виклик методу
            switch (m)
            {
                case 0: // Метод ділення навпіл
                    textBox5.Text = MDP(a, b, Eps, ref k, ref L).ToString();
                    textBox6.Text = L.ToString();
                    label10.Text = "К-ть поділів =";
                    break;

                case 1: // Метод Ньютона
                    if (string.IsNullOrWhiteSpace(textBox4.Text))
                    {
                        MessageBox.Show("Введіть Kmax!");
                        textBox4.Focus();
                        return;
                    }
                    Kmax = Convert.ToInt32(textBox4.Text);
                    textBox5.Text = MN(a, b, Eps, ref k, Kmax, ref L).ToString();
                    textBox6.Text = L.ToString();
                    label10.Text = "К-ть ітерац. =";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Очищення всіх полів
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            if (comboBox1.SelectedIndex == 0)
            {
                label7.Visible = false;
                textBox4.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label7.Visible = true;
                textBox4.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
