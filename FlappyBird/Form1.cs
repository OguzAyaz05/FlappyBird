using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int gravity = 4;
        int jump = -50;
        int pipeSpeed = 5;
        int score = 0;
        int pipeDistance = 650;
        int gapSize = 400;

        Random rnd = new Random();

        
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            Bird.Top += gravity;
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left-= pipeSpeed;
            Score.Text="Score :"+score;

           if (pipeTop.Left <-60)      
            {
                pipeTop.Left = pipeDistance;
                pipeBottom.Left = pipeDistance;

                int randomY = rnd.Next(-150, 0);
                pipeTop.Top = randomY;
                pipeBottom.Top = randomY + gapSize;

                if (score%5 == 0)
                {
                    pipeSpeed++;
                    pipeDistance -= 20;

                    if (gapSize>200)
                    {
                        gapSize -= 20;
                    }

                    if(pipeDistance < 200)
                    {
                        pipeDistance = 200;
                    }
                }

                score++;
            }

            if (Bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
           Bird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
           Bird.Bounds.IntersectsWith(Ground.Bounds) ||
           Bird.Top < -25)
            { 
            
                endGame();
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                Bird.Top += jump;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            Score.Text += "  |  Game Over!";
        }
    }
}
