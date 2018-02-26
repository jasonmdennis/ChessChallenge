using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessMoves;

namespace ChessTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void QueenWithValidPosition()
        {

            string response = Program.getMoves("queen", "d4");

            Assert.AreEqual(response, "a4, b4, c4, e4, f4, g4, h4, d1, d2, d3, d5, d6, d7, d8, c5, c3, b6, b2, a7, a1, e5, e3, f6, f2, g7, g1, h8");
        }

        [TestMethod]
        public void RookWithValidPosition()
        {
            string response = Program.getMoves("rook", "d4");

            Assert.AreEqual(response, "a4, b4, c4, e4, f4, g4, h4, d1, d2, d3, d5, d6, d7, d8");
        }

        [TestMethod]
        public void KnightWithValidPosition()
        {
            string response = Program.getMoves("knight", "d4");

            Assert.AreEqual(response, "f3, f5, b3, b5, c6, e6, c2, e2");
        }

        [TestMethod]
        public void KnightWithInValidPosition()
        {
            string response = Program.getMoves("knight", "d9");

            Assert.AreEqual(response, "error! invalid position");
        }

        [TestMethod]
        public void PawnNotRecognized()
        {
            string response = Program.getMoves("pawn", "d2");
            Assert.AreEqual(response, "Unknown piece");
        }
    }
}
