using System.Collections.Generic;

namespace Chess.ChessPiece
{
    public interface IBishop
    {
         HashSet<string> GetState(int row, int col);
    }
}
