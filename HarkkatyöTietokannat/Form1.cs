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

        // avaa kalenterin
        private void button1_Click(object sender, EventArgs e)
        {

            String ryhma = textBox1.Text;

            Form2 popup = new Form2(ryhma);
            popup.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
