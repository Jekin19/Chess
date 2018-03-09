using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Chess.ChessPiece;

namespace Chess
{
    public class ChessPieceHelper
    {
        public enum ChessPieceType
        {
            None,
            [ChessPieceType(typeof(Pawn))]
            Pawn,
            [ChessPieceType(typeof(Bishop))]
            Bishop,
            [ChessPieceType(typeof(Knight))]
            Knight,
            [ChessPieceType(typeof(Rook))]
            Rook,
            [ChessPieceType(typeof(Queen))]
            Queen,
            [ChessPieceType(typeof(King))]
            King
        }

        public class ChessPieceTypeAttribute : Attribute
        {
            public Type Type { get; set; }

            public ChessPieceTypeAttribute(Type type)
            {
                Type = type;
            }
            
        }

        public static ChessPieceTypeAttribute GetChessPieceTypeAttribute(ChessPieceType chessPieceType)
        {
            try
            {
                var firstOrDefault = chessPieceType.GetType().GetMember(chessPieceType.ToString()).FirstOrDefault();
                var attrs = firstOrDefault?.GetCustomAttributes(typeof(ChessPieceTypeAttribute), true);
                if (attrs?.Length > 0)
                {
                    return ((ChessPieceTypeAttribute)attrs[0]);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }

            return null;
        }

        public static IEnumerable<string> GetChessTypes()
        {
            try
            {
                return Enum.GetValues(typeof(ChessPieceType)).Cast<ChessPieceType>().ToList()
                    .Where(IsIPhoneNumberFinder).Select(type => type.ToString());
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }

            return null;
        }

        public static ChessPieceType GetChessTypeByName(string input)
        {
            try
            {
                return Enum.GetValues(typeof(ChessPieceType)).Cast<ChessPieceType>().ToList()
                    .Where(IsIPhoneNumberFinder).FirstOrDefault(type => type.ToString().Equals(input, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }

            return ChessPieceType.None;
        }

        public static IPhoneNumberFinder GetPhoneNumberFinderByChessPieceType(ChessPieceType chessPieceType,
            IDataProvider dataProvider)
        {
            var type = GetChessPieceTypeAttribute(chessPieceType)?.Type;
            if (type != null)
            {
                var phoneNumberFinder = Activator.CreateInstance(type, dataProvider) as IPhoneNumberFinder;
                return phoneNumberFinder;
            }
            return null;
        }

        private static bool IsIPhoneNumberFinder(ChessPieceType type)
        {
            return GetChessPieceTypeAttribute(type) != null &&
                   typeof(IPhoneNumberFinder).IsAssignableFrom(GetChessPieceTypeAttribute(type).Type);
        }
    }
}
