using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hafizaOyunu
{
    public partial class Form4 : Form
    {
        List<string> sekiller = new List<string>()
        {
            "a","b","c","d",
            "a","b","c","d"
        };
        Random rnd = new Random();
        int sekilindex;
        Timer t = new Timer();
        Timer t2 = new Timer();
        Button first, second;

        public Form4()
        {
            InitializeComponent();
        }
        private void T2_Tick(object sender, EventArgs e)
        {

            t2.Stop();
            first.ForeColor = first.BackColor;
            second.ForeColor = second.BackColor;
            first = null;
            second = null;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.Stop();


            foreach (Control item in Controls)
            {
                if (item is Button btn)
                {
                    btn.ForeColor = btn.BackColor;
                }
            }
        }
        private void sekilatama()
        {
            foreach (Control item in Controls)
            {
                if (item is Button btn)
                {
                    if (sekiller.Count == 0)
                    {
                        sekiller = new List<string>()
                {
                    "a","b","c","d",
                    "a","b","c","d"
                };
                    }

                    sekilindex = rnd.Next(sekiller.Count);
                    btn.Text = sekiller[sekilindex];
                    sekiller.RemoveAt(sekilindex);
                }
            }
        }
        int sayac = 0;
        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (first == null)
            {
                first = btn;
                first.ForeColor = Color.Black;
                return;
            }
            second = btn;
            second.ForeColor = Color.Black;
            if (first.Text == second.Text)
            {
                first.ForeColor = Color.Black;
                second.ForeColor = Color.Black;
                first = null;
                second = null;
                sayac++;
                if (sayac == 16)
                {
                    MessageBox.Show("Kazandınız!");
                    Close();
                    Form1 form1 = new Form1();
                    form1.Show();

                }
            }
            else
            {
                t2.Start();
                t2.Interval = 1000;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            sekilatama();
            t.Tick += T_Tick;
            t.Start();
            t.Interval = 3000;
            t2.Tick += T2_Tick;
        }
    }
}
