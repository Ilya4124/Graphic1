using System;
using System.Windows.Forms;

namespace GRAPHIC
{
    public partial class Form1 : Form
    {
        private double a, b, h;
        private double x, y;
        public Form1()
        {
            InitializeComponent();
        }
    
        public void Build_a_Graph(object sender, EventArgs e)
        {
            if (checkBox_sin.Checked == false && checkBox_tan.Checked == false)
            {
                MessageBox.Show("Choose a graphic!", "Warning!");
                return;
            }
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
            timer1.Enabled = true;

            if (checkBox_sin.Checked)
            {
                x = a;
                this.chart.Series[0].Points.Clear();
                while (x <= b)
                {
                    this.chart.Update();
                    y = Math.Pow(x,2);
                    this.chart.Series[0].Points.AddXY(x,y);
                    x += h;
                }
            }
            if (checkBox_tan.Checked)
            {
                x = a;
                this.chart.Series[1].Points.Clear();
                while (x <= b)
                {
                    this.chart.Update();

                    this.chart.Series[1].Points.Add(((((x * x) + (2 * x) * (x - b) - 600) *5))/1000);
                    x += h;
                }

            }
            timer1.Enabled = false;

        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            Build_a_Graph(sender, e);
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
            a = -10;
            b = 10;
            h = 0.1;
        }
    }
}
