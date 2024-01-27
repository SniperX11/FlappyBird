using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;

        int gravity = 5;

        int score = 0;

        bool gameOver = false;


        public Form1()
        {
            InitializeComponent();
            ground.Controls.Add(scoreText);
            scoreText.Left = 50;
            scoreText.Top = 35;
            RestartGame();
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -20;
            }
        }


        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
            if (e.KeyCode == Keys.R && gameOver)
            {
                RestartGame();
            }
        }


        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over! Pres R to try again";
            gameOver = true;
            restartImage.Enabled = true;
            restartImage.Visible = true;
        }




        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score:" + score;


            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
               flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
               flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }

            if (score >5)
            {
                pipeSpeed = 15;
            }

            if (flappyBird.Top < -25)
            {
                endGame();
            }

        }
      

        private void RestartGame()
        {
            gameOver= false;
            flappyBird.Location = new Point(80, 190);
            pipeTop.Left = 800;
            pipeBottom.Left = 1200;

            score = 0;
            pipeSpeed= 8;
            scoreText.Text = "Score: 0";
            restartImage.Enabled = false;
            restartImage.Visible= false; 
            gameTimer.Start();
        }

        private void RestartClickEVEnt(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
