﻿using System.Collections.Generic;
using Chess.Helpers;

namespace Chess.ChessPiece
{
    public class Bishop : PhoneChessBase, IPhoneNumberFinder, IBishop
    {

        protected override HashSet<string> GetNextState(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            return GetNextStates(row, col, phoneMatrix, ruleEngine);
        }

        public HashSet<string> GetNextStates(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
          return StateHelper.GetNextState(this, row, col, phoneMatrix, ruleEngine);
        }
        
    }
}
