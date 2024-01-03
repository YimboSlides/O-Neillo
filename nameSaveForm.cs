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
    public partial class nameSaveForm : Form
    {
        //string to store name for save
        public string saveName;
        public nameSaveForm()
        {
            InitializeComponent();
        }

        //on submit
        private void btn_submit_Click(object sender, EventArgs e)
        {
            //is field empty
            if (string.IsNullOrWhiteSpace(txt_nameField.Text))
            {
                DateTime currentTime = DateTime.Now;
                //if this is empty, use the current date and time
                this.saveName = currentTime.ToString();
            }
            else
            {
                //otherwise, take whatever the user has entered
                this.saveName = txt_nameField.Text;
            }

            this.Close();
        }
    }
}
