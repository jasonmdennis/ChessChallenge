using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.BRL
{
    abstract class Pieces
    {
        protected static int boardEdge = 8;

        abstract public string GetMoves(string startPosition);

        protected string standardHorizontalMoves(string startPosition, string moves)
        {
            Tuple<int, int> minMax = getHorizontalPosition(startPosition);
            Tuple<int, int> position = getPosition(startPosition);
            for (int i = 1; i <= minMax.Item1; i++)
            {
                moves = formatPosition(i, position.Item2, moves);
            }
            for (int i = minMax.Item2 + 1; i <= boardEdge; i++)
            {
                moves = formatPosition(i, position.Item2, moves);
            }
            return moves;
        }

        protected string standardVerticalMoves(string startPosition, string moves)
        {
            Tuple<int, int> minMax = getVerticalPosition(startPosition);
            Tuple<int, int> position = getPosition(startPosition);
            for (int i = 1; i <= minMax.Item1; i++)
            {
                moves = formatPosition(position.Item1, i, moves);
            }
            for (int i = minMax.Item2 + 1; i <= boardEdge; i++)
            {
                moves = formatPosition(position.Item1, i, moves);
            }

            return moves;
        }

        protected string standardDiagonalMoves(string startPosition, string moves)
        {
            Tuple<int, int> vertMinMax = getVerticalPosition(startPosition);
            Tuple<int, int> hozMinMax = getHorizontalPosition(startPosition);
            Tuple<int, int> position = getPosition(startPosition);
            int columnCounter = position.Item1-1;
            int rowCounter = 1;
            for (int i = position.Item1-1; i >0; i--)
            {
                if(position.Item2 + rowCounter <=boardEdge)
                    moves = formatPosition(columnCounter, position.Item2 + rowCounter, moves);
                if(position.Item2 - rowCounter >0)   
                    moves = formatPosition(columnCounter, position.Item2 - rowCounter, moves);
                columnCounter--;
                rowCounter++;
            }

            columnCounter = position.Item2 + 1;
            rowCounter = 1;
            for (int i = position.Item2+1; i <= boardEdge; i++)
            {
                if(position.Item2 + rowCounter <= boardEdge)
                    moves = formatPosition(columnCounter, position.Item2 + rowCounter, moves);

                if(position.Item2 - rowCounter > 0)
                    moves = formatPosition(columnCounter, position.Item2 - rowCounter, moves);
                columnCounter++;
                rowCounter++;
            }

            return moves;
        }

        protected abstract void customVerticalMoves();
        protected abstract void customDiagonalMoves();
        protected abstract void customHorizontalMoves();

        protected static Tuple<int, int> getPosition(string startPosition)
        {
            
            //the position is alwasy letter + row;
            char[] position = startPosition.ToCharArray();

            int currentColumn = Convert.ToInt32(Char.ToLower(position[0]))-96;
            int currentRow = Convert.ToInt32(startPosition.Substring(1, 1));

            return Tuple.Create(currentColumn, currentRow);

        }

        protected static string formatPosition(int column, int row, string moves)
        {
            if(moves.Length>0)
            {
                moves += ", ";
            }

            moves += buildPosition(column, row);

            return moves;

        }

        private static string buildPosition(int column, int row)
        {
            char col = (char)(column + 96);
            string position = col.ToString() + row.ToString();
            return position;
        }

        protected static Tuple<int, int> getHorizontalPosition(string startPosition)
        {
            int currentPosition = getPosition(startPosition).Item1;

            if (currentPosition > 1)
            {
                return Tuple.Create(currentPosition-1, boardEdge - currentPosition);
            }
            else
            {
                return Tuple.Create(1, boardEdge - currentPosition);
            }
        }

        protected static Tuple<int, int> getVerticalPosition(string startPosition)
        {
            int currentRow = getPosition(startPosition).Item2;

            if (currentRow > 1)
            {
                return Tuple.Create(currentRow - 1, boardEdge - currentRow);
            }
            else
            {
                return Tuple.Create(1, boardEdge - currentRow);
            }
        }
    }
}
