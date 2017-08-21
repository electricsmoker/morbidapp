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
    public partial class AddHistoryOfT : Form
    {
        public AddHistoryOfT()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
                
        }

        private void AddHistoryOfT_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0 | comboBox2.SelectedIndex < 0 | comboBox3.SelectedIndex < 0 | textBox1.Text == "")
                button1.Enabled = false;
            else button1.Enabled = true;
        }
    }
}
