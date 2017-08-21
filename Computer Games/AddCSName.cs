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
    public partial class AddCSName : Form
    {
        public AddCSName()
        {
            InitializeComponent();
        }
        computer_gamesEntities context = new computer_gamesEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            Championship old = (from c in context.Championship
                         where c.NameOfCS == this.textBox1.Text.ToUpper()
                         select c).FirstOrDefault();
            if (old == null)
            {
                Championship g = new Championship();
                g.NameOfCS = this.textBox1.Text.ToUpper();
                context.Championship.Add(g);
                context.SaveChanges();
                MessageBox.Show("Новий чемпіонат доданий.", "Результат");
            }
            else
            {
                MessageBox.Show("Такий чемп вже є.", "Результат");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Championship old = (from c in context.Championship
                                    where c.NameOfCS == this.textBox1.Text.ToUpper()
                                    select c).FirstOrDefault();
                if (old == null)
                {
                    Championship g = new Championship();
                    g.NameOfCS = this.textBox1.Text.ToUpper();
                    context.Championship.Add(g);
                    context.SaveChanges();
                    MessageBox.Show("Новий чемпіонат доданий.", "Результат");
                }
                else
                {
                    MessageBox.Show("Такий чемп вже є.", "Результат");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void AddCSName_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}
