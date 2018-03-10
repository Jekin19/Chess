using System.Collections.Generic;
using Chess.Helpers;

namespace Chess.ChessPiece
{
    public class King : PhoneChessBase, IPhoneNumberFinder
    {

        protected override HashSet<string> GetNextState(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            HashSet<string> set = new HashSet<string>();

                // 5 to 6
                StateHelper.CheckAndAdd(set, row , col + 1, phoneMatrix, ruleEngine);
                // 5 to 9
                StateHelper.CheckAndAdd(set, row + 1, col + 1, phoneMatrix, ruleEngine);
                // 5 to 7
                StateHelper.CheckAndAdd(set, row + 1, col - 1, phoneMatrix, ruleEngine);
                // 5 to 4
                StateHelper.CheckAndAdd(set, row, col - 1, phoneMatrix, ruleEngine);
                // 5 to 8
                StateHelper.CheckAndAdd(set, row + 1, col, phoneMatrix, ruleEngine);
                // 5 to 2
                StateHelper.CheckAndAdd(set, row - 1, col, phoneMatrix, ruleEngine);
                // 5 to 1
                StateHelper.CheckAndAdd(set, row - 1, col-1, phoneMatrix, ruleEngine);
                // 5 to 3
                StateHelper.CheckAndAdd(set, row-1, col + 1, phoneMatrix, ruleEngine);
            

            return set;
        }


    }
}
