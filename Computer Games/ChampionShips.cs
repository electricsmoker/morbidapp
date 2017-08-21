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
    public partial class ChampionShips : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public ChampionShips()
        {
            InitializeComponent();
        }
        private void LoadGames()
        {
            var pl = from c in context.Games
                     select c;
            foreach (Games g in pl)
            {
                this.comboBox3.Items.Add(g.GameName);
                this.comboBox3.SelectedIndex = 0;
            }
        }
        private void LoadCS()
        {
            var pl = from c in context.Championship
                     select c;
            foreach (Championship cs in pl)
            {
                this.comboBox2.Items.Add(cs.NameOfCS);
                this.comboBox2.SelectedIndex = 0;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            var pl = from c in context.Results
                     where c.Championship1.Championship.NameOfCS == (string)this.comboBox2.SelectedItem
                     select new { c.Championship1.Championship.NameOfCS,c.Championship1.Games.GameName, c.Stages.StageName, team1 = c.Teams.TeamName, team2 = c.Teams1.TeamName, WinnerTeam = c.Teams2.TeamName, c.Championship1.YearOfStart };

            dataGridView1.DataSource = pl.ToList();
        }

        private void ChampionShips_Load(object sender, EventArgs e)
        {
            LoadCS();
            LoadGames();
            if (this.comboBox2.Items.Count!=0)
            this.comboBox2.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((string)this.comboBox1.SelectedItem == "Чемпіонати")
            {
                var pl = from c in context.Championship1
                         select new { c.Championship.NameOfCS, c.YearOfStart, c.PrizeFond, c.Games.GameName };
                dataGridView1.DataSource = pl.ToList();
            }
            else if ((string)this.comboBox1.SelectedItem == "Турніри")
            {
                var pl = from c in context.Competition1
                         select new { c.Competition.Name, c.Date, c.Games.GameName };
                dataGridView1.DataSource = pl.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddChampionship ac = new AddChampionship();
            ac.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddTeamPrize atp = new AddTeamPrize();
            atp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddTournaments at = new AddTournaments();
            at.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddMatch am = new AddMatch();
            am.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var pl = from c in context.Championship1
                     where c.Games.GameName == (string)this.comboBox3.SelectedItem
                     select new { c.Championship.NameOfCS,c.PrizeFond,c.YearOfStart };
            dataGridView1.DataSource = pl.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var pl = from c in context.Games
                     where c.GameName == (string)this.comboBox3.SelectedItem
                     select new { c.GameName,c.ReleaseYear,c.Versions,c.ComputersThatSupport };
            dataGridView1.DataSource = pl.ToList();
        }
    }
}

