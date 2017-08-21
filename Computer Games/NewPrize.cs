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
    public partial class NewPrize : Form
    {
        public NewPrize()
        {
            InitializeComponent();
        }
        computer_gamesEntities context = new computer_gamesEntities();
        
        private void NewPrize_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var pr = (from c in context.Prizes
                          where c.Prize == (string)this.textBox1.Text.ToUpper()
                          select c).FirstOrDefault();
                if (pr == null)
                {
                    Prizes prr = new Prizes();
                    prr.Prize = (string)this.textBox1.Text.ToUpper();
                    context.Prizes.Add(prr);
                    context.SaveChanges();
                    MessageBox.Show("Нову нагороду успішно додано!", "Результат");
                }
                else MessageBox.Show("Така нагорода уже існує!", "Результат");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка");
            }
        }
    }
}
