using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Assignment_oNeillo
{
    //class to create a new save slot
    internal class SaveSlot
    {
        //attributes that need to be stored for each slot.
        public string player1Name { get; set; }
        public string player2Name { get; set; }

        //who is next to play
        public int currentPlayer { get; set; }
        public int nextPlayer { get; set; }

        //2d array for the data
        public int[,] data { get; set; }

        //method to save the data 
        public void SaveState()
        {
            //access file
            string filePath = "saves.json";

            //convert object to serialised version
            string serialisedState = JsonConvert.SerializeObject(this);

            //write to the file
            //this currently overwrites the data
            File.WriteAllText(filePath, serialisedState);
        }
    }
}
