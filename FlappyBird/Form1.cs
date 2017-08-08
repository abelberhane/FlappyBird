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
        //Global Variables
        bool jumping = false;
        int pipeSpeed = 3;
        int gravity = 3;
        int Inscore = 0;


        public Form1()
        {
            InitializeComponent();
            //Text displayed at the end of the game. AKA when you die.
            endText1.Text = "Game Over!";
            endText2.Text = "Your final score is: " + Inscore;
            gameDesigner.Text = "Game Designed By Abel Berhane :)";

            //End text is disabled traditionally. 
            endText1.Visible = false;
            endText2.Visible = false;
            gameDesigner.Visible = false;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Logic for pipespeed, the player's gravity and the score. They are attached to the timer to make it scroll.
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            flappyBird.Top += gravity;
            scoreText.Text = " " + Inscore;

            
            //Logic for ending the game. If the player intersects with any of the pipes.... end the game.
            if (flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }
            else if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                endGame();
            }
            else if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds))
            {
                endGame();
            }

            //Logic for incrementing score. As I pass each pipe, add 1.
            if (pipeBottom.Left< -80)
            {
                pipeBottom.Left = 1000;
                Inscore += 1;
            }
            else if (pipeTop.Left < -95)
            {
                pipeTop.Left = 1100;
                Inscore += 1;
            }
        }

        //If the player presses the space bar, allow them to jump and remove 5 pixels of gravity.
        private void inGameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = true;
                gravity = -5;
            }
        }

        //If the player lets up the space bar, the jump is over and gravity is brought back.
        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = false;
                gravity = 5;
            }
        }

        //When the game ends, set the text to true and show all the labels. 
        private void endGame()
        {
            gameTimer.Stop();
            endText1.Visible = true;
            endText2.Visible = true;
            gameDesigner.Visible = true;
        }
    }
}
