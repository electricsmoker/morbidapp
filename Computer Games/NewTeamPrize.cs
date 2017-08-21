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
    public partial class NewTeamPrize : Form
    {
        public NewTeamPrize()
        {
            InitializeComponent();
        }
        computer_gamesEntities context = new computer_gamesEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var pr = (from c in context.TeamsPrizes
                          where c.PrizeName == (string)this.textBox1.Text.ToUpper()
                          select c).FirstOrDefault();
                if (pr == null)
                {
                    TeamsPrizes prr = new TeamsPrizes();
                    prr.PrizeName = (string)this.textBox1.Text.ToUpper();
                    context.TeamsPrizes.Add(prr);
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
