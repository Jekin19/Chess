using System.Collections.Generic;
using Chess.Helpers;

namespace Chess.ChessPiece
{
    public class Rook : PhoneChessBase, IPhoneNumberFinder, IRook
    {        
        protected override HashSet<string> GetNextState(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            return GetMyState(row, col, phoneMatrix, ruleEngine);
        }

        public HashSet<string> GetMyState(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            return this.GetState(row, col, phoneMatrix, this);
        }

    }
}
