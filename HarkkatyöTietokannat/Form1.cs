using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCalendar;


namespace HarkkatyöTietokannat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] varaus;
            varaus = new String[3];

            String ryhma = textBox1.Text;
            varaus = Parser.parseri(haku.etsi(ryhma));

            label2.Text = varaus[0];
            label3.Text = varaus[1];
            label4.Text = varaus[2];
        }

    }
}
