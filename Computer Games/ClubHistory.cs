using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Games
{
    public partial class ClubHistory : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public ClubHistory()
        {
            InitializeComponent();
        }
        private void LoadClubs()
        {
            var pl = from c in context.Teams
                     select c;
            foreach (Teams t in pl)
            {
                this.comboBox4.Items.Add(t.TeamName);
                this.comboBox4.SelectedIndex = 0;
            }
        }
        public void LoadNames()
        {
            var FirstNames = from c in context.Coaches
                             orderby c.FirstName
                             select c.FirstName;

            foreach (var c in FirstNames)
            {
                this.comboBox2.Items.Add(c);
            }
            var SecondNames = from c in context.Coaches
                              orderby c.SecondName
                              select c.SecondName;

            foreach (var c in SecondNames)
            {
                this.comboBox1.Items.Add(c);
            }
        }
        private void ClubHistory_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            LoadClubs();
            LoadNames();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 |
                (dateTimePicker1 == dateTimePicker2))
                button1.Enabled = false;
            else button1.Enabled = true;
            if (comboBox1.SelectedIndex >= 0)
            {
                var snames = (from c in context.Coaches where c.SecondName == (string)comboBox1.SelectedItem select new { c.FirstName, c.SecondName }).ToList();
                comboBox2.Items.Clear();
                foreach (var c in snames)
                {
                    comboBox2.Items.Add(c.FirstName);
                    comboBox2.SelectedIndex = 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt1 = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                DateTime dt2 = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day);
                CoachTrain oldct = (from c in context.CoachTrain
                                    where c.Coaches.SecondName == (string)this.comboBox1.SelectedItem & c.Coaches.FirstName == (string)this.comboBox2.SelectedItem
                                    & c.Teams.TeamName == (string)this.comboBox4.SelectedItem & c.DateBegin == dt1 & c.DateEnd == dt2
                                    select c).FirstOrDefault();
                Coaches co = (from c in context.Coaches
                              where c.SecondName == (string)this.comboBox1.SelectedItem & c.FirstName == (string)this.comboBox2.SelectedItem
                              select c).FirstOrDefault();
                Teams t = (from c in context.Teams
                           where c.TeamName == (string)this.comboBox4.SelectedItem
                           select c).FirstOrDefault();
                if (oldct == null)
                {
                    CoachTrain ct = new CoachTrain();
                    ct.CoachID = co.ID;
                    ct.TeamID = t.ID;
                    ct.DateBegin = dt1;
                    ct.DateEnd = dt2;
                    context.CoachTrain.Add(ct);
                    context.SaveChanges();
                    MessageBox.Show("Історія успішно додана", "Результат");
                }
                else
                {
                    MessageBox.Show("Дана інформація вже є у базі", "Результат");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 |
               (dateTimePicker1 == dateTimePicker2))
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 |
               (dateTimePicker1 == dateTimePicker2))
                button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}
