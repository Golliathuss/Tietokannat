using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HarkkatyöTietokannat
{
   
    public partial class Form2 : Form
    {
        int vertaus = 1;
        public Form2(string ryhma)
        {
            InitializeComponent();
            String[] varaus;
            varaus = new String[6];
            varaus = Parser.parseri(haku.etsi(ryhma));

            label1.Text = varaus[0];
            label2.Text = varaus[1];
            label3.Text = varaus[2];
            label4.Text = varaus[3];
            label5.Text = varaus[4];
            label6.Text = varaus[5];
            vertailu(varaus);
        }

        private int vertailu(String[] varaus)
        {
            DateTime alku1 = DateTime.ParseExact(varaus[vertaus], "'Startdate: 'yyyy-MM-dd'T'HH:mm", null);

            vertaus = vertaus + 3;
            DateTime alku2 = DateTime.ParseExact(varaus[vertaus], "'Startdate: 'yyyy-MM-dd'T'HH:mm", null);
            int result = alku1.Date.CompareTo(alku2.Date);
            vertaus = vertaus + 3;
            return result;

            // alle nolla -> alku1 on aikaisemmin
            // nolla -> sama
        }

    }
}
