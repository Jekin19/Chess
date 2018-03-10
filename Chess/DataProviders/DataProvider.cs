
namespace Chess.DataProviders
{
    public class DataProvider : IDataProvider
    {
        public string[,] PhoneMatrix { get; set; }

        public int PhoneLength { get; set; }

        public string StartingDigit { get; set; }

        public DataProvider()
        {
            PhoneMatrix = new[,]
            {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"},
                {"*", "0", "#"}
            };
            PhoneLength = 7;
        }


        public DataProvider(string[,] phoneMatrix, int length)
        {
            PhoneMatrix = phoneMatrix;
            PhoneLength = length;
        }

        public DataProvider(string[,] phoneMatrix, int length, string startingDigit)
        {
            PhoneMatrix = phoneMatrix;
            PhoneLength = length;
            StartingDigit = startingDigit;
        }
    }
}
