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
    public partial class AddTeamPrize : Form
    {
        public AddTeamPrize()
        {
            InitializeComponent();
        }
        computer_gamesEntities context = new computer_gamesEntities();
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0)
                button4.Enabled = false;
            else button4.Enabled = true;
            if (comboBox3.SelectedIndex >= 0)
            {
                Competition co = (from c in context.Competition
                                  where c.Name == (string)this.comboBox3.SelectedItem
                                  select c).FirstOrDefault();
                var pl = (from c in context.Competition1
                          where c.CompetitionID == co.ID
                          select new { c.Date, c.Games.GameName }).ToList();

                dataGridView1.DataSource = pl;
                dataGridView1.Refresh();
            }
            
        }
        private void LoadTP()
        {
            var TP = (from c in context.TeamsPrizes
                      select c).ToList();
            foreach (TeamsPrizes c in TP)
            {
                this.comboBox2.Items.Add(c.PrizeName);
                this.comboBox2.SelectedIndex = 0;
            }
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
        private void LoadTournaments()
        {
            var pl = from c in context.Competition
                     orderby c.Name
                     select c;
            foreach (Competition c in pl)
            {
                this.comboBox3.Items.Add(c.Name);
                comboBox3.SelectedIndex = 0;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value.Month, this.dateTimePicker1.Value.Day);
                Teams t = (from c in context.Teams
                           where c.TeamName == (string)this.comboBox1.SelectedItem
                           select c).FirstOrDefault();
                TeamsPrizes tp = (from c in context.TeamsPrizes
                                  where c.PrizeName == (string)this.comboBox2.SelectedItem
                                  select c).FirstOrDefault();
                Competition1 c1 = (from c in context.Competition1
                                   where c.Competition.Name == (string)this.comboBox3.SelectedItem & c.Date == dt
                                   select c).FirstOrDefault();
                CompetitionsTeams old_ct = (from c in context.CompetitionsTeams
                                            where c.Teams.TeamName == (string)this.comboBox1.SelectedItem & c.Competition1.Competition.Name == (string)this.comboBox3.SelectedItem
                                            & c.Competition1.Date == dt & c.TeamsPrizes.PrizeName == (string)this.comboBox2.SelectedItem
                                            select c).FirstOrDefault();
                if (old_ct == null)
                {
                    if (c1 == null)
                    {
                        MessageBox.Show("Введіть дату потрібного турніру", "Результат");
                    }
                    else
                    {
                        CompetitionsTeams ct = new CompetitionsTeams();
                        ct.TPrizeID = tp.ID;
                        ct.TeamID = t.ID;
                        ct.Date = dt;
                        ct.CompetiionID = c1.ID;
                        context.CompetitionsTeams.Add(ct);
                        context.SaveChanges();
                        MessageBox.Show("Нова нагорода успішно додана.", "Результат");
                    }
                }
                else
                {
                    MessageBox.Show("Дана нагорода в вибраному турнірі у команди є.", "Результат");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void AddTeamPrize_Load(object sender, EventArgs e)
        {
            button4.Enabled = false;
            LoadClubs();
            LoadTP();
            LoadTournaments();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewTeamPrize ntp = new NewTeamPrize();
            ntp.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0)
                button4.Enabled = false;
            else button4.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0)
                button4.Enabled = false;
            else button4.Enabled = true;
        }

        private void AddTeamPrize_Activated(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            LoadTP();
        }

    }
}
