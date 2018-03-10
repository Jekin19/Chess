
namespace Chess
{
    public interface IPhoneNumberFinder
    {   
        int FindNumberOfPaths(string[,] phoneMatrix, int phoneLength, string startingDigit);

        int FindAllNumberOfPaths(string[,] phoneMatrix, int phoneLength);
    }
}
