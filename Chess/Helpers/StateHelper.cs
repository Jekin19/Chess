using System.Collections.Generic;
using Chess.ChessPiece;

namespace Chess.Helpers
{
    public static class StateHelper
    {
        public static HashSet<string> GetState(this IBishop bishop, int row, int col, string [,] phoneMatrix, IRuleEngine ruleEngine)
        {
            HashSet<string> set = new HashSet<string>();

            for (int i = 1; i <= phoneMatrix.GetUpperBound(0); i++)
            {
                // 1 to 5 
                CheckAndAdd(set, row + i, col + i,  phoneMatrix, ruleEngine);
                // 5 to 7
                CheckAndAdd(set, row + i, col - i,  phoneMatrix, ruleEngine);

                // 5 to 1
                CheckAndAdd(set, row - i, col - i,  phoneMatrix, ruleEngine);
                // 5 to 1 and 9 to 1
                CheckAndAdd(set, row - i, col + i,  phoneMatrix, ruleEngine);

            }

            return set;
        }

        public static HashSet<string> GetState(this IRook rook, int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            HashSet<string> set = new HashSet<string>();

            for (int i = 1; i <= phoneMatrix.GetUpperBound(0); i++)
            {
                // 2 to 5
                CheckAndAdd(set, row + i, col,  phoneMatrix, ruleEngine);

                // 5 to 2
                CheckAndAdd(set, row - i, col,  phoneMatrix, ruleEngine);
            }

            for (int i = 1; i <= phoneMatrix.GetUpperBound(1); i++)
            {
                // 1 to 2
                CheckAndAdd(set, row, col + i,  phoneMatrix, ruleEngine);

                // 3 to 2
                CheckAndAdd(set, row, col - i,  phoneMatrix, ruleEngine);

            }

            return set;
        }

        public static void CheckAndAdd(HashSet<string> set, int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            if (phoneMatrix!=null && row <= phoneMatrix.GetUpperBound(0) && row >= 0 && col <= phoneMatrix.GetUpperBound(1) && col >= 0 && !ruleEngine.CanNotContain(phoneMatrix[row, col]))
            {
                set.Add(phoneMatrix[row, col]);
            }
        }
    }
}
