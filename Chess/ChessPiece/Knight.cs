﻿using System.Collections.Generic;
using Chess.Helpers;

namespace Chess.ChessPiece
{
    public class Knight: PhoneChessBase, IPhoneNumberFinder
    {

        protected override HashSet<string> GetNextState(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            HashSet<string> set = new HashSet<string>();

            // 4 to 3
            StateHelper.CheckAndAdd(set, row - 1, col + 2, phoneMatrix, ruleEngine);

            // 6 to 1
             StateHelper.CheckAndAdd(set, row - 1, col - 2, phoneMatrix, ruleEngine);

            // 3 to 4
            StateHelper.CheckAndAdd(set, row + 1, col + 2, phoneMatrix, ruleEngine);

            // 6 to 7
            StateHelper.CheckAndAdd(set, row + 1, col - 2, phoneMatrix, ruleEngine);

            // 7 to 2
            StateHelper.CheckAndAdd(set, row - 2, col + 1, phoneMatrix, ruleEngine);

            // 9 to 2
            StateHelper.CheckAndAdd(set, row - 2, col - 1, phoneMatrix, ruleEngine);

            // 2 to 9
            StateHelper.CheckAndAdd(set, row + 2, col + 1, phoneMatrix, ruleEngine);

            // 2 to 7
            StateHelper.CheckAndAdd(set, row + 2, col - 1, phoneMatrix, ruleEngine);

            return set;
        }
    }
}
