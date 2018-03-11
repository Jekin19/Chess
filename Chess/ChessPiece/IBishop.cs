using System.Collections.Generic;

namespace Chess.ChessPiece
{
    public interface IBishop
    {
        HashSet<string> GetNextStates(int row, int col, string[,] phoneMatrix, IRuleEngine ruleEngine);
    }
}
