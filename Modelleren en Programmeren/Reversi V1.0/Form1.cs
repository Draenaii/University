using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi_Update
{
    public partial class Reversi : Form
    {
        // Variables for Board and Turn
        int v = 6, beurt = 0, help = 0, scoreplayer1 = 0, scoreplayer2 = 0;
        Pen Help = new Pen(Color.White, (float)2.5);
        Color[] colorsP1 = { Color.Blue, Color.Green, Color.CadetBlue };
        Color colorP1 = Color.Blue;
        Color[] colorsP2 = { Color.Red, Color.Orange, Color.Magenta };
        Color colorP2 = Color.Red;

        // Arrays for Board and Stones
        int[,] board;

        public Reversi()
        {
            InitializeComponent();
            AssignBoardArray();
        }

        // Paint Event
        private void ReversiPanel_Paint(object sender, PaintEventArgs e)
        {
            this.DrawBoard(e.Graphics);
            this.DrawStones(e.Graphics);
            this.DrawHelp(e.Graphics);
            Turn();
        }

        // Method to calculate X-coordinate
        public int CalcXLocationStone(int x)
        {
            int xloc = x * ReversiPanel.Width / v;

            return xloc;
        }

        // Method to calculate Y-coordinate stone
        public int CalcYLocationStone(int y)
        {
            int yloc = y * ReversiPanel.Height / v;

            return yloc;
        }

        // Method to Calculate Row Click
        public int CalcRow(int y)
        {
            int row = y / (ReversiPanel.Height / v);
            return row;
        }

        // Method to Calculate Colom Click
        public int CalcColom(int x)
        {
            int colom = x / (ReversiPanel.Width / v);
            return colom;
        }

        // Method to Assign Values to Board Array
        private void AssignBoardArray()
        {
            board = new int [v, v];
            int row, colom;

            for (row = 0; row < v; row++)
            {
                for (colom = 0; colom < v; colom++)
                {
                    board[row, colom] = 0;
                }
            }

            // Place starting stones
            board[v / 2 - 1, v / 2] = 1;
            board[v / 2, v / 2 - 1] = 1;
            board[v / 2, v / 2] = 2;
            board[v / 2 - 1, v / 2 - 1] = 2;
        }

        // Method to Draw Board
        private void DrawBoard(Graphics gr)
        {
            int x, y;
            Pen Zwart = new Pen(Color.Black);

            for (x = 0; x < v; x++)
            {
                gr.DrawRectangle(Zwart, x * (ReversiPanel.Width / v), 0, ReversiPanel.Width / v, ReversiPanel.Height / v);

                for (y = 0; y < v; y++)
                {
                    gr.DrawRectangle(Zwart, x * (ReversiPanel.Width / v), y * (ReversiPanel.Height / v), ReversiPanel.Width / v, ReversiPanel.Height / v);
                }
            }
        }

        // Method to Draw Stones
        private void DrawStones(Graphics gr)
        {
            int row, colom;
            Brush b1 = new SolidBrush(colorP1);
            Brush b2 = new SolidBrush(colorP2);

            for (colom = 0; colom < v; colom++)
            {
                for (row = 0; row < v; row++)
                {
                    if (board[row, colom] == 1)
                        gr.FillEllipse(b1, CalcXLocationStone(row) + 5, CalcYLocationStone(colom) + 5, (ReversiPanel.Width / v) - 10, (ReversiPanel.Width / v) - 10);
                    else if (board[row, colom] == 2)
                        gr.FillEllipse(b2, CalcXLocationStone(row) + 5, CalcYLocationStone(colom) + 5, (ReversiPanel.Width / v) - 10, (ReversiPanel.Width / v) - 10);
                }
            }
        }

        // Method to draw Help 
        private void DrawHelp(Graphics gr)
        {
            int row, colom;

            for (row = 0; row < v; row++)
            {
                for (colom = 0; colom < v; colom++)
                {

                    if (beurt % 2 == 0)
                    {
                        if (CheckMove(2, 1, row, colom) && board[row, colom] == 0)
                        {
                            gr.DrawEllipse(Help, CalcXLocationStone(row) + 10, CalcYLocationStone(colom) + 10, (ReversiPanel.Width / v) - 20, (ReversiPanel.Width / v) - 20);
                        }
                    }
                    else
                    {
                        if (CheckMove(1, 2, row, colom) && board[row, colom] == 0)
                        {
                            gr.DrawEllipse(Help, CalcXLocationStone(row) + 10, CalcYLocationStone(colom) + 10, (ReversiPanel.Width / v) - 20, (ReversiPanel.Width / v) - 20);
                        }
                    }
                }
            }
        }

        // Method to Check Potential Moves Available
        private bool AvailableMoves(int player, int opponent)
        {

            int row, colom;

            for (row = 0; row < v; row++)
            {
                for (colom = 0; colom < v; colom++)
                {
                    if (board[row, colom] == 0)
                        if (CheckMove(player, opponent, row, colom))
                        {
                        return true;
                        }
                }
            }

            return false;
        }

        // Click Method
        private void ReversiPanel_MouseClick(object sender, MouseEventArgs e)
        {
            ReversiPanel.Invalidate();

            if (this.board[CalcColom(e.X), CalcRow(e.Y)] == 0)
            {
                // For player 2
                if (beurt % 2 == 0 && !checkBoxBot.Checked)
                {
                    if (AvailableMoves(2, 1)) // Check whether a move is even possible for the player
                    {
                        if (CheckMove(2, 1, CalcColom(e.X), CalcColom(e.Y))) // Check whether it is a valid move
                        {
                            // Player 2 makes move
                            this.board[CalcColom(e.X), CalcRow(e.Y)] = 2;
                            CheckClosedIn(2, 1, CalcColom(e.X), CalcColom(e.Y));
                            labelReferee.Text = "Player 2 created a stone in box " + (CalcColom(e.X) + 1) + "," + (CalcRow(e.Y) + 1);
                            labelReferee.ForeColor = Color.Black;
                            beurt++;
                            Help.Color = Color.White;
                            help = 0;

                        }
                        else // Move not valid
                        {
                            labelReferee.ForeColor = Color.Red;
                            labelReferee.Text = "Oops, this move is invalid!";
                        }
                    }
                }
                // For player 1
                else if (beurt % 2 == 1)
                {
                    if (AvailableMoves(1, 2)) // Check whether a move is even possible for the player
                    {
                        if (CheckMove(1, 2, CalcColom(e.X), CalcColom(e.Y))) // Check whether it is a valid move
                        {
                            // Player 1 makes move
                            this.board[CalcColom(e.X), CalcRow(e.Y)] = 1;
                            CheckClosedIn(1, 2, CalcColom(e.X), CalcColom(e.Y));
                            labelReferee.Text = "Player 1 created a stone in box " + (CalcColom(e.X) + 1) + "," + (CalcRow(e.Y) + 1);
                            labelReferee.ForeColor = Color.Black;
                            beurt++;
                            Help.Color = Color.White;
                            help = 0;
                        }
                        else // Move not valid
                        {
                            labelReferee.ForeColor = Color.Red;
                            labelReferee.Text = "Oops, this move is invalid!";
                        }
                    }
                }
            }
            if (beurt % 2 == 0 && checkBoxEasy.Checked && AvailableMoves(2, 1)) // If Easybot is selected, turn on the easy bot
            {
                MoveBotEasy();
            }
            if (beurt % 2 == 0 && checkBoxHard.Checked && AvailableMoves(2, 1)) // If Hardbot is selected, turn on the hard bot
            {
                MoveBotHard();
            }
            Checkscore(); // Checks the score every time the stones get changed
            Turn(); // Goes to next turn and says who's turn it is, also checks whether there is a winner
        }

        // Start New Game
        private void StartButton_Click(object sender, EventArgs e)
        { // Resets the standard values of the game
            beurt = 0; 
            labelPlayer1Score.Text = 2.ToString();
            labelPlayer2Score.Text = 2.ToString();

            if (BoardSize.SelectedIndex  >= 0) // If a non-standard boardsize is wanted, change the size
            {
                v = int.Parse((string)BoardSize.SelectedItem);
            }

            // If a player wants a custom colour, change their colour
            if (kleurPlayer1.SelectedIndex >= 0)
            {
                colorP1 = colorsP1[kleurPlayer1.SelectedIndex];
            }

            if (kleurPlayer2.SelectedIndex >= 0)
            {
                colorP2 = colorsP2[kleurPlayer2.SelectedIndex];
            }

            label3.ForeColor = colorP1;
            labelPlayer1Score.ForeColor = colorP1;

            label4.ForeColor = colorP2;
            labelPlayer2Score.ForeColor = colorP2;

            // Applies the change of boardsize and colours
            AssignBoardArray();
            ReversiPanel.Invalidate();

            // Activates the first move for the bot
            if (checkBoxBot.Checked && checkBoxEasy.Checked || checkBoxHard.Checked)
            {
                MoveBotEasy(); // Randomized first move for the hard bot and normal move for the easy bot
                label4.Text = "Bot";
            }

            // Making sure the singeplayer button is clicked
            if (!checkBoxBot.Checked && checkBoxHard.Checked || checkBoxEasy.Checked)
            {
                labelReferee.ForeColor = Color.Red;
                labelReferee.Text = "Activate Singeplayer before choosing difficulty.";
            }

            // Making sure a difficulty button is clicked
            if (checkBoxBot.Checked && !(checkBoxHard.Checked || checkBoxEasy.Checked))
            {
                labelReferee.ForeColor = Color.Red;
                labelReferee.Text = "Choose bot difficulty.";
            }
        }

        // Method to Check Score
        private void Checkscore()
        {
            int row, colom, score1 = 0, score2 = 0;

            for (row = 0; row < v; row++)
            {
                for (colom = 0; colom < v; colom++)
                {
                    if (board[row, colom] == 1)
                        score1++;
                    else if (board[row, colom] == 2)
                        score2++;
                }
            }
            scoreplayer1 = score1;
            scoreplayer2 = score2;

            labelPlayer1Score.Text = scoreplayer1.ToString();
            labelPlayer2Score.Text = scoreplayer2.ToString();
        }

        // Checks if wanted move is valid
        private bool CheckMove(int player, int opponent,int row, int colom)
        {
            if (CheckDirection(player, opponent, row, colom, 0, -1))
                return true;
            else if (CheckDirection(player, opponent, row, colom, -1, 0))
                return true;
            else if (CheckDirection(player, opponent, row, colom, 0, 1))
                return true;
            else if (CheckDirection(player, opponent, row, colom, 1, 0))
                return true;
            else if (CheckDirection(player, opponent, row, colom, -1, -1))
                return true;
            else if (CheckDirection(player, opponent, row, colom, 1, 1))
                return true;
            else if (CheckDirection(player, opponent, row, colom, 1, -1))
                return true;
            else if (CheckDirection(player, opponent, row, colom, -1, 1))
                return true;

            return false;
        }

        // Method to check move in direction
        private bool CheckDirection(int player, int opponent, int row, int colom, int dx, int dy)
        {
            int t;

            if (colom + dx >= 0 && colom + dx < v && row + dy >= 0 && row + dy < v && board[row + dy, colom + dx] == opponent) // Checks whether a stone of the opponent is next to the 'wanted' move of the player
            {
                for (t = 1; t < v; t++)
                {
                    if (row + (t * dy) < 0 || row + (t * dy) > (v - 1) || colom + (t * dx) < 0 || colom + (t * dx) > (v - 1)) // Breaks the loop if it goes out of the board
                    {
                        break;
                    }
                    else if (board[row + (t * dy), colom + (t * dx)] == player) // Gives the method a true value if the move closes in an opponent
                    {
                        return true;
                    }
                    else if (board[row + (t * dy), colom + (t * dx)] == 0) // Breaks the loop if it encounters a empty square of the board
                    {
                        break;
                    }
                }
            }
            return false;
        }

        // Method to Check if Stone is closed in and if it is the closed in stones get changed colour
        private void CheckClosedIn(int player, int opponent, int row, int colom)
        {
            if (CheckDirection(player, opponent, row, colom, 0, -1))
            {
                ChangeColor(player, opponent, row, colom, 0, -1);
            }
            if (CheckDirection(player, opponent, row, colom, -1, 0))
            {
                ChangeColor(player, opponent, row, colom, -1, 0);
            }
            if (CheckDirection(player, opponent, row, colom, 0, 1))
            {
                ChangeColor(player, opponent, row, colom, 0, 1);
            }
            if (CheckDirection(player, opponent, row, colom, 1, 0))
            {
                ChangeColor(player, opponent, row, colom, 1, 0);
            } 
            if (CheckDirection(player, opponent, row, colom, -1, -1))
            {
                ChangeColor(player, opponent, row, colom, -1, -1);
            } 
            if (CheckDirection(player, opponent, row, colom, 1, 1))
            {
                ChangeColor(player, opponent, row, colom, 1, 1);
            }
            if (CheckDirection(player, opponent, row, colom, 1, -1))
            {
                ChangeColor(player, opponent, row, colom, 1, -1);
            } 
            if (CheckDirection(player, opponent, row, colom, -1, 1))
            {
                ChangeColor(player, opponent, row, colom, -1, 1);
            }   
        }

        //Method to Change Color when Closed In
        private void ChangeColor(int player, int opponent, int row, int colom, int dx, int dy)
        {
            int t;
            for (t = 1; t < v; t++)
            {
                if (row + (t * dy) < 0 || row + (t * dy) > (v - 1) || colom + (t * dx) < 0 || colom + (t * dx) > (v - 1)) // Breaks the loop if it goes out of the board
                {
                    break;
                }
                else if (board[row + (t * dy), colom + (t * dx)] == player) // Breaks the loop when it encounters the players own stone
                {
                    break;
                }
                else if (board[row + (t * dy), colom + (t * dx)] == opponent) // Changes all the opponents stones to the players stones
                {
                    board[row + (t * dy), colom + (t * dx)] = player;
                }
                else if (board[row + (t * dy), colom + (t * dx)] == 0) // Breaks the loop if it encounters a empty square of the board
                {
                    break;
                }
            }
        }

        // Help Button
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            help++;
            ReversiPanel.Invalidate();
            if (help % 2 != 0)
            {
                Help.Color = Color.Gray;
            }
            else
            {
                Help.Color = Color.White;
            }

        }

        //Displays whose turn it is
        private void Turn()
        {
            // Checks if there is a winner
            if (AvailableMoves(2, 1) == false && AvailableMoves(1, 2) == false)
            {

                if (scoreplayer1 > scoreplayer2) // Player 1 wins
                {
                    labelTurnPlayer.Text = "Player 1 WINS!";
                    labelTurnPlayer.ForeColor = colorP1;
                    labelReferee.Text = "WE HAVE A WINNER, CONGRATULATIONS PLAYER 1! ";
                }
                else if ((scoreplayer1 < scoreplayer2) && !checkBoxBot.Checked) // Player 2 wins
                {
                    labelTurnPlayer.Text = "Player 2 WINS!";
                    labelTurnPlayer.ForeColor = colorP2;
                    labelReferee.Text = "WE HAVE A WINNER, CONGRATULATIONS PLAYER 2!";
                }
                else if ((scoreplayer1 < scoreplayer2) && checkBoxBot.Checked) // Bot wins
                {
                    labelTurnPlayer.Text = "Bot WINS!";
                    labelTurnPlayer.ForeColor = colorP2;
                    labelReferee.Text = "SHAME ON YOU, YOU LOST TO A BOT!";
                }
                else if (scoreplayer1 == scoreplayer2) // No one wins
                {
                    labelTurnPlayer.Text = "IT'S A TIE!";
                    labelTurnPlayer.ForeColor = Color.Black;
                    labelReferee.Text = "IT'S A TIE!";
                }
            }

            // Checks who's turn it is
            else if (beurt % 2 == 0 && !checkBoxBot.Checked)
            {
                if (AvailableMoves(2, 1))
                {
                    labelTurnPlayer.Text = "Player 2, it's your turn!";
                }
                else if (!AvailableMoves(2, 1))
                {
                    labelReferee.Text = "Player 2 cannot make a move. Click to continue.";
                    beurt++;
                }
            }
            else if (beurt % 2 == 0 && checkBoxBot.Checked)
            {
                if (AvailableMoves(2, 1))
                {
                    labelTurnPlayer.Text = "Bot, it's your turn!";
                }
                else if (!AvailableMoves(2, 1))
                {
                    labelReferee.Text = "The bot cannot make a move. Click to continue.";
                    beurt++;
                }
            }
            else if (beurt % 2 == 1)
            {
                if (AvailableMoves(1, 2))
                {
                    labelTurnPlayer.Text = "Player 1, it's your turn!";
                }
                else if (!AvailableMoves(1, 2))
                {
                    labelReferee.Text = "Player 1 cannot make a move. Click to continue.";
                    beurt++;
                }
            }
        }

        // Easy (random) Bot Method. It is async because of a wanted delay before the bot makes its move
        async private void MoveBotEasy()
        {
            int row, colom, move;
            List<int> ListRow = new List<int>();
            List<int> ListColom = new List<int>();
            Random random = new Random();

            if (!AvailableMoves(2, 1))
            {
                beurt++;
            }
            else
            {
                for (row = 0; row < v; row++)
                {
                    for (colom = 0; colom < v; colom++)
                    {
                        if (CheckMove(2, 1, row, colom) && board[row, colom] == 0)
                        {
                            await Task.Delay(150); // Delays the bots move
                            ListRow.Add(row);
                            ListColom.Add(colom);
                        }
                    }
                }
            }

            move = random.Next(ListRow.Count); // Makes the bot choose a random available move
            board[ListRow[move], ListColom[move]] = 2; // Makes the actual move (places stone)
            CheckClosedIn(2, 1, ListRow[move], ListColom[move]); // Change the closed in stones to bots stones

            ReversiPanel.Invalidate(); // Shows the move of the bot
            Checkscore(); // Updates the new score of the bot

            labelReferee.ForeColor = Color.Black;
            labelReferee.Text = "Bot created a stone in box " + (ListRow[move] + 1) + "," + (ListColom[move] + 1);

            beurt++;
        }

        // Hard (most slammed stones) Bot Method. It is async because of a wanted delay before the bot makes its move
        async private void MoveBotHard()
        {
            int row, colom, move = 0, m, maxslams = 0;
            List<int> ListRow = new List<int>();
            List<int> ListColom = new List<int>();

            if (!AvailableMoves(2, 1))
            {
                beurt++;
            }
            else
            {
                for (row = 0; row < v; row++)
                {
                    for (colom = 0; colom < v; colom++)
                    {
                        if (CheckMove(2, 1, row, colom) && board[row, colom] == 0)
                        {
                            await Task.Delay(150); // Delays the bots move
                            ListRow.Add(row);
                            ListColom.Add(colom);
                        }
                    }
                }
            }

            // Loops through available moves and counts the possible stones slammed per move
            for (m = 0; m < ListRow.Count; m++)
            {
                int slams = 0;
                slams += CountSlams(2, 1, ListRow[m], ListColom[m], 0, -1);
                slams += CountSlams(2, 1, ListRow[m], ListColom[m], -1, 0);
                slams += CountSlams(2, 1, ListRow[m], ListColom[m], 0, 1);
                slams += CountSlams(2, 1, ListRow[m], ListColom[m], 1, 0);
                slams += CountSlams(2, 1, ListRow[m], ListColom[m], -1, -1);
                slams += CountSlams(2, 1, ListRow[m], ListColom[m], 1, 1);
                slams += CountSlams(2, 1, ListRow[m], ListColom[m], 1, -1);
                slams += CountSlams(2, 1, ListRow[m], ListColom[m], -1, 1);

                // Updates best possible move from the available moves
                if (slams > maxslams)
                {
                    maxslams = slams;
                    move = m;
                }
            }

            board[ListRow[move], ListColom[move]] = 2; // Makes the actual move (places stone)
            CheckClosedIn(2, 1, ListRow[move], ListColom[move]); // Change the closed in stones to bots stones

            ReversiPanel.Invalidate(); // Shows the move of the bot
            Checkscore(); // Updates the new score of the bot

            labelReferee.ForeColor = Color.Black;
            labelReferee.Text = "Bot created a stone in box " + (ListRow[move] + 1) + "," + (ListColom[move] + 1);

            beurt++;
        }

        //Method to count the slams
        private int CountSlams(int player, int opponent, int row, int colom, int dx, int dy)
        {
            int t, slams = 0;
            for (t = 1; t < v; t++)
            {
                if (row + (t * dy) < 0 || row + (t * dy) > (v - 1) || colom + (t * dx) < 0 || colom + (t * dx) > (v - 1)) // Breaks the loop if it goes out of the board
                {
                    break;
                }
                else if (board[row + (t * dy), colom + (t * dx)] == player) // Breaks the loop when it encounters the bots own stone
                {
                    break;
                }
                else if (board[row + (t * dy), colom + (t * dx)] == opponent) // Adds 1 to amount of slams when encountering opponent
                {
                    slams++;
                }
                else if (board[row + (t * dy), colom + (t * dx)] == 0) // Breaks the loop if it encounters a empty square of the board
                {
                    break;
                }
            }
            return slams;
        }

    }
}


//Gemaakt door Sam Groen & Thijmen van der Meijden