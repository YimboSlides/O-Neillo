using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_oNeillo
{
    public partial class changeNamesForm : Form
    {
        //variables for player names
        public string name1;
        public string name2;
        //boolean to determine if cancel pressed or not
        public bool change;

        public changeNamesForm()
        {
            InitializeComponent();
        }

        //event handler for submit button
        private void btn_submit_Click(object sender, EventArgs e)
        {
            change = true;

            //checks text boxes
            if (string.IsNullOrWhiteSpace(txt_changeName1.Text))
            {
                //if this is empty, use the default name 'Player1'
                this.name1 = "Player1";
            }
            else
            {
                //otherwise, take whatever the user has entered
                this.name1 = txt_changeName1.Text;
            }

            if (string.IsNullOrWhiteSpace(txt_changeName2.Text))
            {
                //if this is empty, use the default name 'Player1'
                this.name2 = "Player2";
            }
            else
            {
                //otherwise, take whatever the user has entered
                this.name2 = txt_changeName2.Text;
            }
            //closes box
            this.Close();

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            change = false;
            //makes no changes to player names
            this.Close();
        }
    }
}
