using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace sah_v2
{
    class Rook : Piece
    {
        public static int ct1 = 0;
        public static int ct2 = 0;
        public static int ct3 = 0;
        public static int ct4 = 0;

        public Rook(int i, int j, int color) : base(i, j, color)
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
                    GetAvailableMovesBlackRook();
                if (button.PieceColor == -1)
                    GetAvailableMovesWhiteRook();
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
                    if (firstB.PieceLocationI == 0 && firstB.PieceLocationJ == 0)
                        Rook.ct1++;
                    if (firstB.PieceLocationI == 7 && firstB.PieceLocationJ == 0)
                        Rook.ct2++;
                    if (firstB.PieceLocationI == 0 && firstB.PieceLocationJ == 7)
                        Rook.ct3++;
                    if (firstB.PieceLocationI == 7 && firstB.PieceLocationJ == 7)
                        Rook.ct4++;
                    if (Positions[firstB.PieceLocationI, firstB.PieceLocationJ] == 6 || Positions[firstB.PieceLocationI,firstB.PieceLocationJ] == -6)
                    {
                        if (Positions[button.PieceLocationI, button.PieceLocationJ] == 4 || Positions[button.PieceLocationI, button.PieceLocationJ] == -4)
                            Castle(button, args);
                    }
                    else
                    {
                        button.Image = firstB.Image;
                        button.PieceColor = firstB.PieceColor;
                        Positions[button.PieceLocationI, button.PieceLocationJ] = value;
                        Positions[firstB.PieceLocationI, firstB.PieceLocationJ] = 0;
                        firstB.Image = null;
                        firstB.PieceColor = 0;
                        value = 0;
                        LChecked.Text = null;
                    }
                    if (firstB.PieceLocationI == 4 && firstB.PieceLocationJ == 0)
                        King.bkct++;
                    if (firstB.PieceLocationI == 4 && firstB.PieceLocationJ == 7)
                        King.wkct++;
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
        private void Castle(object sender, EventArgs args)
        {
            var button = sender as Piece;
            if (button.PieceLocationI==0 && button.PieceLocationJ==0)
            {
                if (ct1 == 0 && King.bkct == 0)
                {
                    pieces[2, 0].Image = firstB.Image;
                    pieces[2, 0].PieceColor = firstB.PieceColor;
                    Positions[2, 0] = value;
                    firstB.Image = null;
                    firstB.PieceColor = 0;
                    value = 0;

                    pieces[3, 0].Image = button.Image;
                    pieces[3, 0].PieceColor = button.PieceColor;
                    Positions[3, 0] = 4;
                    button.Image = null;
                    button.PieceColor = 0;
                    Positions[0, 0] = 0;
                }
            }
            if (button.PieceLocationI == 7 && button.PieceLocationJ == 0)
            {
                if (ct2 == 0 && King.bkct == 0)
                {
                    pieces[6, 0].Image = firstB.Image;
                    pieces[6, 0].PieceColor = firstB.PieceColor;
                    Positions[6, 0] = value;
                    firstB.Image = null;
                    firstB.PieceColor = 0;
                    value = 0;

                    pieces[5, 0].Image = button.Image;
                    pieces[5, 0].PieceColor = button.PieceColor;
                    Positions[5, 0] = 4;
                    button.Image = null;
                    button.PieceColor = 0;
                    Positions[7, 0] = 0;
                }
            }
            if (button.PieceLocationI == 0 && button.PieceLocationJ == 7)
            {
                if (ct3 == 0 && King.wkct == 0)
                {
                    pieces[2, 7].Image = firstB.Image;
                    pieces[2, 7].PieceColor = firstB.PieceColor;
                    Positions[2, 7] = value;
                    firstB.Image = null;
                    firstB.PieceColor = 0;
                    value = 0;

                    pieces[3, 7].Image = button.Image;
                    pieces[3, 7].PieceColor = button.PieceColor;
                    Positions[3, 7] = -4;
                    button.Image = null;
                    button.PieceColor = 0;
                    Positions[0, 7] = 0;
                }
            }
            if (button.PieceLocationI == 7 && button.PieceLocationJ == 7)
            {
                if (ct4 == 0 && King.wkct == 0)
                {
                    pieces[6, 7].Image = firstB.Image;
                    pieces[6, 7].PieceColor = firstB.PieceColor;
                    Positions[6, 7] = value;
                    firstB.Image = null;
                    firstB.PieceColor = 0;
                    value = 0;

                    pieces[5, 7].Image = button.Image;
                    pieces[5, 7].PieceColor = button.PieceColor;
                    Positions[5, 7] = -4;
                    button.Image = null;
                    button.PieceColor = 0;
                    Positions[7, 7] = 0;
                }
            }
        }
        public void GetAvailableMovesBlackRook()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    A[i, j] = 0;
            int x = PieceLocationI;
            int y = PieceLocationJ;
            if (PieceColor == 1)
            {
                while (x < 8)
                {
                    if (Positions[x, y] <= 0)
                        A[x, y] = 1;
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
                    if (Positions[x, y] <= 0)
                        A[x, y] = 1;
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
                    if (Positions[x, y] <= 0)
                        A[x, y] = 1;
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
                    if (Positions[x, y] <= 0)
                        A[x, y] = 1;
                    if (Positions[x, y] < 0)
                        break;
                    if (Positions[x, y] > 0 && Positions[x, y] != 4)
                        break;
                    ++y;
                }
            }
        }
        public void GetAvailableMovesWhiteRook()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    A[i, j] = 0;
            int x = PieceLocationI;
            int y = PieceLocationJ;
            if (PieceColor == -1)
            {
                while (x < 8)
                {
                    if (Positions[x, y] >= 0)
                        A[x, y] = 1;
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
                    if (Positions[x, y] >= 0)
                        A[x, y] = 1;
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
                    if (Positions[x, y] >= 0)
                        A[x, y] = 1;
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
                    if (Positions[x, y] >= 0)
                        A[x, y] = 1;
                    if (Positions[x, y] > 0)
                        break;
                    if (Positions[x, y] < 0 && Positions[x, y] != -4)
                        break;
                    ++y;
                }
            }
        }
    }
}
