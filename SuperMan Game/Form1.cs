﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Game
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void gameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void gameKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }

            if(e.KeyCode == Keys.S)
            {
                gameTimer.Start();
                score = 0;
                ScoreText.Text = "Score :" + score;
                pipeBottom.Left = 600;
                pipeTop.Left = 720;
                flappyBird.Top = 200;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            ScoreText.Text = "Score :" + score;
            bannerText.Text = "SuperMan : Code from Home";
            LossText.Text = "HOLD SPACE TO FLY!";

            if (pipeBottom.Left < -50)
            {
                score++;
                Random rndm = new Random();
                int randomVal = rndm.Next(580, 720);
                pipeBottom.Left = randomVal;
            }
            if(pipeTop.Left <-50)
            {
                score++;
                Random rndm = new Random();
                int randomVal = rndm.Next(580, 720);
                pipeTop.Left = randomVal;
            }

            if(flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||  
                flappyBird.Bounds.IntersectsWith(basePic.Bounds) ||
                (flappyBird.Top < -25) 
                )
            {
                endGame();
            }

        }
        // Handling the event of ending the game //
        private void endGame()
        {
            gameTimer.Stop();
            bannerText.Text = "You scored " + score + " Points Pal";
            LossText.Text = "PRESS 'S' TO RESTART";

        }
    }
}
