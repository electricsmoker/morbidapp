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
    public partial class AddGame : Form
    {
        public AddGame()
        {
            InitializeComponent();
        }
        computer_gamesEntities context = new computer_gamesEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Games old = (from c in context.Games
                             where c.GameName == this.textBox1.Text.ToUpper()
                             select c).FirstOrDefault();
                if (old == null)
                {
                    Games g = new Games();
                    g.GameName = this.textBox1.Text.ToUpper();
                    int d = int.Parse(this.textBox2.Text.ToUpper());
                    g.ReleaseYear = d;
                    g.Versions = this.textBox3.Text.ToUpper();
                    g.ComputersThatSupport = this.textBox4.Text.ToUpper();
                    context.Games.Add(g);
                    context.SaveChanges();
                    MessageBox.Show("Новий гра успішно додана в базу даних.", "Результат");
                }
                else
                {
                    MessageBox.Show("Така гра вже є.", "Результат");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void AddGame_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}
