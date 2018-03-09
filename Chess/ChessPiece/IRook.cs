using System.Collections.Generic;

namespace Chess.ChessPiece
{
    public interface IRook
    {
        HashSet<string> GetState(int row, int col);
    }
}
