using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class AI
    {
        private Board b;

        public AI(Board b)
        {
            this.b = b;
        }
        public int MinMax(int depth, char turn)
        {
            if (b.hasWon(Board.computer))
            {
                return 1;
            }
            if (b.hasWon(Board.human))
            {
                return -1;
            }

            List<Cell> availableCells = b.getAvailableCells();
            if (availableCells.Count == 0)
            {
                return 0;
            }

            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < availableCells.Count; i++)
            {
                Cell cell = availableCells[i];

                if (turn == Board.computer)
                {
                    b.PlaceMove(cell, Board.computer);
                    int currentScore = MinMax(depth + 1, Board.human);
                    max = Math.Max(currentScore, max);

                    if (currentScore >= 0)
                    {
                        if (depth == 0)
                        {
                            b.computerMove = cell;
                        }
                    }
                    if (currentScore == 1)
                    {
                        b.gameBoard[cell.x, cell.y] = Board.noPlayer;
                        break;
                    }
                    if (i == availableCells.Count - 1 && max < 0)
                    {
                        if (depth == 0)
                        {
                            b.computerMove = cell;
                        }
                    }
                }
                else if (turn == Board.human)
                {
                    b.PlaceMove(cell, Board.human);
                    int currentScore = MinMax(depth + 1, Board.computer);
                    min = Math.Min(currentScore, min);
                    if (min == -1)
                    {
                        b.gameBoard[cell.x, cell.y] = Board.noPlayer;
                        break;
                    }
                }
                b.gameBoard[cell.x, cell.y] = Board.noPlayer;
            }
            return turn == Board.computer ? max : min;
        }
    }

}
