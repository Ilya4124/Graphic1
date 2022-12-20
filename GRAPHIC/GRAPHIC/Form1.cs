using System;
using System.Windows.Forms;

namespace GRAPHIC
{
    public partial class Form1 : Form
    {
        private double a, b, h;
        private double x0, y;
        public Form1()
        {
            InitializeComponent();
        }


        public void InsertParams()
        {
            if (textBox_a.Text == "" || textBox_b.Text == "" || textBox_h.Text == "")
            {
                MessageBox.Show("Default value!", "Warning!");
                DefaultParams();
            }
            else
            {
                a = Convert.ToDouble(textBox_a.Text);
                b = Convert.ToDouble(textBox_b.Text);
                h = Convert.ToDouble(textBox_h.Text);
            }
        }
        public void Build_a_Graph(object sender, EventArgs e)
        {
            if (checkBox_sin.Checked == false && checkBox_tan.Checked == false)
            {
                MessageBox.Show("Choose a graphic!", "Warning!");
                return;
            }

            InsertParams();
            timer1.Enabled = true;

            if (checkBox_sin.Checked)
            {
                x0 = a;
                this.chart.Series[0].Points.Clear();
                while (x0 <= b)
                {
                    this.chart.Update();
                    y = Math.Pow(x0, 2);
                    this.chart.Series[0].Points.AddXY(x0, y);
                    x0 += h;
                }
            }
            if (checkBox_tan.Checked)
            {
                x0 = a;
                while (x0 <= b)
                {
                    if (checkbox_clear.Checked == true)
                    {
                        this.chart.Series[1].Points.Clear();
                    }
                    for (double i = x0 - 5; i <= x0 + 5; i += 0.5)
                    {
                        this.chart.Series[1].Points.AddXY(i, tangent(x0, i));
                        this.chart.Update();
                    }
                    x0 += h;
                }
            }
            timer1.Enabled = false;

        }

        private double f(double x)
        {
            return Math.Pow(x, 2);
        }

        private double f_dx(double x)
        {
            return (f(x + 0.05) - f(x)) / (0.05);
        }

        private double tangent(double x0, double x)
        {
            return f_dx(x0) * (x - x0) + f(x0);
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            Build_a_Graph(sender, e);
        }

        private void Tangent_Clear(object sender, EventArgs e)
        {
        }

        public void ClearGraph(object sender, EventArgs e)
        {
            if (checkBox_sin.Checked == false)
            {
                MessageBox.Show("Choose a graphic!", "Warning!");
                return;
            }
            if (checkBox_sin.Checked)
            {
                this.chart.Series[0].Points.Clear();
            }
            if (checkBox_tan.Checked)
            {
                this.chart.Series[1].Points.Clear();
            }

        }

        public void Close_a_Graph(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit?", "Warning!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        public void DefaultParams()
        {
            a = -5;
            b = 4;
            h = 0.1;
        }
    }
}
