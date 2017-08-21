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
    public partial class Gamer : Form
    {
        public Gamer()
        {
            InitializeComponent();
            
        }
        computer_gamesEntities context = new computer_gamesEntities();
        private void button3_Click(object sender, EventArgs e)
        {
            PersonalPrize pp = new PersonalPrize();
            pp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddGamer ag = new AddGamer();
            ag.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TeamsGamers tg = new TeamsGamers();
            //Teams 
            var pl = (from d in context.Player
                      //where d.Player.CityID == d.Player.City.ID //& d.GamerID == d.Player.ID
                      select new { d.SecondName, d.FirstName, d.City.Name }).ToList();
            
            //var pl2 = (from c in context.Teams
            //           select c).ToList();

            //foreach (Teams c in pl2)
            //{
            //    var pl3 = (from d in context.TeamsGamers
            //               where d.Player.CityID == d.Player.City.ID & d.TeamID == c.ID
            //               select new { d.Player.SecondName, d.Player.FirstName, d.Player.City.Name, c.TeamName });
            //    var pl4 = pl3.ToList();


            //}
            
            dataGridView1.DataSource = pl.ToList();
          
        }
        private void LoadPrizes()
        {
            context = new computer_gamesEntities();

            var counties = from c in context.Prizes
                           orderby c.Prize
                           select c;

            foreach (Prizes c in counties)
            {
                this.comboBox1.Items.Add(c.Prize);
                //this.comboBox1.Text = c.Name;

            }
        }
        private void LoadTeams()
        {
            context = new computer_gamesEntities();

            var counties = from c in context.Teams
                           orderby c.TeamName
                           select c;

            foreach (Teams c in counties)
            {
                this.comboBox2.Items.Add(c.TeamName);
                //this.comboBox1.Text = c.Name;

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Player p = new Player();
            var pl = (from d in context.CompetitionsGamers
                      where d.GamerID == d.Player.ID & d.Prizes.Prize == (string)this.comboBox1.SelectedItem
                      select new { d.Player.SecondName, d.Prizes.Prize, d.Competition1.Competition.Name,d.Competition1.Date,d.Competition1.Games.GameName }).ToList();
            dataGridView1.DataSource = pl.ToList();
            dataGridView1.Refresh();


            // ХАЙ ТУСУЄТЬСЯ!!!!!!!!!!!!
            //Player p = new Player();
            //var pl = (from d in context.CompetitionsGamers
            //         where d.GamerID == d.Player.ID
            //         select new { d.Player.SecondName, d.Prizes.Prize, d.Competition1.Competition.Name }).ToList();
            //dataGridView1.DataSource = pl.ToList();
            //dataGridView1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Coaches ccc = new Coaches();
            var ccc = (from c in context.Coaches
                       select c).ToList();
            //var pl2 = from i in context.TeamsGamers
            //          join f in context.Player
            //          on i.GamerID equals f.ID
            //          join g in context.Teams
            //          on i.TeamID equals g.ID
            var pl = (from d in context.TeamsGamers
                      where d.GamerID == d.Player.ID & d.Teams.TeamName == (string)this.comboBox2.SelectedItem  
                      select new { d.Player.SecondName, d.Teams.TeamName, d.PlayBegin,d.PlayEnd });
           
            
            dataGridView1.DataSource = pl.ToList();
            
            dataGridView1.Refresh();
        }

        private void Gamer_Load(object sender, EventArgs e)
        {
            LoadPrizes();
            LoadTeams();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeletePlayer dp = new DeletePlayer();
            dp.ShowDialog();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddPlayerHistory aph = new AddPlayerHistory();
            aph.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GamerInformation gi = new GamerInformation();
            gi.ShowDialog();
        }
    }
    
}
