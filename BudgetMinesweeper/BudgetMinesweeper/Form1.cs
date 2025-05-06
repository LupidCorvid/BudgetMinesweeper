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
        int DIG_SIZE = 25; //How big a digSpot is
        int LOWEST_X = 20; //Where the minefield should start
        int LOWEST_Y = 60; //Where the minefield should start
        float DEFAULT_MINE_PERCENT = .3f;

        GameBoard gameBoard = null;
        bool gameStarted = false;
        int boardLength = 0;
        int boardWidth = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (!gameStarted) { 
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
                    gameStarted = true;
                    txtLength.BackColor = Color.White;
                    txtWidth.BackColor = Color.White;

                    //Spawn length x width buttons
                    int idCount = 0;
                    boardLength = int.Parse(txtLength.Text);
                    boardWidth = int.Parse(txtWidth.Text);
                    gameBoard = new GameBoard(boardLength, boardWidth, DEFAULT_MINE_PERCENT);

                    //Board creation
                    for (int i = 0; i < boardLength; i++)
                    {
                        for(int j = 0; j < boardWidth; j++)
                        {
                            int x = LOWEST_X + (j * DIG_SIZE);
                            int y = LOWEST_Y + (i * DIG_SIZE);

                            //TODO: Determine if this square should be a mine. Try to keep mines as spaced out as possible.


                            DigSpot spot = new DigSpot(idCount, 0, x, y); //ID, mine, x, y
                            Controls.Add(spot.theButton);
                            gameBoard.minefield[i][j] = spot;
                            idCount++;
                        }
                    }

                    /*Steps to adding mines:
                     * Create the board. Along the way, sprinkle in the mine squares
                     * After board creation, check every square
                     *      For each square,
                     */
                }
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                for (int i = 0; i < gameBoard.getLength(); i++)
                    for (int j = 0; j < gameBoard.getWidth(); j++)
                        Controls.Remove(gameBoard.minefield[i][j].theButton); //Remove visual elements from the form
                gameBoard = null; //Reset the board
                gameStarted = false;
            }
        }
    }
}
