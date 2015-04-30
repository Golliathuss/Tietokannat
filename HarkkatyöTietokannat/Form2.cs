using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calendar;

namespace HarkkatyöTietokannat
{
   
    public partial class Form2 : Form
    {

        List<Appointment> m_Appointments;
        int vertaus = 0;

        public Form2(string ryhma)
        {
            InitializeComponent();

            // asetetaan kalenteri näyttämään aina maanantai ensimmäisenä niin että kalenterissä näkyy vain yksi viikko kerrallaan
            DateTime input = DateTime.Now;
            int delta = DayOfWeek.Monday - input.DayOfWeek;
            dayView1.StartDate = input.AddDays(delta);

            String[] varaus;
            varaus = new String[6];

            // tehdään haku
            String data = haku.etsi(ryhma);

            // tarkistetaan varausten maara
            String testi = "subject";
            int count = (data.Length - data.Replace(testi, "").Length) / testi.Length;

            // viedään saatu data parserille eroteltavaksi
            varaus = Parser.parseri(data);


            // Asetetaan varaukset kalenteriin oikeille kohdilleen
            m_Appointments = new List<Appointment>();
            for (int i = 0; i < count; i++)
            {
                String title = varaus[vertaus];
                vertaus++;
                DateTime alku1 = DateTime.ParseExact(varaus[vertaus], "'Startdate: 'yyyy-MM-dd'T'HH:mm", null);
                vertaus++;
                DateTime alku2 = DateTime.ParseExact(varaus[vertaus], "'Enddate: 'yyyy-MM-dd'T'HH:mm", null);
                vertaus++;
                
                Appointment m_Appointment = new Appointment();
                m_Appointment.StartDate = alku1;
                m_Appointment.EndDate = alku2;
                m_Appointment.Title = title;
                m_Appointment.Color = System.Drawing.Color.Red;
                m_Appointments.Add(m_Appointment);
            }
            dayView1.Invalidate();
        }
        private void dayView1_ResolveAppointments(object sender, ResolveAppointmentsEventArgs args)
        {
            List<Appointment> m_Apps = new List<Appointment>();

            foreach (Appointment m_App in m_Appointments)
                if ((m_App.StartDate >= args.StartDate) &&
                    (m_App.StartDate <= args.EndDate))
                    m_Apps.Add(m_App);

            args.Appointments = m_Apps;
        }

        // Kalenterin viikko eteenpäin
        private void button1_Click(object sender, EventArgs e)
        {
            dayView1.StartDate = dayView1.StartDate.AddDays(7);
        }

        // Kalenterin viikko taaksepäin
        private void button2_Click(object sender, EventArgs e)
        {
            dayView1.StartDate = dayView1.StartDate.AddDays(-7);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
