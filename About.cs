﻿using System;
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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            string desc = "This application was developed by Alex Wallings, as part of the Year 1" +
                " programming assignment to recreate the game of 'Othello'. This game makes the use of many " +
                "features of programming learnt as part of this Module. It utilises the GameBoardImageArray class.";

            txt_AboutDesc.Text = desc;
        }
    }
}
