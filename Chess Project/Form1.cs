using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sah_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var clr1 = Color.AntiqueWhite;
            var clr2 = Color.Peru;
            const int buttonSize = 80;

            this.Width = 970;
            this.Height = 679;
            this.Text = "chess";
            this.BackColor = Color.PeachPuff;

            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    Piece.pieces[i, j] = new Piece(i, j, 2)
                    {
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(buttonSize * i, buttonSize * j),
                        FlatStyle = FlatStyle.Flat
                    };

                    if ((i + j) % 2 == 0)
                    {
                        Piece.pieces[i, j].BackColor = clr1;
                    }
                    else
                    {
                        Piece.pieces[i, j].BackColor = clr2;
                    }

                    if (j == 0 || j == 1)
                    {
                        Piece.pieces[i, j].PieceColor = 1;
                    }
                    else if (j == 6 || j == 7)
                    {
                        Piece.pieces[i, j].PieceColor = -1;
                    }
                    else
                        Piece.pieces[i, j].PieceColor = 0;

                    this.Controls.Add(Piece.pieces[i, j]);
                }
            }

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Piece.pieces[i, j].Click += Piece.pieces[i, j].Move;
                }

            Piece.LTurn = new Label()
            {
                Text = "White moves!",
                Location = new Point(660, 200),
                AutoSize = true,
                Font = new Font("Calibri", 20),
                ForeColor = Color.Black,
                BackColor = Color.Peru,
                //BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(Piece.LTurn);

            Piece.LChecked = new Label()
            {
                Location = new Point(660, 240),
                AutoSize = true,
                Font = new Font("Calibri", 20),
                ForeColor = Color.Black,
                BackColor = Color.Peru,
                //BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(Piece.LChecked);

            SetImage(Piece.pieces);
        }
        public void SetImage(Button[,] A)
        {
            
            A[0, 0].Image = Image.FromFile("images/Chess_rdt60.png");
            A[1, 0].Image = Image.FromFile("images/Chess_ndt60.png");
            A[2, 0].Image = Image.FromFile("images/Chess_bdt60.png");
            A[3, 0].Image = Image.FromFile("images/Chess_qdt60.png");
            A[4, 0].Image = Image.FromFile("images/Chess_kdt60.png");
            A[5, 0].Image = Image.FromFile("images/Chess_bdt60.png");
            A[6, 0].Image = Image.FromFile("images/Chess_ndt60.png");
            A[7, 0].Image = Image.FromFile("images/Chess_rdt60.png");
            A[0, 1].Image = Image.FromFile("images/Chess_pdt60.png");
            A[1, 1].Image = Image.FromFile("images/Chess_pdt60.png");
            A[2, 1].Image = Image.FromFile("images/Chess_pdt60.png");
            A[3, 1].Image = Image.FromFile("images/Chess_pdt60.png");
            A[4, 1].Image = Image.FromFile("images/Chess_pdt60.png");
            A[5, 1].Image = Image.FromFile("images/Chess_pdt60.png");
            A[6, 1].Image = Image.FromFile("images/Chess_pdt60.png");
            A[7, 1].Image = Image.FromFile("images/Chess_pdt60.png");
            A[0, 7].Image = Image.FromFile("images/Chess_rlt60.png");
            A[1, 7].Image = Image.FromFile("images/Chess_nlt60.png");
            A[2, 7].Image = Image.FromFile("images/Chess_blt60.png");
            A[3, 7].Image = Image.FromFile("images/Chess_qlt60.png");
            A[4, 7].Image = Image.FromFile("images/Chess_klt60.png");
            A[5, 7].Image = Image.FromFile("images/Chess_blt60.png");
            A[6, 7].Image = Image.FromFile("images/Chess_nlt60.png");
            A[7, 7].Image = Image.FromFile("images/Chess_rlt60.png");
            A[0, 6].Image = Image.FromFile("images/Chess_plt60.png");
            A[1, 6].Image = Image.FromFile("images/Chess_plt60.png");
            A[2, 6].Image = Image.FromFile("images/Chess_plt60.png");
            A[3, 6].Image = Image.FromFile("images/Chess_plt60.png");
            A[4, 6].Image = Image.FromFile("images/Chess_plt60.png");
            A[5, 6].Image = Image.FromFile("images/Chess_plt60.png");
            A[6, 6].Image = Image.FromFile("images/Chess_plt60.png");
            A[7, 6].Image = Image.FromFile("images/Chess_plt60.png");
        }
        
    }
}
