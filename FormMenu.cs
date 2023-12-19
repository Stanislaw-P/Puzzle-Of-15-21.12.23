using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Of_15
{
    public partial class FormMenu : Form
    {

        public FormMenu()
        {
            InitializeComponent();

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void buttonDigit_Click(object sender, EventArgs e)
        {
            FormDigit goDigit = new FormDigit();
            goDigit.Show();
        }

        private void buttonIron_Click(object sender, EventArgs e)
        {
            FormIron goIron = new FormIron();
            goIron.Show();
        }
    }
}
