using Chess;
using Chess.ChessPiece;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessUnitTest.ChessPiece
{
    [TestClass]
    public class KingUnitTest
    {
        private readonly string[,] _phoneMatrix = { {"1", "2", "3"},
            {"4", "5", "6"},
            {"7", "8", "9"},
            {"*", "0", "#"}};

        private readonly IPhoneNumberFinder _chessPiece = new King();

        [TestMethod]
        public void TestBaseCases()
        {
            Assert.AreEqual(0, _chessPiece.FindAllNumberOfPaths(null, 2));
            Assert.AreEqual(0, _chessPiece.FindNumberOfPaths(null, 2, null));

            Assert.AreEqual(0, _chessPiece.FindNumberOfPaths(_phoneMatrix, 7, "0"));

            Assert.AreEqual(0, _chessPiece.FindNumberOfPaths(_phoneMatrix, -1, "4"));
            Assert.AreEqual(0, _chessPiece.FindAllNumberOfPaths(_phoneMatrix, -1));

        }

        [TestMethod]
        public void TestFindAllNumberOfPaths()
        {

            int[] input = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int total = 0;
            foreach (var i in input)
            {
                total = total + _chessPiece.FindNumberOfPaths(_phoneMatrix, 3, i.ToString());
            }
            Assert.AreEqual(total, _chessPiece.FindAllNumberOfPaths(_phoneMatrix, 3));

            Assert.AreEqual(40, _chessPiece.FindAllNumberOfPaths(_phoneMatrix, 2));

        }

        [TestMethod]
        public void TestFindNumberOfPaths()
        {
            Assert.AreEqual(8, _chessPiece.FindNumberOfPaths(_phoneMatrix, 2, "5"));
        }

    }
}