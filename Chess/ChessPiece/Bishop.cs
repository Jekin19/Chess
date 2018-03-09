using System.Collections.Generic;

namespace Chess.ChessPiece
{
    public class Bishop : PhoneChessBase, IPhoneNumberFinder, IBishop
    {
        public Bishop(IDataProvider dataProvider) : base(dataProvider) { }

        protected override HashSet<string> GetNextState(int row, int col)
        {
            return GetState(row, col);
        }


        public HashSet<string> GetState( int row, int col)
        {
          return this.GetState(row, col, RowSize, ColSize, PhoneMatrix, this);
        }
        
    }
}
