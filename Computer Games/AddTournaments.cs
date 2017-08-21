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
    public partial class AddTournaments : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public AddTournaments()
        {
            InitializeComponent();
        }
        private void LoadGames()
        {
            var pl = from c in context.Games
                     select c;
            foreach (Games g in pl)
            {
                this.comboBox1.Items.Add(g.GameName);
                this.comboBox1.SelectedIndex = 0;
            }
        }
        private void LoadT()
        {
            var pl = from c in context.Competition
                     select c;
            foreach (Competition c in pl)
            {
                this.comboBox2.Items.Add(c.Name);
                this.comboBox2.SelectedIndex = 0;
            }
        }
        private void AddTournaments_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            LoadGames();
            LoadT();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddGame ag = new AddGame();
            ag.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                Competition1 old = (from c in context.Competition1
                                    where c.Competition.Name == (string)this.comboBox2.SelectedItem //& c.Games.GameName == (string)this.comboBox1.SelectedItem
                                    & c.Date == dt
                                    select c).FirstOrDefault();
                Competition co = (from c in context.Competition
                                  where c.Name == (string)this.comboBox2.SelectedItem
                                  select c).FirstOrDefault();
                Games g = (from c in context.Games
                           where c.GameName == (string)this.comboBox1.SelectedItem
                           select c).FirstOrDefault();
                if (old == null)
                {
                    Competition1 c1 = new Competition1();
                    c1.Date = dt;
                    c1.CompetitionID = co.ID;
                    c1.GameID = g.ID;
                    context.Competition1.Add(c1);
                    context.SaveChanges();
                    MessageBox.Show("Новий турнір зареєстровано.", "Результат");
                }
                else
                {
                    MessageBox.Show("Турнір з такою назвою або датою проведення вже є.", "Результат");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddNameOfT anot = new AddNameOfT();
            anot.ShowDialog();
        }

        private void AddTournaments_Activated(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            LoadGames();
            LoadT();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox1.SelectedIndex < 0)
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox1.SelectedIndex < 0)
                button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}
