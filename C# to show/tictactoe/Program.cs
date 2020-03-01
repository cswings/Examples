using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace tictactoe
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int files = 2;
            while (files > 0)
            { 
          
                int gamesToPlay = 100;
                Board b = new Board();
                b.games = 0;
                Players player1 = new Players(1);
                Players player2 = new Players(2);

                while (gamesToPlay > 0)
                {
                    b.StartGame();
                    int movesToDo = 8;
                    while (movesToDo > 0)
                    {
                        b.TakeTurn(player2);
                        movesToDo--;
                        b.TakeTurn(player1);
                        movesToDo--;
                    }
                    b.CheckThemOut();
                    gamesToPlay--;
                }
                b.PrintOut(files);
                files--;
            }
            
        }

    }
    class Board
    {
        private int[] tictactoe = new int[10];
        private int[] corners = { 1, 3, 7, 9 };
        private int[] others = { 2, 4, 6, 8 };
        private readonly int middle = 5;
        private List<int> player1Moves = new List<int>();
        private List<int> player2Moves = new List<int>();
        private List<int> totalMoves = new List<int>();

        private List<int> p1TotalMoves = new List<int>();
        private List<int> p2TotalMoves = new List<int>();

        private List<string> whatsHappening = new List<string>();
        private int turns = 0;

        private int spaces = 9;
        public int games = 0;
        private string p1First;
        private string p2First;

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        public int p1wins = 0;
        public int p2wins = 0;
        public int ties = 0;

        private readonly int[][] winningSpots = new int[8][];

        
        public Board()
        {
            
        }

        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        public void PrintOut(int whichOne)
        {
            
            //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string folder = "tictactoe";
            //int start = path.IndexOf(folder);
            ////string path2 = path.Substring(0, start - 1) + "Game1.txt";

            if(whichOne == 2)
            {
                FileStream stream = new FileStream("Game1.txt", FileMode.Create);

                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine("Craig Swingle");
                    writer.WriteLine($"Player 1 won {p1wins} games Player 2 won {p2wins} games there were {ties} ties");
                    foreach (string line in whatsHappening)
                    {
                        writer.WriteLine(line);
                    }
                }
                   
            }
            else
            {
                FileStream stream = new FileStream("Game2.txt", FileMode.Create);

                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine("Craig Swingle");
                    writer.WriteLine($"Player 1 won {p1wins} games Player 2 won {p2wins} games there were {ties} ties");
                    foreach (string line in whatsHappening)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
        public void CheckThemOut()
        {   int play1 = 1;
            int play2 = 2;
            int win = 0;
            foreach(int[] row in winningSpots)
            {
                int _count1 = 0;
                int _count2 = 0;
                foreach (int num in row)
                {
                    if(tictactoe[num] == play1)
                    {
                        _count1++;
                    }
                    else if(tictactoe[num] == play2)
                    {
                        _count2++;
                    }
                }
                if(_count1 == 3)
                {
                    p1wins++;
                    win = 1;
                    break;
                }
                else if(_count2 == 3)
                {
                    p2wins++;
                    win = 1;
                    break;
                }
            }
            if(win != 1)
            {
                ties++;
            }
            foreach(int move in player1Moves)
            {
                p1TotalMoves.Add(move);
            }
            foreach(int move in player2Moves)
            {
                p2TotalMoves.Add(move);
            }
            if (games > 1 && games < 100)
            { whatsHappening.Add($"{games}\t\t{p1First}\t\t\t{p2First}\t\t2"); }
        }

        public void StartGame()
        {
            p1First = "";
            p2First = "";
            int[] row1Win = { 1, 2, 3 };
            int[] row2Win = { 4, 5, 6 };
            int[] row3Win = { 7, 8, 9 };
            int[] col1Win = { 1, 4, 7 };
            int[] col2Win = { 2, 5, 8 };
            int[] col3Win = { 3, 6, 9 };
            int[] diagLRWin = { 1, 5, 9 };
            int[] diagRLWin = { 3, 5, 7 };
            winningSpots[0] = row1Win;
            winningSpots[1] = row2Win;
            winningSpots[2] = row3Win;
            winningSpots[3] = col1Win;
            winningSpots[4] = col2Win;
            winningSpots[5] = col3Win;
            winningSpots[6] = diagLRWin;
            winningSpots[7] = diagRLWin;
            turns = 0;
            if(player1Moves.Count() > 1 && player2Moves.Count() > 1)
            {
                player1Moves.Clear();
                player2Moves.Clear();
            }
            tictactoe = new int[10];

            int start = RandomNumber(1, 9);
            games++;
            PlaceMark(start, 1);
            p1First = start.ToString();            
            
            totalMoves.Add(start);
            player1Moves.Add(start);
            spaces = 8;
        }
       

        private void PlaceMark(int where, int who)
        {
            switch (where)
            {
                case 1:
                    tictactoe[1] = who;
                    break;
                case 2:
                    tictactoe[2] = who;
                    break;
                case 3:
                    tictactoe[3] = who;
                    break;
                case 4:
                    tictactoe[4] = who;
                    break;
                case 5:
                    tictactoe[5] = who;
                    break;
                case 6:
                    tictactoe[6] = who;
                    break;
                case 7:
                    tictactoe[7] = who;
                    break;
                case 8:
                    tictactoe[8] = who;
                    break;
                case 9:
                    tictactoe[9] = who;
                    break;
            }
            turns++;
            if(turns == 2)
            {
                p2First = where.ToString();
            }
            if (games == 1 || games == 100)
            {
                whatsHappening.Add($"Player{who} goes {where}");
            }
            if(games == 2 && turns < 2)
            {
                whatsHappening.Add("Game\tPlayer1FirstMove\tPlayer2FirstMove\tWinner");
            }

            
            spaces--;
        }
       
        public void TakeTurn(Players p)
        {
            if (spaces > 0)
            {
                int player = p.WhichOne();                
                int moveCount = totalMoves.Count;
                //find last move in moves
                int lastMove = totalMoves[moveCount - 1];
                int spotChosen = 0;
                //start with checking if middle is open
                if (corners.Contains(lastMove) && tictactoe[middle] == 0
                    || others.Contains(lastMove) && tictactoe[middle] == 0)
                {
                    //if a corner is taken, take middle
                    spotChosen = 5;
                    PlaceMark(5, player);

                }
                else if (tictactoe[middle] != 0)
                {                      
                    int whereToGo = CheckWin(player);
                    spotChosen = whereToGo;
                    PlaceMark(spotChosen, player);
                }
                if (player == 1)
                {
                    player1Moves.Add(spotChosen);
                }
                else
                {
                    player2Moves.Add(spotChosen);
                }
                totalMoves.Add(spotChosen);
            }
            
        }

        public int CheckWin(int player)
        {
            //int otherPlayer = 0;
            int win = 0;
            int myLast = 0;
            int theirLast = 0;
            int tried = 0;
            // int rowWithPlayerMost = 0;
            // int rowWithOtherPlayerMost = 0;
            if (player == 1)
            {
                //otherPlayer = 2;
                var my1Moves = player1Moves;
                //check player2Moves
                var p2Moves = player2Moves;

                if (my1Moves.Count() > 0)
                {
                    myLast = my1Moves.Last();
                }
                if(p2Moves.Count() > 0)
                {
                    theirLast = p2Moves.Last();
                    if(p2Moves.Count()>1)
                    {
                        if (spaces <= 2)
                        {
                            //check for last 2 places
                            for (int i = 1; i < tictactoe.Count(); i++)
                            {
                                if (tictactoe[i] == 0)
                                {
                                    return i;
                                }
                            }
                        }
                        foreach (int[] row in winningSpots)
                        {
                            var come = row.Except(p2Moves);
                            //check that player does or does not intersect
                            var no = row.Intersect(p2Moves);
                            if (no.Count() == 2 && come.Count() > 0)
                            {
                                if (tictactoe[come.Last()] == 0)
                                {   //take that spot
                                    return come.Last();
                                }                                
                            }
                            tried = 1;
                        }
                    }
                }
                int diff = Math.Abs(theirLast - myLast);

                //take last and try to add to it
                if (tried == 0)
                {
                    switch (myLast)
                    {
                        //if not 5, then its already taken
                        case 1:
                            //take a row
                            if (tictactoe[2] == 0)
                            {
                                win = 2;
                            }
                            else
                            {
                                win = 4;
                            }
                            break;
                        case 2:
                            if (tictactoe[1] == 0)
                            {
                                win = 1;
                            }
                            else
                            {
                                win = 3;
                            }
                            break;
                        case 3:
                            if (tictactoe[2] == 0)
                            {
                                win = 2;
                            }
                            else
                            {
                                win = 6;
                            }
                            break;
                        case 4:
                            if (tictactoe[1] == 0)
                            {
                                win = 1;
                            }
                            else
                            {
                                win = 7;
                            }
                            break;
                        case 5:
                            if (tictactoe[1] == 0)
                            {
                                win = 1;
                            }
                            else if (tictactoe[3] == 0)
                            {
                                win = 3;
                            }
                            else if (tictactoe[7] == 0)
                            {
                                win = 7;
                            }
                            else if (tictactoe[9] == 0)
                            {
                                win = 9;
                            }
                            break;
                        case 6:
                            if (tictactoe[3] == 0)
                            {
                                win = 3;
                            }
                            else
                            {
                                win = 9;
                            }
                            break;
                        case 7:
                            if (tictactoe[4] == 0)
                            {
                                win = 4;
                            }
                            else
                            {
                                win = 8;
                            }
                            break;
                        case 8:
                            if (tictactoe[7] == 0)
                            {
                                win = 7;
                            }
                            else
                            {
                                win = 9;
                            }
                            break;
                        case 9:
                            if (tictactoe[6] == 0)
                            {
                                win = 6;
                            }
                            else
                            {
                                win = 8;
                            }
                            break;
                        default:
                            if (theirLast == 5)
                            {
                                win = 1;
                            }
                            break;
                    }
                }
                else
                {
                    //go for an open place
                    if(tictactoe[2] == 0)
                    {
                        win = 2;
                    }
                    else if(tictactoe[8] == 0)
                    {
                        win = 8;
                    }
                    else if(tictactoe[9] == 0)
                    {
                        win = 9;
                    }
                }
                
            }
            else
            {
                //otherPlayer = 1;
                //check player1Moves
                var my2Moves = player2Moves;
                //check player2Moves
                var p1Moves = player1Moves;

                if (my2Moves.Count > 0)
                {
                    myLast = my2Moves.Last();
                }
                if (p1Moves.Count() > 0)
                {
                    theirLast = p1Moves.Last();
                }

                if (p1Moves.Count() > 0)
                {
                    theirLast = p1Moves.Last();
                    if (p1Moves.Count() > 1)
                    {
                        if (spaces <= 2)
                        {
                            //check for last 2 places
                            for (int i = 1; i < tictactoe.Count(); i++)
                            {
                                if (tictactoe[i] == 0)
                                {
                                    return i;
                                }
                            }
                        }
                        foreach (int[] row in winningSpots)
                        {
                            var come1 = row.Except(p1Moves);
                            //check that player does or does not intersect
                            var no = row.Intersect(p1Moves);
                            if (no.Count() == 2)
                            {
                                if (tictactoe[come1.Last()] == 0)
                                {   //take that spot
                                    return come1.Last();
                                }                                
                            }
                            tried = 1;
                        }
                    }
                }

                int diff = Math.Abs(theirLast - myLast);
                if (tried == 0)
                {
                    switch (myLast)
                    {
                        //if not 5, then its already taken
                        case 1:
                            //take a row
                            if (tictactoe[2] == 0)
                            {
                                win = 2;
                            }
                            else
                            {
                                win = 4;
                            }
                            break;
                        case 2:
                            if (tictactoe[1] == 0)
                            {
                                win = 1;
                            }
                            else
                            {
                                win = 3;
                            }
                            break;
                        case 3:
                            if (tictactoe[2] == 0)
                            {
                                win = 2;
                            }
                            else
                            {
                                win = 6;
                            }
                            break;
                        case 4:
                            if (tictactoe[1] == 0)
                            {
                                win = 1;
                            }
                            else
                            {
                                win = 7;
                            }
                            break;
                        case 5:
                            if (tictactoe[1] == 0)
                            {
                                win = 1;
                            }
                            else if (tictactoe[3] == 0)
                            {
                                win = 3;
                            }
                            else if (tictactoe[7] == 0)
                            {
                                win = 7;
                            }
                            else if (tictactoe[9] == 0)
                            {
                                win = 9;
                            }
                            break;
                        case 6:
                            if (tictactoe[3] == 0)
                            {
                                win = 3;
                            }
                            else
                            {
                                win = 9;
                            }
                            break;
                        case 7:
                            if (tictactoe[4] == 0)
                            {
                                win = 4;
                            }
                            else
                            {
                                win = 8;
                            }
                            break;
                        case 8:
                            if (tictactoe[7] == 0)
                            {
                                win = 7;
                            }
                            else
                            {
                                win = 9;
                            }
                            break;
                        case 9:
                            if (tictactoe[6] == 0)
                            {
                                win = 6;
                            }
                            else
                            {
                                win = 8;
                            }
                            break;
                        default:
                            if (theirLast == 5)
                            {
                                win = 1;
                            }
                            break;
                    }
                }
                else
                {
                    if (tictactoe[2] == 0)
                    {
                        win = 2;
                    }
                    else if (tictactoe[8] == 0)
                    {
                        win = 8;
                    }
                    else if (tictactoe[9] == 0)
                    {
                        win = 9;
                    }
                }

               
            }
            return win;
        }

         
    }
    class Players
    {
        private readonly int v;        

        public Players(int v)
        {
            this.v = v;
        }

        public int WhichOne()
        {
            return v;
        }
       

        
    }       
}
