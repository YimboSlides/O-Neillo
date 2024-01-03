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
    public partial class selectSlotForm : Form
    {
        //this is used when saving from pressing new game or exit

        //slot number and list of save names
        public int slot;
        List<string> saveNames = new List<string>();


        public selectSlotForm(string name1, string name2, string name3, string name4, string name5)
        {
            //takes the save names and adds to list
            saveNames.Add(name1);
            saveNames.Add(name2);
            saveNames.Add(name3);
            saveNames.Add(name4);
            saveNames.Add(name5);


            InitializeComponent();
            //greys out submit button until save selected
            if (cmbo_saveDrop.Text == "Select Save")
            {
                btn_submit.Enabled = false;
            }

            //adds the saves to a drop down list
            foreach (string name in saveNames)
            {
                cmbo_saveDrop.Items.Add(name);
            }
        }

       
        private void btn_submit_Click(object sender, EventArgs e)
        {
            //returns the value for the chosen slot
            switch (cmbo_saveDrop.SelectedIndex)
            {
                case 0:
                    this.slot = 0;
                    break;
                case 1:
                    this.slot = 1;
                    break;
                case 2:
                    this.slot = 2;
                    break;
                case 3:
                    this.slot = 3;
                    break;
                case 4:
                    this.slot = 4;
                    break;
            }
            this.Close();
        }

        private void cmbo_saveDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
            //enables button when save chosen
            if (cmbo_saveDrop.Text != "Select Save")
            {
                btn_submit.Enabled = true;
            }

        }
    }
}
