namespace Lab_5._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Перевірка, який метод обрано при запуску
            if (radioButtonNewton.Checked)
            {
                label7.Visible = true;
                textBox4.Visible = true;
            }
            else // Для МДП
            {
                label7.Visible = false;
                textBox4.Visible = false;
            }
        }
        // ======================= ФУНКЦІЇ ==========================
        double f(double x, ref int k1)
        {
            switch (k1)
            {
                case 0: return x * x - 4;
                case 1: return 3 * x - 4 * Math.Log(x) - 5;
                case 2: return Math.Cos(x) - x;
            }
            return 0;
        }

        double fp(double x, double d, ref int k1)
        {
            return (f(x + d, ref k1) - f(x, ref k1)) / d;
        }

        double f2p(double x, double d, ref int k1)
        {
            return (f(x + d, ref k1) + f(x - d, ref k1) - 2 * f(x, ref k1)) / (d * d);
        }

        // ======================= Методи ===========================
        void MDP(double a, double b, double Eps, ref int k1, ref int L, out double root)
        {
            double c = 0, Fc;
            while (b - a > Eps)
            {
                c = 0.5 * (b - a) + a;
                L++;
                Fc = f(c, ref k1);
                if (Math.Abs(Fc) < Eps)
                {
                    root = c;
                    return;
                }
                if (f(a, ref k1) * Fc > 0) a = c;
                else b = c;
            }
            root = c;
        }

        void MN(double a, double b, double Eps, ref int k1, int Kmax, ref int L, out double root)
        {
            double x, Dx, D;
            int i;
            Dx = 0.0;
            D = Eps / 100.0;
            x = b;
            if (f(x, ref k1) * f2p(x, D, ref k1) < 0) x = a;

            if (f(x, ref k1) * f2p(x, D, ref k1) < 0)
                MessageBox.Show("Для цього рівняння збіжність ітерацій не гарантована");

            for (i = 1; i <= Kmax; i++)
            {
                Dx = f(x, ref k1) / fp(x, D, ref k1);
                x = x - Dx;
                if (Math.Abs(Dx) < Eps)
                {
                    L = i;
                    root = x;
                    return;
                }
            }
            MessageBox.Show("За задану кількість ітерацій кореня не знайдено");
            root = -1000.0;
        }

        private void radioButtonMDP_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            textBox4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int L = 0, k = -1, Kmax = 0, m = -1;
            double D, Eps = 0, a, b, R;

            // Вибір методу
            if (radioButtonMDP.Checked) m = 0;
            if (radioButtonNewton.Checked) m = 1;
            if (m == -1)
            {
                MessageBox.Show("Оберіть метод!");
                return;
            }

            // Вибір рівняння через ComboBox
            k = comboBoxEquation.SelectedIndex;
            if (k == -1)
            {
                MessageBox.Show("Оберіть рівняння!");
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

            // Перевірка на наявність кореня на інтервалі
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

            // Виклик методу
            switch (m)
            {
                case 0: // МДП
                    MDP(a, b, Eps, ref k, ref L, out R);
                    textBox5.Text = R.ToString();
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
                    MN(a, b, Eps, ref k, Kmax, ref L, out R);
                    textBox5.Text = R.ToString();
                    textBox6.Text = L.ToString();
                    label10.Text = "К-ть ітерац. =";
                    break;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButtonNewton_CheckedChanged_1(object sender, EventArgs e)
        {
            label7.Visible = true;
            textBox4.Visible = true;
        }
    }
}
