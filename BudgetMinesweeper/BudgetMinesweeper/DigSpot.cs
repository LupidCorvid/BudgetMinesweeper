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
        int mine;
        bool isDug;
        int posX; int posY;
        int len = 25;
        int width = 25;
        public Button theButton;

        public DigSpot(int givenID, int givenMine, int x, int y)
        {
            ID = givenID;
            label = "";
            mine = givenMine;
            isDug = false;
            posX = x; posY = y;

            theButton = new Button()
            {
                Tag = ID,
                Text = label,
                Size = new Size(len, width),
                Location = new Point(posX, posY)
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
        public void RevealMine()
        {

        }
    }
}
