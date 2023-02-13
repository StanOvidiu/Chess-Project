using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace sah_v2
{
    class Bishop : Piece
    {
        public Bishop(int i, int j, int color) : base(i, j, color)
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

                base.Move2(sender, args);
                if (button.PieceColor == 1)
                    GetAvailableMovesBlackBishop();
                if (button.PieceColor == -1)
                    GetAvailableMovesWhiteBishop();
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
                IsChecked(button, args, LChecked);
                Turns(LTurn);
            }
        }
        public void GetAvailableMovesBlackBishop()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    A[i, j] = 0;
            int x = PieceLocationI;
            int y = PieceLocationJ;
            if (PieceColor == 1)
            {
                while (x < 8 && y < 8)
                {
                    if (Positions[x, y] <= 0)
                        A[x, y] = 1;
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
                    if (Positions[x, y] <= 0)
                        A[x, y] = 1;
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
                    if (Positions[x, y] <= 0)
                        A[x, y] = 1;
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
                    if (Positions[x, y] <= 0)
                        A[x, y] = 1;
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 3)
                        break;
                    --x;
                    ++y;
                }
            }
        }
        public void GetAvailableMovesWhiteBishop()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    A[i, j] = 0;
            int x = PieceLocationI;
            int y = PieceLocationJ;
            if (PieceColor == -1)
            {
                while (x < 8 && y < 8)
                {
                    if (Positions[x, y] >= 0)
                        A[x, y] = 1;
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
                    if (Positions[x, y] >= 0)
                        A[x, y] = 1;
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
                    if (Positions[x, y] >= 0)
                        A[x, y] = 1;
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
                    if (Positions[x, y] >= 0)
                        A[x, y] = 1;
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -3)
                        break;
                    --x;
                    ++y;
                }
            }
        }
    }
}
