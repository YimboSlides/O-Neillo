using GameboardGUI;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Speech.Synthesis;
using Assignment_oNeillo;
using Newtonsoft;
using System.Text.Json;
using Newtonsoft.Json;


namespace GameBoardTest
{
    public partial class Board : Form
    {
        //Initialising the dimensions of the board
        const int rowNum = 8;
        const int colNum = 8;

        //List of SaveSlots
        SaveList Slots = new SaveList();

        //other variables for game over and TTS
        bool gameOver = false;
        bool speaking = false;
        bool gameBegun = false;

        //text for messages to user
        string invalidMsg = "That move is invalid";
        string noMovesMsg = "currently has no valid moves left";
        string gameOverMsg = "Game Over. Winner is";

        //creating an object of the class GameBoardImageArray
        GameboardImageArray _gameBoardGui;

        //2D array to store the gameData
        int[,] gameBoardData;
        int[,] startingBoard;

        //finds the file path for the images
        string tileImagesDirPath = Directory.GetCurrentDirectory() + @"\images\";

        //makes object for each player
        Player player1 = new Player(0, true, "Player1");
        Player player2 = new Player(1, false, "Player2");

        //passses through 4 variables
        //name for players
        //data for board
        //whether the data has been saved or not
        public Board(string name1, string name2)
        {

            InitializeComponent();

            //assigns player names
            player1.name = name1;
            player2.name = name2;

           
            
            //establishes board size
            Point top = new Point(75, 75);
            Point bottom = new Point(75, 225);

            //generates the data for the gameboard

            gameBoardData = this.GenerateBoard();

            try
            {
                //this instantiates a gui version of the board

                //places all of the data into the constructor (position, images, data etc)
                _gameBoardGui = new GameboardImageArray(this, gameBoardData, top, bottom, 0, tileImagesDirPath);
                _gameBoardGui.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);
                _gameBoardGui.UpdateBoardGui(gameBoardData);
            }
            catch (Exception ex)
            {
                //if board cannot be made for any reason, throw exception
                DialogResult result = MessageBox.Show(ex.ToString(), "Game board size problem", MessageBoxButtons.OK);
                this.Close();
            }

            //set player names
            lbl_name1.Text = player1.name;
            lbl_name2.Text = player2.name;

            //sets turn order arrows
            pbox_arrow1.Visible = true;
            pbox_arrow2.Visible = false;

            //display starting score
            lbl_ScoreOne.Text = player1.CalcScore(gameBoardData, rowNum, colNum).ToString();
            lbl_ScoreTwo.Text = player2.CalcScore(gameBoardData, rowNum, colNum).ToString();

            //Initialise basic data to fill saves with
            SaveSlot Save = new SaveSlot();
            Save.data = startingBoard;
            Save.player1Name = player1.name;
            Save.player2Name = player2.name;
            Save.currentPlayer = 0;
            Save.nextPlayer = 1;
            Save.name = "Empty";
            Save.empty = true;

            string filePath = "game_data.json";

            //deserialises content in the json file
            string stateData = File.ReadAllText(filePath);

            //statement to deal with empty game_data file
            if (stateData == "")
            {
                //new temporary list 
                SaveList tempSaves = new SaveList();
                tempSaves.saves = new List<SaveSlot>();

                for (int i = 0; i < 5; i++)
                {
                    //adds 'empty' save slot
                    tempSaves.saves.Add(Save);

                }
                //converts to Json data, writes to file
                string serialisedState = JsonConvert.SerializeObject(tempSaves.saves);
                File.WriteAllText(filePath, serialisedState);

                //recollects data
                stateData = File.ReadAllText(filePath);
            }

            //sets list of saves to all data in Json file
            Slots.saves = JsonConvert.DeserializeObject<List<SaveSlot>>(stateData);

            //if the list is not full (less than 5 saves found)
            //add 'empty' saves to fill out.
            if (Slots.saves.Count() < 5)
            {
                int count;

                count = Slots.saves.Count();

                for (int i = count; i < 5; i++)
                {
                    Slots.saves.Add(Save);
                }
            }

            //cannot load a save that are 'empty'
            if (Slots.saves[0].empty == true)
            {
                load1.Enabled = false;
            }
            if (Slots.saves[1].empty == true)
            {
                load2.Enabled = false;
            }
            if (Slots.saves[2].empty == true)
            {
                load3.Enabled = false;
            }
            if (Slots.saves[3].empty == true)
            {
                load4.Enabled = false;
            }
            if (Slots.saves[4].empty == true)
            {
                load5.Enabled = false;
            }

            //Sets the save names on the GUI to whatever they have been named
            save1ToolStripMenuItem.Text = $"Save 1 - {Slots.saves[0].name}";
            save2ToolStripMenuItem.Text = $"Save 2 - {Slots.saves[1].name}";
            save3ToolStripMenuItem.Text = $"Save 3 - {Slots.saves[2].name}";
            save4ToolStripMenuItem.Text = $"Save 4 - {Slots.saves[3].name}";
            save5ToolStripMenuItem.Text = $"Save 5 - {Slots.saves[4].name}";

            load1.Text = $"Save 1 - {Slots.saves[0].name}";
            load2.Text = $"Save 2 - {Slots.saves[1].name}";
            load3.Text = $"Save 3 - {Slots.saves[2].name}";
            load4.Text = $"Save 4 - {Slots.saves[3].name}";
            load5.Text = $"Save 5 - {Slots.saves[4].name}";

        }

        //creates board
        int[,] GenerateBoard()
        {
            //2D array for the data, 64 square grid
            int[,] boardArray = new int[8, 8];
            int boardVal = 10;
            //10 refers to empty square, 1 is white and 0 is black


            //cycles through entire board
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    //places empty square at position
                    //finds the four centre squares, places starting pieces
                    if (row == 3)
                    {
                        switch (col)
                        {
                            case 3:
                                boardVal = 1;
                                break;
                            case 4:
                                boardVal = 0;
                                break;
                            default:
                                boardVal = 10;
                                break;
                        }
                    }
                    else if (row == 4)
                    {
                        switch (col)
                        {
                            case 3:
                                boardVal = 0;
                                break;
                            case 4:
                                boardVal = 1;
                                break;
                            default:
                                boardVal = 10;
                                break;
                        }
                    }

                    //add this data to grid
                    boardArray[row, col] = boardVal;
                }
            }
            //return grid data
            startingBoard = boardArray;
            return boardArray;
        }

        //handles when tile is clicked
        private void GameTileClicked(object sender, EventArgs e)
        {
            gameBegun = true;
            saveGameToolStripMenuItem.Enabled = true;
            //grabs the position user has clicked
            int selectedRow = _gameBoardGui.GetCurrentRowIndex(sender);
            int selectedCol = _gameBoardGui.GetCurrentColumnIndex(sender);


            //These if statements check if the moves being made are valid

            //checks who has current turn
            if (player1.isTurn == true)
            {
                //checks they currently has moves available
                if (player1.noMoves == false)
                {
                    //for the active player, checks if move is valid
                    //if the move isnt valid, it doesnt hand over control to other player
                    bool result = player1.ValidateMove(gameBoardData, selectedRow, selectedCol);
                    if (result)
                    {
                        //if valid, makes the move
                        //flips necessary tiles
                        gameBoardData = player1.MakeMove(gameBoardData, selectedRow, selectedCol);

                        //updates board
                        _gameBoardGui.UpdateBoardGui(gameBoardData);

                        //switches turn order
                        player2.isTurn = true;

                        pbox_arrow1.Visible = false;
                        pbox_arrow2.Visible = true;

                        //checks the status of player's turn
                        player2.CheckGameOver(gameBoardData);
                        player1.CheckGameOver(gameBoardData);

                        //for text to speech
                        if (TTSstatus())
                        {
                            SpeechSynthesizer textToSpeech = new SpeechSynthesizer();
                            textToSpeech.Speak($"{player1.name} has placed a piece at {selectedRow} {selectedCol}");
                        }
                    }
                    //if move is invalid
                    else if (result == false)
                    {

                        //notifies user
                        if (TTSstatus())
                        {
                            SpeechSynthesizer textToSpeech = new SpeechSynthesizer();
                            textToSpeech.Speak(invalidMsg);
                        }

                    }
                }

                //if opposing player no longer has any valid mvoes
                if (player2.noMoves == true)
                {
                    if (player1.noMoves != true)
                    {
                        //notifies user
                        if (TTSstatus())
                        {
                            SpeechSynthesizer textToSpeech = new SpeechSynthesizer();
                            textToSpeech.Speak(player2.name + " " + noMovesMsg);
                        }
                        else
                        {
                            MessageBox.Show(player2.name + " " + noMovesMsg);
                        }

                        //switches turn to current player
                        player2.isTurn = false;
                        player1.isTurn = true;

                        //switches turn order image
                        pbox_arrow1.Visible = true;
                        pbox_arrow2.Visible = false;
                    }

                }

                //updates player scores
                lbl_ScoreOne.Text = player1.CalcScore(gameBoardData, rowNum, colNum).ToString();
                lbl_ScoreTwo.Text = player2.CalcScore(gameBoardData, rowNum, colNum).ToString();


            }
            //above code repeated for player 2
            else if (player2.isTurn == true)
            {

                bool result = player2.ValidateMove(gameBoardData, selectedRow, selectedCol);
                if (player2.noMoves == false)
                {

                    if (result)
                    {
                        gameBoardData = player2.MakeMove(gameBoardData, selectedRow, selectedCol);
                        _gameBoardGui.UpdateBoardGui(gameBoardData);

                        player1.isTurn = true;

                        pbox_arrow1.Visible = true;
                        pbox_arrow2.Visible = false;

                        player1.CheckGameOver(gameBoardData);
                        player2.CheckGameOver(gameBoardData);

                        if (TTSstatus())
                        {
                            SpeechSynthesizer textToSpeech = new SpeechSynthesizer();
                            textToSpeech.Speak($"{player2.name} has placed a piece at {selectedRow} {selectedCol}");
                        }
                    }
                    else if (result == true)
                    {

                        if (TTSstatus())
                        {
                            SpeechSynthesizer textToSpeech = new SpeechSynthesizer();
                            textToSpeech.Speak(invalidMsg);
                        }

                    }
                }

                if (player1.noMoves == true)
                {
                    if (player2.noMoves != true)
                    {
                        if (TTSstatus())
                        {
                            SpeechSynthesizer textToSpeech = new SpeechSynthesizer();
                            textToSpeech.Speak(player1.name + " " + noMovesMsg);
                        }
                        else
                        {
                            MessageBox.Show(player1.name + " " + noMovesMsg);
                        }
                        player1.isTurn = false;
                        player2.isTurn = true;

                        pbox_arrow1.Visible = false;
                        pbox_arrow2.Visible = true;
                    }

                }
                lbl_ScoreTwo.Text = player2.CalcScore(gameBoardData, rowNum, colNum).ToString();
                lbl_ScoreOne.Text = player1.CalcScore(gameBoardData, rowNum, colNum).ToString();



            }
            //if both players have no moves remaining
            if (player1.noMoves == true && player2.noMoves == true)
            {
                //game is over
                gameOver = true;
                gameBegun = false;
                //take score
                int p1Score = int.Parse(lbl_ScoreOne.Text);
                int p2Score = int.Parse(lbl_ScoreTwo.Text);

                //player 1 win
                if (p1Score > p2Score)
                {
                    if (TTSstatus())
                    {
                        SpeechSynthesizer textToSpeech = new SpeechSynthesizer();
                        textToSpeech.Speak(gameOverMsg + " " + player1.name);
                    }
                    else
                    {
                        MessageBox.Show(gameOverMsg + " " + player1.name);

                    }

                }
                //player 2 win
                else if (p2Score > p1Score)
                {
                    if (TTSstatus())
                    {
                        SpeechSynthesizer textToSpeech = new SpeechSynthesizer();
                        textToSpeech.Speak(gameOverMsg + " " + player2.name);
                    }
                    else
                    {
                        MessageBox.Show(gameOverMsg + " " + player2.name);

                    }
                }
                //tie
                else if (p2Score == p1Score)
                {
                    if (TTSstatus())
                    {
                        SpeechSynthesizer textToSpeech = new SpeechSynthesizer();
                        textToSpeech.Speak("Game Over. This game is a tie.");
                    }
                    else
                    {
                        MessageBox.Show("Game Over. This game is a Tie");

                    }


                }

            }




        }

        //event handler for exit button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bool to check if they want to save
            bool save;

            //checks if game in progress
            if (gameBegun == true)
            {
                save = SaveChoice("You are ending a game in progress. Do you want to save?");
            }
            else
            {
                save = false;
            }

            //if user wants to save 
            if (save == true)
            {
                //gets user to choose a slot
                Select_Slot test = new Select_Slot(Slots.saves[0].name, Slots.saves[1].name, Slots.saves[2].name, Slots.saves[3].name, Slots.saves[4].name);
                test.FormBorderStyle = FormBorderStyle.FixedDialog;
                test.MaximizeBox = false;
                test.MinimizeBox = false;
                test.ShowDialog();

                //replaces that slot with saved data
                SaveGame(test.slot);
            }

            //close form
            this.Close();
        }

        //event handler for tts
        private void speakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //when a user interacts with the speak item
            SpeechSynthesizer textToSpeech = new SpeechSynthesizer();

            //uses the status tool
            bool result = TTSstatus();

            if (result)
            {
                //notifies user that it has been activated or deactivated
                textToSpeech.Speak("Text to speech enabled");
            }
            else
            {
                textToSpeech.Speak("Text to speech disabled");
            }

        }

        //tts status checker, user to determine if speech is needed
        public bool TTSstatus()
        {
            //checks to see if TTS is active

            //looks if it has been checked
            if (speakToolStripMenuItem.Checked)
            {
                speaking = true;
            }
            else
            {
                speaking = false;
            }
            return speaking;

        }

        //determines if game-in-progress must be saved
        public bool SaveChoice(string text)
        {
            //gets intent from Save Menu
            //save or new game
            bool saveGame = false;

            //if game is over
            if (gameOver == true)
            {
                //cannot save a finished game
                saveGame = false;

            }
            else
            {
                //open dialog box prompt
                Save saveMenu = new Save(text, "Yes", "No");
                saveMenu.ShowDialog();

                //wait for response
                saveGame = saveMenu.saveGame;

            }
            //return response
            return saveGame;
        }

        //save game
        public void SaveGame(int index)
        {
            //boolean for finding if they want to save
            bool response;

            //boolean for allowing save to be loaded
            bool enable;

            //is the slot empty
            if (Slots.saves[index].empty != true)
            {
                //ask if they want to overwrite data (returns boolean)
                response = SaveChoice($"Save {index + 1} already has data. Do you want to overwrite this save?");
                enable = false;
            }
            else
            {
                //if data is empty
                response = true;

                //data should now be able to be loaded
                enable = true;
            }

            if(response == true)
            {
                //determines who is set to play when this save is loaded
                int turn, nTurn;
                if (player1.isTurn == true)
                {
                    turn = 0;
                    nTurn = 1;
                }
                else
                {
                    turn = 1;
                    nTurn = 0;
                }

                //creates new object of save slot
                SaveSlot Save1 = new SaveSlot();
                //stores the necessary game info
                Save1.player1Name = player1.name;
                Save1.player2Name = player2.name;
                Save1.currentPlayer = turn;
                Save1.nextPlayer = nTurn;
                Save1.data = gameBoardData;
                Save1.empty = false;

                //Name the save
                Save_Name Name = new Save_Name();
                Name.FormBorderStyle = FormBorderStyle.FixedDialog;
                Name.MaximizeBox = false;
                Name.MinimizeBox = false;
                Name.ShowDialog();

                Save1.name = Name.saveName;

                Slots.saves[index] = Save1;

                //access file
                string filePath = "game_data.json";

                //convert object to serialised version
                string serialisedState = JsonConvert.SerializeObject(Slots.saves);

                //write to the file
                //this currently overwrites the data
                File.WriteAllText(filePath, serialisedState);

                //checks slot that was chosen
                switch (index)
                {
                    case 0:
                        //sets the GUI name
                        save1ToolStripMenuItem.Text = $"Save 1 - {Slots.saves[0].name}";
                        load1.Text = $"Save 1 - {Slots.saves[0].name}";

                        //if the save was previously empty
                        if (enable == true)
                        {
                            //allow it to be loaded
                            load1.Enabled = true;
                        }
                        break;
                    case 1:
                        save2ToolStripMenuItem.Text = $"Save 2 - {Slots.saves[1].name}";
                        load2.Text = $"Save 1 - {Slots.saves[1].name}";
                        if (enable == true)
                        {
                            load2.Enabled = true;
                        }
                        break;
                    case 2:
                        save3ToolStripMenuItem.Text = $"Save 3 - {Slots.saves[2].name}";
                        load3.Text = $"Save 1 - {Slots.saves[2].name}";
                        if (enable == true)
                        {
                            load3.Enabled = true;
                        }
                        break;
                    case 3:
                        save4ToolStripMenuItem.Text = $"Save 4 - {Slots.saves[3].name}";
                        load4.Text = $"Save 1 - {Slots.saves[3].name}";
                        if (enable == true)
                        {
                            load4.Enabled = true;
                        }
                        break;
                    case 4:
                        save5ToolStripMenuItem.Text = $"Save 5 - {Slots.saves[4].name}";
                        load5.Text = $"Save 1 - {Slots.saves[4].name}";
                        if (enable == true)
                        {
                            load5.Enabled = true;
                        }
                        break;
                }
            }

        }

        //new game
        public void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            bool save;
            //executes save choice
            if (gameBegun == true)
            {
                save = SaveChoice("You are ending a game in progress. Do you want to save?");
            }
            else
            {
                save = false;
            }


            //if user does want to save game
            if (save == true)
            {
                Select_Slot test = new Select_Slot(Slots.saves[0].name, Slots.saves[1].name, Slots.saves[2].name, Slots.saves[3].name, Slots.saves[4].name);
                test.FormBorderStyle = FormBorderStyle.FixedDialog;
                test.MaximizeBox = false;
                test.MinimizeBox = false;
                test.ShowDialog();

                SaveGame(test.slot);
            }

            //generate new board
            gameBoardData = this.GenerateBoard();

            //reset to start settings
            player1.noMoves = false;
            player2.noMoves = false;

            //resets turn order
            player1.isTurn = true;
            player2.isTurn = false;

            pbox_arrow1.Visible = true;
            pbox_arrow2.Visible = false;

            //resets save option
            gameBegun = false;
            saveGameToolStripMenuItem.Enabled = false;

            //updates the gameboard and score count
            _gameBoardGui.UpdateBoardGui(gameBoardData);
            lbl_ScoreOne.Text = player1.CalcScore(gameBoardData, rowNum, colNum).ToString();
            lbl_ScoreTwo.Text = player2.CalcScore(gameBoardData, rowNum, colNum).ToString();


        }

        //info panel
        private void informationPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //changes visibility of panel
            //if it is currently checked
            if (informationPanelToolStripMenuItem.Checked)
            {
                //turn on
                pnl_info.Visible = true;
            }
            else
            {
                //turn off
                pnl_info.Visible = false;
            }

        }

        //about window
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            //creates static about window
            about.FormBorderStyle = FormBorderStyle.FixedDialog;
            about.MaximizeBox = false;
            about.MinimizeBox = false;
            about.Show();
        }

        //load game
        private void LoadGame(int index)
        {
            //retrieve data in json file
            string filePath = "game_data.json";
            string stateData = File.ReadAllText(filePath);
            Slots.saves = JsonConvert.DeserializeObject<List<SaveSlot>>(stateData);

            //Load given slot
            SaveSlot LoadedSlot = Slots.saves[index];

            gameBoardData = LoadedSlot.data;

            //player names
            player1.name = LoadedSlot.player1Name;
            lbl_name1.Text = player1.name;
            player2.name = LoadedSlot.player2Name;
            lbl_name2.Text = player2.name;

            //finds who was meant to play next
            if (LoadedSlot.currentPlayer == 0)
            {
                player1.isTurn = true;
                player2.isTurn = false;

                //resets arrows
                pbox_arrow1.Visible = true;
                pbox_arrow2.Visible = false;
            }
            else
            {
                player2.isTurn = true;
                player1.isTurn = false;

                //resets arrows
                pbox_arrow1.Visible = false;
                pbox_arrow2.Visible = true;
            }

            //updates the board, updates score
            _gameBoardGui.UpdateBoardGui(gameBoardData);

            
            lbl_ScoreOne.Text = player1.CalcScore(gameBoardData, rowNum, colNum).ToString();
            lbl_ScoreTwo.Text = player2.CalcScore(gameBoardData, rowNum, colNum).ToString();
        }

        //logic to change names mid game
        private (string, string) ChangeName()
        {
            //new form
            Enter_Names ChangeName = new Enter_Names();
            //tuple
            (string, string) names;
            
            ChangeName.FormBorderStyle = FormBorderStyle.FixedDialog;
            ChangeName.MaximizeBox = false;
            ChangeName.MinimizeBox = false;
            ChangeName.ShowDialog();

            //if the names have been changed
            if(ChangeName.change == true)
            {
                names.Item1 = ChangeName.name1;
                names.Item2 = ChangeName.name2;
            }
            else
            {
                //if cancel pressed
                names.Item1 = player1.name;
                names.Item2 = player2.name;
            }
            return names;
        }

        //event handlers for the save slots

        //saves in slot 1
        private void save1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveGame(0);

        }

        //saves in slot 2
        private void save2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveGame(1);
        }

        //saves in slot 3
        private void save3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveGame(2);
        }

        //saves in slot 4
        private void save4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveGame(3);
        }

        //saves in slot 5
        private void save5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveGame(4);
        }

        //loads appropriate slot
        private void load1_Click(object sender, EventArgs e)
        {
            LoadGame(0);
        }

        private void load2_Click(object sender, EventArgs e)
        {
            LoadGame(1);
        }

        private void load3_Click(object sender, EventArgs e)
        {
            LoadGame(2);
        }

        private void load4_Click(object sender, EventArgs e)
        {
            LoadGame(3);
        }

        private void load5_Click(object sender, EventArgs e)
        {
            LoadGame(4);
        }

        //Option for user to change names after the start screen
        private void changeNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (string, string) names = ChangeName();

            player1.name = names.Item1;
            player2.name = names.Item2;

            lbl_name1.Text = player1.name;
            lbl_name2.Text = player2.name;

        }
    }




}