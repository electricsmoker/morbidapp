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
    public partial class AddTrainer : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public AddTrainer()
        {
            InitializeComponent();
        }
        private void LoadC()
        {
            var pl = from c in context.Country
                     select c;
            foreach (Country c in pl)
            {
                this.comboBox1.Items.Add(c.CountryName);
                this.comboBox1.SelectedIndex = 0;
            }
        }
        private void LoadTeams()
        {
            var pl = from c in context.Teams
                     select c;
            foreach (Teams c in pl)
            {
                this.comboBox2.Items.Add(c.TeamName);
                this.comboBox2.SelectedIndex = 0;
            }
        }

        private void AddTrainer_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            LoadTeams();
            LoadC();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddCountry ac = new AddCountry();
            ac.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Coaches oldcoach = (from c in context.Coaches
                                    where c.SecondName == this.textBox2.Text.ToUpper() & c.FirstName == this.textBox1.Text.ToUpper()
                                    select c).FirstOrDefault();
                Country cc = (from c in context.Country
                              where c.CountryName == (string)this.comboBox1.SelectedItem
                              select c).FirstOrDefault();
                Teams t = (from c in context.Teams
                           where c.TeamName == (string)this.comboBox2.SelectedItem
                           select c).FirstOrDefault();
                CoachTrain ct = (from c in context.CoachTrain
                                 where c.TeamID == t.ID & DateTime.Now > c.DateBegin & DateTime.Now < c.DateEnd
                                 select c).FirstOrDefault();
                if (oldcoach == null)
                {
                    if (ct == null)
                    {
                        Coaches c = new Coaches();
                        CoachTrain ct1 = new CoachTrain();
                        c.FirstName = this.textBox1.Text.ToUpper();
                        c.SecondName = this.textBox2.Text.ToUpper();
                        c.CountryID = cc.CountryID;
                        ct1.DateBegin = DateTime.Now;
                        ct1.DateEnd = new DateTime(DateTime.Now.Year + 5, DateTime.Now.Month, DateTime.Now.Day);
                        ct1.TeamID = t.ID;
                        ct1.CoachID = c.ID;
                        context.Coaches.Add(c);
                        context.CoachTrain.Add(ct1);
                        context.SaveChanges();
                        MessageBox.Show("Новий тренер успішно доданий", "Результат");
                    }
                    else
                    {
                        MessageBox.Show("В даний момент цю команду трнує інший спеціаліст", "Результат");
                    }
                }
                else
                {
                    MessageBox.Show("Такий тренер вже є у базі", "Результат");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void AddTrainer_Activated(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            LoadC();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0)
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0)
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0)
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0)
                button1.Enabled = false;
            else button1.Enabled = true;
        }

    }
}
