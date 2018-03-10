using System.Collections.Generic;
using Chess.Helpers;

namespace Chess.ChessPiece
{
    public class Queen : PhoneChessBase, IPhoneNumberFinder, IBishop, IRook
    {

        protected override HashSet<string> GetNextState(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            var bishop = this as IBishop;
            var result = bishop.GetState(row, col, phoneMatrix, ruleEngine);

            var rook = this as IRook;
            result.UnionWith(rook.GetState(row, col, phoneMatrix, ruleEngine));

            return result;
        }


         HashSet<string> IBishop.GetMyState(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
             var bishop = this as IBishop;
             return bishop.GetState(row, col, phoneMatrix, ruleEngine);
         }

        HashSet<string> IRook.GetMyState(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine)
        {
            var rook = this as IRook;
            return rook.GetState(row, col, phoneMatrix, ruleEngine);
        }
    }
}
