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
    public partial class ClubsAndTrainers : Form
    {
        public ClubsAndTrainers()
        {
            InitializeComponent();
        }
        computer_gamesEntities context = new computer_gamesEntities();
        private void LoadTP()
        {
            var TP = (from c in context.TeamsPrizes
                     select c).ToList();
            foreach (TeamsPrizes c in TP)
            {
                this.comboBox1.Items.Add(c.PrizeName);
                this.comboBox1.SelectedIndex = 0;
            }
        }
        private void LoadCountries()
        {
            context = new computer_gamesEntities();

            var counties = from c in context.Country
                           orderby c.CountryName
                           select c;

            foreach (Country c in counties)
            {
                this.comboBox2.Items.Add(c.CountryName);
                comboBox1.SelectedIndex = 0;

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var pl = from c in context.CompetitionsTeams
                     where c.TeamsPrizes.PrizeName == (string)this.comboBox1.SelectedItem
                     select new { c.Teams.TeamName, c.Competition1.Competition.Name, c.TeamsPrizes.PrizeName,c.Competition1.Games.GameName, c.Competition1.Date };
            dataGridView1.DataSource = pl.ToList();

        }

        private void ClubsAndTrainers_Load(object sender, EventArgs e)
        {
            LoadTP();
            LoadCountries();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var pl = from c in context.Teams
                     where c.City.Country.CountryName == (string)this.comboBox2.SelectedItem
                     select new { c.TeamName, c.City.Name, c.City.Country.CountryName };
            dataGridView1.DataSource = pl.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var pl = from c in context.Teams
                     select new { c.TeamName, c.City.Country.CountryName, c.City.Name };
            dataGridView1.DataSource = pl.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClub ad = new AddClub();
            ad.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InformationAboutClub iac = new InformationAboutClub();
            iac.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Trainers t = new Trainers();
            t.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddTeamPrize adp = new AddTeamPrize();
            adp.ShowDialog();
        }
    }
}
