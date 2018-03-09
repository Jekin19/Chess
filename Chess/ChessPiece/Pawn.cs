using System.Collections.Generic;

namespace Chess.ChessPiece
{
    public class Pawn : PhoneChessBase, IPhoneNumberFinder
    {
        public Pawn(IDataProvider dataProvider) : base(dataProvider) { }

        protected override HashSet<string> GetNextState(int row, int col)
        {
            HashSet<string> set = new HashSet<string>();

            // 5 to 9
            StateHelper.CheckAndAdd(set, row + 1, col + 1, RowSize, ColSize, PhoneMatrix, this);
            // 5 to 7
            StateHelper.CheckAndAdd(set, row + 1, col - 1, RowSize, ColSize, PhoneMatrix, this);
            // 5 to 8
            StateHelper.CheckAndAdd(set, row + 1, col, RowSize, ColSize, PhoneMatrix, this);
            
            return set;
        }


    }
}
