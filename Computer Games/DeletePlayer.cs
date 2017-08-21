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
    public partial class DeletePlayer : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public DeletePlayer()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedIndex >= 0)
            {
                var snames = (from c in context.Player where c.SecondName == (string)comboBox1.SelectedItem select new { c.FirstName, c.ThirdName }).ToList();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                foreach (var c in snames)
                {
                    comboBox2.Items.Add(c.FirstName);
                    comboBox3.Items.Add(c.ThirdName);
                    comboBox2.SelectedIndex = 0;
                    comboBox3.SelectedIndex = 0;
                }
            }
        }
        public void LoadNames()
        {
            //context = new computer_gamesEntities();

            var FirstNames = from c in context.Player
                             orderby c.FirstName
                             select c.FirstName;

            foreach (var c in FirstNames)
            {
                this.comboBox2.Items.Add(c);
                //this.comboBox1.Text = c.Name;

            }
            var SecondNames = from c in context.Player
                              orderby c.SecondName
                              select c.SecondName;

            foreach (var c in SecondNames)
            {
                this.comboBox1.Items.Add(c);
                //this.comboBox1.Text = c.Name;

            }
            var ThirdNames = from c in context.Player
                             orderby c.ThirdName
                             select c.ThirdName;

            foreach (var c in ThirdNames)
            {
                this.comboBox3.Items.Add(c);
                //this.comboBox1.Text = c.Name;

            }
        }
        
        private void DeletePlayer_Load(object sender, EventArgs e)
        {
            LoadNames();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player p = new Player();
            p = (from c in context.Player
                 where c.SecondName == (string)this.comboBox1.SelectedItem & c.FirstName == (string)this.comboBox2.SelectedItem &
                 c.ThirdName == (string)this.comboBox3.SelectedItem
                 select c).FirstOrDefault();
            context.Player.Remove(p);
            context.SaveChanges();

        }

       
    }
}
