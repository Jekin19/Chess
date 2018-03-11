
namespace Chess
{
    
    public interface IRuleEngine
    {
        bool CanNotContain(string digit);

        bool CanNotStartWith(string digit);
    }
}
