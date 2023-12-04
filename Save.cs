using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using GameBoardTest;

namespace Assignment_oNeillo
{
    //class for the save notice form
    public partial class Save : Form
    {   
        //bool for if user wants to save game-in-progress
        public bool saveGame;

        //constructor
        //accepts message, name for button1, name for button2
        public Save(string message, string btn1Text, string btn2Text)
        {
            //create box
            InitializeComponent();
            this.txt_Save.Text = message;
            this.btn_saveGame.Text = btn1Text;
            this.btn_newGame.Text = btn2Text;

        }
        
        //if 'No' is clicked
        public void btn_newGame_Click(object sender, EventArgs e)
        {
            saveGame = false;
            this.Close();

        }

        //if 'yes' is clicked
        private void btn_SaveGame_Click(object sender, EventArgs e)
        {
            saveGame = true;
            this.Close();
        }
    }
}
