using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GameBoardTest
{
    //creating the class 'Player' to use as the basis for most methods
    //this covers the game logic
    public class Player
    {
        //a number of attributes
        int score; //set for the player's score to display on screen
        int colour; //colour set to 1 or 0 (how white and black are referenced for the game data)
        int opposite; //whatever the opposing colour is
        public bool isTurn; //determines turn order
        public string name; //name as given by user
        
        public bool noMoves = false; //if player has any moves left, gameOver is true

        //used to store the validation for each move in each direction
        (bool, List<List<int>>) testN, testS, testE, testW, testNE, testNW, testSE, testSW;
        

        

        //basic constructor
        public Player(int colour, bool isTurn, string name)
        {
            //passes player colour, turn order and name
            this.colour = colour;
            this.isTurn = isTurn;
            this.name = name;

            //based on colour, sets the opposing player's
            if (colour == 0)
            {
                this.opposite = 1;
            }
            else
            {
                this.opposite = 0;
            }
        }

        //checks if there are any valid moves left
        //need to adjust so check takes place before moves
        public void CheckGameOver(int[,] arr)
        {
            //adjusts 'gameOver' based on if there are valid moves left
            bool finish = true;
            List<bool> results = new List<bool> { };
            int invalidCount = 0;


            //for each empty square on the board, check if it is valid in every direction.
            //if any one of these is true, the player has valid moves remaining. 

            //nested loop to cycle through every square on board
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    //checks if the space is empty
                    if (arr[r, c] == 10)
                    {
                        bool valid = false;
                        //reusing existing validation
                        testN = ValidNorth(arr, r, c);
                        testS = ValidEast(arr, r, c);
                        testE = ValidSouth(arr, r, c);
                        testW = ValidWest(arr, r, c);
                        testNE = ValidSE(arr, r, c);
                        testNW = ValidSW(arr, r, c);
                        testSE = ValidNW(arr, r, c);
                        testSW = ValidNE(arr, r, c);

                        
                        bool[] tests = { testN.Item1, testS.Item1, testE.Item1, testW.Item1, testNE.Item1, testNW.Item1, testSE.Item1, testSW.Item1 };

                        //if valid in any direction, it is a valid move
                        foreach(bool test in tests)
                        {
                            if (test == true)
                            {
                                valid = true;
                                break;
                            }
                        }

                        //add to list for every move
                        results.Add(valid);
                       
                    }
                    else
                    {
                        //if the move is invalid, make a note of how many invalid moves
                        //have been identified, including spaces with pieces present
                        invalidCount++;
                    }
                }
                
            }
            //checks if every square on the board is invalid,
            //if so then we know there are no valid moves.
            if(invalidCount != 64)
            {
                //searches the results for a valid move
                foreach (bool result in results)
                {
                    if (result == true)
                    {
                        //if there is at least 1 valid move, the player can continue
                        finish = false;
                        noMoves = finish;
                    }
                }
            }
            
            noMoves = finish;
        }

        //calculate score method, receives gameboard data array and
        //dimensions of board
        public int CalcScore(int[,] arr, int r, int c)
        {
            //temp counter
            int count = 0;
            //nested loop cycles through each square on the board
            for(int i = 0; i < r; i++)
            {
                for(int j = 0; j < c; j++)
                {
                    //checks if the space has a piece on it
                    if (arr[i,j] == colour)
                    {
                        //searches the array for all pieces, increases count by 1
                        count = count + 1;
                    }
                }
                
                
            }
            //once all are found, score is updated
            score = count;
            return score;
        }
        

        //Makes move
        //changes the gameboard data and updates board.
        public int[,] MakeMove(int[,] arr, int row, int col)
        {
            
            //changes the selected position to player piece
            arr[row, col] = colour;

            //checks if the move has flipped any pieces
            if(testN.Item1 == true)
            {
                //takes the list of coordinates, and cycles through them
                List<List<int>>method = testN.Item2;
                for(int i = 0; i < method.Count(); i++)
                {
                    //gets the row and column from each coordinate
                    int y = method[i][0];
                    int x = method[i][1];
                    //flips colour
                    arr[y, x] = colour;
                    
                }
                //clears the list to be used again
                method.Clear();
            }
            if(testS.Item1 == true)
            {
                List<List<int>> method = testS.Item2;
                for (int i = 0; i < method.Count(); i++)
                {
                    //gets the row and column from each coordinate
                    int y = method[i][0];
                    int x = method[i][1];
                    //flips colour
                    arr[y, x] = colour;

                }
                //clears the list to be used again
                method.Clear();
            }
            if(testE.Item1 == true)
            {
                List<List<int>> method = testE.Item2;
                for (int i = 0; i < method.Count(); i++)
                {
                    //gets the row and column from each coordinate
                    int y = method[i][0];
                    int x = method[i][1];
                    //flips colour
                    arr[y, x] = colour;

                }
                //clears the list to be used again
                method.Clear();
            }
            if(testW.Item1 == true)
            {
                List<List<int>> method = testW.Item2;
                for (int i = 0; i < method.Count(); i++)
                {
                    //gets the row and column from each coordinate
                    int y = method[i][0];
                    int x = method[i][1];
                    //flips colour
                    arr[y, x] = colour;

                }
                //clears the list to be used again
                method.Clear();
            }
            if(testNE.Item1 == true)
            {
                List<List<int>> method = testNE.Item2;
                for (int i = 0; i < method.Count(); i++)
                {
                    //gets the row and column from each coordinate
                    int y = method[i][0];
                    int x = method[i][1];
                    //flips colour
                    arr[y, x] = colour;

                }
                //clears the list to be used again
                method.Clear();
            }
            if(testNW.Item1 == true)
            {
                List<List<int>> method = testNW.Item2;
                for (int i = 0; i < method.Count(); i++)
                {
                    //gets the row and column from each coordinate
                    int y = method[i][0];
                    int x = method[i][1];
                    //flips colour
                    arr[y, x] = colour;

                }
                //clears the list to be used again
                method.Clear();
            }
            if(testSE.Item1 == true)
            {
                List<List<int>> method = testSE.Item2;
                for (int i = 0; i < method.Count(); i++)
                {
                    //gets the row and column from each coordinate
                    int y = method[i][0];
                    int x = method[i][1];
                    //flips colour
                    arr[y, x] = colour;

                }
                method.Clear();
            }
            if(testSW.Item1 == true)
            {
                List<List<int>> method = testSW.Item2;
                for (int i = 0; i < method.Count(); i++)
                {
                    //gets the row and column from each coordinate
                    int y = method[i][0];
                    int x = method[i][1];
                    //flips colour
                    arr[y, x] = colour;

                }
                //clears the list to be used again
                method.Clear();
            }

            int[,] newData = arr;
            
            //returns array to change GUI
            return newData;
        }
            
        
        //validates move
        //checks the logic of the move, then returns if it is valid
        public bool ValidateMove(int[,] arr, int row, int col)
        {
            bool validMove = false;
            
            //is move on an unoccupied square
            if (arr[row, col] == 10)
            {
                //checks each direction if the move is valid
                testN = ValidNorth(arr, row, col);
                testS = ValidSouth(arr, row, col);
                testE = ValidEast(arr, row, col);
                testW = ValidWest(arr, row, col);
                testNE = ValidNE(arr, row, col);
                testNW = ValidNW(arr, row, col);
                testSE = ValidSE(arr, row, col);
                testSW = ValidSW(arr, row, col);
             
                
                //stores the boolean values from each method
                bool[] tests = { testN.Item1, testS.Item1, testE.Item1, testW.Item1, testNE.Item1, testNW.Item1, testSE.Item1, testSW.Item1 };
                //if the move is valid in at least one of these directions, then it is a valid move
                foreach (bool test in tests)
                {
                    if (test == true)
                    {
                        isTurn = false;
                        validMove = true;
                        return validMove;
                    }
                }

            }
            else
            {
                return validMove;
            }

            return validMove;
            
        }

        //The following 8 methods each check a direction from the chosen point on the board,
        //identify if the move is valid and if there are any pieces that need to be flipped.
        
        //This was done for ease of testing, to make sure that each directon worked
        //independently.
        internal (bool, List<List<int>>) ValidNorth(int[,] arr,  int row, int col)
        {
            //boolean return value
            bool valid = false;
            //iterates to allow a new coord to be added
            int coordNum = 0;
            //2d list for the coordinates
            List<List<int>> coords = new List<List<int>>();
            
            
            //value to set specific boundary (in this case top)
            const int topRow = 0;

            //checks for minimum gap of three between point selected and boundary
            if (row == topRow || row - 1 == topRow)
            {
                return (valid, coords);
            }
            //checks opposite colour in this space
            else if(arr[row - 1, col] == opposite)
            {
                //adds this to a list of values that may need to be overturned
                coords.Add(new List<int>());
                coords[coordNum].Add(row - 1);
                coords[coordNum].Add(col);

                coordNum = coordNum + 1;
                //loops through each next point in this direction until matching colour is found,
                //or until boundary is reached.
                for (int r = row - 2; r >= topRow; r--)
                {
                    //once colour found, return that it is valid in this direction
                    if (arr[r, col] == colour)
                    {
                        valid = true;
                        return (valid, coords);
                    }
                    else if (arr[r, col] == opposite)
                    {
                        //if more opposite colours are found, add coordinates
                        coords.Add(new List<int>());
                        coords[coordNum].Add(r);
                        coords[coordNum].Add(col);

                        coordNum = coordNum + 1;
                    }
                    else
                    {
                        valid = false;
                        return (valid, coords);
                    }
                    
                }
                
            }
            //returns if the move is valid or not, and the positions of 
            //pieces that need to flip
            return (valid, coords);
        }
                
        internal (bool, List<List<int>>) ValidSouth(int[,] arr, int row, int col)
        {
            bool valid = false;
            int coordNum = 0;

            List<List<int>> coords = new List<List<int>>();

            const int bottomRow = 7;

            if (row == bottomRow || row + 1 == bottomRow)
            {
                return (valid, coords);
            }
            else if (arr[row + 1, col] == opposite)
            {
                coords.Add(new List<int>());
                coords[coordNum].Add(row + 1);
                coords[coordNum].Add(col);

                coordNum = coordNum + 1;

                for (int r = row + 2; r <= bottomRow; r++)
                {
                    if (arr[r, col] == colour)
                    {
                        valid = true;
                        return (valid, coords);
                    }
                    else if (arr[r, col] == opposite)
                    {
                        //if more opposite colours are found, add coordinates
                        coords.Add(new List<int>());
                        coords[coordNum].Add(r);
                        coords[coordNum].Add(col);

                        coordNum = coordNum + 1;
                    }
                    else
                    {
                        valid = false;
                        return (valid, coords);
                    }

                }

            }
            return (valid, coords);
        }
        
        internal (bool, List<List<int>>) ValidEast(int[,] arr, int row, int col)
        {
            bool valid = false;
            int coordNum = 0;

            List<List<int>> coords = new List<List<int>>();

            const int farCol = 0;

            if (col == farCol || col - 1 == farCol)
            {
                return (valid, coords);
            }
            else if (arr[row, col - 1] == opposite)
            {
                coords.Add(new List<int>());
                coords[coordNum].Add(row);
                coords[coordNum].Add(col - 1);

                coordNum = coordNum + 1;
                for (int c = col - 2; c >= farCol; c--)
                {
                    if (arr[row, c] == colour)
                    {
                        valid = true;
                        return (valid, coords);

                    }
                    else if (arr[row, c] == opposite)
                    {
                        //if more opposite colours are found, add coordinates
                        coords.Add(new List<int>());
                        coords[coordNum].Add(row);
                        coords[coordNum].Add(c);

                        coordNum = coordNum + 1;
                    }
                    else
                    {
                        valid = false;
                        return (valid, coords);
                    }

                }

            }
            return (valid, coords);
        }
        
        internal (bool, List<List<int>>) ValidWest(int[,] arr, int row, int col)
        {
            bool valid = false;
            int coordNum = 0;

            List<List<int>> coords = new List<List<int>>();

            const int farCol = 7;

            if (col == farCol || col + 1 == farCol)
            {
                return (valid, coords);
            }
            else if (arr[row, col + 1] == opposite)
            {
                coords.Add(new List<int>());
                coords[coordNum].Add(row);
                coords[coordNum].Add(col + 1);

                coordNum = coordNum + 1;
                for (int c = col + 2; c <= farCol; c++)
                {
                    if (arr[row, c] == colour)
                    {
                        valid = true;
                        return (valid, coords);
                    }
                    else if (arr[row, c] == opposite)
                    {
                        //if more opposite colours are found, add coordinates
                        coords.Add(new List<int>());
                        coords[coordNum].Add(row);
                        coords[coordNum].Add(c);

                        coordNum = coordNum + 1;
                    }
                    else
                    {
                        valid = false;
                        return (valid, coords);
                    }

                }

            }
            return (valid, coords);
        }
        
        internal (bool, List<List<int>>) ValidNE(int[,] arr, int row, int col)
        {
            bool valid = false;
            int coordNum = 0;

            List<List<int>> coords = new List<List<int>>();

            const int topRow = 0;
            const int farCol = 0;

            if(row == topRow || row - 1 == topRow || col == farCol || col - 1 == farCol)
            {
                return (valid, coords);
            }else if (arr[row-1, col-1] == opposite)
            {
                coords.Add(new List<int>());
                coords[coordNum].Add(row - 1);
                coords[coordNum].Add(col - 1);

                coordNum = coordNum + 1;
                int c = col - 2;
                for (int r = row - 2; r >= topRow; r--)
                {
                    if(c >= farCol)
                    {
                        if (arr[r, c] == colour)
                        {
                            valid = true;
                            return (valid, coords);
                        }
                        else if (arr[r, c] == opposite)
                        {
                            //if more opposite colours are found, add coordinates
                            coords.Add(new List<int>());
                            coords[coordNum].Add(r);
                            coords[coordNum].Add(c);

                            coordNum = coordNum + 1;
                        }
                        else
                        {
                            valid = false;
                            return (valid, coords);
                        }
                    }
                    c--;
                    
                    
                }
            }

            return (valid, coords);


        }
       
        internal (bool, List<List<int>>) ValidNW(int[,] arr, int row, int col)
        {
            bool valid = false;
            int coordNum = 0;

            List<List<int>> coords = new List<List<int>>();

            const int topRow = 0;
            const int farCol = 7;

            if (row == topRow || row - 1 == topRow || col == farCol || col + 1 == farCol)
            {
                return (valid, coords);
            }
            else if (arr[row - 1, col + 1] == opposite)
            {
                coords.Add(new List<int>());
                coords[coordNum].Add(row - 1);
                coords[coordNum].Add(col + 1);

                coordNum = coordNum + 1;

                int c = col + 2;
                for (int r = row - 2; r >= topRow; r--)
                {
                    if(c <= farCol)
                    {
                        if (arr[r, c] == colour)
                        {
                            valid = true;
                            return (valid, coords);
                        }
                        else if (arr[r, c] == opposite)
                        {
                            //if more opposite colours are found, add coordinates
                            coords.Add(new List<int>());
                            coords[coordNum].Add(r);
                            coords[coordNum].Add(c);

                            coordNum = coordNum + 1;
                        }
                        else
                        {
                            valid = false;
                            return (valid, coords);
                        }
                    }
                    c++;
                    
                }
            }
            return (valid,coords);
        }
        
        internal (bool, List<List<int>>) ValidSE(int[,] arr, int row, int col)
        {
            bool valid = false;
            int coordNum = 0;

            List<List<int>> coords = new List<List<int>>();

            const int bottomRow = 7;
            const int farCol = 0;
            if (row == bottomRow || row + 1 == bottomRow || col == farCol || col - 1 == farCol)
            {
                return (valid, coords);
            }
            else if (arr[row + 1, col - 1] == opposite)
            {
                
                coords.Add(new List<int>());
                coords[coordNum].Add(row + 1);
                coords[coordNum].Add(col - 1);

                coordNum = coordNum + 1;

                int c = col - 2;
                for (int r = row + 2; r <= bottomRow; r++)
                {
                    if(c >= farCol)
                    {
                        if (arr[r, c] == colour)
                        {
                            valid = true;
                            return (valid, coords);
                        }
                        else if (arr[r, c] == opposite)
                        {
                            //if more opposite colours are found, add coordinates
                            coords.Add(new List<int>());
                            coords[coordNum].Add(r);
                            coords[coordNum].Add(c);

                            coordNum = coordNum + 1;
                        }
                        else
                        {
                            valid = false;
                            return (valid, coords);
                        }
                        c--;
                    }
             
                }
            }
            return (valid, coords);
        }

        internal (bool, List<List<int>>) ValidSW(int[,] arr, int row, int col)
        {
            bool valid = false;
            int coordNum = 0;

            List<List<int>> coords = new List<List<int>>();

            const int bottomRow = 7;
            const int farCol = 7;
            if (row == bottomRow || row + 1 == bottomRow || col == farCol || col + 1 == farCol)
            {
                return (valid, coords);
            }
            else if (arr[row + 1, col + 1] == opposite)
            {
                coords.Add(new List<int>());
                coords[coordNum].Add(row + 1);
                coords[coordNum].Add(col + 1);

                coordNum = coordNum + 1;

                int c = col + 2;
                
                for (int r = row + 2; r <= bottomRow; r++)
                {
                   if(c <= farCol)
                   {
                        if (arr[r, c] == colour)
                        {
                            valid = true;
                            return (valid, coords);
                        }
                        else if (arr[r, c] == opposite)
                        {
                            //if more opposite colours are found, add coordinates
                            coords.Add(new List<int>());
                            coords[coordNum].Add(r);
                            coords[coordNum].Add(c);

                            coordNum = coordNum + 1;
                        }
                        else
                        {
                            valid = false;
                            return (valid, coords);
                        }
                        c++;
                    }
                    
                    
                }
            }
            return (valid, coords);
        }
            
            
           
    }
        
            
           
            
            
            

        
        
            

            

        
    

}
