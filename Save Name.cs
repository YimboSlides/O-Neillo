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
    public partial class Save_Name : Form
    {
        public string saveName;
        public Save_Name()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_saveName.Text))
            {
                DateTime currentTime = DateTime.Now;
                //if this is empty, use the current date and time
                this.saveName = currentTime.ToString();
            }
            else
            {
                //otherwise, take whatever the user has entered
                this.saveName = txt_saveName.Text;
            }

            this.Close();
        }
    }
}
