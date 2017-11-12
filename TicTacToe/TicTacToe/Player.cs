using System;
using System.Threading;

namespace TicTacToe
{
    public class Player
    {
        private string name;
        private char marker; // 'X' or 'O'
        private bool human;

        Board b;
        AI mm;

        public Player() { }
        public Player(string name, bool human, Board b)
        {
            this.name = name;
            this.marker = human ? 'X' : 'O';
            this.human = human;
            this.b = b;
            this.mm = new AI(this.b);
        }

        public string GetName()
        {
            return name;
        }
        public char GetMarker()
        {
            return marker;
        }
        public bool IsHuman()
        {
            return human;
        }
        public void GetPlayerMove() //get the currentPlayer Move
        {
            if (this.IsHuman())
            {
                GetHumanMove();
            }
            else
            {
                GetComputerMove();
            }
        }

        private void GetHumanMove()
        {
            bool moveOk = true;

            Cell cell = new Cell();
            string move;

            do
            {
                if (!moveOk)
                {
                    Console.WriteLine("Cell already filled...");
                }
                do
                {
                    Console.Write(this + ":");
                    move = Console.ReadLine();
                    move = move.ToUpper();

                    switch (move)
                    {
                        case "A1":
                            {
                                cell.x = 0; cell.y = 0;
                                break;
                            }
                        case "A2":
                            {
                                cell.x = 1; cell.y = 0;
                                break;
                            }
                        case "A3":
                            {
                                cell.x = 2; cell.y = 0;
                                break;
                            }
                        case "B1":
                            {
                                cell.x = 0; cell.y = 1;
                                break;
                            }
                        case "B2":
                            {
                                cell.x = 1; cell.y = 1;
                                break;
                            }
                        case "B3":
                            {
                                cell.x = 2; cell.y = 1;
                                break;
                            }
                        case "C1":
                            {
                                cell.x = 0; cell.y = 2;
                                break;
                            }
                        case "C2":
                            {
                                cell.x = 1; cell.y = 2;
                                break;
                            }
                        case "C3":
                            {
                                cell.x = 2; cell.y = 2;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong Move...");
                                break;
                            }
                    }
                }
                while (move != "A1" && move != "A2" && move != "A3" &&
                   move != "B1" && move != "B2" && move != "B3" &&
                   move != "C1" && move != "C2" && move != "C3");


                moveOk = b.PlaceMove(cell, Board.human);
            }
            while (!moveOk);
        }
        private void GetComputerMove()
        {
            mm.MinMax(0, this.GetMarker());
            b.PlaceMove(b.computerMove, Board.computer);

            if (b.computerMove.Equals(new Cell(0, 0)))
            {
                Console.WriteLine(this + ": A1");

            }
            else if (b.computerMove.Equals(new Cell(1, 0)))
            {
                Console.WriteLine(this + ": A2");
            }
            else if (b.computerMove.Equals(new Cell(2, 0)))
            {
                Console.WriteLine(this + ": A3");
            }
            else if (b.computerMove.Equals(new Cell(0, 1)))
            {
                Console.WriteLine(this + ": B1");
            }
            else if (b.computerMove.Equals(new Cell(1, 1)))
            {
                Console.WriteLine(this + ": B2");
            }
            else if (b.computerMove.Equals(new Cell(2, 1)))
            {
                Console.WriteLine(this + ": B3");
            }
            else if (b.computerMove.Equals(new Cell(0, 2)))
            {
                Console.WriteLine(this + ": C1");
            }
            else if (b.computerMove.Equals(new Cell(1, 2)))
            {
                Console.WriteLine(this + ": C2");
            }
            else if (b.computerMove.Equals(new Cell(2, 2)))
            {
                Console.WriteLine(this + ": C3");
            }
            Thread.Sleep(2000);
        }

        public override string ToString()
        {
            return this.GetName() + "(" + this.GetMarker() + ")";
        }
    }
}
