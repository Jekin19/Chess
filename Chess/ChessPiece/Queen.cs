using System.Collections.Generic;
using Chess.Helpers;

namespace Chess.ChessPiece
{
    public class Queen : PhoneChessBase, IPhoneNumberFinder, IBishop, IRook
    {

        protected override HashSet<string> GetNextState(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            var bishop = this as IBishop;
            var result = bishop.GetNextState(row, col, phoneMatrix, ruleEngine);

            var rook = this as IRook;
            result.UnionWith(rook.GetNextState(row, col, phoneMatrix, ruleEngine));

            return result;
        }


         HashSet<string> IBishop.GetNextStates(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
             var bishop = this as IBishop;
             return bishop.GetNextState(row, col, phoneMatrix, ruleEngine);
         }

        HashSet<string> IRook.GetNextStates(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            var rook = this as IRook;
            return rook.GetNextState(row, col, phoneMatrix, ruleEngine);
        }
    }
}
