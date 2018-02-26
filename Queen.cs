using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMoves.BRL
{
    class Queen : Pieces
    {
        private static Tuple<int, int> position = Tuple.Create(0, 0);
        string orginalPostion = "";
        string moves = "";
        public override string GetMoves(string startPosition)
        {
            orginalPostion = startPosition;
            position = getPosition(startPosition);

            moves = standardHorizontalMoves(startPosition, moves);
            moves = standardVerticalMoves(startPosition, moves);
            moves = standardDiagonalMoves(startPosition, moves);

            return moves;
        }

        protected override void customDiagonalMoves()
        {
            throw new NotImplementedException();
        }

        protected override void customHorizontalMoves()
        {
            throw new NotImplementedException();
        }

        protected override void customVerticalMoves()
        {
            throw new NotImplementedException();
        }
    }
}
