
namespace Chess
{
    public interface IDataProvider
    {
        string[,] PhoneMatrix { get; set; }
        int Length { get; set; }
    }
}
