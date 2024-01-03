using Assignment_oNeillo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBoardTest
{
    public partial class Start_Screen : Form
    {
        //player names
        string name1;
        string name2;
        
        public Start_Screen()
        {
            InitializeComponent();

        }
        //Event when 'Start Game' is pressed
        private void btn_start_Click(object sender, EventArgs e)
        {
            
            //checks the input field for player names
            if (string.IsNullOrWhiteSpace(txt_p1Name.Text))
            {
                //if this is empty, use the default name 'Player1'
                name1 = "Player1";
            }
            else
            {
                //otherwise, take whatever the user has entered
                name1 = txt_p1Name.Text;
            }

            //above code but for player2
            if (string.IsNullOrWhiteSpace(txt_p2Name.Text))
            {
                name2 = "Player2";
            }
            else
            {
                name2 = txt_p2Name.Text;
            }
            //opens a new O'Neillo game, passing through the player names


            

            boardForm oNeillo = new boardForm(name1, name2);

            //adjusts form settings so that size cannot be changed
            oNeillo.FormBorderStyle = FormBorderStyle.FixedDialog;
            oNeillo.MaximizeBox = false;
            oNeillo.MinimizeBox = false;
            oNeillo.Show();


        }

        //when the user presses the 'Quit' button
        private void btn_quit_Click(object sender, EventArgs e)
        {
            //closes the form
            this.Close();
        }

    }
}
