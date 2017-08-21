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
    public partial class AddPlayerHistory : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public AddPlayerHistory()
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
            }
            var ThirdNames = from c in context.Player
                             orderby c.ThirdName
                             select c.ThirdName;

            foreach (var c in ThirdNames)
            {
                this.comboBox3.Items.Add(c);
            }
        }
        private void LoadTeams()
        {
            var pl = from c in context.Teams
                     select c;
            foreach (Teams c in pl)
            {
                this.comboBox4.Items.Add(c.TeamName);
                this.comboBox4.SelectedIndex = 0;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 |
                textBox1.Text == "" | textBox2.Text == "")
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

        private void AddPlayerHistory_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            LoadNames();
            LoadTeams();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TeamsGamers old = (from c in context.TeamsGamers
                                   where c.Teams.TeamName == (string)this.comboBox4.SelectedItem
                                   & c.Player.FirstName == (string)this.comboBox2.SelectedItem
                                   & c.Player.SecondName == (string)this.comboBox1.SelectedItem
                                   & c.Player.ThirdName == (string)this.comboBox3.SelectedItem
                                   select c).FirstOrDefault();
                Teams t = (from c in context.Teams
                           where c.TeamName == (string)this.comboBox4.SelectedItem
                           select c).FirstOrDefault();
                Player p = (from c in context.Player
                            where c.FirstName == (string)this.comboBox2.SelectedItem
                            & c.SecondName == (string)this.comboBox1.SelectedItem
                            & c.ThirdName == (string)this.comboBox3.SelectedItem
                            select c).FirstOrDefault();
                if (old == null)
                {
                    TeamsGamers tg = new TeamsGamers();
                    tg.TeamID = t.ID;
                    tg.GamerID = p.ID;
                    int yb = int.Parse(this.textBox2.Text.ToUpper());
                    int ye = int.Parse(this.textBox1.Text.ToUpper());
                    tg.PlayBegin = yb;
                    tg.PlayEnd = ye;
                    context.TeamsGamers.Add(tg);
                    context.SaveChanges();
                    MessageBox.Show("Історія успішно додана.", " Результат");
                }
                else
                {
                    MessageBox.Show("Історія даного гравця вже є.", " Результат");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
                             
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 |
               textBox1.Text == "" | textBox2.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 |
               textBox1.Text == "" | textBox2.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 |
               textBox1.Text == "" | textBox2.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 |
               textBox1.Text == "" | textBox2.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | comboBox4.SelectedIndex < 0 |
               textBox1.Text == "" | textBox2.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}
