using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.BRL
{
    class Knight : Pieces
    {
        private static Tuple<int, int> verticalMoveSize = Tuple.Create(1, 2);
        private static Tuple<int, int> horizontalMoveSize = Tuple.Create(2, 1);
        private static Tuple<int, int> position = Tuple.Create(0, 0);
        string moves = "";

        public override string GetMoves(string startPosition)
        {
            position = getPosition(startPosition);

            customHorizontalMoves();
            customVerticalMoves();
            
            return moves;
        }

        protected override void customDiagonalMoves()
        {
            throw new NotImplementedException();
        }

        protected override void customHorizontalMoves()
        {
            int leftMove = position.Item1 - horizontalMoveSize.Item1;
            int rightMove = position.Item1 + horizontalMoveSize.Item1;
            if (rightMove < boardEdge)
            {
                int colUnicode = rightMove;
                if (position.Item2 - horizontalMoveSize.Item2 >= 1)
                    moves = formatPosition(colUnicode, position.Item2 - horizontalMoveSize.Item2, moves);

                if (position.Item2 + horizontalMoveSize.Item2 <= boardEdge)
                    moves = formatPosition(colUnicode, position.Item2 + horizontalMoveSize.Item2, moves);
            }
            if (leftMove >= 1 && leftMove < boardEdge)
            {
                int colUnicode = leftMove;
                if (position.Item2 - horizontalMoveSize.Item2 >= 1)
                    moves = formatPosition(colUnicode, position.Item2 - horizontalMoveSize.Item2, moves);

                if (position.Item2 + horizontalMoveSize.Item2 <= boardEdge)
                    moves = formatPosition(colUnicode, position.Item2 + horizontalMoveSize.Item2, moves);
            }
        }
        protected override void customVerticalMoves()
        {
            int upMove = position.Item2 + verticalMoveSize.Item2;
            int downMove = position.Item2 - verticalMoveSize.Item2;
            if (upMove <= boardEdge)
            {
                int rowUnicode = upMove;
                if (position.Item1 - verticalMoveSize.Item1 >= 1)
                    moves = formatPosition(position.Item1 - verticalMoveSize.Item1, rowUnicode, moves);

                if (position.Item1 + verticalMoveSize.Item1 <= boardEdge)
                    moves = formatPosition(position.Item1 + verticalMoveSize.Item1, rowUnicode, moves);
            }
            if (downMove >= 1 && downMove < boardEdge)
            {
                int rowUnicode = downMove;
                if (position.Item1 - verticalMoveSize.Item1 >= 1)
                    moves = formatPosition(position.Item2 - verticalMoveSize.Item1, rowUnicode, moves);

                if (position.Item1 + verticalMoveSize.Item1 <= boardEdge)
                    moves = formatPosition(position.Item1 + verticalMoveSize.Item1, rowUnicode, moves);
            }
        }

    }
}
