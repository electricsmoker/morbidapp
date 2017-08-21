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
    public partial class AddChampionship : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public AddChampionship()
        {
            InitializeComponent();
        }
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
        private void LoadGames()
        {
            var pl = from c in context.Games
                     select c;
            foreach (Games g in pl)
            {
                this.comboBox2.Items.Add(g.GameName);
                this.comboBox2.SelectedIndex = 0;
            }
        }
        private void AddChampionship_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            LoadCS();
            LoadGames();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddCSName acsn = new AddCSName();
            acsn.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddGame ag = new AddGame();
            ag.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int d = int.Parse(this.textBox1.Text.ToUpper());
                int d1 = int.Parse(this.textBox2.Text.ToUpper());

                Championship1 old = (from c in context.Championship1
                                     where c.Championship.NameOfCS == (string)this.comboBox1.SelectedItem & c.YearOfStart == d
                                     select c).FirstOrDefault();

                Championship css = (from c in context.Championship
                                    where c.NameOfCS == (string)this.comboBox1.SelectedItem
                                    select c).FirstOrDefault();
                Games g = (from c in context.Games
                           where c.GameName == (string)this.comboBox2.SelectedItem
                           select c).FirstOrDefault();
                if (old == null)
                {
                    Championship1 cs = new Championship1();
                    cs.NameOfChampionshipID = css.ID;
                    cs.YearOfStart = d;
                    cs.PrizeFond = d1;
                    cs.GamesID = g.ID;
                    context.Championship1.Add(cs);
                    context.SaveChanges();
                    MessageBox.Show("Новий чемпіонат успішно доданий у базу.", "Результат");
                }
                else
                {
                    MessageBox.Show("Чемпіонат з такою датою вже проводився", "Результат");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }
        private void AddChampionship_Activated(object sender, EventArgs e)
        {
            this.comboBox2.Items.Clear();
            LoadGames();
            this.comboBox1.Items.Clear();
            LoadCS();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | textBox1.Text.ToUpper() == "" | textBox2.Text.ToUpper() == "")
                button3.Enabled = false;
            else button3.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | textBox1.Text.ToUpper() == "" | textBox2.Text.ToUpper() == "")
                button3.Enabled = false;
            else button3.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | textBox1.Text.ToUpper() == "" | textBox2.Text.ToUpper() == "")
                button3.Enabled = false;
            else button3.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | textBox1.Text.ToUpper() == "" | textBox2.Text.ToUpper() == "")
                button3.Enabled = false;
            else button3.Enabled = true;
        }
    }
}
