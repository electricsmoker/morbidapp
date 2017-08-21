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
    public partial class AddClub : Form
    {
        public AddClub()
        {
            InitializeComponent();
        }
        
        computer_gamesEntities context = new computer_gamesEntities();
        private void LoadCountries()
        {
            context = new computer_gamesEntities();

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
            context = new computer_gamesEntities();

            var counties = from c in context.City
                           orderby c.Name
                           select c;

            foreach (City c in counties)
            {
                this.comboBox2.Items.Add(c.Name);
            }
        }
        private void AddClub_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            LoadCountries();
            LoadCities();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            AddCountry ac = new AddCountry();
            ac.ShowDialog();
            LoadCities();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddCity addc = new AddCity();
            addc.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Teams oldteam = (from c in context.Teams
                                 where c.TeamName == textBox1.Text.ToUpper()
                                 select c).FirstOrDefault();
                City cc = (from c in context.City
                           where c.Name == (string)this.comboBox2.SelectedItem
                           select c).FirstOrDefault();
                if (oldteam == null)
                {
                    Teams t = new Teams();
                    t.TeamName = textBox1.Text.ToUpper();
                    t.CityID = cc.ID;
                    t.President = textBox4.Text.ToString() + textBox2.Text.ToString() + textBox3.Text.ToString();
                    context.Teams.Add(t);
                    context.SaveChanges();
                    MessageBox.Show("Нова команда успішно додана в базу", "Результат");
                }
                else
                {
                    MessageBox.Show("Команда з такою назвою уже існує!", "Результат");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() == "" | textBox2.Text.ToUpper() == "" | textBox3.Text.ToUpper() == "" | textBox4.Text.ToUpper() == "" | comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0)
                button2.Enabled = false;
            else button2.Enabled = true;
            if (comboBox1.SelectedIndex >= 0)
            {
                var cities = (from c in context.City where c.Country.CountryName == (string)comboBox1.SelectedItem select c).ToList();
                comboBox2.Items.Clear();
                foreach (var city in cities)
                {
                    comboBox2.Items.Add(city.Name);
                    comboBox2.SelectedIndex = 0;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            AddTeamPrize adp = new AddTeamPrize();
            adp.ShowDialog();
        }

        private void AddClub_Activated(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            this.comboBox2.Items.Clear();
            LoadCities();
            LoadCountries();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() == "" | textBox2.Text.ToUpper() == "" | textBox3.Text.ToUpper() == "" | textBox4.Text.ToUpper() == "" | comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0)
                button2.Enabled = false;
            else button2.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() == "" | textBox2.Text.ToUpper() == "" | textBox3.Text.ToUpper() == "" | textBox4.Text.ToUpper() == "" | comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0)
                button2.Enabled = false;
            else button2.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() == "" | textBox2.Text.ToUpper() == "" | textBox3.Text.ToUpper() == "" | textBox4.Text.ToUpper() == "" | comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0)
                button2.Enabled = false;
            else button2.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() == "" | textBox2.Text.ToUpper() == "" | textBox3.Text.ToUpper() == "" | textBox4.Text.ToUpper() == "" | comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0)
                button2.Enabled = false;
            else button2.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() == "" | textBox2.Text.ToUpper() == "" | textBox3.Text.ToUpper() == "" | textBox4.Text.ToUpper() == "" | comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0)
                button2.Enabled = false;
            else button2.Enabled = true;
        }
    }
}
