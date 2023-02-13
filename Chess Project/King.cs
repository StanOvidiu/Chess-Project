using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace sah_v2
{
    class King : Piece
    {
        public static int bkct = 0;
        public static int wkct = 0;
        public King(int i, int j, int color) : base(i, j, color)
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
                    GetAvailableMovesBlackKing();
                if (button.PieceColor == -1)
                    GetAvailableMovesWhiteKing();
                firstB = button;
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
                Turns(LTurn);
            }
        }
        public void GetAvailableMovesBlackKing()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    A[i, j] = 0;
            if (PieceColor == 1)
            {
                if (PieceLocationI == 4 && PieceLocationJ == 0)
                    if (Positions[5, 0] == 0 && Positions[6, 0] == 0 && Positions[7, 0] == 4)
                        A[7, 0] = 1;
                if (PieceLocationI == 4 && PieceLocationJ == 0)
                    if (Positions[3, 0] == 0 && Positions[2, 0] == 0 && Positions[1, 0] == 0 && Positions[0, 0] == 4)
                        A[0, 0] = 1;

                if (PieceLocationJ + 1 < 8)
                    if (Positions[PieceLocationI, PieceLocationJ + 1] <= 0)
                        A[PieceLocationI, PieceLocationJ + 1] = 1;
                if (PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI, PieceLocationJ - 1] <= 0)
                        A[PieceLocationI, PieceLocationJ - 1] = 1;
                if (PieceLocationI + 1 < 8)
                    if (Positions[PieceLocationI + 1, PieceLocationJ] <= 0)
                        A[PieceLocationI + 1, PieceLocationJ] = 1;
                if (PieceLocationI - 1 >= 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ] <= 0)
                        A[PieceLocationI - 1, PieceLocationJ] = 1;
                if (PieceLocationI + 1 < 8 && PieceLocationJ + 1 < 8)
                    if (Positions[PieceLocationI + 1, PieceLocationJ + 1] <= 0)
                        A[PieceLocationI + 1, PieceLocationJ + 1] = 1;
                if (PieceLocationI - 1 >= 0 && PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ - 1] <= 0)
                        A[PieceLocationI - 1, PieceLocationJ - 1] = 1;
                if (PieceLocationI + 1 < 8 && PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI + 1, PieceLocationJ - 1] <= 0)
                        A[PieceLocationI + 1, PieceLocationJ - 1] = 1;
                if (PieceLocationI - 1 >= 0 && PieceLocationJ + 1 < 8)
                    if (Positions[PieceLocationI - 1, PieceLocationJ + 1] <= 0)
                        A[PieceLocationI - 1, PieceLocationJ + 1] = 1;
            }
        }
        public void GetAvailableMovesWhiteKing()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    A[i, j] = 0;
            if (PieceColor == -1)
            {
                if (PieceLocationI == 4 && PieceLocationJ == 7)
                    if (Positions[5, 7] == 0 && Positions[6, 7] == 0 && Positions[7, 7] == -4)
                        A[7, 7] = 1;
                if (PieceLocationI == 4 && PieceLocationJ == 7)
                    if (Positions[3, 7] == 0 && Positions[2, 7] == 0 && Positions[1, 7] == 0 && Positions[0,7] == -4)
                        A[0, 7] = 1;

                if (PieceLocationJ + 1 < 8)
                    if (Positions[PieceLocationI, PieceLocationJ + 1] >= 0)
                        A[PieceLocationI, PieceLocationJ + 1] = 1;
                if (PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI, PieceLocationJ - 1] >= 0)
                        A[PieceLocationI, PieceLocationJ - 1] = 1;
                if (PieceLocationI + 1 < 8)
                    if (Positions[PieceLocationI + 1, PieceLocationJ] >= 0)
                        A[PieceLocationI + 1, PieceLocationJ] = 1;
                if (PieceLocationI - 1 >= 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ] >= 0)
                        A[PieceLocationI - 1, PieceLocationJ] = 1;
                if (PieceLocationI + 1 < 8 && PieceLocationJ + 1 < 8)
                    if (Positions[PieceLocationI + 1, PieceLocationJ + 1] >= 0)
                        A[PieceLocationI + 1, PieceLocationJ + 1] = 1;
                if (PieceLocationI - 1 >= 0 && PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI - 1, PieceLocationJ - 1] >= 0)
                        A[PieceLocationI - 1, PieceLocationJ - 1] = 1;
                if (PieceLocationI + 1 < 8 && PieceLocationJ - 1 >= 0)
                    if (Positions[PieceLocationI + 1, PieceLocationJ - 1] >= 0)
                        A[PieceLocationI + 1, PieceLocationJ - 1] = 1;
                if (PieceLocationI - 1 >= 0 && PieceLocationJ + 1 < 8)
                    if (Positions[PieceLocationI - 1, PieceLocationJ + 1] >= 0)
                        A[PieceLocationI - 1, PieceLocationJ + 1] = 1;
            }
        }
    }
}
