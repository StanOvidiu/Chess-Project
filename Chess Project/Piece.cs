using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sah_v2
{
    public class Piece : Button
    {
        static public Piece[,] pieces = new Piece[8, 8];
        static public Label LTurn = new Label();
        static public Label LChecked = new Label();

        public int PieceColor; //Tag
        public int PieceLocationI;
        public int PieceLocationJ;

        //values: 1=pawn,2=knight,3=bishop,4=rook,5=queen,6=king
        //colors: 1=black,0=empty,-1=white
        protected static int[,] A = new int[8, 8];
        public static int[,] Positions = { 
            { 4, 1, 0, 0, 0, 0, -1, -4 }, 
            { 2, 1, 0, 0, 0, 0, -1, -2 }, 
            { 3, 1, 0, 0, 0, 0, -1, -3 }, 
            { 5, 1, 0, 0, 0, 0, -1, -5 }, 
            { 6, 1, 0, 0, 0, 0, -1, -6 }, 
            { 3, 1, 0, 0, 0, 0, -1, -3 }, 
            { 2, 1, 0, 0, 0, 0, -1, -2 }, 
            { 4, 1, 0, 0, 0, 0, -1, -4 }
        };
        protected static bool first_click = true;
        protected static Piece firstB = null;
        protected static int value;
        protected static int xx;
        protected static int yy;
        public static int turn=-1;
        protected static int turn2;

        public Piece()
        {

        }
        public Piece(int i,int j,int color)
        {
            this.PieceLocationI = i;
            this.PieceLocationJ = j;
            this.PieceColor = color;
        }

        public void Move(object sender, EventArgs args)
        {
            var button = sender as Piece;
            Piece x;
            switch (Piece.Positions[button.PieceLocationI, button.PieceLocationJ])
            {
                case 1:
                case -1:
                    x = new Pawn(button.PieceLocationI,button.PieceLocationJ,button.PieceColor);
                    x.Move2(sender,args);
                    break;
                case 2:
                case -2:
                    x = new Knight(button.PieceLocationI, button.PieceLocationJ, button.PieceColor);
                    x.Move2(sender, args);
                    break;
                case 3:
                case -3:
                    x = new Bishop(button.PieceLocationI, button.PieceLocationJ, button.PieceColor);
                    x.Move2(sender, args);
                    break;
                case 4:
                case -4:
                    x = new Rook(button.PieceLocationI, button.PieceLocationJ, button.PieceColor);
                    x.Move2(sender, args);
                    break;
                case 5:
                case -5:
                    x = new Queen(button.PieceLocationI, button.PieceLocationJ, button.PieceColor);
                    x.Move2(sender, args);
                    break;
                case 6:
                case -6:
                    x = new King(button.PieceLocationI, button.PieceLocationJ, button.PieceColor);
                    x.Move2(sender, args);
                    break;
                case 0:
                    x = new Empty(button.PieceLocationI, button.PieceLocationJ, button.PieceColor);
                    x.Move2(sender, args);
                    break;
            }
        }
        public virtual void Move2(object sender, EventArgs args)
        {

        }
        public void Turns(Label Turn)
        {
            if (Piece.turn == 1)
                Turn.Text = "Black moves!";
            else
                Turn.Text = "White Moves!";
        }

        public void IsChecked(object sender, EventArgs args, Label LChecked)
        {
            var button = sender as Piece;
            if (Positions[button.PieceLocationI, button.PieceLocationJ] == 1)
            {
                if (PieceLocationI > 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ + 1] == -6)
                        LChecked.Text = "Check! Protect your king!";
                if (PieceLocationI < 7)
                    if (Positions[PieceLocationI + 1, PieceLocationJ + 1] == -6)
                        LChecked.Text = "Check! Protect your king!";
            }
            else if (Positions[button.PieceLocationI, button.PieceLocationJ] == -1)
            {
                if (PieceLocationI > 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ - 1] == 6)
                        LChecked.Text = "Check! Protect your king!";
                if (PieceLocationI < 7)
                    if (Positions[PieceLocationI + 1, PieceLocationJ - 1] == 6)
                        LChecked.Text = "Check! Protect your king!";
            }
            else if(Positions[button.PieceLocationI, button.PieceLocationJ] == 2)
            {
                if (button.PieceLocationI + 2 < 8 && button.PieceLocationI + 2 >= 0 && button.PieceLocationJ + 1 < 8 && button.PieceLocationJ + 1 >= 0)
                    if (Positions[PieceLocationI + 2, PieceLocationJ + 1] == -6)
                        LChecked.Text = "Check! Protect your king!";
                if (button.PieceLocationI - 2 < 8 && button.PieceLocationI - 2 >= 0 && button.PieceLocationJ + 1 < 8 && button.PieceLocationJ + 1 >= 0)
                    if (Positions[PieceLocationI - 2, PieceLocationJ + 1] == -6)
                        LChecked.Text = "Check! Protect your king!";
                if (button.PieceLocationI + 2 < 8 && button.PieceLocationI + 2 >= 0 && button.PieceLocationJ - 1 < 8 && button.PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI + 2, PieceLocationJ - 1] == -6)
                        LChecked.Text = "Check! Protect your king!";
                if (button.PieceLocationI - 2 < 8 && button.PieceLocationI - 2 >= 0 && button.PieceLocationJ - 1 < 8 && button.PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI - 2, PieceLocationJ - 1] == -6)
                        LChecked.Text = "Check! Protect your king!";
                if (button.PieceLocationI - 1 < 8 && button.PieceLocationI - 1 >= 0 && button.PieceLocationJ + 2 < 8 && button.PieceLocationJ + 2 >= 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ + 2] == -6)
                        LChecked.Text = "Check! Protect your king!";
                if (button.PieceLocationI + 1 < 8 && button.PieceLocationI + 1 >= 0 && button.PieceLocationJ + 2 < 8 && button.PieceLocationJ + 2 >= 0)
                    if (Positions[PieceLocationI + 1, PieceLocationJ + 2] == -6)
                        LChecked.Text = "Check! Protect your king!";
                if (button.PieceLocationI - 1 < 8 && button.PieceLocationI - 1 >= 0 && button.PieceLocationJ - 2 < 8 && button.PieceLocationJ - 2 >= 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ - 2] == -6)
                        LChecked.Text = "Check! Protect your king!";
                if (button.PieceLocationI + 1 < 8 && button.PieceLocationI + 1 >= 0 && button.PieceLocationJ - 2 < 8 && button.PieceLocationJ - 2 >= 0)
                    if (Positions[PieceLocationI + 1, PieceLocationJ - 2] == -6)
                        LChecked.Text = "Check! Protect your king!";
            }
            else if(Positions[button.PieceLocationI, button.PieceLocationJ] == -2)
            {
                if (PieceLocationI + 2 < 8 && PieceLocationI + 2 >= 0 && PieceLocationJ + 1 < 8 && PieceLocationJ + 1 >= 0)
                    if (Positions[PieceLocationI + 2, PieceLocationJ + 1] == 6)
                        LChecked.Text = "Check! Protect your king!";
                if (PieceLocationI - 2 < 8 && PieceLocationI - 2 >= 0 && PieceLocationJ + 1 < 8 && PieceLocationJ + 1 >= 0)
                    if (Positions[PieceLocationI - 2, PieceLocationJ + 1] == 6)
                        LChecked.Text = "Check! Protect your king!";
                if (PieceLocationI + 2 < 8 && PieceLocationI + 2 >= 0 && PieceLocationJ - 1 < 8 && PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI + 2, PieceLocationJ - 1] == 6)
                        LChecked.Text = "Check! Protect your king!";
                if (PieceLocationI - 2 < 8 && PieceLocationI - 2 >= 0 && PieceLocationJ - 1 < 8 && PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI - 2, PieceLocationJ - 1] == 6)
                        LChecked.Text = "Check! Protect your king!";
                if (PieceLocationI - 1 < 8 && PieceLocationI - 1 >= 0 && PieceLocationJ + 2 < 8 && PieceLocationJ + 2 >= 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ + 2] == 6)
                        LChecked.Text = "Check! Protect your king!";
                if (PieceLocationI + 1 < 8 && PieceLocationI + 1 >= 0 && PieceLocationJ + 2 < 8 && PieceLocationJ + 2 >= 0)
                    if (Positions[PieceLocationI + 1, PieceLocationJ + 2] == 6)
                        LChecked.Text = "Check! Protect your king!";
                if (PieceLocationI - 1 < 8 && PieceLocationI - 1 >= 0 && PieceLocationJ - 2 < 8 && PieceLocationJ - 2 >= 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ - 2] == 6)
                        LChecked.Text = "Check! Protect your king!";
                if (PieceLocationI + 1 < 8 && PieceLocationI + 1 >= 0 && PieceLocationJ - 2 < 8 && PieceLocationJ - 2 >= 0)
                    if (Positions[PieceLocationI + 1, PieceLocationJ - 2] == 6)
                        LChecked.Text = "Check! Protect your king!";
            }
            else if(Positions[button.PieceLocationI, button.PieceLocationJ] == 3)
            {
                int x = PieceLocationI;
                int y = PieceLocationJ;
                while (x < 8 && y < 8)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 3)
                        break;
                    x++;
                    y++;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x >= 0 && y >= 0)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 3)
                        break;
                    --x;
                    --y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x < 8 && y >= 0)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 3)
                        break;
                    ++x;
                    --y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x >= 0 && y < 8)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 3)
                        break;
                    --x;
                    ++y;
                }
            }
            else if(Positions[button.PieceLocationI, button.PieceLocationJ] == -3)
            {
                int x = PieceLocationI;
                int y = PieceLocationJ;
                while (x < 8 && y < 8)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -3)
                        break;
                    x++;
                    y++;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x >= 0 && y >= 0)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -3)
                        break;
                    --x;
                    --y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x < 8 && y >= 0)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -3)
                        break;
                    ++x;
                    --y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x >= 0 && y < 8)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -3)
                        break;
                    --x;
                    ++y;
                }
            }
            else if(Positions[button.PieceLocationI, button.PieceLocationJ] == 4)
            {
                int x = PieceLocationI;
                int y = PieceLocationJ;
                while (x < 8)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 4)
                        break;
                    ++x;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x >= 0)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 4)
                        break;
                    --x;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (y >= 0)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 4)
                        break;
                    --y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (y < 8)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 4)
                        break;
                    ++y;
                }
            }
            else if(Positions[button.PieceLocationI, button.PieceLocationJ] == -4)
            {
                int x = PieceLocationI;
                int y = PieceLocationJ;
                while (x < 8)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -4)
                        break;
                    ++x;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x >= 0)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -4)
                        break;
                    --x;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (y >= 0)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -4)
                        break;
                    --y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (y < 8)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -4)
                        break;
                    ++y;
                }
            }
            else if(Positions[button.PieceLocationI, button.PieceLocationJ] == 5)
            {
                int x = PieceLocationI;
                int y = PieceLocationJ;
                while (x < 8 && y < 8)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 5)
                        break;
                    x++;
                    y++;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x >= 0 && y >= 0)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 5)
                        break;
                    --x;
                    --y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x < 8 && y >= 0)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 5)
                        break;
                    ++x;
                    --y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x >= 0 && y < 8)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 5)
                        break;
                    --x;
                    ++y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x < 8)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 5)
                        break;
                    ++x;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x >= 0)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 5)
                        break;
                    --x;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (y >= 0)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 5)
                        break;
                    --y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (y < 8)
                {
                    if (Positions[x, y] == -6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 5)
                        break;
                    ++y;
                }
            }
            else if(Positions[button.PieceLocationI, button.PieceLocationJ] == -5)
            {
                int x = PieceLocationI;
                int y = PieceLocationJ;
                while (x < 8)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -5)
                        break;
                    ++x;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x >= 0)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -5)
                        break;
                    --x;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (y >= 0)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -5)
                        break;
                    --y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (y < 8)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -5)
                        break;
                    ++y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x < 8 && y < 8)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -3)
                        break;
                    x++;
                    y++;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x >= 0 && y >= 0)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -5)
                        break;
                    --x;
                    --y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x < 8 && y >= 0)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -5)
                        break;
                    ++x;
                    --y;
                }
                x = PieceLocationI;
                y = PieceLocationJ;
                while (x >= 0 && y < 8)
                {
                    if (Positions[x, y] == 6)
                        LChecked.Text = "Check! Protect your king!";
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -5)
                        break;
                    --x;
                    ++y;
                }
            }
        }
    }
}
