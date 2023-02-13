using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace sah_v2
{
    class Knight : Piece
    {
        public Knight(int i, int j, int color) : base(i, j, color)
        {

        }
        
        public override void Move2(object sender, EventArgs args)
        {
            var button = sender as Piece;
            if (first_click)
            {
                turn2 = turn;
                if (turn == -1 && button.PieceColor == 1)
                    return;
                if (turn == 1 && button.PieceColor == -1)
                    return;
                if (turn == -1 && button.PieceColor == -1)
                    turn = 1;
                if (turn == 1 && button.PieceColor == 1)
                    turn = -1;

                if (button.PieceColor == 1)
                    GetAvailableMovesBlackKnight(button);
                if (button.PieceColor == -1)
                    GetAvailableMovesWhiteKnight(button);
                firstB = button;
                firstB.PieceColor = button.PieceColor;
                value = Positions[PieceLocationI, PieceLocationJ];
                xx = PieceLocationI;
                yy = PieceLocationJ;
                first_click = false;
            }
            else
            {
                first_click = true;
                if (A[button.PieceLocationI, button.PieceLocationJ] == 1)
                {
                    if (firstB.PieceLocationI == 4 && firstB.PieceLocationJ == 0)
                        King.bkct++;
                    if (firstB.PieceLocationI == 4 && firstB.PieceLocationJ == 7)
                        King.wkct++;
                    if (firstB.PieceLocationI == 0 && firstB.PieceLocationJ == 0)
                        Rook.ct1++;
                    if (firstB.PieceLocationI == 7 && firstB.PieceLocationJ == 0)
                        Rook.ct2++;
                    if (firstB.PieceLocationI == 0 && firstB.PieceLocationJ == 7)
                        Rook.ct3++;
                    if (firstB.PieceLocationI == 7 && firstB.PieceLocationJ == 7)
                        Rook.ct4++;
                    button.Image = firstB.Image;
                    button.PieceColor = firstB.PieceColor;
                    Positions[button.PieceLocationI, button.PieceLocationJ] = value;
                    Positions[firstB.PieceLocationI, firstB.PieceLocationJ] = 0;
                    firstB.Image = null;
                    firstB.PieceColor = 0;
                    value = 0;
                    LChecked.Text = null;
                }
                else
                {
                    turn = turn2;
                    Positions[xx, yy] = value;
                }
                IsChecked(button, args, LChecked);
                Turns(LTurn);
            }
        }
        public void GetAvailableMovesBlackKnight(Piece x)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    A[i, j] = 0;
            if (x.PieceColor == 1)
            {
                if(PieceLocationI + 2 < 8 && PieceLocationI + 2 >= 0 && PieceLocationJ + 1 < 8 && PieceLocationJ + 1 >= 0)
                    if(Positions[PieceLocationI + 2,PieceLocationJ + 1] <= 0)
                    {
                        A[PieceLocationI + 2, PieceLocationJ + 1] = 1;
                    }
                if(PieceLocationI - 2 < 8 && PieceLocationI - 2 >= 0 && PieceLocationJ + 1 < 8 && PieceLocationJ + 1 >= 0)
                    if (Positions[PieceLocationI - 2, PieceLocationJ + 1] <= 0)
                    {
                        A[PieceLocationI - 2, PieceLocationJ + 1] = 1;
                    }
                if(PieceLocationI + 2 < 8 && PieceLocationI + 2 >= 0 && PieceLocationJ - 1 < 8 && PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI + 2, PieceLocationJ - 1] <= 0)
                    {
                        A[PieceLocationI + 2, PieceLocationJ - 1] = 1;
                    }
                if(PieceLocationI - 2 < 8 && PieceLocationI - 2 >= 0 && PieceLocationJ - 1 < 8 && PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI - 2, PieceLocationJ - 1] <= 0)
                    {
                        A[PieceLocationI - 2, PieceLocationJ - 1] = 1;
                    }
                if (PieceLocationI - 1 < 8 && PieceLocationI - 1 >= 0 && PieceLocationJ + 2 < 8 && PieceLocationJ + 2 >= 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ + 2] <= 0)
                    {
                        A[PieceLocationI - 1, PieceLocationJ + 2] = 1;
                    }
                if (PieceLocationI + 1 < 8 && PieceLocationI + 1 >= 0 && PieceLocationJ + 2 < 8 && PieceLocationJ + 2 >= 0)
                    if (Positions[PieceLocationI + 1, PieceLocationJ + 2] <= 0)
                    {
                        A[PieceLocationI + 1, PieceLocationJ + 2] = 1;
                    }
                if (PieceLocationI - 1 < 8 && PieceLocationI - 1 >= 0 && PieceLocationJ - 2 < 8 && PieceLocationJ - 2 >= 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ - 2] <= 0)
                    {
                        A[PieceLocationI - 1, PieceLocationJ - 2] = 1;
                    }
                if (PieceLocationI + 1 < 8 && PieceLocationI + 1 >= 0 && PieceLocationJ - 2 < 8 && PieceLocationJ - 2 >= 0)
                    if (Positions[PieceLocationI + 1, PieceLocationJ - 2] <= 0)
                    {
                        A[PieceLocationI + 1, PieceLocationJ - 2] = 1;
                    }
            }
        }
        public void GetAvailableMovesWhiteKnight(Piece x)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    A[i, j] = 0;
            if (x.PieceColor == -1)
            {
                if (PieceLocationI + 2 < 8 && PieceLocationI + 2 >= 0 && PieceLocationJ + 1 < 8 && PieceLocationJ + 1 >= 0)
                    if (Positions[PieceLocationI + 2, PieceLocationJ + 1] >= 0)
                    {
                        A[PieceLocationI + 2, PieceLocationJ + 1] = 1;
                    }
                if (PieceLocationI - 2 < 8 && PieceLocationI - 2 >= 0 && PieceLocationJ + 1 < 8 && PieceLocationJ + 1 >= 0)
                    if (Positions[PieceLocationI - 2, PieceLocationJ + 1] >= 0)
                    {
                        A[PieceLocationI - 2, PieceLocationJ + 1] = 1;
                    }
                if (PieceLocationI + 2 < 8 && PieceLocationI + 2 >= 0 && PieceLocationJ - 1 < 8 && PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI + 2, PieceLocationJ - 1] >= 0)
                    {
                        A[PieceLocationI + 2, PieceLocationJ - 1] = 1;
                    }
                if (PieceLocationI - 2 < 8 && PieceLocationI - 2 >= 0 && PieceLocationJ - 1 < 8 && PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI - 2, PieceLocationJ - 1] >= 0)
                    {
                        A[PieceLocationI - 2, PieceLocationJ - 1] = 1;
                    }
                if (PieceLocationI - 1 < 8 && PieceLocationI - 1 >= 0 && PieceLocationJ + 2 < 8 && PieceLocationJ + 2 >= 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ + 2] >= 0)
                    {
                        A[PieceLocationI - 1, PieceLocationJ + 2] = 1;
                    }
                if (PieceLocationI + 1 < 8 && PieceLocationI + 1 >= 0 && PieceLocationJ + 2 < 8 && PieceLocationJ + 2 >= 0)
                    if (Positions[PieceLocationI + 1, PieceLocationJ + 2] >= 0)
                    {
                        A[PieceLocationI + 1, PieceLocationJ + 2] = 1;
                    }
                if (PieceLocationI - 1 < 8 && PieceLocationI - 1 >= 0 && PieceLocationJ - 2 < 8 && PieceLocationJ - 2 >= 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ - 2] >= 0)
                    {
                        A[PieceLocationI - 1, PieceLocationJ - 2] = 1;
                    }
                if (PieceLocationI + 1 < 8 && PieceLocationI + 1 >= 0 && PieceLocationJ - 2 < 8 && PieceLocationJ - 2 >= 0)
                    if (Positions[PieceLocationI + 1, PieceLocationJ - 2] >= 0)
                    {
                        A[PieceLocationI + 1, PieceLocationJ - 2] = 1;
                    }
            }
        }
    }
}
