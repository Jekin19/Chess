using System.Collections.Generic;
using Chess.ChessPiece;

namespace Chess
{
    public static class StateHelper
    {
        public static HashSet<string> GetState(this IBishop bishop, int row, int col, int rowSize, int colSize, string [,] phoneMatrix, IRuleEngine ruleEngine)
        {
            HashSet<string> set = new HashSet<string>();

            for (int i = 1; i < rowSize; i++)
            {
                // 1 to 5 
                CheckAndAdd(set, row + i, col + i, rowSize, colSize, phoneMatrix, ruleEngine);
                // 5 to 7
                CheckAndAdd(set, row + i, col - i, rowSize, colSize, phoneMatrix, ruleEngine);

                // 5 to 1
                CheckAndAdd(set, row - i, col - i, rowSize, colSize, phoneMatrix, ruleEngine);
                // 5 to 1 and 9 to 1
                CheckAndAdd(set, row - i, col + i, rowSize, colSize, phoneMatrix, ruleEngine);

            }

            return set;
        }

        public static HashSet<string> GetState(this IRook rook, int row, int col, int rowSize, int colSize, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            HashSet<string> set = new HashSet<string>();

            for (int i = 1; i < rowSize; i++)
            {
                // 2 to 5
                CheckAndAdd(set, row + i, col, rowSize, colSize, phoneMatrix, ruleEngine);

                // 5 to 2
                CheckAndAdd(set, row - i, col, rowSize, colSize, phoneMatrix, ruleEngine);
            }

            for (int i = 1; i < colSize; i++)
            {
                // 1 to 2
                CheckAndAdd(set, row, col + i, rowSize, colSize, phoneMatrix, ruleEngine);

                // 3 to 2
                CheckAndAdd(set, row, col - i, rowSize, colSize, phoneMatrix, ruleEngine);

            }

            return set;
        }

        public static void CheckAndAdd(HashSet<string> set, int row, int col, int rowSize, int colSize, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            if (row < rowSize && row >= 0 && col < colSize && col >= 0 && phoneMatrix!= null && !ruleEngine.CanNotContain(phoneMatrix[row, col]))
            {
                set.Add(phoneMatrix[row, col]);
            }
        }
    }
}
