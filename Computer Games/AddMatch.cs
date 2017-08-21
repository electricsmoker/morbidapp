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
    public partial class AddMatch : Form
    {
        public AddMatch()
        {
            InitializeComponent();
        }
        computer_gamesEntities context = new computer_gamesEntities();
        private void LoadCS()
        {
            var pl = from c in context.Championship
                     select c;
            foreach (Championship c in pl)
            {
                this.comboBox1.Items.Add(c.NameOfCS);
                this.comboBox1.SelectedIndex = 0;
            }
        }
        private void LoadTeam1()
        {
            var pl = from c in context.Teams
                     select c;
            foreach (Teams c in pl)
            {
                this.comboBox2.Items.Add(c.TeamName);
                this.comboBox2.SelectedIndex = 0;
            }
        }
        private void LoadStage()
        {
            var pl = from c in context.Stages
                     select c;
            foreach (Stages s in pl)
            {
                this.comboBox6.Items.Add(s.StageName);
                this.comboBox6.SelectedIndex = 0;
            }
        }
        private void LoadIron()
        {
            var pl = from c in context.Iron
                     select c;
            foreach (Iron i in pl)
            {
                this.comboBox4.Items.Add(i.IronName);
                this.comboBox5.Items.Add(i.IronName);
                this.comboBox4.SelectedIndex = 0;
                this.comboBox5.SelectedIndex = 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int y = int.Parse(textBox1.Text.ToUpper());
                Results old = (from c in context.Results
                               where c.Championship1.Championship.NameOfCS == (string)this.comboBox1.SelectedItem
                               & y == c.Championship1.YearOfStart & c.Teams.TeamName == (string)this.comboBox2.SelectedItem
                               & c.Teams1.TeamName == (string)this.comboBox3.SelectedItem & c.Stages.StageName == (string)this.comboBox6.SelectedItem
                               select c).FirstOrDefault();
                Stages s = (from c in context.Stages
                            where c.StageName == (string)this.comboBox6.SelectedItem
                            select c).FirstOrDefault();
                Teams t1 = (from c in context.Teams
                            where c.TeamName == (string)this.comboBox2.SelectedItem
                            select c).FirstOrDefault();
                Teams t2 = (from c in context.Teams
                            where c.TeamName == (string)this.comboBox3.SelectedItem
                            select c).FirstOrDefault();
                Iron i1 = (from c in context.Iron
                           where c.IronName == (string)this.comboBox4.SelectedItem
                           select c).FirstOrDefault();
                Iron i2 = (from c in context.Iron
                           where c.IronName == (string)this.comboBox5.SelectedItem
                           select c).FirstOrDefault();
                Teams winner = (from c in context.Teams
                                where c.TeamName == (string)this.comboBox7.SelectedItem
                                select c).FirstOrDefault();
                Championship1 c1 = (from c in context.Championship1
                                    where c.Championship.NameOfCS == (string)this.comboBox1.SelectedItem & c.YearOfStart == y
                                    select c).FirstOrDefault();
                if (old == null)
                {
                    Results r = new Results();
                    r.StageID = s.ID;
                    r.Team_id1 = t1.ID;
                    r.Team_id2 = t2.ID;
                    r.Iron_id1 = i1.ID;
                    r.Iron_id2 = i2.ID;
                    r.WinnerID = winner.ID;
                    r.CS_id = c1.ID;
                    context.Results.Add(r);
                    context.SaveChanges();
                    MessageBox.Show("Матч успішно зареєстровано.", "Результат");
                }
                else
                {
                    MessageBox.Show("В даному турнірі на даній стадії такий матч відбувся.", "Результат");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void AddMatch_Load(object sender, EventArgs e)
        {
            LoadTeam1();
            LoadCS();
        }

        private void AddMatch_Activated(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 | comboBox5.SelectedIndex < 0 | comboBox6.SelectedIndex < 0 | comboBox7.SelectedIndex < 0
                | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true; 
            if (comboBox2.SelectedIndex >= 0)
            {
                comboBox3.Items.Clear();
                var pl = from c in context.Teams
                         select c;
                foreach (Teams c in pl)
                {
                    if (c.TeamName != (string)comboBox2.SelectedItem)
                    {
                        this.comboBox3.Items.Add(c.TeamName);
                        this.comboBox3.SelectedIndex = 0;
                    }
                }
            }
            
        }
        private void AddMatch_Load_1(object sender, EventArgs e)
        {
            LoadTeam1();
            LoadCS();
            LoadIron();
            LoadStage();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 | comboBox5.SelectedIndex < 0 | comboBox6.SelectedIndex < 0 | comboBox7.SelectedIndex < 0
                | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
            if (comboBox3.SelectedIndex >= 0 & comboBox2.SelectedIndex >= 0)
            {
                this.comboBox7.Items.Clear();
                this.comboBox7.Items.Add(comboBox2.SelectedItem);
                this.comboBox7.Items.Add(comboBox3.SelectedItem);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 | comboBox5.SelectedIndex < 0 | comboBox6.SelectedIndex < 0 | comboBox7.SelectedIndex < 0 
                | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
            if (comboBox1.SelectedIndex >= 0)
            {
                var pl = from c in context.Championship1
                         where c.Championship.NameOfCS == (string)this.comboBox1.SelectedItem
                         select new { c.Championship.NameOfCS, c.YearOfStart, c.Games.GameName };
                dataGridView1.DataSource = pl.ToList();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 | comboBox5.SelectedIndex < 0 | comboBox6.SelectedIndex < 0 | comboBox7.SelectedIndex < 0
                | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 | comboBox5.SelectedIndex < 0 | comboBox6.SelectedIndex < 0 | comboBox7.SelectedIndex < 0
                | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 | comboBox5.SelectedIndex < 0 | comboBox6.SelectedIndex < 0 | comboBox7.SelectedIndex < 0
                | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 | comboBox5.SelectedIndex < 0 | comboBox6.SelectedIndex < 0 | comboBox7.SelectedIndex < 0
                | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 | comboBox5.SelectedIndex < 0 | comboBox6.SelectedIndex < 0 | comboBox7.SelectedIndex < 0
                | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}
