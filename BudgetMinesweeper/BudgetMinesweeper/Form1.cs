using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetMinesweeper
{
    public partial class Form1 : Form
    {
        int MAX_LENGTH = 20;
        int MAX_WIDTH = 30;

        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            //Verify length and width
            if (txtLength.Text == "" || txtWidth.Text == "") MessageBox.Show("You need to enter a length or width");
            else if (int.TryParse(txtLength.Text, out int s) == false || int.TryParse(txtWidth.Text, out int t) == false)
            {
                MessageBox.Show("Enter only numbers in the length and width fields");
                if (int.TryParse(txtLength.Text, out int u) == false)
                    txtLength.BackColor = Color.Red;
                else txtLength.BackColor = Color.White;

                if (int.TryParse(txtWidth.Text, out int v) == false)
                    txtWidth.BackColor = Color.Red;
                else txtWidth.BackColor = Color.White;
            }
            //Verify integers
            else if (int.Parse(txtLength.Text) > MAX_LENGTH || int.Parse(txtWidth.Text) > MAX_WIDTH)
            {
                MessageBox.Show("The length or width is too big");
                if (int.Parse(txtLength.Text) > MAX_LENGTH)
                    txtLength.BackColor = Color.Red;
                else txtLength.BackColor = Color.White;

                if (int.Parse(txtWidth.Text) > MAX_WIDTH)
                    txtWidth.BackColor = Color.Red;
                else txtWidth.BackColor = Color.White;
            }

            //Create the board
            else
            {
                txtLength.BackColor = Color.White;
                txtWidth.BackColor = Color.White;

                //Spawn length x width buttons
                DigSpot spot = new DigSpot(1, 0, 20, 60);
                Controls.Add(spot.theButton);
                
            }
            
        }

        private void Reset_Click(object sender, EventArgs e)
        {

        }
    }
}
