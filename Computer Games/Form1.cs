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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        public void ss()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gamer g = new Gamer();
            g.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClubsAndTrainers cat = new ClubsAndTrainers();
            cat.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChampionShips cs = new ChampionShips();
            cs.ShowDialog();
        }
    }
   
}
