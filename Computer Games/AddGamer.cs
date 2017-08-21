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
    public partial class AddGamer : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public AddGamer()
        {
            InitializeComponent();
        }
        private void LoadCountries()
        {
            var counties = from c in context.Country
                           orderby c.CountryName
                           select c;
            foreach (Country c in counties)
            {
                this.comboBox1.Items.Add(c.CountryName);
                comboBox1.SelectedIndex = 0;
            }
        }
        private void LoadCities()
        {
            var counties = from c in context.City
                           orderby c.Name
                           select c;

            foreach (City c in counties)
            {
                this.comboBox3.Items.Add(c.Name);
            }
        }
        private void LoadTeams()
        {
            var counties = from c in context.Teams
                           orderby c.TeamName
                           select c;

            foreach (Teams c in counties)
            {
                this.comboBox4.Items.Add(c.TeamName);
            }
        }
        private void LoadSchools()
        {
            var counties = from c in context.Schools
                           orderby c.SchoolName
                           select c;

            foreach (Schools c in counties)
            {
                this.comboBox2.Items.Add(c.SchoolName);
            }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            AddCountry ac = new AddCountry();
            ac.ShowDialog();
            LoadCities();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddSchool adds = new AddSchool();
            adds.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddCity addc = new AddCity();
            addc.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Country co = (from d in context.Country
                              where d.CountryName == (string)this.comboBox1.SelectedItem
                              select d).FirstOrDefault();
                City ci = (from d in context.City
                           where d.Name == (string)this.comboBox3.SelectedItem
                           select d).FirstOrDefault();
                Schools sc = (from d in context.Schools
                              where d.SchoolName == (string)this.comboBox2.SelectedItem
                              select d).FirstOrDefault();
                Teams t = (from d in context.Teams
                           where d.TeamName == (string)this.comboBox4.SelectedItem
                           select d).FirstOrDefault();
                DateTime tt = new DateTime(this.dateTimePicker1.Value.Year, this.dateTimePicker1.Value.Month, this.dateTimePicker1.Value.Day);
                Player oldplayer;
                GamerStuding gs = new GamerStuding();
                oldplayer = (from d in context.Player
                             where d.FirstName == this.textBox1.Text.ToUpper() & d.SecondName == this.textBox2.Text.ToUpper() & d.ThirdName == this.textBox3.Text.ToUpper()
                             & d.CityID == ci.ID //& d.Birthday == tt
                             select d).FirstOrDefault();
                if (oldplayer == null)
                {
                    Player p = new Player();
                    GamerStuding gss = new GamerStuding();
                    TeamsGamers tg = new TeamsGamers();
                    p.FirstName = (string)this.textBox1.Text.ToUpper();
                    p.SecondName = (string)this.textBox2.Text.ToUpper();
                    p.ThirdName = (string)this.textBox3.Text.ToUpper();
                    p.CityID = ci.ID;
                    p.Birthday = tt;
                    context.Player.Add(p);
                    context.SaveChanges();
                    gss.GamerID = p.ID;
                    gss.SchoolID = sc.ID;
                    gss.StudyBegin = int.Parse(this.textBox7.Text.ToUpper());
                    gss.StudyEnd = int.Parse(this.textBox6.Text.ToUpper());
                    context.GamerStuding.Add(gss);
                    context.SaveChanges();
                    tg.TeamID = t.ID;
                    tg.GamerID = p.ID;
                    tg.PlayBegin = int.Parse(this.textBox5.Text.ToUpper());
                    tg.PlayEnd = int.Parse(this.textBox4.Text.ToUpper());
                    context.TeamsGamers.Add(tg);
                    context.SaveChanges();
                    MessageBox.Show("Новий гравець успішно доданий в базу даних.", "Результат");
                }
                else MessageBox.Show("Гравець з такими данними вже існує!", "Результат");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" | this.textBox2.Text == "" | this.textBox3.Text == ""
            | this.textBox4.Text == "" | this.textBox5.Text == "" | this.textBox6.Text == "" | this.textBox7.Text == ""
                | this.comboBox1.SelectedIndex < 0 | this.comboBox2.SelectedIndex < 0 | this.comboBox3.SelectedIndex < 0 | this.comboBox4.SelectedIndex < 0)
                this.button1.Enabled = false;
            else this.button1.Enabled = true;
            if (comboBox1.SelectedIndex >= 0)
            {
                var cities = (from c in context.City where c.Country.CountryName == (string)comboBox1.SelectedItem select c).ToList();
                comboBox3.Items.Clear();
                foreach (var city in cities)
                {
                    comboBox3.Items.Add(city.Name);
                    comboBox3.SelectedIndex = 0;
                }
            }
        }
        private void AddGamer_Load(object sender, EventArgs e)
        {
            LoadTeams();
            LoadSchools();
            LoadCities();
            LoadCountries();
            button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" | this.textBox2.Text == "" | this.textBox3.Text == ""
            | this.textBox4.Text == "" | this.textBox5.Text == "" | this.textBox6.Text == "" | this.textBox7.Text == ""
                | this.comboBox1.SelectedIndex < 0 | this.comboBox2.SelectedIndex < 0 | this.comboBox3.SelectedIndex < 0 | this.comboBox4.SelectedIndex < 0)
                this.button1.Enabled = false;
            else this.button1.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" | this.textBox2.Text == "" | this.textBox3.Text == ""
            | this.textBox4.Text == "" | this.textBox5.Text == "" | this.textBox6.Text == "" | this.textBox7.Text == ""
                | this.comboBox1.SelectedIndex < 0 | this.comboBox2.SelectedIndex < 0 | this.comboBox3.SelectedIndex < 0 | this.comboBox4.SelectedIndex < 0)
                this.button1.Enabled = false;
            else this.button1.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" | this.textBox2.Text == "" | this.textBox3.Text == ""
            | this.textBox4.Text == "" | this.textBox5.Text == "" | this.textBox6.Text == "" | this.textBox7.Text == ""
                | this.comboBox1.SelectedIndex < 0 | this.comboBox2.SelectedIndex < 0 | this.comboBox3.SelectedIndex < 0 | this.comboBox4.SelectedIndex < 0)
                this.button1.Enabled = false;
            else this.button1.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" | this.textBox2.Text == "" | this.textBox3.Text == ""
            | this.textBox4.Text == "" | this.textBox5.Text == "" | this.textBox6.Text == "" | this.textBox7.Text == ""
                | this.comboBox1.SelectedIndex < 0 | this.comboBox2.SelectedIndex < 0 | this.comboBox3.SelectedIndex < 0 | this.comboBox4.SelectedIndex < 0)
                this.button1.Enabled = false;
            else this.button1.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" | this.textBox2.Text == "" | this.textBox3.Text == ""
            | this.textBox4.Text == "" | this.textBox5.Text == "" | this.textBox6.Text == "" | this.textBox7.Text == ""
                | this.comboBox1.SelectedIndex < 0 | this.comboBox2.SelectedIndex < 0 | this.comboBox3.SelectedIndex < 0 | this.comboBox4.SelectedIndex < 0)
                this.button1.Enabled = false;
            else this.button1.Enabled = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" | this.textBox2.Text == "" | this.textBox3.Text == ""
            | this.textBox4.Text == "" | this.textBox5.Text == "" | this.textBox6.Text == "" | this.textBox7.Text == ""
                | this.comboBox1.SelectedIndex < 0 | this.comboBox2.SelectedIndex < 0 | this.comboBox3.SelectedIndex < 0 | this.comboBox4.SelectedIndex < 0)
                this.button1.Enabled = false;
            else this.button1.Enabled = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" | this.textBox2.Text == "" | this.textBox3.Text == ""
            | this.textBox4.Text == "" | this.textBox5.Text == "" | this.textBox6.Text == "" | this.textBox7.Text == ""
                | this.comboBox1.SelectedIndex < 0 | this.comboBox2.SelectedIndex < 0 | this.comboBox3.SelectedIndex < 0 | this.comboBox4.SelectedIndex < 0)
                this.button1.Enabled = false;
            else this.button1.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" | this.textBox2.Text == "" | this.textBox3.Text == ""
            | this.textBox4.Text == "" | this.textBox5.Text == "" | this.textBox6.Text == "" | this.textBox7.Text == ""
                | this.comboBox1.SelectedIndex < 0 | this.comboBox2.SelectedIndex < 0 | this.comboBox3.SelectedIndex < 0 | this.comboBox4.SelectedIndex < 0)
                this.button1.Enabled = false;
            else this.button1.Enabled = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" | this.textBox2.Text == "" | this.textBox3.Text == ""
            | this.textBox4.Text == "" | this.textBox5.Text == "" | this.textBox6.Text == "" | this.textBox7.Text == ""
                | this.comboBox1.SelectedIndex < 0 | this.comboBox2.SelectedIndex < 0 | this.comboBox3.SelectedIndex < 0 | this.comboBox4.SelectedIndex < 0)
                this.button1.Enabled = false;
            else this.button1.Enabled = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" | this.textBox2.Text == "" | this.textBox3.Text == ""
            | this.textBox4.Text == "" | this.textBox5.Text == "" | this.textBox6.Text == "" | this.textBox7.Text == ""
                | this.comboBox1.SelectedIndex < 0 | this.comboBox2.SelectedIndex < 0 | this.comboBox3.SelectedIndex < 0 | this.comboBox4.SelectedIndex < 0)
                this.button1.Enabled = false;
            else this.button1.Enabled = true;
        }
    }
}
