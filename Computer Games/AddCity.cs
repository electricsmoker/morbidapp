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
    public partial class AddCity : Form
    {
        computer_gamesEntities context;
        public AddCity()
        {
            InitializeComponent();
           
        }
        
        private void LoadCountries()
        {
            context = new computer_gamesEntities();
            
            var counties = from c in context.Country
                           orderby c.CountryName
                           select c;
            foreach (Country c in counties)
            {
                this.comboBox1.Items.Add(c.CountryName);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Country cc = new Country();
                cc = (from d in context.Country
                      where d.CountryName == (string)comboBox1.SelectedItem
                      select d).FirstOrDefault();
                City oldcity = new City();
                oldcity = (from c in context.City
                           where c.Name == (string)this.textBox1.Text.ToUpper()
                           select c).FirstOrDefault();
                if (oldcity == null)
                {
                    City c = new City();
                    c.Name = (string)this.textBox1.Text.ToUpper();
                    c.CountryID = cc.CountryID;
                    context.City.Add(c);
                    context.SaveChanges();
                    MessageBox.Show("Нове місто успішно додано в базу даних.", "Результат");
                }
                else MessageBox.Show("Місто вже існує.", "Результат");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddCountry ac = new AddCountry();
            ac.ShowDialog();
        }
        private void AddCity_Load(object sender, EventArgs e)
        {
            LoadCountries();
            button1.Enabled = false;
        }

        private void AddCity_Activated(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            LoadCountries();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | textBox1.Text.ToUpper() == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}
