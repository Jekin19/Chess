using System.Collections.Generic;

namespace Chess.ChessPiece
{
    public interface IRook
    {
        HashSet<string> GetNextStates(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine);
    }
}
