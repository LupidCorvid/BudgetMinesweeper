using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BudgetMinesweeper
{
    class DigSpot
    {
        int ID;
        string label; //What shows to the player
        int mine; //The hidden number underneath. -1 is a mine
        bool isDug;
        int posX; int posY;
        int len = 25;
        int width = 25;
        public Button theButton;
        int textColor = 1; //Start with blank color, 0 is red
        Color[] colors = { Color.Red, Color.White, Color.Blue, Color.Green, Color.LightCoral,
            Color.Purple, Color.DarkBlue, Color.Teal, Color.Black, Color.Gray};
        int currColor = 1;

        public DigSpot(int givenID, int givenMine, int x, int y)
        {
            ID = givenID;
            label = "";
            mine = givenMine;
            isDug = false;
            posX = x; posY = y;
            currColor = 1;

            theButton = new Button()
            {
                Tag = ID,
                Text = label,
                Size = new Size(len, width),
                Location = new Point(posX, posY),
                ForeColor = colors[1]
            };
        }

        public int GetID(){ return ID; }
        public void SetID(int newID) { ID = newID; }
        public void SetMineLabel()
        {
            if (!isDug && label == "")
            {
                label = "!";
            }
        }
        public int getMineValue() { return mine; }
        public void setMineValue(int value) { mine = value; }

        public void RevealMine()
        {

        }
        public void IncrementColor() {
            currColor++;
            theButton.ForeColor = colors[currColor];
        }
        public void DecrementColor()
        {
            currColor--;
            theButton.ForeColor = colors[currColor];
        }
    }
}
