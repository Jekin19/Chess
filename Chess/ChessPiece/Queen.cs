using System.Collections.Generic;

namespace Chess.ChessPiece
{
    public class Queen : PhoneChessBase, IPhoneNumberFinder, IBishop, IRook
    {
        public Queen(IDataProvider dataProvider) : base(dataProvider) { }

        protected override HashSet<string> GetNextState(int row, int col)
        {
            var bishop = this as IBishop;
            var result = bishop.GetState(row, col);

            var rook = this as IRook;
            result.UnionWith(rook.GetState(row, col, RowSize, ColSize, PhoneMatrix, this));

            return result;
        }


         HashSet<string> IBishop.GetState(int row, int col)
         {
             var bishop = this as IBishop;
             return bishop.GetState(row, col, RowSize, ColSize, PhoneMatrix, this);
         }

        HashSet<string> IRook.GetState(int row, int col)
        {
            var rook = this as IRook;
            return rook.GetState(row, col, RowSize, ColSize, PhoneMatrix, this);
        }
    }
}
