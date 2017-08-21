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
    public partial class Trainers : Form
    {
        computer_gamesEntities context = new computer_gamesEntities();
        public Trainers()
        {
            InitializeComponent();
        }
        public void LoadNames()
        {
            var FirstNames = from c in context.Coaches
                             orderby c.FirstName
                             select c.FirstName;

            foreach (var c in FirstNames)
            {
                this.comboBox2.Items.Add(c);
            }
            var SecondNames = from c in context.Coaches
                              orderby c.SecondName
                              select c.SecondName;

            foreach (var c in SecondNames)
            {
                this.comboBox1.Items.Add(c);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                var snames = (from c in context.Coaches where c.SecondName == (string)comboBox1.SelectedItem select new { c.FirstName, c.SecondName }).ToList();
                comboBox2.Items.Clear();
                foreach (var c in snames)
                {
                    comboBox2.Items.Add(c.FirstName);
                    comboBox2.SelectedIndex = 0;
                }
            }
        }

        private void Trainers_Load(object sender, EventArgs e)
        {
            LoadNames();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var pl = from c in context.CoachTrain
                     where c.Coaches.FirstName == (string)this.comboBox2.SelectedItem & c.Coaches.SecondName == (string)this.comboBox1.SelectedItem
                     select new { c.Teams.TeamName, c.DateBegin, c.DateEnd };
            dataGridView1.DataSource = pl.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTrainer at = new AddTrainer();
            at.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClubHistory ch = new ClubHistory();
            ch.ShowDialog();
        }
    }
}
