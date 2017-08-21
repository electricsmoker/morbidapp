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
    public partial class PersonalPrize : Form
    {
        public PersonalPrize()
        {
            InitializeComponent();
        }
        computer_gamesEntities context = new computer_gamesEntities();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null | comboBox2.SelectedItem == null | comboBox3.SelectedItem == null |
                comboBox4.SelectedItem == null | comboBox5.SelectedItem == null | dateTimePicker1.Value == null)
                button1.Enabled = false;
            else button1.Enabled = true; 
            if (comboBox1.SelectedIndex >= 0)
            {
                var snames = (from c in context.Player where c.SecondName == (string)comboBox1.SelectedItem select new { c.FirstName, c.ThirdName }).ToList();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                foreach (var c in snames)
                {
                    comboBox2.Items.Add(c.FirstName);
                    comboBox3.Items.Add(c.ThirdName);
                    comboBox2.SelectedIndex = 0;
                    comboBox3.SelectedIndex = 0;
                }
            }
        }
        public void LoadNames()
        {
            var FirstNames = from c in context.Player
                           orderby c.FirstName
                           select c.FirstName;

            foreach (var c in FirstNames)
            {
                this.comboBox2.Items.Add(c);
            }
            var SecondNames = from c in context.Player
                             orderby c.SecondName
                             select c.SecondName;

            foreach (var c in SecondNames)
            {
                this.comboBox1.Items.Add(c);
            }
            var ThirdNames = from c in context.Player
                              orderby c.ThirdName
                              select c.ThirdName;

            foreach (var c in ThirdNames)
            {
                this.comboBox3.Items.Add(c);
            }
        }
        private void LoadPrizes()
        {
            context = new computer_gamesEntities();

            var counties = from c in context.Prizes
                           orderby c.Prize
                           select c;

            foreach (Prizes c in counties)
            {
                this.comboBox4.Items.Add(c.Prize);
            }
        }
        private void LoadTournaments()
        {
            context = new computer_gamesEntities();

            var counties = from c in context.Competition
                           orderby c.Name
                           select c;

            foreach (var c in counties)
            {
                this.comboBox5.Items.Add(c.Name);
            }
        }
        private void PersonalPrize_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            LoadNames();
            LoadPrizes();
            LoadTournaments();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewPrize np = new NewPrize();
            np.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CompetitionsGamers cg = new CompetitionsGamers();
                Player p = (from c in context.Player
                            where c.SecondName == (string)this.comboBox1.SelectedItem & c.FirstName == (string)this.comboBox2.SelectedItem & c.ThirdName == (string)this.comboBox3.SelectedItem
                            select c).FirstOrDefault();
                Prizes pr = (from c in context.Prizes
                             where c.Prize == (string)this.comboBox4.SelectedItem
                             select c).FirstOrDefault();
                Competition co = (from c in context.Competition
                                  where c.Name == (string)this.comboBox5.SelectedItem
                                  select c).FirstOrDefault();
                DateTime dt = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value.Month, this.dateTimePicker1.Value.Day);
                Competition1 c1 = (from c in context.Competition1
                                   where c.CompetitionID == co.ID & c.Date == dt
                                   select c).FirstOrDefault();
                CompetitionsGamers cg1 = (from c in context.CompetitionsGamers
                                          where c.PrizeID == pr.ID & c.CompetitionID == c.Competition1.ID  & p.ID == c.GamerID
                                          select c).FirstOrDefault();
                if (cg1 == null)
                {
                    if (c1 == null)
                    {
                        MessageBox.Show("Введіть дату потрібного турніру", "Результат");
                    }
                    else
                    {
                        cg.GamerID = p.ID;
                        cg.CompetitionID = c1.ID;
                        cg.PrizeID = pr.ID;
                        cg.Date = dt;
                        context.CompetitionsGamers.Add(cg);
                        context.SaveChanges();
                        MessageBox.Show("Нова нагорода успішно додана.", "Результат");
                    }
                }
                else
                {
                    MessageBox.Show("ця нагорода в цьому турнірі уже є в гравця", "Результат");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Competition co = (from c in context.Competition
                              where c.Name == (string)this.comboBox5.SelectedItem
                              select c).FirstOrDefault();
            var pl = (from c in context.Competition1
                      where c.CompetitionID == co.ID
                      select c.Date).ToList();

            dataGridView1.DataSource = pl;
            dataGridView1.Refresh();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null | comboBox2.SelectedItem == null | comboBox3.SelectedItem == null |
                comboBox4.SelectedItem == null | comboBox5.SelectedItem == null | dateTimePicker1.Value == null)
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null | comboBox2.SelectedItem == null | comboBox3.SelectedItem == null |
                comboBox4.SelectedItem == null | comboBox5.SelectedItem == null | dateTimePicker1.Value == null)
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null | comboBox2.SelectedItem == null | comboBox3.SelectedItem == null |
                comboBox4.SelectedItem == null | comboBox5.SelectedItem == null | dateTimePicker1.Value == null)
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex >= 0)
            {
                Competition co = (from c in context.Competition
                                  where c.Name == (string)this.comboBox5.SelectedItem
                                  select c).FirstOrDefault();
                var pl = (from c in context.Competition1
                          where c.CompetitionID == co.ID
                          select new { c.Date, c.Games.GameName }).ToList();

                dataGridView1.DataSource = pl;
                dataGridView1.Refresh();
            }
            if (comboBox1.SelectedItem == null | comboBox2.SelectedItem == null | comboBox3.SelectedItem == null |
                comboBox4.SelectedItem == null | comboBox5.SelectedItem == null | dateTimePicker1.Value == null)
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedItem == null | comboBox2.SelectedItem == null | comboBox3.SelectedItem == null |
                comboBox4.SelectedItem == null | comboBox5.SelectedItem == null | dateTimePicker1.Value == null)
                button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}
