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
    public partial class GamerInformation : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public GamerInformation()
        {
            InitializeComponent();
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
                this.comboBox1.SelectedIndex = 0;
            }
            var ThirdNames = from c in context.Player
                             orderby c.ThirdName
                             select c.ThirdName;

            foreach (var c in ThirdNames)
            {
                this.comboBox3.Items.Add(c);
            }
        }

        private void GamerInformation_Load(object sender, EventArgs e)
        {
            LoadNames();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                this.textBox1.Clear();
                this.textBox3.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Player p = (from c in context.Player
                            where c.FirstName == (string)this.comboBox2.SelectedItem
                            & c.SecondName == (string)this.comboBox1.SelectedItem
                            & c.ThirdName == (string)this.comboBox3.SelectedItem
                            select c).FirstOrDefault();
                var tg = (from c in context.TeamsGamers
                          where c.Player.FirstName == (string)this.comboBox2.SelectedItem
                          & c.Player.SecondName == (string)this.comboBox1.SelectedItem
                          & c.Player.ThirdName == (string)this.comboBox3.SelectedItem
                          select c).ToList();

                textBox1.Text = p.City.Country.CountryName.ToString();
                foreach (TeamsGamers tg1 in tg)
                {
                    {
                        if (tg1.PlayBegin <= DateTime.Now.Year & tg1.PlayEnd >= DateTime.Now.Year)
                        {
                            textBox3.Text = tg1.Teams.TeamName;
                        }
                    }

                }
                if (textBox3.Text.ToUpper() == "")
                    MessageBox.Show("на даний момент гравець ніде не грає", "Результат");

                var pl = from c in context.CompetitionsGamers
                         where c.Player.FirstName == (string)this.comboBox2.SelectedItem
                                  & c.Player.SecondName == (string)this.comboBox1.SelectedItem
                                  & c.Player.ThirdName == (string)this.comboBox3.SelectedItem
                         select new { c.Player.SecondName, c.Player.FirstName, c.Competition1.Competition.Name, c.Date, c.Prizes.Prize };
                dataGridView2.DataSource = pl.ToList();
                var pl1 = from c in context.TeamsGamers
                          where c.Player.FirstName == (string)this.comboBox2.SelectedItem
                                   & c.Player.SecondName == (string)this.comboBox1.SelectedItem
                                   & c.Player.ThirdName == (string)this.comboBox3.SelectedItem
                          select new { c.Player.SecondName, c.Player.FirstName, c.Teams.TeamName, c.PlayBegin, c.PlayEnd };
                dataGridView1.DataSource = pl1.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }

        }
    }
}
