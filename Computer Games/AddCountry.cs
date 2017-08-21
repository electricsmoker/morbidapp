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
    public partial class AddCountry : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public AddCountry()
        {
            InitializeComponent();
        }
        private void CreateCountry()
        {
           Country oldCountry;
           try
           {
               oldCountry = (from c in context.Country
                             where c.CountryName == this.textBox1.Text.ToUpper()
                             select c).FirstOrDefault();
               if (oldCountry == null)
               {
                   Country c = new Country();
                   c.CountryName = this.textBox1.Text.ToUpper();
                   context.Country.Add(c);
                   context.SaveChanges();
                   MessageBox.Show("Нова країна успішно додана в базу даних.", "Результат");
               }
               else MessageBox.Show("Країна з такою назвою вже існує!", "Результат");

           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Помилка");
           }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CreateCountry();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void AddCountry_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
    }
}
