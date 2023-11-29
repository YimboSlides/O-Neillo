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

        //List of Objects for having multiple saves

        List<SaveSlot> saves = new List<SaveSlot>();

        //other variables for game over and TTS
        bool gameOver = false;
        bool speaking = false;

        //text for messages to user
        string invalidMsg = "That move is invalid";
        string noMovesMsg = "currently has no valid moves left";
        string gameOverMsg = "Game Over. Winner is";

        //creating an object of the class GameBoardImageArray
        GameboardImageArray _gameBoardGui;

        //2D array to store the gameData
        int[,] gameBoardData;
        
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

            pbox_arrow1.Visible = true;
            pbox_arrow2.Visible = false;

            //display starting score
            lbl_ScoreOne.Text = player1.CalcScore(gameBoardData, rowNum, colNum).ToString();
            lbl_ScoreTwo.Text = player2.CalcScore(gameBoardData, rowNum, colNum).ToString();
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
            return boardArray;
        }

        //unused function for gathering save data
        public void RecoverSaves()
        {
            string filePath = "saves.json";

            //deserialises content in the json file
            string stateData = File.ReadAllText(filePath);
            SaveSlot LoadedState = JsonConvert.DeserializeObject<SaveSlot>(stateData);


        }

        //handles when tile is clicked
        private void GameTileClicked(object sender, EventArgs e)
        {
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
            //closes form
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
        public bool SaveChoice()
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
                Save saveMenu = new Save("You currently have a game in progress. Would you like to save this game?", "Yes", "No");
                saveMenu.ShowDialog();

                //wait for response
                saveGame = saveMenu.saveGame;

            }
            //return response
            return saveGame;
        }

        //save game
        public void SaveGame()
        {
            //determins who is set to play when this save is loaded
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
            SaveSlot Save = new SaveSlot();
            //stores the necessary game info
            Save.player1Name = player1.name;
            Save.player2Name = player2.name;
            Save.currentPlayer = turn;
            Save.nextPlayer = nTurn;
            Save.data = gameBoardData;

            //saves game state to json file
            Save.SaveState();


        }
        
        //new game
        public void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //executes save choice
            bool save = SaveChoice();

            //if user does want to save game
            if (save == true)
            {
                SaveGame();
                this.Close();

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
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //finds json file
            string filePath = "saves.json";

            //deserialises content in the json file
            string stateData = File.ReadAllText(filePath);
            SaveSlot LoadedState = JsonConvert.DeserializeObject<SaveSlot>(stateData);

            //changes the values for the relevant game information

            //gamedata
            gameBoardData = LoadedState.data;

            //player names
            player1.name = LoadedState.player1Name;
            lbl_name1.Text = player1.name;
            player2.name = LoadedState.player2Name;
            lbl_name2.Text = player2.name;

            //finds who was meant to play next
            if (LoadedState.currentPlayer == 0)
            {
                player1.isTurn = true;
                player2.isTurn = false;
            }
            else
            {
                player2.isTurn = true;
                player1.isTurn = false;
            }

            //updates the board, updates score
            _gameBoardGui.UpdateBoardGui(gameBoardData);
            lbl_ScoreOne.Text = player1.CalcScore(gameBoardData, rowNum, colNum).ToString();
            lbl_ScoreTwo.Text = player2.CalcScore(gameBoardData, rowNum, colNum).ToString();

        }

        //save game
        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //saves game
            SaveGame();
            MessageBox.Show("Game Saved");
        }

        //unused for multiple save slots
        private void save1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveGame();
        }
    }




}