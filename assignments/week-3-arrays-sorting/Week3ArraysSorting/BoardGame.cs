using System;
using System.Security.Principal;

namespace Week3ArraysSorting
{
    /// <summary>
    /// Board Game implementation for Assignment 2 Part A
    /// Demonstrates multi-dimensional arrays with interactive gameplay
    /// 
    /// Learning Focus: 
    /// - Multi-dimensional array manipulation (char[,])
    /// - Console rendering and user input
    /// - Game state management and win detection
    /// 
    /// Choose ONE game to implement:
    /// - Tic-Tac-Toe (3x3 grid)
    /// - Connect Four (6x7 grid with gravity)
    /// - Or something else creative using a 2D array! (I need to be able to understand the rules from your instructions)
    /// </summary>
    public class BoardGame
    { 
        private char[,] board = new char[6, 7]; // 6 rows, 7 columns
        private char currentPlayer = 'X';
        private bool gameOver = false;
        private string winner = "";

        /// <summary>
        /// Constructor - Initialize the board game
        /// TODO: Set up your chosen game
        /// </summary>
        public BoardGame()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = '*';
                }
            }
        }
        
        /// <summary>
        /// Main game loop - handles the complete game session
        /// TODO: Implement the full game experience
        /// </summary>
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("=== BOARD GAME (Part A) ===");
            Console.WriteLine();
            
            // Display game instructions
            DisplayInstructions();
            
            // Implement main game loop
            bool playAgain = true;
            
            while (playAgain)
            {
                // TODO: Reset game state for new game
                InitializeNewGame();
                
                // TODO: Play one complete game
                PlayOneGame();
                
                // TODO: Ask if player wants to play again
                playAgain = AskPlayAgain();
            }
            
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }
        
        /// <summary>
        /// Display game instructions and controls
        /// TODO: Customize for your chosen game
        /// </summary>
        private void DisplayInstructions()
        {
            Console.WriteLine();
            
            // Connect Four:
            Console.WriteLine("CONNECT FOUR RULES:");
            Console.WriteLine("- Players take turns dropping tokens");
            Console.WriteLine("- Enter column number (0-6) when prompted");
            Console.WriteLine("- First to get 4 in a row wins!");
            
            Console.WriteLine();
        }
        
        /// <summary>
        /// Initialize/reset the game for a new round
        /// TODO: Reset board and game state
        /// </summary>
        private void InitializeNewGame()
        {
            // Clear/Reset the board array
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = '*';
                }
            }
            // Reset current player to 'X'
            currentPlayer = 'X';
            // Reset game over flag
            gameOver = false;
            // Clear winner
            winner = "";

            // Console.WriteLine("TODO: Initialize new game state");
        }
        
        /// <summary>
        /// Play one complete game until win/draw/quit
        /// TODO: Implement the core game loop
        /// </summary>
        private void PlayOneGame()
        {
            // TODO: Game loop structure:
            while (!gameOver)
            {
                RenderBoard();
                GetPlayerMove();
                //UpdateBoard();
                CheckWinCondition();
                SwitchPlayer();
            }
            
            // Console.WriteLine("TODO: Implement main game loop");
            // Console.WriteLine("This should include:");
            // Console.WriteLine("1. Render board to console");
            // Console.WriteLine("2. Get and validate player input");
            // Console.WriteLine("3. Update board with move");
            // Console.WriteLine("4. Check for win/draw conditions");
            // Console.WriteLine("5. Switch to next player");
        }
        
        /// <summary>
        /// Render the current board state to console
        /// TODO: Create clear, readable board display
        /// </summary>
        private void RenderBoard()
        {
            Console.Clear();
            Console.WriteLine("=== BOARD GAME (Part A) ===");
            Console.WriteLine();
            
            // Display game instructions
            DisplayInstructions();

            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{board[i, j]:D2}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Get and validate player move input
        /// TODO: Handle user input with validation
        /// </summary>
        private void GetPlayerMove()
        {
            // bool validMove = false;
            int i;
            do
            {
                Console.WriteLine($"Player {currentPlayer}, enter your move: ");
                i = Convert.ToInt32(Console.ReadLine());
            } while (!IsValidMove(i));
            DropToken(i, currentPlayer);
        }
        
        private void UpdateBoard()
        {
            Console.Clear();
            Console.WriteLine("=== BOARD GAME (Part A) ===");
            Console.WriteLine();
            
            // Display game instructions
            DisplayInstructions();
        }
        
        /// <summary>
        /// Check if current board state has a winner or draw
        /// TODO: Implement win detection logic
        /// </summary>
        private void CheckWinCondition()
        {
            // For Connect Four:
            // - Check horizontal, vertical, and diagonal lines for 4 in a row
            // - Check for draw (top row full, no winner)

            char XO;
            bool win;

            XO = currentPlayer;
            win = false;

            for (int i = board.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = board.GetLength(1) - 1; j >= 0; j--)
                {
                    // Console.Write($"board[{i},{j}]");
                    // Console.Write("checking right diagonal");
                    // checks to make sure that i-3 and j-3 aren't less than 0
                    if (i > 2 && j > 2)
                    {   // should check
                        // 4***
                        // *3**
                        // **2*
                        // ***1
                        if (board[i, j] == XO &&        //1
                        board[i - 1, j - 1] == XO &&    //2
                        board[i - 2, j - 2] == XO &&    //3
                        board[i - 3, j - 3] == XO)      //4
                            win = true;
                    }
                    // checks to make sure that j-3 isn't less than 0
                    if (j > 2)
                    {   // should check
                        // 4321
                        // Console.WriteLine($"checking horizontal [{i},{j}],[{i},{j-1}],[{i},{j-2}],[{i},{j-3}]");
                        if (board[i, j] == XO &&        //1
                        board[i, j - 1] == XO &&        //2
                        board[i, j - 2] == XO &&        //3
                        board[i, j - 3] == XO)          //4
                        {
                            win = true;
                        }
                    }

                    // Console.Write("checking vertical");
                    // checks to make sure that i-3 isn't less than 0
                    if (i > 2)
                    {   // should check
                        // 4
                        // 3
                        // 2
                        // 1
                        // Console.WriteLine($"checking vertical [{i},{j}],[{i-1},{j}],[{i-2},{j}],[{i-3},{j}]");
                        if (board[i, j] == XO &&    //1
                        board[i - 1, j] == XO &&    //2
                        board[i - 2, j] == XO &&    //3
                        board[i - 3, j] == XO)      //4
                            win = true;
                    }

                    // checks to make sure that i-3 isn't less than 0 and 
                    // j + 3 isn't greater than the col length of the board array
                    if (i > 2 && j < board.GetLength(1) - 3 )
                    {   // should check
                        // ***4
                        // **3*
                        // *2**
                        // 1***
                        // Console.WriteLine($"checking left diagonal [{i},{j}],[{i-1},{j+1}],[{i-2},{j+2}],[{i-3},{j+3}]");
                        if (board[i, j] == XO &&        //1
                        board[i - 1, j + 1] == XO &&    //2
                        board[i - 2, j + 2] == XO &&    //3
                        board[i - 3, j + 3] == XO)      //4
                            win = true;                        
                    }
                }
            }

            gameOver = win;
            if (gameOver)
            {
                winner = $"Player {currentPlayer} wins!";
            }
        }
        
        /// <summary>
        /// Ask player if they want to play another game
        /// TODO: Simple yes/no prompt with validation
        /// </summary>
        private bool AskPlayAgain()
        {
            // Console.WriteLine("TODO: Ask if player wants to play again");

            bool replayChoice = true;
            while (replayChoice)
            {
                Console.WriteLine("Play again? y/n yes/no");
                string? choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "y":
                        return true;
                    case "yes":
                        return true;
                    case "n":
                        return false;
                    case "no":
                        return false;
                    default:
                        Console.WriteLine("Invalid choice. Please enter y/n or yes/no.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }

            // Placeholder - always return false for now
            return false;
        }

        /// <summary>
        /// Switch to the next player's turn
        /// TODO: Toggle between X and O
        /// </summary>
        private void SwitchPlayer()
        {
            // TODO: Switch currentPlayer between 'X' and 'O'            
            // Console.WriteLine("TODO: Switch to next player");
            if (currentPlayer == 'X')
                currentPlayer = 'O';
            else currentPlayer = 'X';
        }

        // TODO: Add helper methods as needed
        // Examples:
        // - IsValidMove(int row, int col)
        // - IsBoardFull()
        // - CheckRow(int row, char player)
        // - CheckColumn(int col, char player)
        // - CheckDiagonals(char player)
        // - DropToken(int column, char player) // For Connect Four

        private bool IsValidMove(int col)
        {
            if (col < 0 || col > (board.GetLength(1) - 1))
                return false;
            else if (board[0, col] != '*')
                return false;
            else
                return true;
        }
        
        private void DropToken(int col, char player)
        {
            for (int r = board.GetLength(0) -1; r > 0; r--)
            {
                // Console.WriteLine($"testing {r}");
                if (board[r, col] != 'X' && board[r, col] != 'O')
                {
                    // Console.WriteLine($"testing {r}");
                    board[r, col] = (currentPlayer == 'X') ? 'X' : 'O';
                    break;
                }
            }
        }
    }
}