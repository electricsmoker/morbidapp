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
    public partial class AddNameOfT : Form
    {
        public AddNameOfT()
        {
            InitializeComponent();
        }
        computer_gamesEntities context = new computer_gamesEntities();
        private void AddNameOfT_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Competition co = new Competition();
                Competition old = (from c in context.Competition
                                   where c.Name == this.textBox1.Text.ToUpper()
                                   select c).FirstOrDefault();
                if (old == null)
                {
                    co.Name = this.textBox1.Text.ToUpper();
                    context.Competition.Add(co);
                    context.SaveChanges();
                    MessageBox.Show("Новий турнір додано.", "Результат");
                }
                else
                {
                    MessageBox.Show("Дана назва вже є", "Результат");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}
