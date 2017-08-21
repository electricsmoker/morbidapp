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
    public partial class AddSchool : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public AddSchool()
        {
            InitializeComponent();
        }
        private void CreateSchool()
        {
            try
            {
                Schools OldSchool;
                try
                {
                    OldSchool = (from c in context.Schools
                                 where c.SchoolName == this.textBox1.Text.ToUpper()
                                 select c).FirstOrDefault();
                    if (OldSchool == null)
                    {
                        Schools c = new Schools();
                        c.SchoolName = this.textBox1.Text.ToUpper();
                        context.Schools.Add(c);
                        context.SaveChanges();
                        MessageBox.Show("Нова школа успішно додана в базу даних.", "Результат");
                    }
                    else MessageBox.Show("Школа з такою назвою вже існує!", "Результат");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AddSchool_Load(object sender, EventArgs e)
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
