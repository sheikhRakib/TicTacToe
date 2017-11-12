using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        public Player HUMAN;
        public Player COMPUTER;

        public static readonly char noPlayer = '?';
        public static readonly char computer = 'O';
        public static readonly char human = 'X';

        public char[,] gameBoard = { { '?', '?', '?' }, { '?', '?', '?' }, { '?', '?', '?' } };

        public Cell computerMove;

        public Board()
        {
            TITLE();
            this.HUMAN = new Player(PlayerName(), true, this);
            this.COMPUTER = new Player("computer", false, this);

            Console.WriteLine(this.HUMAN + " " + COMPUTER);
        }

        private string PlayerName()
        {
            Console.WriteLine("\nNote : Human always gets 'X' and Computer gets 'O'\n\n\n");
            Console.Write("Enter Player name : ");
            string name = Console.ReadLine(); //Read User Name

            return name;
        }
        public bool isGameOver()
        {
            return hasWon(computer) || hasWon(human) || getAvailableCells().Count == 0;
        }
        public bool hasWon(char player)
        {
            if ((gameBoard[0, 0] == gameBoard[1, 1] &&
                gameBoard[0, 0] == gameBoard[2, 2] &&
                 gameBoard[0, 0] == player) ||
                (gameBoard[0, 2] == gameBoard[1, 1] &&
                gameBoard[0, 2] == gameBoard[2, 0] &&
                 gameBoard[0, 2] == player))
            {
                return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if ((gameBoard[i, 0] == gameBoard[i, 1] &&
                gameBoard[i, 0] == gameBoard[i, 2] &&
                 gameBoard[i, 0] == player) ||
                   (gameBoard[0, i] == gameBoard[1, i] &&
                gameBoard[0, i] == gameBoard[2, i] &&
                 gameBoard[0, i] == player))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Cell> getAvailableCells()
        {
            List<Cell> availableCells = new List<Cell>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameBoard[i, j] == noPlayer)
                    {
                        availableCells.Add(new Cell(i, j));
                    }
                }
            }
            return availableCells;
        }

        public bool PlaceMove(Cell cell, char player)
        {
            if (gameBoard[cell.x, cell.y] != Board.noPlayer)
                return false;
            gameBoard[cell.x, cell.y] = player;
            return true;
        }
        private void TITLE()
        {
            Console.WriteLine("\t\t\t\tTIC TAC TOE\n\t\t\t\tversion 0.1\n");
        }

        public void display()
        {
            Console.Clear();
            TITLE();
            Console.WriteLine();

            Console.WriteLine("\t\t\t\t  A   B   C");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\t\t\t\t");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" ---");
                }
                Console.WriteLine();
                Console.Write("\t\t\t      ");
                Console.Write("{0} | ", i + 1);


                for (int j = 0; j < 3; j++)
                {
                    string value = "?";

                    if (gameBoard[i, j] == computer)
                        value = "O";
                    else if (gameBoard[i, j] == human)
                        value = "X";

                    Console.Write("{0} | ", value);
                }
                Console.WriteLine();
            }
            Console.Write("\t\t\t\t");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(" ---");
            }
            Console.WriteLine();
        }



        public void Start()
        {
            Console.Title = "Tic Tac Toe";
            display();

            Random ran = new Random();
            while (!isGameOver())
            {
                HUMAN.GetPlayerMove();
                display();

                if (isGameOver())
                {
                    break;
                }
                COMPUTER.GetPlayerMove();
                display();

                if (isGameOver())
                {
                    break;
                }
            }

            if (hasWon(Board.computer))
            {
                Console.WriteLine("You lost...");
            }
            else if (hasWon(Board.human))
            {
                Console.WriteLine("You won...");
            }
            else
            {
                Console.WriteLine("Match Draw...");
            }
        }
    }
}
