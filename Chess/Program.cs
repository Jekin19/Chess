using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
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
                    IDataProvider dataProvider = new DataProvider();
                    var phoneNumberFinder =
                        ChessPieceHelper.GetPhoneNumberFinderByChessPieceType(chessPiece, dataProvider);

                    var currentForegroundColor = Console.ForegroundColor;
                    if (phoneNumberFinder != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Total no. of {0} digit phone numbers for {1} are: {2}", dataProvider.Length, input,
                            phoneNumberFinder.FindNumberOfPaths(10));
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
