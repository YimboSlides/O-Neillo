using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Assignment_oNeillo
{
    //class to store attributes for a save slot
    public class SaveSlot
    {
        //attributes that need to be stored for each slot.
        public string player1Name { get; set; }
        public string player2Name { get; set; }

        //who is next to play
        public int currentPlayer { get; set; }
        public int nextPlayer { get; set; }

        //2d array for the data
        public int[,] data { get; set; }

        //name of slot
        public string name { get; set; }

        //empty or not
        public bool empty { get; set; }

        //store settings
        public bool ttsActive { get; set; }

        public bool panelActive { get; set; }
    }
}
