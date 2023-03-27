/* Tic Tac Toe.cs
 * Assignment 1
 * 
 *  Revision History:
 *         Yichen Liu, 2020.09.20:Created
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YichenYLLiuAssignment1

{
    public partial class Form1 : Form
    {

        // variables to keep track of current game state
        bool isX = true;
        int turn = 0;
        char[] positionValues = new char[10] { 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n', 'n'};

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handle the event when click on a PictureBox
        /// </summary>
        /// <param name="position">the clicked PictureBox</param>
        /// <param name="index">the related index of clicked PictureBox (eg. 1 for pos1, 9 for pos9)</param>
        private void click (PictureBox position, int index)
        {
            // when the clicked PictureBox is null, change the image to X or O depend on current turn.
            // then update positionValues to keep track of current game board.
            if (position.Image == null)
            {
                if (isX)
                {
                    position.Image = TicTacToe.Properties.Resources.X;
                    isX = false;
                    turn += 1;
                    positionValues[index] = 'x';
                }
                else if (!isX)
                {
                    position.Image = TicTacToe.Properties.Resources.O;
                    isX = true;
                    turn += 1;
                    positionValues[index] = 'o';
                }
            }
        }


        /// <summary>
        /// reset the game board to initial state
        /// </summary>
        private void reset ()
        {
            pos1.Image = null;
            pos2.Image = null;
            pos3.Image = null;
            pos4.Image = null;
            pos5.Image = null;
            pos6.Image = null;
            pos7.Image = null;
            pos8.Image = null;
            pos9.Image = null;
            turn = 0;
            isX = true;
            for (int i =0;i<positionValues.Length; i++)
            {
                positionValues[i] = 'n';
            }    
        }


        /// <summary>
        /// check if there is a winner, return related character
        /// </summary>
        /// <returns>'n' for no winner, 'd' for draw, 'x' for X is winner, 'o' for O is winner</returns>
        private char checkWin()
        {
            if (positionValues[1]==positionValues[2] && positionValues[2]==positionValues[3]&& positionValues[1]!='n')
            {
                return positionValues[1];
            }
            else if (positionValues[1] == positionValues[5] && positionValues[5] == positionValues[9] && positionValues[1] != 'n')
            {
                return positionValues[1];
            }
            else if (positionValues[1] == positionValues[4] && positionValues[4] == positionValues[7] && positionValues[1] != 'n')
            {
                return positionValues[1];
            }
            else if (positionValues[4] == positionValues[5] && positionValues[4] == positionValues[6] && positionValues[4] != 'n')
            {
                return positionValues[4];
            }
            else if (positionValues[7] == positionValues[8] && positionValues[8] == positionValues[9] && positionValues[7] != 'n')
            {
                return positionValues[8];
            }
            else if (positionValues[2] == positionValues[8] && positionValues[5] == positionValues[8] && positionValues[2] != 'n')
            {
                return positionValues[2];
            }
            else if (positionValues[3] == positionValues[6] && positionValues[6] == positionValues[9] && positionValues[3] != 'n')
            {
                return positionValues[3];
            }
            else if (positionValues[3] == positionValues[5] && positionValues[5] == positionValues[7] && positionValues[3] != 'n')
            {
                return positionValues[3];
            }


            if (turn == 9)
            {
                return 'd';
            }    
            return 'n';
        }

        /// <summary>
        /// pop up winning message box and reset the board when game ends
        /// </summary>
        /// <param name="winner">character that represent who the winner is</param>
        private void showWinner (char winner)
        {
            if (winner == 'x')
            {
                MessageBox.Show("X player won the game!");
                reset();
            }
            else if (winner == 'o')
            {
                MessageBox.Show("O player won the game!");
                reset();
            }
            else if (winner == 'd')
            {
                MessageBox.Show("Game draw!");
                reset();
            }
        }




        private void pos1_Click(object sender, EventArgs e)
        {
            click(pos1,1);
            showWinner(checkWin());
        }

        private void pos2_Click(object sender, EventArgs e)
        {
            click(pos2,2);

            showWinner(checkWin());
        }

        private void pos3_Click(object sender, EventArgs e)
        {
            click(pos3,3);

            showWinner(checkWin());
        }

        private void pos4_Click(object sender, EventArgs e)
        {
            click(pos4,4);

            showWinner(checkWin());
        }

        private void pos5_Click(object sender, EventArgs e)
        {
            click(pos5,5);

            showWinner(checkWin());
        }

        private void pos6_Click(object sender, EventArgs e)
        {
            click(pos6,6);

            showWinner(checkWin());
        }

        private void pos7_Click(object sender, EventArgs e)
        {
            click(pos7,7);

            showWinner(checkWin());
        }

        private void pos8_Click(object sender, EventArgs e)
        {
            click(pos8,8);

            showWinner(checkWin());
        }

        private void pos9_Click(object sender, EventArgs e)
        {
            click(pos9,9);

            showWinner(checkWin());
        }

        // manual reset button
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
