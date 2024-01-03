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
    public partial class confirmSaveForm : Form
    {
        //bool for if user wants to save game-in-progress
        public bool saveGame;

        //constructor
        //accepts message, name for button1, name for button2
        public confirmSaveForm(string message, string btn1Text, string btn2Text)
        {
            //create box
            InitializeComponent();
            this.txt_saveMsg.Text = message;
            this.btn_yes.Text = btn1Text;
            this.btn_no.Text = btn2Text;

        }

        //if 'No' is clicked
        public void btn_no_Click(object sender, EventArgs e)
        {
            //will not save game
            saveGame = false;
            this.Close();

        }

        //if 'yes' is clicked
        private void btn_yes_Click(object sender, EventArgs e)
        {
            //will save game
            saveGame = true;
            this.Close();
        }

        
    }
}
