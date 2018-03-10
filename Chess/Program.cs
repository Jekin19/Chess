using System;
using Chess.DataProviders;
using Chess.Helpers;

namespace Chess
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please choose from one of the following chess pieces OR enter Exit to terminate the program");
                foreach (var chessType in ChessPieceHelper.GetChessTypes())
                {
                    Console.WriteLine(chessType);
                }
                Console.WriteLine();

                var input = Console.ReadLine();
                if (input != null)
                {
                    if (input.Equals("EXIT", StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }

                    var chessPiece = ChessPieceHelper.GetChessTypeByName(input);
                    var phoneNumberFinder =
                        ChessPieceHelper.GetPhoneNumberFinderByChessPieceType(chessPiece);

                    var currentForegroundColor = Console.ForegroundColor;
                    if (phoneNumberFinder != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        //Default Inputs
                       IDataProvider dataProvider = new DataProvider();

                        Console.WriteLine("Total no. of {0} digit phone numbers for {1} are: {2}", dataProvider.PhoneLength, input, 
                            phoneNumberFinder.FindAllNumberOfPaths(dataProvider.PhoneMatrix, dataProvider.PhoneLength));
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter valid input!");
                    }

                    Console.ForegroundColor = currentForegroundColor;
                    Console.WriteLine();
                }
            }
        }
    }
}
