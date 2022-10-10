using System.Security.Policy;

namespace Лаба2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numNBox1.Text = Properties.Settings.Default.money.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            double money;
            try
            {
                money = double.Parse(this.numNBox1.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Одна ошибка и ты ошибся🐺", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                return;
            }
            Properties.Settings.Default.money = money;
            Properties.Settings.Default.Save();

            MessageBox.Show(Logic.Compare(money));
        }

        public class Logic
        {
            public static string Compare(double n)
            {
                string outMessage1 = "";
                double rub = 0, kop = 0;
                if (n == 0)
                {
                    outMessage1 = "Нет денег";
                }
                if (n > 0 && n < 10000)
                {
                    rub = (int)n / 100;
                    kop = n % 100;
                    double help;
                     
                    if (rub > 0)
                    {
                        help = rub % 10;
                        if (help == 5 || help == 6 || help == 7 || help == 8 || help == 9 || rub == 10 || rub == 11 || rub == 12 || rub == 13 || rub == 14)
                        {
                            outMessage1 = $"{rub} рублей";
                        }
                        else
                        {
                            if (help == 1)
                            {
                                outMessage1 = $"{rub} рубль";
                            }
                            else
                            {
                                outMessage1 = $"{rub} рубля";
                            }
                        }
                    }
                    if (kop > 0)
                    {
                        help = kop % 10;
                        if (help == 5 || help == 6 || help == 7 || help == 8 || help == 9 || kop == 10 || kop == 11 || kop == 12 || kop == 13 || kop == 14)
                        {
                            outMessage1 += $" {kop} копеек";
                        }
                        else
                        {
                            if (help == 1)
                            {
                                outMessage1 += $" {kop} копейка";
                            }
                            else
                            {
                                outMessage1 += $" {kop} копейки";
                            }
                        }
                    }   
                }
                return outMessage1;
            }
        }

        private void Form1_ForeColorChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            double money;
            money = double.Parse(this.numNBox1.Text);
            Properties.Settings.Default.money = money;
            Properties.Settings.Default.Save();
        }
    }
}