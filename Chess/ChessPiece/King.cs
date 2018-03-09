using System.Collections.Generic;

namespace Chess.ChessPiece
{
    public class King : PhoneChessBase, IPhoneNumberFinder
    {
        public King(IDataProvider dataProvider) : base(dataProvider) { }

        protected override HashSet<string> GetNextState(int row, int col)
        {
            HashSet<string> set = new HashSet<string>();

            for (int i = 1; i < RowSize; i++)
            {
                // 5 to 6
                StateHelper.CheckAndAdd(set, row , col + 1, RowSize, ColSize, PhoneMatrix, this);
                // 5 to 9
                StateHelper.CheckAndAdd(set, row + 1, col + 1, RowSize, ColSize, PhoneMatrix, this);
                // 5 to 7
                StateHelper.CheckAndAdd(set, row + 1, col - 1, RowSize, ColSize, PhoneMatrix, this);
                // 5 to 4
                StateHelper.CheckAndAdd(set, row, col - 1, RowSize, ColSize, PhoneMatrix, this);
                // 5 to 8
                StateHelper.CheckAndAdd(set, row + 1, col, RowSize, ColSize, PhoneMatrix, this);
                // 5 to 2
                StateHelper.CheckAndAdd(set, row - 1, col, RowSize, ColSize, PhoneMatrix, this);
                // 5 to 1
                StateHelper.CheckAndAdd(set, row - 1, col-1, RowSize, ColSize, PhoneMatrix, this);
                // 5 to 3
                StateHelper.CheckAndAdd(set, row-1, col + 1, RowSize, ColSize, PhoneMatrix, this);
            }

            return set;
        }


    }
}
