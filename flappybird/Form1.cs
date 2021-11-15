using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappybird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 8;
        int score = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappybird.Top += gravity;
            pipebottom.Left -= pipeSpeed;
            pipetop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if(pipebottom.Left < -150)
            {
                pipebottom.Left = 800;
                score++;

            }

            if (pipetop.Left < -180)
            {
                pipetop.Left = 950; 
                score++;
            }
            if(flappybird.Bounds.IntersectsWith(pipebottom.Bounds) ||
              flappybird.Bounds.IntersectsWith(pipetop.Bounds) ||
              flappybird.Bounds.IntersectsWith(ground.Bounds) ||
                flappybird.Top < -25)
            {
                endGame();
            }
           
            if (score > 5 )
            {
                pipeSpeed = 15;
            }

            if (score > 20)
            {
                pipeSpeed = 20;
            }

            if (score > 50)
            {
                pipeSpeed = 30;
            } 

          

        }


        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -8;
               
            }
        }
        private void gamekeyisup(object sender, KeyEventArgs e)
        {
          
            if (e.KeyCode == Keys.Space)
            {
                gravity = 8;
            }
        }

      private void endGame()
        {

            gameTimer.Stop();
            scoreText.Text += "  Game over !!! ";
        }

        private void scoreText_Click(object sender, EventArgs e)
        {

        }
    }
}
