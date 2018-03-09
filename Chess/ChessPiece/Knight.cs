using System.Collections.Generic;

namespace Chess.ChessPiece
{
    public class Knight: PhoneChessBase, IPhoneNumberFinder
    {
        public Knight(IDataProvider dataProvider) : base(dataProvider) { }

        protected override HashSet<string> GetNextState(int row, int col)
        {
            HashSet<string> set = new HashSet<string>();

            // 4 to 3
            StateHelper.CheckAndAdd(set, row - 1, col + 2, RowSize, ColSize, PhoneMatrix, this);

            // 6 to 1
             StateHelper.CheckAndAdd(set, row - 1, col - 2, RowSize, ColSize, PhoneMatrix, this);

            // 3 to 4
            StateHelper.CheckAndAdd(set, row + 1, col + 2, RowSize, ColSize, PhoneMatrix, this);

            // 6 to 7
            StateHelper.CheckAndAdd(set, row + 1, col - 2, RowSize, ColSize, PhoneMatrix, this);

            // 7 to 2
            StateHelper.CheckAndAdd(set, row - 2, col + 1, RowSize, ColSize, PhoneMatrix, this);

            // 9 to 2
            StateHelper.CheckAndAdd(set, row - 2, col - 1, RowSize, ColSize, PhoneMatrix, this);

            // 2 to 9
            StateHelper.CheckAndAdd(set, row + 2, col + 1, RowSize, ColSize, PhoneMatrix, this);

            // 2 to 7
            StateHelper.CheckAndAdd(set, row + 2, col - 1, RowSize, ColSize, PhoneMatrix, this);

            return set;
        }
    }
}
