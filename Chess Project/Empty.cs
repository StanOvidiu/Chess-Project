using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sah_v2
{
    class Empty:Piece
    {
        public Empty(int i, int j, int color) : base(i, j, color)
        {

        }
        
        public override void Move2(object sender, EventArgs args)
        {
            var button = sender as Piece;
            if (first_click)
            {
                return;
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
    }
}
