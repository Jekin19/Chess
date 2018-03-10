
namespace Chess.DataProviders
{
    public interface IDataProvider
    {
        string[,] PhoneMatrix { get; set; }
        int PhoneLength { get; set; }
        string StartingDigit { get; set; }
    }
}
