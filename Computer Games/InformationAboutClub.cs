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
    public partial class InformationAboutClub : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public InformationAboutClub()
        {
            InitializeComponent();
        }
        private void LoadClubs()
        {
            var pl = from c in context.Teams
                     orderby c.TeamName
                     select c;
            foreach (Teams c in pl)
            {
                this.comboBox1.Items.Add(c.TeamName);
                comboBox1.SelectedIndex = 0;
            }
        }
        private void LoadChamps()
        {
            var pl = from c in context.Championship
                     orderby c.NameOfCS
                     select c;
            foreach (Championship c in pl)
            {
                this.comboBox2.Items.Add(c.NameOfCS);
                this.comboBox2.SelectedIndex = 0;
            }
        }
        private void InformationAboutClub_Load(object sender, EventArgs e)
        {
            LoadClubs();
            LoadChamps();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Teams t = new Teams();
                t = (from c in context.Teams
                     where c.TeamName == (string)comboBox1.SelectedItem
                     select c).FirstOrDefault();
                this.textBox3.Text = t.President.ToString();
                this.textBox1.Text = t.City.Country.CountryName.ToString();
                this.textBox2.Text = t.City.Name;
                var pl = from c in context.CoachTrain
                         where c.TeamID == t.ID
                         select new { c.Coaches.SecondName, c.Coaches.FirstName, c.DateBegin, c.DateEnd };
                dataGridView2.DataSource = pl.ToList();
                var pl1 = from c in context.TeamsGamers
                          where c.TeamID == t.ID & c.Player.ID == c.GamerID
                          select new { c.Player.SecondName, c.Player.FirstName, c.PlayBegin, c.PlayEnd };
                dataGridView1.DataSource = pl1.ToList();
                var pl2 = from c in context.Results
                          where c.Championship1.Championship.NameOfCS == (string)this.comboBox2.SelectedItem &
                          (c.Team_id1 == t.ID | c.Team_id2 == t.ID)
                          select new { c.Championship1.YearOfStart, Team1 = c.Teams.TeamName, Team2 = c.Teams1.TeamName, TeamwWin = c.Teams2.TeamName, TeamsIron1 = c.Iron.IronName, TeamsIron2 = c.Iron1.IronName, c.Stages.StageName, c.Championship1.PrizeFond };

                dataGridView3.DataSource = pl2.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

    }
}
